using MySql.Data.MySqlClient;
using System;
using System.Data.Common;
using Dapper;
using System.Collections.Generic;

namespace WebApp.Services
{
    public class UserService
    {
        DbConnection ServerDbConnection = new MySqlConnection("server=192.168.1.79;user id=root; password=123456; database=testdb; pooling=false;SslMode=none");

        public int AddUser(string name, string city)
        {
            string sql = "insert into student(name,city,cdt) values(@name,@city,@cdt)";
            return ServerDbConnection.Execute(sql, new { name = name, city = city, cdt = DateTime.Now });
        }

        public IList<dynamic> GetUserList()
        {
            return ServerDbConnection.Query("select * from student").AsList();
        }
    }
}
