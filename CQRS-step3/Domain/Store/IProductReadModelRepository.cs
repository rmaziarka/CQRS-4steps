using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS_step3.Domain.Store.Models;

namespace CQRS_step3.Domain.Store
{
    public interface IProductReadModelRepository
    {
        void Insert(ProductReadModel product);
        void Update(ProductReadModel product);
        ProductReadModel Find(int productId);
    }
}
