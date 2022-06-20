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
    public partial class FormRegist : Form
    {
        public User CurrentUser;
        public FormRegist(User user)
        {
            InitializeComponent();
            CurrentUser = user;
            this.userdata1.DataSource = CurrentUser;
        }

    }
}
