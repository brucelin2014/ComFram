// 2020-12-24, Bruce

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace ComFram
{
    public class PersonService
    {
        public List<PersonModel> FindListByLastName(string lastName)
        {
            using (IDbConnection db = new SqlConnection(DBHelper.ConnStrng))
            {
                // SQL注入
                //string sql = "SELECT * FROM Person WHERE LastName = '" + lastName + "' OR '1' = '1'";

                // 格式化
                //string sql = string.Format("SELECT * FROM Person WHERE LastName = '{0}'", lastName);

                // C#6语法
                //string sql = $"SELECT * FROM Person WHERE LastName = '{lastName}'";
                //IEnumerable<PersonModel> lst = db.Query<PersonModel>(sql);

                // @作为参数, 防止SQL注入
                string sql = $"SELECT * FROM Person WHERE LastName=@LastName";
                IEnumerable<PersonModel> lst = db.Query<PersonModel>(sql, new { LastName = lastName });

                return lst.ToList();
            }
        }

    }

}
