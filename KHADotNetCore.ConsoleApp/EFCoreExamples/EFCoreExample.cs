using KHADotNetCore.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace KHADotNetCore.ConsoleApp.EFCoreExamples
{
    public class EFCoreExample
    {
        private readonly AppDbContext db;
        public EFCoreExample()
        {
            db = new AppDbContext();
        }

        public void Read()
        {
            List<BlogModel>blogList = db.Blogs.ToList();

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
            BlogModel? blog = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if(blog is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }

            Console.WriteLine("BlodId "+ blog.BlogId);
            Console.WriteLine("BlogTitle " + blog.BlogTitle);
            Console.WriteLine("Author " + blog.BlogAuthor);
            Console.WriteLine("BlogContent " + blog.BlogContent);
            Console.WriteLine();
        }

        public void Create(string title,string author,string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };
            db.Blogs.Add(blog);

            int result = db.SaveChanges();]
            string message = result > 0 ? "Saving successful." : "saving failed";
            Console.WriteLine(message);
        }

        public void Update(int id, string title, string author, string content)
        {
            BlogModel? blog = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (blog is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            blog.BlogTitle = title;
            blog.BlogAuthor = author;
            blog.BlogContent = content;

            int result = db.SaveChanges();
            string message = result > 0 ? "Update successful." : "Update failed";
            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            BlogModel? blog = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (blog is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            db.Blogs.Remove(blog);

            int result = db.SaveChanges();
            string message = result > 0 ? "Delete successful." : "Delete failed";
            Console.WriteLine(message);
        }
    }
}
