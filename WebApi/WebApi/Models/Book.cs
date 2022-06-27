namespace WebApi.Models
{
    public class Book
    {
        public int id { get; set; }
        public string BookName { get; set; }
        public bool IsLend { get; set; }
        public Users User { get; set; }
        public int UserId { get; set; }

        
        //public Book(int id, string bookName, Users user)
        //{
          //  this.id = id;
          //  this.BookName = bookName;
          //  this.User = user;
          //  this.UserId = this.User.id;
        //}

        

    }
}
