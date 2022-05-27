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
    public partial class FormParent : Form
    {
        MainForm formMain = new MainForm();
        public FormParent()
        {
            InitializeComponent();
        }
    }
}