using System.Data;
using System.Data.SqlClient;

namespace KHADotNetCore.ConsoleApp.AdoDotNetExamples
{
    public class AdoDotNetExample
    {
        private readonly SqlConnection _sqlConnection;
        private string query = String.Empty;
        public AdoDotNetExample()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "DESKTOP-V1H7OM6";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "KaungKaung";

            _sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
        }

        public void Read()
        {
            query = "SELECT * FROM Tbl_Blog";

            _sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, _sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            _sqlConnection.Close();

            //DataSet => accept many tables
            //DataTable => each table
            //DataRow

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine($"BlodId {dr["BlogId"]}");
                Console.WriteLine("BlogTitle " + dr["BlogTitle"]);
                Console.WriteLine("Author " + dr["BlogAuthor"]);
                Console.WriteLine("BlogContent " + dr["BlogContent"]);
                Console.WriteLine();
            }
        }

        public void Edit(int id)
        {
            query = "SELECT * FROM Tbl_Blog WHERE BlogId = @BlogId";

            _sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, _sqlConnection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            _sqlConnection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No  data found");
                return;
            }

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine($"BlodId " + dr["BlogId"]);
                Console.WriteLine("BlogTitle " + dr["BlogTitle"]);
                Console.WriteLine("Author " + dr["BlogAuthor"]);
                Console.WriteLine("BlogContent " + dr["BlogContent"]);
                Console.WriteLine();
            }
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

            _sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, _sqlConnection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();
            _sqlConnection.Close();

            string message = result > 0 ? "Saving Successful." : "Saving Failed";
            Console.WriteLine(message);
        }

        public void Update(int id, string title, string author, string content)
        {
            query = @"UPDATE [dbo].[Tbl_Blog] SET 
                    [BlogTitle] = @BlogTitle,
                    [BlogAuthor] = @BlogAuthor,
                    [BlogContent] = @BlogContent
                    WHERE BlogId = @BlogId";

            _sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, _sqlConnection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int result = cmd.ExecuteNonQuery();
            _sqlConnection.Close();

            string message = result > 0 ? "Updating Successful." : "Updating Failed";
            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            query = @"DELETE FROM [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";

            _sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, _sqlConnection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int result = cmd.ExecuteNonQuery();
            _sqlConnection.Close();

            string message = result > 0 ? "Delete Successful." : "Delete Failed";
            Console.WriteLine(message);
        }
    }
}
