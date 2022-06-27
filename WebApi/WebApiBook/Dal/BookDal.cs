using MySqlConnector;
using System.Data;
using WebApi.Dal.Core;
using WebApi.Models;

namespace WebApi.Dal
{
    public class BookDal
    {

        public List<Book> GetAll()
        {
            DataTable res = SqlHelper.ExecuteTable("SELECT * FROM book");
            List<Book> bookList = ToModelList(res);
            return bookList;
        }

        public List<Book> GetBook(int id)
        {
            DataTable res = SqlHelper.ExecuteTable("SELECT * FROM book WHERE id = @id",
                new MySqlParameter("@id", id));

            List<Book> bookList = ToModelList(res);
            return bookList;
        }

        public List<Book> GetBookByUser(int userId)
        {
            DataTable res = SqlHelper.ExecuteTable("SELECT * FROM book WHERE UserId = @UserId",
                new MySqlParameter("@UserId", userId));

            List<Book> bookList = ToModelList(res);
            return bookList;
        }

        public int AddBook(string bookName, int userId)
        {
            return SqlHelper.ExecuteNonQuery(
                "INSERT INTO book(BookName,UserId) VALUES(@BookName,@UserId)",
                new MySqlParameter("@BookName", bookName),
                new MySqlParameter("@UserId", userId));
        }

        public int RemoveBook(int id)
        {
            return SqlHelper.ExecuteNonQuery(
                "DELETE FROM book WHERE id = @id",
                new MySqlParameter("@id", id));
        }

        public int RemoveAllBook(int userId)
        {
            return SqlHelper.ExecuteNonQuery(
                "DELETE FROM book WHERE UserId = @UserId",
                new MySqlParameter("@UserId", userId));
        }

        private Book ToModel(DataRow row)
        {
            Book book = new Book();
            book.id = (int)row["id"];
            book.BookName = row["BookName"].ToString();
            book.UserId = (int)row["UserId"];
            book.IsLend = (bool)row["IsLend"];
            return book;
        }

        private List<Book> ToModelList(DataTable res)
        {
            List<Book> bookList = new List<Book>();
            for (int i = 0; i < res.Rows.Count; i++)
            {
                DataRow row = res.Rows[i];
                Book book = ToModel(row);
                bookList.Add(book);
            }
            return bookList;
        }
    }
}
