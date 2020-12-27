// 2020-12-27, Bruce

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
    public class UserAccDao : IDao
    {
        public List<IModel> FindListByName(string name)
        {
            using (IDbConnection db = new SqlConnection(DBHelper.ConnStrng))
            {
                string sql = $"SELECT * FROM UserAcc WHERE 1=1";
                if (!string.IsNullOrWhiteSpace(name))
                {
                    sql += $" AND UserName LIKE CONCAT('%',@UserName,'%')";
                }
                IEnumerable<UserAccModel> lst = db.Query<UserAccModel>(sql, new { UserName = name });
                return lst.ToList<IModel>();
            }
        }

        public IModel FindByID(int id)
        {
            using (IDbConnection db = new SqlConnection(DBHelper.ConnStrng))
            {
                string sql = $"SELECT * FROM UserAcc WHERE ID=@ID";
                IEnumerable<UserAccModel> lst = db.Query<UserAccModel>(sql, new { ID = id });
                return lst.FirstOrDefault();
            }
        }

        public IModel FindByCode(string code)
        {
            using (IDbConnection db = new SqlConnection(DBHelper.ConnStrng))
            {
                string sql = $"SELECT * FROM UserAcc WHERE UserCode=@UserCode";
                IEnumerable<UserAccModel> lst = db.Query<UserAccModel>(sql, new { UserCode = code });
                return lst.FirstOrDefault();
            }
        }

        public List<IModel> FindListByPage(int nPageIndex, int nPageSize)
        {
            using (IDbConnection db = new SqlConnection(DBHelper.ConnStrng))
            {
                string sql = $"SELECT * FROM UserAcc";
                IEnumerable<UserAccModel> lst = db.Query<UserAccModel>(sql);
                lst = lst.OrderBy(x => x.ID).Skip((nPageIndex - 1) * nPageSize).Take(nPageSize).ToList();
                return lst.ToList<IModel>();
            }
        }

        public bool InsertData(IModel model)
        {
            using (IDbConnection db = new SqlConnection(DBHelper.ConnStrng))
            {
                UserAccModel userAcc = (UserAccModel)model;
                userAcc.CreatedDate = DateTime.Now;
                userAcc.LastModifiedDate = DateTime.Now;

                string sql = "INSERT INTO UserAcc(UserCode,UserName,Password,CreatedDate,LastModifiedDate) VALUES(@UserCode,@UserName,@Password,@CreatedDate,@LastModifiedDate)";
                int ret = db.Execute(sql, userAcc);
                return ret > 0;
            }
        }

        public bool UpdateData(IModel model)
        {
            using (IDbConnection db = new SqlConnection(DBHelper.ConnStrng))
            {
                UserAccModel user = (UserAccModel)model;
                user.LastModifiedDate = DateTime.Now;

                string sql = "UPDATE UserAcc SET UserCode=@UserCode,UserName=@UserName,Password=@Password,LastModifiedDate=@LastModifiedDate WHERE ID=@ID";
                int ret = db.Execute(sql, user);
                return ret > 0;
            }
        }

        public bool DeleteData(IModel model)
        {
            using (IDbConnection db = new SqlConnection(DBHelper.ConnStrng))
            {
                UserAccModel user = (UserAccModel)model;
                string sql = "DELETE FROM UserAcc WHERE ID=@ID";
                int ret = db.Execute(sql, user);
                return ret > 0;
            }
        }
        
    }

}
