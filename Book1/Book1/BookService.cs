using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Book1
{
    public class BookService
    {
        public BookService()
        {
            using (var context = new BookContext())
            {
                if (context.Users.Count() == 0)
                {
                    context.Users.Add(new User("user1", 123456));
                    context.Users.Add(new User("user2", 123456));
                }
            }
        }

        public List<Book> Books
        {
            get
            {
                using (var context = new BookContext())
                {
                    return context.Books
                      .Include("User")
                      .ToList<Book>();
                }
            }
        }

        public Book GetBook(string id)
        {
            using (var context = new BookContext())
            {
                return context.Books
                  .Include("User")
                  .SingleOrDefault(o => o.BookId == id);
            }
        }

        public void AddBook(Book book)
        {
            FixBook(book);
            using (var context = new BookContext())
            {
                context.Entry(book).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        private static void FixBook(Book newBook)
        {
            newBook.UserId = newBook.User.UserId;
            newBook.User = null;
        }

        public void RemoveBook(string id)
        {
            using (var context = new BookContext())
            {
                var book = context.Books
             .SingleOrDefault(o => o.BookId == id);
                if (book == null) return;
                context.Books.Remove(book);
                context.SaveChanges();
            }
        }

        public List<Book> QueryOrdersByUserName(string userName)
        {
            using (var context = new BookContext())
            {
                return context.Books
                  .Include("User")
                  .Where(book => book.User.Name == userName)
                  .ToList();
            }
        }

        public List<Book> QueryOrdersByBookName(string bookName)
        {
            using (var context = new BookContext())
            {
                return context.Books
                  .Include("User")
                  .Where(book => book.Name == bookName)
                  .ToList();
            }
        }


    }
}
