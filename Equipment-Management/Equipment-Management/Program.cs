using System;
using System.Collections.Generic;
using System.Data;
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

        public static class mystr
        {
            public static string str = "";
            public static string str2 = "";
            public static DataGridView data;
            public static int num;
            public static int i;
            public static TreeView tree;
        }
        public static class increase
        {
            public static int dataLend_id;
        }
        //存储树控件的节点信息
        public static class TreeViewList
        {
            public static List<List<string>> name = new List<List<string>>();
            public static List<List<string>> id = new List<List<string>>();
            public static List<string> deleteid = new List<string>();
        }
    }
        
}
