using FundosDataLibrary.DataAccess;
using FundosDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundosDataLibrary.BusinessLogic
{
    public static class FundoHistoryProcessor
    {

        public static List<FundoHistoryModel> Load(DateTime startTime, DateTime endTime)
        {

            var format = "yyyy-MM-dd HH:mm:ss:fff";

            var param = new
            {
                StartTime = startTime.ToString(format),
                EndTime = endTime.ToString(format)
                
            };

            string sql = @"select * from dbo.Fundos for system_time from @StartTime to @EndTime";

            return SqlDataAccess.LoadData<FundoHistoryModel>(sql,param);

        }

        public static List<FundoHistoryModel> Load(long codigoDoSistema, DateTime date)
        {
            var format = "yyyy-MM-dd HH:mm:ss:fff";

            string sql = @"select * from dbo.Fundos for system_time as of @Date";

            return SqlDataAccess.LoadData<FundoHistoryModel>(sql, new {  Date = date.ToString(format) });

        }
    }
}
