using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Services
{
    public class DbService : IDbService
    {
        public bool CheckIndexNumber(string index)
        {
            using (var con = new SqlConnection("Server=localhost,32770;Initial Catalog=s18706;User ID=sa;Password=Root1234"))
            using (var com = new SqlCommand())
            {
                com.Connection = con;

                con.Open();
                
                com.CommandText = "select * from student where IndexNumber=@index";
                com.Parameters.AddWithValue("index", index);
                
                var dr = com.ExecuteReader();
                if (!dr.Read())
                {
                    return false;
                }
            }
            return true;
        }

        
    }
}
