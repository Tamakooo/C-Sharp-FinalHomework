using WebApi.Models;

namespace WebApi.Bll.Interfaces
{
    public interface IBookBll
    {
        List<Book> GetAll();
        Book GetBook(int id);
    }
}
