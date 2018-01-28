using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;
using Newtonsoft.Json;

namespace CQRS_step3.Infrastructure
{
    public class JsonObjectTypeHandler : SqlMapper.ITypeHandler
    {
        public void SetValue(IDbDataParameter parameter, object value)
        {
            parameter.Value = (value == null)
                ? (object)DBNull.Value
                : JsonConvert.SerializeObject(value);
            parameter.DbType = DbType.String;
        }

        public object Parse(Type destinationType, object value)
        {
            return JsonConvert.DeserializeObject(value.ToString(), destinationType);
        }
    }
}