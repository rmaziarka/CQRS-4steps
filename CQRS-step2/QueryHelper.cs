using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace CQRS_step2
{
    public class QueryHelper
    {
        public static string GetQuery<T>()
        {
            var fileName = typeof(T).Name + ".sql";
            var filePath = @"~/Domain/Products/QueryHandlers/" + fileName;

            return System.IO.File.ReadAllText(HostingEnvironment.MapPath(filePath));
        }
    }
}