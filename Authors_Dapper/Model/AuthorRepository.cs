using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authors_Dapper.Model
{
    class AuthorRepository :IRepository<Author>, IDisposable
    {
        SqlConnection connection = null;

        public AuthorRepository()
        {
            connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["LibraryDb"].ConnectionString;
        }
        public int Create(Author obj)
        {
            string sql = "INSERT INTO Authors(FirstName, LastName) VALUES (@FirstName, @LastName)";
            return connection.Execute(sql, obj);
        }
        public int Delete(Author obj)
        {
            string sql = "DELETE FROM Authors WHERE ID = @Id";
            return connection.Execute(sql, obj);
        }

        public void Dispose()
        {
            connection?.Dispose();
        }

        public IList<Author> GetAll()
        {
            string sql = "SELECT * FROM Authors";
            var authors = connection.Query<Author>(sql).ToList();
            return authors;
        }
        public Author GetById(int id)
        {
            string sql = "SELECT * FROM Authors WHERE Id = @Id";
            Author author = connection.QueryFirstOrDefault<Author>(sql, new { Id = id });
            return author;
        }

        public int Update(Author obj)
        {
            string sql = "UPDATE Authors SET FirstName = @FirstName, LastName = @LastName WHERE Id = @Id";
            return connection.Execute(sql, obj);
        }
        public List<string> GetAllBooks()
        {
            List<string> AllBooks = new List<string>();

            var query = "SELECT * FROM Authors JOIN Books ON Authors.Id = Books.Id_Author";

            var authors = new Dictionary<int, Author>();

            var result = connection.Query<Author, Book, Author>(
                query,
                (author, book) =>
                {

                    Author authorEntry;

                    if (!authors.TryGetValue(author.Id, out authorEntry))
                    {
                        authors.Add(author.Id, author);
                        author.Books = new List<Book>();
                        authorEntry = author;
                    }

                    authorEntry.Books.Add(book);

                    return authorEntry;
                },
                splitOn: "Id"
                );
            foreach (var pair in authors)
            {
                var author = pair.Value;
                string str=$"{author.Id}: {author.FirstName} {author.LastName}: все книги:  ";
                foreach (var book in author.Books)
                {
                    str+=$"{book.Name}, ";
                }
                AllBooks.Add(str);
            }
            return AllBooks ;
        }
        public List<Book> SearchByName(Author a )
        {
            string query = $"SELECT Name FROM Books JOIN Authors ON Books.Id_Author=Authors.Id " +
                $"WHERE Authors.Id={a.Id}";
                //LastName ={a.LastName} OR Authors.FirstName={a.FirstName} ";
            var temp = connection.Query<Book>(query).ToList();  
            return temp;
        }
        public List<Book> SearchById(int ID)
        {
            string query = $"SELECT Name FROM Books JOIN Authors ON Books.Id_Author=Authors.Id " +
                $"WHERE Authors.ID={ID} ";
            var temp = connection.Query<Book>(query).ToList();
            return temp;
           
        }
    }
}
