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

namespace Equipment_Management
{
    public partial class Main : Form
    {
        public int time_flag;    // 出入库 选择时间变量  1、2、3 分别代表 出库、入库、出入库
        public int id_flag;      // 部门ID


        public Main()
        {
            InitializeComponent();
        }

        private void 装备信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            装备基本信息 to_zbjbxx = new 装备基本信息();
            to_zbjbxx.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“masterDataSet.ArmsPerson”中。您可以根据需要移动或删除它。
            this.armsPersonTableAdapter.Fill(this.masterDataSet.ArmsPerson);
            // TODO: 这行代码将数据加载到表“equipment_Management_Information_SystemDataSet.Outlayln”中。您可以根据需要移动或删除它。
            this.outlaylnTableAdapter.Fill(this.equipment_Management_Information_SystemDataSet.Outlayln);
            WelcomePicture.Visible = true;
            统计与查询.Visible = false;
            装备经费管理.Visible = false;
            装备库存管理.Visible = false;
            系统管理.Visible = false;
        }

  
        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Load load = new Load();
            load.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void 统计查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 经费明细管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 部门基本信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            部门基本信息 to_bmjbxx = new 部门基本信息();
            to_bmjbxx.Show();
        }

        private void 人员基本信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            人员基本信息 to_ryjbxx = new 人员基本信息();
            to_ryjbxx.Show();
        }

      

     

        private void 出入库统计表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 将其他层的panel隐藏
            统计与查询.Visible = true;
            装备经费管理.Visible = false;
            装备库存管理.Visible = false;
            系统管理.Visible = false;

            // 将同层的panel隐藏
            库存装备流水统计表.Visible = false;
            部门人员查询.Visible = false;
            装备经费汇总.Visible = false;
            装备出入库统计表.Visible = true;
        }

        private void 部门人员查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 将其他层的panel隐藏
            统计与查询.Visible = true;
            装备经费管理.Visible = false;
            装备库存管理.Visible = false;
            系统管理.Visible = false;

            // 将同层的panel隐藏
            库存装备流水统计表.Visible = false;
            部门人员查询.Visible = true;
            装备经费汇总.Visible = false;
            装备出入库统计表.Visible = false;
        }

        private void 装备经费汇总ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 将其他层的panel隐藏
            统计与查询.Visible = true;
            装备经费管理.Visible = false;
            装备库存管理.Visible = false;
            系统管理.Visible = false;

            // 将同层的panel隐藏
            库存装备流水统计表.Visible = false;
            部门人员查询.Visible = false;
            装备经费汇总.Visible = true;
            装备出入库统计表.Visible = false;
        }

        private void 装备库存流水统计表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 将其他层的panel隐藏
            统计与查询.Visible = true;
            装备经费管理.Visible = false;
            装备库存管理.Visible = false;
            系统管理.Visible = false;

            // 将同层的panel隐藏
            库存装备流水统计表.Visible = true;
            部门人员查询.Visible = false;
            装备经费汇总.Visible = false;
            装备出入库统计表.Visible = false;
        }

        private void 出入库信息日期选择按钮_Click(object sender, EventArgs e)
        {
            // 数据库操作
            string conStr = "Data Source = VCC-PC; Initial Catalog = master; Integrated Security = SSPI";
            SqlConnection conn = new SqlConnection(conStr);
            try
            {
                conn.Open();
                //  MessageBox.Show("打开数据库成功！");
                string cmdStr1 = "select * from Takeout where OptDate between " + 装备流水信息时间查询选择1.Value.ToString() + "and" + 装备流水信息时间查询选择2.Value.ToString();     // 出库时间命令
                string cmdStr2 = "select * from StoreIn where OptDate between " + 装备流水信息时间查询选择1.Value.ToString() + "and" + 装备流水信息时间查询选择2.Value.ToString();     // 入时间库命令

                SqlCommand command1 = new SqlCommand(cmdStr1, conn);  // 在出库中查找
                SqlCommand command2 = new SqlCommand(cmdStr2, conn);  // 在入库中查找

                /**********  绑定表  *******************/
                if(time_flag == 1)
                {

                }
                else if(time_flag == 2)
                {

                }
                else if(time_flag == 3)
                {

                }


                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }

        private void 出入库信息查询按钮_Click(object sender, EventArgs e)
        {
            int flag = 0;       // 判定选择按钮
            if (出库信息查询选择.Checked == true)
            {
                flag = 1;
            }
            else if (入库信息查询选择.Checked == true)
                flag = 2; 
            else if (出入库信息查询选择.Checked == true)
                flag = 3;

            if (flag == 0)  // 判断查询类型是否为空
            {
                MessageBox.Show("请选择您所查询的类型！");
                return;
            }

            // 数据库操作
            string conStr = "Data Source = VCC-PC; Initial Catalog = master; Integrated Security = SSPI";
            SqlConnection conn = new SqlConnection(conStr);
            try
            {
                conn.Open();
                //  MessageBox.Show("打开数据库成功！");
                string cmdStr = "";     // 命令操作
                if (flag == 1)       // 查询出库信息
                {
                    cmdStr = "select * from Takeout";
                }
                else if (flag == 2)  // 如果查询入库信息
                {
                    cmdStr = "select * from Storeln";

                }
                else if (flag == 3)  // 如果查询出入库信息
                {
                    /*         功能待实现              */
                }
                SqlCommand command = new SqlCommand(cmdStr, conn);  // 在departments表中查找
                    
        
                /**********  绑定表  *******************/


                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

       


        }

        private void 出入库导出表格按钮_Click(object sender, EventArgs e)
        {
            string fileName = "";
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xlsx";
            saveDialog.Filter = "Excel文件|*.xlsx";
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，您的电脑可能未安装Excel");
                return;
            }
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook =
                        workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet =
                        (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1 
                                                                                         //写入标题             
            for (int i = 0; i < 装备流水信息数据显示.ColumnCount; i++)
            { worksheet.Cells[1, i + 1] = 装备流水信息数据显示.Columns[i].HeaderText; }
            //写入数值
            for (int r = 0; r < 装备流水信息数据显示.Rows.Count; r++)
            {
                for (int i = 0; i < 装备流水信息数据显示.ColumnCount; i++)
                {
                    worksheet.Cells[r + 2, i + 1] = 装备流水信息数据显示.Rows[r].Cells[i].Value;
                }
                System.Windows.Forms.Application.DoEvents();
            }
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
            MessageBox.Show(fileName + "资料保存成功", "提示", MessageBoxButtons.OK);
            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);  //fileSaved = true;                 
                }
                catch (Exception ex)
                {//fileSaved = false;                      
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                }
            }
            xlApp.Quit();
            GC.Collect();//强行销毁           
        }

      

        private void 人员信息查询输入_TextChanged(object sender, EventArgs e)
        {

        }

        private void 装备出入库导出表格按钮_Click(object sender, EventArgs e)
        {
            string fileName = "";
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xlsx";
            saveDialog.Filter = "Excel文件|*.xlsx";
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，您的电脑可能未安装Excel");
                return;
            }
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook =
                        workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet =
                        (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1 
                                                                                         //写入标题             
            for (int i = 0; i < 装备出入库信息数据显示.ColumnCount; i++)
            { worksheet.Cells[1, i + 1] = 装备出入库信息数据显示.Columns[i].HeaderText; }
            //写入数值
            for (int r = 0; r < 装备出入库信息数据显示.Rows.Count; r++)
            {
                for (int i = 0; i < 装备出入库信息数据显示.ColumnCount; i++)
                {
                    worksheet.Cells[r + 2, i + 1] = 装备出入库信息数据显示.Rows[r].Cells[i].Value;
                }
                System.Windows.Forms.Application.DoEvents();
            }
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
            MessageBox.Show(fileName + "资料保存成功", "提示", MessageBoxButtons.OK);
            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);  //fileSaved = true;                 
                }
                catch (Exception ex)
                {//fileSaved = false;                      
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                }
            }
            xlApp.Quit();
            GC.Collect();//强行销毁       
        }

        private void 装备经费汇总表导出按钮_Click(object sender, EventArgs e)
        {
            string fileName = "";
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xlsx";
            saveDialog.Filter = "Excel文件|*.xlsx";
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，您的电脑可能未安装Excel");
                return;
            }
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook =
                        workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet =
                        (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1 
                                                                                         //写入标题             
            for (int i = 0; i < 装备经费汇总数据库表.ColumnCount; i++)
            { worksheet.Cells[1, i + 1] = 装备经费汇总数据库表.Columns[i].HeaderText; }
            //写入数值
            for (int r = 0; r < 装备经费汇总数据库表.Rows.Count; r++)
            {
                for (int i = 0; i < 装备经费汇总数据库表.ColumnCount; i++)
                {
                    worksheet.Cells[r + 2, i + 1] = 装备经费汇总数据库表.Rows[r].Cells[i].Value;
                }
                System.Windows.Forms.Application.DoEvents();
            }
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
            MessageBox.Show(fileName + "资料保存成功", "提示", MessageBoxButtons.OK);
            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);  //fileSaved = true;                 
                }
                catch (Exception ex)
                {//fileSaved = false;                      
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                }
            }
            xlApp.Quit();
            GC.Collect();//强行销毁     
        }

        private void 装备流水统计查询容器_Enter(object sender, EventArgs e)
        {

        }

        private void 部门人员信息数据显示_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //清空dataGridView里所有控件的数据
            //MessageBox.Show("点击成功！");
            
        }

        private void 部门人员查询_Paint(object sender, PaintEventArgs e)
        {
            部门人员信息数据显示.DataSource = null;   // 将绑定的数据源清空

        }

        private void 部门人员基本信息表搜索按钮_Click(object sender, EventArgs e)
        {
            string textInput = 部门人员基本信息表成员.Text;   // 读取查询内容并判断 是否为空   
            if (textInput == "")
            {
                MessageBox.Show("查询内容不能为空，请重新输入！\n");
                return;
            }
            string conStr = "Data Source = VCC-PC; Initial Catalog = master; Integrated Security = SSPI";
           // string conStr = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=liuliu;pwd=201608";
            SqlConnection conn = new SqlConnection(conStr);
            try
            {
                conn.Open();
                //MessageBox.Show("打开数据库成功！");
      
                SqlCommand command = new SqlCommand("select * from  ArmsPerson where Dep_Id = '" + id_flag.ToString() + "'", conn);  // 在departments表中查找
                SqlDataReader reader = command.ExecuteReader();

                int flag = 0;           // 判断输入信息是否存在且唯一
                while (reader.Read())
                {
                    if (textInput == reader["Ryname"].ToString())
                    {
                        flag++; 
                    }
                }
                if (flag == 0)
                {
                    MessageBox.Show("输入信息有误，该部门是否存在此人！");
                    return;
                }
                reader.Close();
               // 部门人员基本信息表部门名.Text = textInput;      // 将查询部门名显示出来
                                                    //   command.CommandText = "select * from ArmsPerson where Dep_Id = '" + idInput.ToString() + "'";        // 在ArmsPerson表里查找

                /**********  绑定表  *******************/

                DataSet myds = new DataSet();
                SqlDataAdapter myda = new SqlDataAdapter("select * from ArmsPerson where Dep_Id = '" + id_flag.ToString() + "'" + " AND  Ryname = '" + textInput.ToString() + "'", conn);
                myda.Fill(myds);
                部门人员信息数据显示.DataSource = myds.Tables[0];


                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void 人员信息查询按钮_Click(object sender, EventArgs e)
        {
            string textInput = 人员信息查询输入.Text;   // 读取查询内容并判断 是否为空   
            if (textInput == "")
            {
                MessageBox.Show("查询内容不能为空，请重新输入！\n");
                return;
            }

            // 连接数据库 并显示信息
            //  string conStr = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=liuliu;pwd=201608";
            string conStr = "Data Source = VCC-PC; Initial Catalog = master; Integrated Security = SSPI";
            SqlConnection conn = new SqlConnection(conStr);
            try
            {
                conn.Open();
                //MessageBox.Show("打开数据库成功！");
                int idInput = -1;            // 输入内容对应的唯一ID号 
                SqlCommand command = new SqlCommand("select * from Departments", conn);  // 在departments表中查找
                SqlDataReader reader = command.ExecuteReader();

                int flag = 0;           // 判断输入信息是否存在且唯一
                while (reader.Read())
                {
                    if (textInput == reader["DepName"].ToString())
                    {
                        flag++;
                        idInput = int.Parse(reader["DepId"].ToString());    // 得到部门标识值
                    }
                }
                if (flag != 1)
                {
                    MessageBox.Show("输入信息有误，请检查是否存在该部门！");
                    return;
                }
                reader.Close();
                id_flag = idInput;  // 将选择得到的值保存在全局变量中
                部门人员基本信息表部门名.Text = textInput;      // 将查询部门名显示出来
                                                    //   command.CommandText = "select * from ArmsPerson where Dep_Id = '" + idInput.ToString() + "'";        // 在ArmsPerson表里查找

                /**********  绑定表  *******************/

                DataSet myds = new DataSet();
                SqlDataAdapter myda = new SqlDataAdapter("select * from ArmsPerson where Dep_Id = '" + idInput.ToString() + "'", conn);
                myda.Fill(myds);
                部门人员信息数据显示.DataSource = myds.Tables[0];


                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void 部门人员基本信息表部门名_Click(object sender, EventArgs e)
        {

        }

        private void 部门人员信息数据显示_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int CIndex = e.RowIndex;        // 获取选中行
            if (CIndex >= 0 && 部门人员信息数据显示[0,e.RowIndex].Value != System.DBNull.Value)        // 当按钮选择行时
            {
                //获取在同一行第一列的单元格中的字段值  
                int _UID = Convert.ToInt32(部门人员信息数据显示[ 0,e.RowIndex].Value);    // 得到选中行编号
               // MessageBox.Show(_UID.ToString());

                if(MessageBox.Show("您是否要查看详细信息？","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) != DialogResult)
                {
                    部门人员详细信息窗口 allInfor = new 部门人员详细信息窗口(_UID);
                   
                    allInfor.Show();
                }
                
            }
        }

        private void 装备出入库统计表_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 装备出入库查询按钮_Click(object sender, EventArgs e)
        {
            string textInput = 人员信息查询输入.Text;   // 读取查询内容并判断 是否为空   
            if (textInput == "")
            {
                MessageBox.Show("查询内容不能为空，请重新输入！\n");
                return;
            }

            //  string conStr = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=liuliu;pwd=201608";
            string conStr = "Data Source = VCC-PC; Initial Catalog = master; Integrated Security = SSPI";
            SqlConnection conn = new SqlConnection(conStr);
            try
            {
                conn.Open();
                //MessageBox.Show("打开数据库成功！");
                int idInput = -1;            // 输入内容对应的唯一ID号 
                SqlCommand command = new SqlCommand("select * from Departments", conn);  // 在departments表中查找
                SqlDataReader reader = command.ExecuteReader();

                int flag = 0;           // 判断输入信息是否存在且唯一
                while (reader.Read())
                {
                    if (textInput == reader["DepName"].ToString())
                    {
                        flag++;
                        idInput = int.Parse(reader["DepId"].ToString());    // 得到部门标识值
                    }
                }
                if (flag == 0)
                {
                    MessageBox.Show("输入信息有误，请检查是否存在该部门！");
                    return;
                }
                reader.Close();
                id_flag = idInput;  // 将选择得到的值保存在全局变量中
                 //   command.CommandText = "select * from ArmsPerson where Dep_Id = '" + idInput.ToString() + "'";        // 在ArmsPerson表里查找

                /**********  绑定表  *******************/

                DataSet myds = new DataSet();
                SqlDataAdapter myda = new SqlDataAdapter("select * from ArmsPerson where Dep_Id = '" + idInput.ToString() + "'", conn);
                myda.Fill(myds);
                部门人员信息数据显示.DataSource = myds.Tables[0];


                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void 装备经费汇总_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
