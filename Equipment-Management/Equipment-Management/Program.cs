using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Equipment_Management
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Load());
        }
    }
    public static class LogInUser
    {
        public static string userName;
        public static string userType;
        public static bool logFlag;//登录时用于判断是否能登录
        public static bool addFlag;//添加账户时用于判断是否能添加
    }

    public static class MyPanel
    {
        public static List<Panel> lastpanels = new List<Panel>();
        //隐藏旧panel，显示新panel
        public static void Show(List<Panel> mypanels)
        {
            foreach (Panel items in lastpanels)
            {
                items.Visible = false;
            }
            lastpanels.Clear();
            lastpanels.AddRange(mypanels);
            foreach (Panel items in lastpanels)
            {
                items.Visible = true;
            }
        }
    }
    public static class StrList
    {
        public static List<string> items = new List<string>();
        public static bool timeFlag = false;
    }
    public static class DBClass_lilang
    {
        public static string strConn = "Server = 25.24.20.180; Initial Catalog = " +
            "Equipment Management Information System; uid = lilang; pwd = 201608";
        public static SqlConnection conn = new SqlConnection(strConn);
    }
    public static class StreamCode
    {
        public static int id;
        public static int GetCode(string idName, string libraryName)
        {
            id = DateTime.Now.Year;
            string strcmd = String.Format("select MAX(" + idName + ") from " + libraryName);
            SqlCommand cmd = new SqlCommand(strcmd, DBClass_lilang.conn);
            if (cmd.ExecuteScalar().ToString() != "")
            {
                if (int.Parse(cmd.ExecuteScalar().ToString().Substring(0, 4)) >= DateTime.Now.Year)
                {
                    id = id * 10000;
                    id += int.Parse(cmd.ExecuteScalar().ToString().Substring(4, 4)) + 1;
                }
            }
            else
            {
                id = id * 10000;
            }
            return id;
        }
    }
    public static class AddModify
    {
        public static bool AddModifyFlag = true;//true为Add，false为修改
    }
}
