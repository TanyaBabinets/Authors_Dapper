using Authors_Dapper.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Authors_Dapper
{
     static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());



            //    using (AuthorRepository rep = new AuthorRepository())
            //    {
            //        rep.Create(new Author
            //        {
            //            FirstName = "John",
            //            LastName = "Righter"
            //        });

            //        var author = rep.GetById(1);

            //        author.FirstName = "Jeffrey";
            //        author.LastName = "Richter";
            //        rep.Update(author);

            //        var authors = rep.GetAll();
            //        foreach (var a in authors)
            //        {
            //            Console.WriteLine($"{a.Id} {a.FirstName} {a.LastName}");
            //        }
            //    }
            //    //OneToMany();
            //    //MultiTableQueryOneToMany();
            //}


            //static void OneToMany()
            //{
            //    var connection = new SqlConnection();
            //    connection.ConnectionString = ConfigurationManager.ConnectionStrings["LibraryDb"].ConnectionString;

            //    var query = "SELECT * FROM Authors WHERE Id = @Id;"
            //        + "SELECT Id, Name, YearPress, Id_Author FROM Books WHERE Id_Author = @Id";

            //    var result = connection.QueryMultiple(query, new { Id = 2 });

            //    var author = result.ReadSingle<Author>();
            //    author.Books = result.Read<Book>().ToList();

            //    Console.WriteLine($"{author.FirstName} {author.LastName}");
            //    foreach (var book in author.Books)
            //    {
            //        Console.WriteLine($"\t{book.Name} {book.YearPress}");
            //    }
            //}


        }
    }
}
