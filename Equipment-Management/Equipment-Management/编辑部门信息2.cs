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
    public partial class 编辑部门信息2 : Form
    {
        public 编辑部门信息2()
        {
            InitializeComponent();
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
                    cmd.CommandText = "update Departments set[DepId]='" + textBox1.Text + "'" +
                      ",[DepName]='" + textBox2.Text + "'" +
                      ",[Describes]='" + textBox3.Text + "'" +
                      ",[UpperId]='" + comboBox1.Text + "'" +
                    
                      "where[DepId]='" + mystr.num + "'";
                    cmd.ExecuteNonQuery();


                    //mystr.data.DataSource = dsMydataBase.Tables["Departments"];
                    MessageBox.Show("成功修改数据");
                    mystr.tree.Nodes.Clear();
                    TreeViewRefresh();

                    DBClass_xu.conn.Close();
                    Close();


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + " 打开数据库失败");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void 编辑部门信息2_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“equipment_Management_Information_SystemDataSet12.Departments”中。您可以根据需要移动或删除它。
            this.departmentsTableAdapter.Fill(this.equipment_Management_Information_SystemDataSet12.Departments);

        }
        public static void WriteList(string id, string name, string upperid, int count)
        {
            //这里存的是upperid的id、name和upperid
            string id1 = "";
            string name1 = "";
            string upperid1 = "";
            //当upperid为空或者upperid = id时，即到达顶级部门，就结束递归
            if (upperid == "" || upperid == id)
            {
                return;
            }
            //找出upperid的upperid
            string strcmd = "select [UpperId] from Departments where [DepId] = '" + upperid + "'";
            SqlCommand cmd = new SqlCommand(strcmd, DBClass_xu.conn);
            //如果有的话。这里若用cmd.ExecuteScalar() != null貌似有的地方会出问题所以改了
            if (cmd.ExecuteScalar() != null)
            {
                if (cmd.ExecuteScalar().ToString() != "")
                {
                    //记录
                    upperid1 = cmd.ExecuteScalar().ToString();
                    //把upperid的id和name读出来
                    string strda = "select [DepId], [DepName] from Departments " +
                        "where [DepId] = '" + upperid + "'";
                    SqlDataAdapter da = new SqlDataAdapter(strda, DBClass_xu.conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Dep");
                    //因为应该只有一行（部门不应该有重复），所以只读rows[0]的。
                    id1 = ds.Tables["Dep"].Rows[0]["DepId"].ToString();
                    name1 = ds.Tables["Dep"].Rows[0]["DepName"].ToString();
                }

            }
            //递归
            WriteList(id1, name1, upperid1, count);
            //递归返回后添加
            TreeViewList.id[count].Add(id1);
            TreeViewList.name[count].Add(name1);
            //返回
            return;
        }
        public static void TreeViewRefresh()
        {
            //这里是新加的，用来清空，要不然除非重开应用，否则一直都是之前的树
            TreeViewList.id.Clear();
            TreeViewList.name.Clear();
            //将整个表的内容读出来（除了“描述”这个无关属性）
            string strda = "select [DepId], [DepName], [UpperId] from Departments";
            SqlDataAdapter da = new SqlDataAdapter(strda, DBClass_xu.conn);
            DataSet ds = new DataSet();
            //存到ds的Dep表里
            da.Fill(ds, "Dep");
            //将Dep表里的内容读出到TreeViewList里
            //存放形式：比如id里的：1；1，2；1，3//1为顶级部门，2和3为其子部门
            //其实就是把每一个部门及其所有的上级部门写到这个自定义的List里
            //用递归的形式将上级部门放到前面
            for (int i = 0; i < ds.Tables["Dep"].Rows.Count; i++)
            {
                //这里先添加空的，否则会报错
                TreeViewList.id.Add(new List<string>());
                TreeViewList.name.Add(new List<string>());
                //用writelist将数据写进list，参数说明看声明部分
                WriteList(ds.Tables["Dep"].Rows[i]["DepId"].ToString(),
                    ds.Tables["Dep"].Rows[i]["DepName"].ToString(),
                    ds.Tables["Dep"].Rows[i]["UpperId"].ToString(), i);
                //递归只会将上级部门写入，所以还要将本部门添加进去
                //id[i]的意思就是前面新加的空list<string>
                TreeViewList.id[i].Add(ds.Tables["Dep"].Rows[i]["DepId"].ToString());
                TreeViewList.name[i].Add(ds.Tables["Dep"].Rows[i]["DepName"].ToString());
            }
            //这两个循环用来添加treeview控件的结点
            //这个循环是用来换list<string>的，具体如：1；1，2；1，3等等
            for (int i = 0; i < TreeViewList.id.Count; i++)
            {
                //每一次循环都要将被选中的结点重置为顶级结点
                //后面写添加功能时就不用了，用treeView1.SelectedNode.Nodes.Add（key，text）就行了，
                //然后将key和text记录（作为id和name）、SelectedNode的key
                //（读这个值用SelectedNode.name，应该就行了）也记录（作为upperid）
                mystr.tree.SelectedNode = mystr.tree.TopNode;
                //这个循环就将list<string>里的所有东西添加为结点，当然重复的就跳过
                for (int j = 0; j < TreeViewList.id[i].Count; j++)
                {
                    //检验是否为第一次添加，即添加顶级部门--“部门信息”（id为1）
                    if (TreeViewList.id[i][j] == "1" && mystr.tree.SelectedNode == null)
                    {
                        //treeView1.Nodes.Add（）这个是添加顶级结点的
                        mystr.tree.Nodes.Add(TreeViewList.id[i][j], TreeViewList.name[i][j]);
                        //这里将顶级结点设为选中结点
                        mystr.tree.SelectedNode = mystr.tree.TopNode;
                    }
                    //检验是否重复，find的第二个参数为true则会遍历treeView1.Nodes开始的整个树
                    //用返回的结点组（好像是TreeNodeCollection）的长度来判断是否找到，用null好像不行
                    if (mystr.tree.Nodes.Find(TreeViewList.id[i][j], true).Length == 0)
                    {
                        //没有就添加
                        mystr.tree.SelectedNode.Nodes.Add(TreeViewList.id[i][j], TreeViewList.name[i][j]);
                    }
                    //让选中结点改变为当前树中找到的第一个id相同的结点
                    mystr.tree.SelectedNode = mystr.tree.Nodes.Find(TreeViewList.id[i][j], true)[0];
                }
            }
        }
    }
}
