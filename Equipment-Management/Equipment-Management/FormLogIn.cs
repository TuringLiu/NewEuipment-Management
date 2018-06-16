using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Equipment_Management
{
    public partial class FormLogIn : Form
    {
        public FormLogIn()
        {
            InitializeComponent();
        }

        //点击登录按钮
        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            LogInUser.logFlag = true;
            if(textBoxUserName.Text =="" || textBoxPwd.Text == "")
            {
                MessageBox.Show("用户名或密码为空", "提示");
                return;
            }
            try
            {
                if (DBClass_lilang.conn.State != ConnectionState.Open)
                {
                    DBClass_lilang.conn.Open();
                }
                //判断用户名是否存在，密码是否正确
                string strcmd = "select [Usersname] from ArmsUsers " +
                    "where [Usersname] = '" + textBoxUserName.Text + "'";
                SqlCommand cmd1 = new SqlCommand(strcmd, DBClass_lilang.conn);
                if (cmd1.ExecuteScalar() == null)
                {
                    MessageBox.Show("用户名不存在", "提示");
                    LogInUser.logFlag = false;
                }
                strcmd = "select [Userspwd] from ArmsUsers " +
                    "where [Userspwd] = '" + textBoxPwd.Text + "'";
                SqlCommand cmd2 = new SqlCommand(strcmd, DBClass_lilang.conn);
                if (cmd2.ExecuteScalar().ToString().Trim() != textBoxPwd.Text)
                {
                    MessageBox.Show("密码不正确", "提示");
                    LogInUser.logFlag = false;
                    //记录登录错误的信息
                    strcmd = String.Format("insert SysLog(LogId, LogDate, LogTime," +
                        " LogType, Title, Body, UserName)values('{0}','{1}','{2}'" +
                        ",'{3}','{4}','{5}','{6}')", StreamCode.GetCode("LogId", "SysLog"),
                        DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(),
                        "登录", "用户登录密码错误", "用户名: " + LogInUser.userName, LogInUser.userName);
                    SqlCommand cmd3 = new SqlCommand(strcmd, DBClass_lilang.conn);
                    cmd3.ExecuteNonQuery();
                }
                if (LogInUser.logFlag)
                {
                    //记录username和usertype
                    LogInUser.userName = textBoxUserName.Text;
                    strcmd = "select [User_type] from ArmsUsers " +
                        "where [Usersname] = '" + textBoxUserName.Text + "'";
                    SqlCommand cmd3 = new SqlCommand(strcmd, DBClass_lilang.conn);
                    LogInUser.userType = cmd3.ExecuteScalar().ToString().Trim();
                    //记录登录成功的信息
                    strcmd = String.Format("insert SysLog(LogId, LogDate, LogTime," +
                        " LogType, Title, Body, UserName)values('{0}','{1}','{2}'" +
                        ",'{3}','{4}','{5}','{6}')", StreamCode.GetCode("LogId", "SysLog"),
                        DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(),
                        "登录", "用户登录成功", "用户名: " + LogInUser.userName, LogInUser.userName);
                    SqlCommand cmd4 = new SqlCommand(strcmd, DBClass_lilang.conn);
                    cmd4.ExecuteNonQuery();
                    DBClass_lilang.conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "\n打开数据库失败");
                LogInUser.logFlag = false;
            }
            if (LogInUser.logFlag)
            {
                this.Hide();
                new Main().Show();
            }
        }

        //关闭窗口
        private void FormLogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (DBClass_lilang.conn.State != ConnectionState.Open)
                {
                    DBClass_lilang.conn.Open();
                }
                //记录注销登录的信息
                string strcmd = String.Format("insert SysLog(LogId, LogDate, LogTime," +
                        " LogType, Title, Body, UserName)values('{0}','{1}','{2}'" +
                        ",'{3}','{4}','{5}','{6}')", StreamCode.GetCode("LogId", "SysLog"),
                        DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(),
                        "注销登录", "用户注销登录成功", "用户名: " + LogInUser.userName, LogInUser.userName);
                SqlCommand cmd = new SqlCommand(strcmd, DBClass_lilang.conn);
                cmd.ExecuteNonQuery();
                DBClass_lilang.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "\n打开数据库失败");
            }
            Application.Exit();
        }
    }
}
