using Dapper;
using KHADotNetCore.ConsoleApp.Models;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace KHADotNetCore.ConsoleApp.DapperExamples
{
    public class DapperExample
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-V1H7OM6",
            InitialCatalog = "TestDb",
            UserID = "sa",
            Password = "KaungKaung",
        };
        private string query = "";
        public void Read()
        {
            query = "SELECT * FROM Tbl_Blog";
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            List<BlogModel> blogList = db.Query<BlogModel>(query).ToList();

            foreach (var blog in blogList)
            {
                Console.WriteLine($"BlodId {blog.BlogId}");
                Console.WriteLine("BlogTitle " + blog.BlogTitle);
                Console.WriteLine("Author " + blog.BlogAuthor);
                Console.WriteLine("BlogContent " + blog.BlogContent);
                Console.WriteLine();
            }
        }

        public void Edit(int id)
        {
            query = "SELECT * FROM Tbl_Blog WHERE BlogId = @BlogId";
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            var blogObj = db.Query<BlogModel>(query, new { BlogId = id }).FirstOrDefault();

            if (blogObj is null)
            {
                Console.WriteLine("no  data found");
                return;
            }

            Console.WriteLine($"BlodId {blogObj.BlogId}");
            Console.WriteLine("BlogTitle " + blogObj.BlogTitle);
            Console.WriteLine("Author " + blogObj.BlogAuthor);
            Console.WriteLine("BlogContent " + blogObj.BlogContent);
            Console.WriteLine();
        }

        public void Create(string title, string author, string content)
        {
            query = @"INSERT INTO [dbo].[Tbl_Blog]
                        (
                            [BlogTitle],
                            [BlogAuthor],
                            [BlogContent]
                        )
                        VALUES
                        (
                            @BlogTitle,
                            @BlogAuthor,
                            @BlogContent
                        )";
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query,blog);

            string message = result > 0 ? "Saving successful." : "saving failed";
            Console.WriteLine(message);
        }

        public void Update(int id, string title, string author, string content)
        {
            query = @"UPDATE [dbo].[Tbl_Blog] SET 
                        [BlogTitle] = @BlogTitle,
                        [BlogAuthor] = @BlogAuthor,
                        [BlogContent] = @BlogContent
                        WHERE BlogId = @BlogId";
            BlogModel blog = new BlogModel()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);
            string message = result > 0 ? "updating successful." : "updating failed";
            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            query = @"DELETE FROM [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, new { BlogId = id });
            string message = result > 0 ? "delete successful." : "delete failed";
            Console.WriteLine(message);
        }
    }
}
