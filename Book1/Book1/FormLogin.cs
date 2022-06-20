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
    public partial class FormLogin : Form
    {
        UserService userService;
        public String loginname { get; set; }

        public int logincode { get; set; }

        public FormLogin()
        {
            InitializeComponent();
            userService = new UserService();
            userdata.DataSource = userService.Users;
            name.DataBindings.Add("Text", this, "loginname");
            code.DataBindings.Add("Text", this, "logincode");
        }

        private void login_Click(object sender, EventArgs e)
        {
            User user=userService.GetUser2(loginname);
            if (user != null && user.Code == logincode)
            {
                MainForm mainform = new MainForm(user);
                mainform.ShowDialog();
            }
        }

        private void register_Click(object sender, EventArgs e)
        {
            FormRegist formRegist = new FormRegist(new User());
            if (formRegist.ShowDialog() == DialogResult.OK)
            {
                userService.AddUser(formRegist.CurrentUser);
                userdata.ResetBindings(false);
            }
        }
    }
}
