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
    public partial class 部门基本信息 : Form
    {
        public 部门基本信息()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            编辑部门信息 do_bmxx = new 编辑部门信息();
            do_bmxx.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            编辑部门信息 do_bmxx = new 编辑部门信息();
            do_bmxx.Show();
        }

        private void 部门基本信息_Load(object sender, EventArgs e)
        {

        }
    }
}
