using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Book1
{
    public partial class FormAdd : Form
    {
        private BookService bookService;
        public Book CurrentBook { get; set; }
        public bool AddModel { get; set; }
        public event Action<FormAdd> CloseFromAdd;

        public FormAdd(Book book,BookService bookService)
        {
            InitializeComponent();
            using (BookContext ctx = new BookContext())
            {
                userdata.DataSource = ctx.Users.ToList();
            }
            this.bookService = bookService;
            this.CurrentBook = book;
            bookdata.DataSource = CurrentBook;

              
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CurrentBook.User = (User)userdata.Current;
            CurrentBook.Name = text2.Text;
            CurrentBook.BookId = text1.Text;
            bookService.AddBook(CurrentBook);
            CloseFromAdd(this);
        }
    }
}
