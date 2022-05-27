using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book1
{
    public class Book
    {
        public string BookId { get; set; }
        public string Name { get; set; }

        public bool IsLended { get; set; }
        public User User { get; set; }
        public string UserName { get => (User != null) ? User.Name : ""; }

        public  int UserId { get; set; }

        public Book()
        {
            BookId = Guid.NewGuid().ToString();
        }
        public Book(string ID,string name,User user)
        {
            this.BookId = ID;
            this.Name = name;
            this.User = user;
        }

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append($"Id:{BookId},name:{Name},user:{User}");
            return strBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            var book = obj as Book;
            return book != null &&BookId == book.BookId;
        }

        public int CompareTo(Book other)
        {
            if (other == null) return 1;
            return this.BookId.CompareTo(other.BookId);
        }
    }
}
