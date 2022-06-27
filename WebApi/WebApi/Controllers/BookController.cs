using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Bll;
using WebApi.Dal;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public List<Book> GetAll()
        {
            BookBll bookBll = new BookBll();
            List<Book> bookList = bookBll.GetAll();
            return bookList;
        }

        [HttpGet]
        public Book GetBook(int id)
        {
            BookBll bookBll = new BookBll();
            Book book = bookBll.GetBook(id);
            return book;
        }

        [HttpGet]
        public List<Book> GetBookByUser(int userId)
        {
            BookDal bookDal = new BookDal();
            List<Book> booklist = bookDal.GetBookByUser(userId);
            return booklist;
        }

        [HttpPost]
        public string Insert(int userId, string bookName)
        {
            BookDal bookDal = new BookDal();
            int rows = bookDal.AddBook(bookName, userId);
            if (rows > 0)
            {
                return "添加成功";
            }
            else
            {
                return "添加失败";
            }
        }

        [HttpDelete]
        public string Remove(int id)
        {
            BookDal bookDal = new BookDal();
            int rows = bookDal.RemoveBook(id);
            if (rows > 0)
            {
                return "删除成功";
            }
            else
            {
                return "删除失败";
            }
        }

        [HttpDelete]
        public string RemoveAll(int userId)
        {
            BookDal bookDal = new BookDal();
            int rows = bookDal.RemoveAllBook(userId);
            if (rows > 0)
            {
                return "删除成功";
            }
            else
            {
                return "删除失败";
            }
        }
    }
}
