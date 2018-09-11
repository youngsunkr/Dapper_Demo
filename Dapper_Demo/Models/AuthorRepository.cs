using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace Dapper_Demo.Models
{
    public class AuthorRepository
    {
        private string connectionString = DbConn.GetConnectionString();

        public List<Author> ReadAll()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Author>("Select * FROM Author").ToList();
            }
        }

        public Author Find(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Author>("Select * From Author WHERE Id = @Id", new { id }).SingleOrDefault();
            }
        }

        public int Update(Author author)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sqlQuery = "UPDATE Author SET FirstName = @FirstName, " +
                                  " LastName = @LastName " + "WHERE Id = @Id";
                int rowsAffected = db.Execute(sqlQuery, author);
                return rowsAffected;
            }
        }

        public List<Author> Read()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string readSp = "GetAllAuthors";
                return db.Query<Author>(readSp, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
