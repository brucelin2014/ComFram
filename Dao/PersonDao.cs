// 2020-12-24, Bruce
//string sql = "SELECT * FROM Person WHERE LastName = '" + lastName + "' OR '1' = '1'"; // SQL注入
//string sql = string.Format("SELECT * FROM Person WHERE LastName = '{0}'", lastName); // 格式化
//string sql = $"SELECT * FROM Person WHERE LastName = '{lastName}'"; // C#6语法
//string sql = $"SELECT * FROM Person WHERE LastName=@LastName"; // @作为参数, 防止SQL注入

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
    public class PersonDao : IDao
    {
        public List<IModel> FindListByName(string lastName)
        {
            using (IDbConnection db = new SqlConnection(DBHelper.ConnStrng))
            {
                string sql = $"SELECT * FROM Person WHERE 1=1";
                if (!string.IsNullOrWhiteSpace(lastName))
                {
                    sql += $" AND LastName LIKE CONCAT('%',@LastName,'%')";
                }
                IEnumerable<PersonModel> lst = db.Query<PersonModel>(sql, new { LastName = lastName });
                return lst.ToList<IModel>();
            }
        }

        public IModel FindByID(int id)
        {
            using (IDbConnection db = new SqlConnection(DBHelper.ConnStrng))
            {
                string sql = $"SELECT * FROM Person WHERE ID=@ID";
                IEnumerable<PersonModel> lst = db.Query<PersonModel>(sql, new { ID = id });
                return lst.FirstOrDefault();
            }
        }

        public List<IModel> FindListByPage(int nPageIndex, int nPageSize)
        {
            using (IDbConnection db = new SqlConnection(DBHelper.ConnStrng))
            {
                string sql = $"SELECT * FROM Person";
                IEnumerable<PersonModel> lst = db.Query<PersonModel>(sql);
                lst = lst.OrderBy(x => x.ID).Skip((nPageIndex - 1) * nPageSize).Take(nPageSize).ToList();
                return lst.ToList<IModel>();
            }
        }

        public bool InsertData(IModel model)
        {
            using (IDbConnection db = new SqlConnection(DBHelper.ConnStrng))
            {
                PersonModel person = (PersonModel)model;
                person.CreatedDate = DateTime.Now;
                person.LastModifiedDate = DateTime.Now;

                string sql = "INSERT INTO Person(FirstName,LastName,Email,CreatedDate,LastModifiedDate) VALUES(@FirstName,@LastName,@Email,@CreatedDate,@LastModifiedDate)";
                int ret = db.Execute(sql, person);
                return ret > 0;
            }
        }

        public bool UpdateData(IModel model)
        {
            using (IDbConnection db = new SqlConnection(DBHelper.ConnStrng))
            {
                PersonModel person = (PersonModel)model;
                person.LastModifiedDate = DateTime.Now;

                string sql = "UPDATE Person SET FirstName=@FirstName,LastName=@LastName,Email=@Email,LastModifiedDate=@LastModifiedDate WHERE ID=@ID";
                int ret = db.Execute(sql, person);
                return ret > 0;
            }
        }

        public bool DeleteData(IModel model)
        {
            using (IDbConnection db = new SqlConnection(DBHelper.ConnStrng))
            {
                PersonModel person = (PersonModel)model;
                string sql = "DELETE FROM Person WHERE ID=@ID";
                int ret = db.Execute(sql, person);
                return ret > 0;
            }
        }

    }

}
