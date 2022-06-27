using WebApi.Bll.Interfaces;
using WebApi.Dal;
using WebApi.Models;

namespace WebApi.Bll
{
    public class BookBll:IBookBll
    {
        BookDal bookDal = new BookDal();
        public List<Book> GetAll()
        {
            return bookDal.GetAll().FindAll(m => !m.IsLend);
        }
        public Book GetBook(int id)
        {
            List<Book> bookList = bookDal.GetBook(id);
            
            if (bookList.Count <= 0)
            {
                return null;//返回默认值
            }
            else
            {
                Book book = bookList.Find(m => !m.IsLend);
                return book;
            }
        }
    }
}
