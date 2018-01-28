using System.Threading.Tasks;
using System.Transactions;
using MediatR;

namespace CQRS_step3.Infrastructure
{
    public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next)
        {
            var transactionOptions = new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
                Timeout = TransactionManager.MaximumTimeout
            };

            using (var transaction = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                TransactionScopeAsyncFlowOption.Enabled))
            {
                var response = await next();
                transaction.Complete();
                return response;
            }
        }
    }
}