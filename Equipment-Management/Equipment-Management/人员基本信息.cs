using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Equipment_Management
{
    public partial class 人员基本信息 : Form
    {
        public 人员基本信息()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            编辑人员信息 do_ryxx = new 编辑人员信息();
            do_ryxx.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            编辑人员信息 do_ryxx = new 编辑人员信息();
            do_ryxx.Show();
        }
    }
}
