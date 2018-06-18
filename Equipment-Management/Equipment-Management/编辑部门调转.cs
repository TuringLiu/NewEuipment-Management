using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Equipment_Management.Program;

namespace Equipment_Management
{
    public partial class 编辑部门调转 : Form
    {
        public 编辑部门调转()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void WriteList(string id, string name, string upperid, int count)
        {
            string id1 = "";
            string name1 = "";
            string upperid1 = "";
            if (upperid == "" || upperid == id)
            {
                return;
            }
            string strcmd = "select [UpperId] from Departments where [DepId] = '" + upperid + "'";
            SqlCommand cmd = new SqlCommand(strcmd, DBClass_xu.conn);
            if (cmd.ExecuteScalar() != null)
            {
                upperid1 = cmd.ExecuteScalar().ToString();
                string strda = "select [DepId], [DepName] from Departments " +
                    "where [DepId] = '" + upperid + "'";
                SqlDataAdapter da = new SqlDataAdapter(strda, DBClass_xu.conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "Dep");
                id1 = ds.Tables["Dep"].Rows[0]["DepId"].ToString();
                name1 = ds.Tables["Dep"].Rows[0]["DepName"].ToString();
            }
            WriteList(id1, name1, upperid1, count);
            TreeViewList.id[count].Add(id1);
            TreeViewList.name[count].Add(name1);
            return;
        }
        private void 编辑部门调转_Load(object sender, EventArgs e)
        {
            try
            {
                DBClass_xu.conn.Open();
                string strda = "select [DepId], [DepName], [UpperId] from Departments";
                SqlDataAdapter da = new SqlDataAdapter(strda, DBClass_xu.conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "Dep");
                for (int i = 0; i < ds.Tables["Dep"].Rows.Count; i++)
                {
                    TreeViewList.id.Add(new List<string>());
                    TreeViewList.name.Add(new List<string>());
                    WriteList(ds.Tables["Dep"].Rows[i]["DepId"].ToString(),
                        ds.Tables["Dep"].Rows[i]["DepName"].ToString(),
                        ds.Tables["Dep"].Rows[i]["UpperId"].ToString(), i);
                    TreeViewList.id[i].Add(ds.Tables["Dep"].Rows[i]["DepId"].ToString());
                    TreeViewList.name[i].Add(ds.Tables["Dep"].Rows[i]["DepName"].ToString());
                }
                for (int i = 0; i < TreeViewList.id.Count; i++)
                {
                    treeView2.SelectedNode = treeView2.TopNode;
                    for (int j = 0; j < TreeViewList.id[i].Count; j++)
                    {
                        if (TreeViewList.id[i][j] == "1" && treeView2.SelectedNode == null)
                        {
                            treeView2.Nodes.Add(TreeViewList.id[i][j], TreeViewList.name[i][j]);
                            treeView2.SelectedNode = treeView2.TopNode;
                        }
                        if (treeView2.Nodes.Find(TreeViewList.id[i][j], true).Length == 0)
                        {
                            treeView2.SelectedNode.Nodes.Add(TreeViewList.id[i][j], TreeViewList.name[i][j]);
                        }
                        treeView2.SelectedNode = treeView2.Nodes.Find(TreeViewList.id[i][j], true)[0];
                    }
                }
                DBClass_xu.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "\n打开数据库失败");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (DBClass_xu.conn.State != ConnectionState.Open)//检查连接状态是否为已连接
                {
                    DBClass_xu.conn.Open();
                }
               
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DBClass_xu.conn;

                    string strcmd = "select DepId from Departments where DepName='" + treeView2.SelectedNode.Text + "'";
                    cmd.CommandText = strcmd;
                    int save = int.Parse(cmd.ExecuteScalar().ToString());

                    cmd.CommandText = "update ArmsPerson set[Dep_Id]='" + save+ "'" +
                      "where[RyId]='" + mystr.str + "'";
                    cmd.ExecuteNonQuery();

                    DataSet dsMydataBase = new DataSet();
                    SqlDataAdapter daBaseInform = new SqlDataAdapter("Select*From ArmsPerson", DBClass_xu.conn);
                    daBaseInform.Fill(dsMydataBase, "ArmsPerson");

                    mystr.data.DataSource = dsMydataBase.Tables["ArmsPerson"];
                    MessageBox.Show("成功修改数据");
                    DBClass_xu.conn.Close();
                    Close();
                    
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + " 打开数据库失败");
            }








        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
    
}
