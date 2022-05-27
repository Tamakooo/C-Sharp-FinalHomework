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
    public partial class MainForm : Form
    {
        BookService bookService;

        public String Keyword { get; set; }

        public MainForm()
        {
            InitializeComponent();
            bookService = new BookService();
            bookdata.DataSource = bookService.Books;
            text.DataBindings.Add("Text", this, "Keyword");

        }

        public void QueryAll()
        {
            bookdata.DataSource = bookService.Books;
            bookdata.ResetBindings(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Book book = bookdata.Current as Book;
            if (book == null)
            {
                MessageBox.Show("请选择一本书进行删除");
                return;
            }
            bookService.RemoveBook(book.BookId);
            QueryAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (box.SelectedIndex)
            {
                case 0:
                    bookdata.DataSource = bookService.Books;
                    break;
                case 1:
                    Book book = bookService.GetBook(Keyword);
                    List<Book> result = new List<Book>();
                    if (book != null) result.Add(book);
                    bookdata.DataSource = result;
                    break;
                case 2:
                    bookdata.DataSource = bookService.QueryOrdersByBookName(Keyword);
                    break;
                case 3:
                    bookdata.DataSource = bookService.QueryOrdersByUserName(Keyword);
                    break;
            }
            bookdata.ResetBindings(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAdd formAdd = new FormAdd(new Book(),bookService);
            new FormAdd(new Book(),bookService).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QueryAll();
        }
    }
}
