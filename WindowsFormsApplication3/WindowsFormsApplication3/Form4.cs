using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace WindowsFormsApplication3
{
    public partial class Form4 : Form
    {
        private string sumday;
        public Form4()
        {
            try
            {
                InitializeComponent();
                oracle.LinkToOracle("orcl", "hui", "oracle");
                OracleCommand cmd = oracle.getConnection().CreateCommand();
                cmd.CommandText = String.Format("select * from teacher");
                OracleDataAdapter sda = new OracleDataAdapter(cmd);
                DataTable query = new DataTable();
                sda.Fill(query);
                dataGridView1.DataSource = query;
                oracle.LinkClose();
            cmd.Dispose();
            }
            
            
            catch (Exception ex)
            {
                MessageBox.Show("登录失败！！");
            }
        }
        /*private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex != 0 && e.RowIndex != -1)
            {

                //获取控件的值


                MessageBox.Show(this.dataGridView1.Rows[e.RowIndex].Cells[0].EditedFormattedValue.ToString());

                //或者可以做其他事件处理程序

            }

        }

        private void dataGrid1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // pnlBottom.Enabled = true;
            //获得当前选中的行 
            int rowindex = e.RowIndex;
            foreach (DataGridViewColumn c in dataGridView1.SelectedColumns)
            {
                listBox1.Items.Add("选定的列是：" + c.Index );
            }
            string value0 = "a";
            string value1 = "s";
            string value2 = "f";
            try
            {
                //获得当前行的第一列的值 
                //value1 =Row.Cells[1].Value.ToString();
                //获得当前行的第0列的值 
               // value0 = dgvHome.Rows[rowindex].Cells[0].Value.ToString();
                //获得当前行的第二列的值 
                //value2 = dgvHome.Rows[rowindex].Cells[2].Value.ToString().Trim();
                //MessageBox.Show("第0列的值：{0};第一列的值：{1};第二列的值:{2}", value0, value1, value2);
                MessageBox.Show("第0列的值：{0};第一列的值：{1};第二列的值:{2}","value0,value1,value2" );
            } 
            catch (Exception exc) { } 

 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //获得当前选中的行的索引 
            int rowindex = e.RowIndex;
            try
            {
                //获得当前行的第一列的值 
                String a = dataGridView1.Rows[rowindex].Cells[0].Value.ToString(); //获得当前行的第二列的值 
                // = dataGridView1.Rows[rowindex].Cells[1].Value.ToString(); //获得当前行的第三列的值 
                //txt_gtype.Text = dataGridView1.Rows[rowindex].Cells[2].Value.ToString(); //获得当前行的第四列的值 
               // txt_gamount.Text = dataGridView1.Rows[rowindex].Cells[3].Value.ToString(); //获得当前行的第五列的值 
               // txt_gmade.Text = dataGridView1.Rows[rowindex].Cells[4].Value.ToString();
                MessageBox.Show(a);
            }
            catch (Exception exc)
            { MessageBox.Show(exc.Message); }
        }*/

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            oracle.LinkToOracle("orcl", "hui", "oracle");
            OracleCommand cmd = oracle.getConnection().CreateCommand();
            cmd.CommandText = String.Format("select * from teacher");
            OracleDataAdapter sda = new OracleDataAdapter(cmd);
            DataTable query = new DataTable();
            sda.Fill(query);
            dataGridView1.DataSource = query;
            oracle.LinkClose();
            cmd.Dispose();
            if (this.radioButton2.Checked == true)
            {

            }
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            oracle.LinkToOracle("orcl", "hui", "oracle");
            OracleCommand cmd = oracle.getConnection().CreateCommand();
            cmd.CommandText = String.Format("select * from department");
            OracleDataAdapter sda = new OracleDataAdapter(cmd);
            DataTable query = new DataTable();
            sda.Fill(query);
            dataGridView1.DataSource = query;
            oracle.LinkClose();
            cmd.Dispose();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            oracle.LinkToOracle("orcl", "hui", "oracle");
            OracleCommand cmd = oracle.getConnection().CreateCommand();
            if (radioButton1.Checked)
            {
                OracleDataAdapter sda = new OracleDataAdapter("select * from department", oracle.getConnection());
                DataTable query = new DataTable();
                query = (DataTable)dataGridView1.DataSource;
                OracleCommandBuilder sb = new OracleCommandBuilder(sda);
                sda.Update(query);
                query.Clear();
                sda.Fill(query);
            }
            if (radioButton2.Checked)
            {
                OracleDataAdapter sda = new OracleDataAdapter("select * from teacher", oracle.getConnection());
                DataTable query = new DataTable();
                query = (DataTable)dataGridView1.DataSource;
                OracleCommandBuilder sb = new OracleCommandBuilder(sda);
                sda.Update(query);
                query.Clear();
                sda.Fill(query);
            }
            oracle.LinkClose();
            cmd.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {


            if (dataGridView1.DataSource == null || dataGridView1.CurrentRow == null)
            {
                return;
            }
            else
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    DialogResult dr = MessageBox.Show("确定删除选中的记录   ", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        try
                        {
                            oracle.LinkToOracle("orcl", "hui", "oracle");
                            OracleCommand cmd = oracle.getConnection().CreateCommand();
                            if (radioButton1.Checked)
                            {
                                foreach (DataGridViewRow row in this.dataGridView1.SelectedRows) //遍历所选中的dataGridView记录行
                                {

                                    string strName = row.Cells[1].Value.ToString();  //取dataGridView1中的第三列的值
                                    cmd.CommandText = string.Format("delete from department where tno='{0}'", strName); //SQL语句

                                    cmd.ExecuteNonQuery();  //执行删除操作
                                    cmd.CommandText = String.Format("select * from department");
                                    OracleDataAdapter sda = new OracleDataAdapter(cmd);
                                    DataTable query = new DataTable();
                                    sda.Update(query);
                                    query.Clear();
                                    sda.Fill(query);
                                    dataGridView1.DataSource = query;
                                    cmd.Dispose();
                                }
                            }
                            if (radioButton2.Checked)
                            {
                                foreach (DataGridViewRow row in this.dataGridView1.SelectedRows) //遍历所选中的dataGridView记录行
                                {

                                    string strName = row.Cells[0].Value.ToString();  //取dataGridView1中的第三列的值
                                    cmd.CommandText = string.Format("delete from teacher where tno='{0}'", strName); //SQL语句

                                    cmd.ExecuteNonQuery();  //执行删除操作
                                    cmd.CommandText = String.Format("select * from teacher");
                                    OracleDataAdapter sda = new OracleDataAdapter(cmd);
                                    DataTable query = new DataTable();
                                    sda.Update(query);
                                    query.Clear();
                                    sda.Fill(query);
                                    dataGridView1.DataSource = query;
                                    cmd.Dispose();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "提示");
                        }
                        finally
                        {
                            oracle.LinkClose();
                        }

                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.Clear();

            }
            oracle.LinkToOracle("orcl", "hui", "oracle");
            OracleCommand cmd = oracle.getConnection().CreateCommand();
            cmd.CommandText = String.Format("select sum(tsalary) from teacher");
            int sum = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.CommandText = String.Format("select max(tsalary) from teacher");
            int max = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.CommandText = String.Format("select min(tsalary) from teacher");
            int min = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.CommandText = String.Format("select avg(tsalary) from teacher");
            int avg = Convert.ToInt32(cmd.ExecuteScalar());
            
            //OracleDataAdapter sda = new OracleDataAdapter(cmd);
            //DataTable query = new DataTable();
            //sda.Fill(query);
            //listBox1.DataSource = query;
            //DataSet ds = new DataSet();
            //sda.Fill(ds);
            //listBox1.DataSource = ds;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows) //遍历所选中的dataGridView记录行
            {
                try
                {
                    string strName = row.Cells[0].Value.ToString();  //取dataGridView1中的第三列的值
                    cmd.CommandText = string.Format("select sum(workdays)from tm where tno='{0}'", strName); //SQL语句
                    int sumday = Convert.ToInt32(cmd.ExecuteScalar());
                    listBox1.Items.Add("项目工作的总天数：" + sumday);
                    listBox1.Items.Add(" ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("此教师无工作天数");
                }
                try
                {
                    string str = row.Cells[1].Value.ToString();
                    cmd.CommandText = string.Format("select sum(pfund)from myproject,teacher where myproject.tno=teacher.tno and teacher.dno='{0}'", str); //SQL语句
                    int sump = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.CommandText = string.Format("select dname from department where dno='{0}'", str);
                    String dname = Convert.ToString(cmd.ExecuteScalar());
                    listBox1.Items.Add(dname + "的项目总经费：" + sump);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("无此项目经费");
                }

            }
            listBox1.Items.Add(" ");
            listBox1.Items.Add("教师工资的总和：" + sum);
            listBox1.Items.Add(" ");
            listBox1.Items.Add("教师工资的平均值：" + avg);
            listBox1.Items.Add(" ");
            listBox1.Items.Add("教师工资的最大值：" + max);
            listBox1.Items.Add(" ");
            listBox1.Items.Add("教师工资的最小值：" + min);
            oracle.LinkClose();
            cmd.Dispose();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.Clear();

            }
            oracle.LinkToOracle("orcl", "hui", "oracle");
            OracleCommand cmd = oracle.getConnection().CreateCommand();
            String tname = textBox1.Text;

            cmd.CommandText = String.Format("select * from teacher where tname='{0}'", tname);
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            try
            {
                if (reader["tname"].ToString() == tname)
                {
                    listBox1.Items.Add("*******教师基本信息*******");
                    listBox1.Items.Add("教师姓名：" + tname);
                    listBox1.Items.Add(" ");
                    listBox1.Items.Add("教师编号：" + reader["tno"].ToString());
                    listBox1.Items.Add(" ");
                    listBox1.Items.Add("教师所在系（DNO）：" + reader["dno"].ToString());
                    listBox1.Items.Add(" ");
                    listBox1.Items.Add("教师性别：" + reader["tsex"].ToString());
                    listBox1.Items.Add(" ");
                    listBox1.Items.Add("教师工资：" + reader["tsalary"].ToString());
                    listBox1.Items.Add(" ");
                    listBox1.Items.Add("教师的生日：" + reader["tbirthday"].ToString());
                    listBox1.Items.Add(" ");
                    listBox1.Items.Add("教师登录密码：" + reader["pwd"].ToString());
                    listBox1.Items.Add(" ");
                    listBox1.Items.Add("********项目基本信息********");
                    cmd.CommandText = String.Format("select * from myproject,teacher where myproject.tno=teacher.tno and myproject.tno='{0}'", reader["tno"].ToString());
                    OracleDataReader reader1 = cmd.ExecuteReader();
                    //reader1.Read();
                    try
                    {
                        while (reader1.Read())
                        {

                            listBox1.Items.Add("此教师的编号：" + reader1["tno"].ToString());
                            listBox1.Items.Add("此教师负责的项目编号：" + reader1["PNO"].ToString());
                            listBox1.Items.Add("此教师负责的父项目编号：" + reader1["parentpno"].ToString());

                            listBox1.Items.Add("此教师负责的项目名：" + reader1["pname"].ToString());
                            listBox1.Items.Add("此教师负责的项目资金：" + reader1["pfund"].ToString());
                            listBox1.Items.Add("此教师负责的项目开始时间：" + reader1["pbegindate"].ToString());
                            listBox1.Items.Add("此教师负责的项目花费时间：" + reader1["ptimespan"].ToString() + "天");
                            listBox1.Items.Add(" ");
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("查询错误");
                    }
                    listBox1.Items.Add("**此教师参与的项目基本信息以及工作天数** ");
                    cmd.CommandText = String.Format("select * from tm,teacher where tm.tno=teacher.tno and tm.tno='{0}'", reader["tno"].ToString());
                    OracleDataReader reader2 = cmd.ExecuteReader();
                    try
                    {
                        while (reader2.Read())
                        {

                            listBox1.Items.Add("此教师的编号：" + reader2["tno"].ToString());
                            listBox1.Items.Add("此教师参与的项目编号：" + reader2["PNO"].ToString());
                            listBox1.Items.Add("此教师负责的项目工作天数：" + reader2["workdays"].ToString() + "天");
                            listBox1.Items.Add(" ");
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("查询错误");
                    }
                }


                //MessageBox.Show("密码错误");
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询错误");
            }

            oracle.LinkClose();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.Clear();

            }
            oracle.LinkToOracle("orcl", "hui", "oracle");
            OracleCommand cmd = oracle.getConnection().CreateCommand();
            String tno = textBox2.Text;

            cmd.CommandText = String.Format("select * from teacher where tno='{0}'", tno);
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            try
            {
                if (reader["tno"].ToString() == tno)
                {
                    listBox1.Items.Add("********教师基本信息******** ");
                    listBox1.Items.Add("教师姓名：" + reader["tname"].ToString());
                    listBox1.Items.Add(" ");
                    listBox1.Items.Add("教师编号：" + tno);
                    listBox1.Items.Add(" ");
                    listBox1.Items.Add("教师所在系（DNO）：" + reader["dno"].ToString());
                    listBox1.Items.Add(" ");
                    listBox1.Items.Add("教师性别：" + reader["tsex"].ToString());
                    listBox1.Items.Add(" ");
                    listBox1.Items.Add("教师工资：" + reader["tsalary"].ToString());
                    listBox1.Items.Add(" ");
                    listBox1.Items.Add("教师的生日：" + reader["tbirthday"].ToString());
                    listBox1.Items.Add(" ");
                    listBox1.Items.Add("教师登录密码：" + reader["pwd"].ToString());

                    listBox1.Items.Add(" ");
                    listBox1.Items.Add("*******项目基本信息*******");
                    cmd.CommandText = String.Format("select * from myproject,teacher where myproject.tno=teacher.tno and myproject.tno='{0}'", reader["tno"].ToString());
                    OracleDataReader reader1 = cmd.ExecuteReader();
                    //reader1.Read();
                    try
                    {
                        while (reader1.Read())
                        {

                            listBox1.Items.Add("此教师的编号：" + reader1["tno"].ToString());
                            listBox1.Items.Add("此教师负责的项目编号：" + reader1["PNO"].ToString());
                            listBox1.Items.Add("此教师负责的父项目编号：" + reader1["parentpno"].ToString());

                            listBox1.Items.Add("此教师负责的项目名：" + reader1["pname"].ToString());
                            listBox1.Items.Add("此教师负责的项目资金：" + reader1["pfund"].ToString());
                            listBox1.Items.Add("此教师负责的项目开始时间：" + reader1["pbegindate"].ToString());
                            listBox1.Items.Add("此教师负责的项目花费时间：" + reader1["ptimespan"].ToString() + "天");
                            listBox1.Items.Add(" ");
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("查询错误");
                    }
                    listBox1.Items.Add("**此教师参与的项目基本信息以及工作天数** ");
                    cmd.CommandText = String.Format("select * from tm,teacher where tm.tno=teacher.tno and tm.tno='{0}'", reader["tno"].ToString());
                    OracleDataReader reader2 = cmd.ExecuteReader();
                    try
                    {
                        while (reader2.Read())
                        {

                            listBox1.Items.Add("此教师的编号：" + reader2["tno"].ToString());
                            listBox1.Items.Add("此教师参与的项目编号：" + reader2["PNO"].ToString());
                            listBox1.Items.Add("此教师负责的项目工作天数：" + reader2["workdays"].ToString() + "天");
                            listBox1.Items.Add(" ");
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("查询错误");
                    }
                }

            }


                //MessageBox.Show("密码错误");


            catch (Exception ex)
            {
                MessageBox.Show("查询错误");
            }

            oracle.LinkClose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.Clear();

            }
            oracle.LinkToOracle("orcl", "hui", "oracle");
            OracleCommand cmd = oracle.getConnection().CreateCommand();
            String pname = textBox3.Text;
          
            cmd.CommandText = String.Format("select  * from tm,myproject where myproject.pno=tm.pno and myproject.pname='{0}'", pname);
            OracleDataReader reader = cmd.ExecuteReader();
            
            try
            {
                listBox1.Items.Add("**此项目的参与人员以及工作天数**");
               
                    while (reader.Read())
                    {

                        listBox1.Items.Add("此教师的编号：" + reader["tno"].ToString());
                        listBox1.Items.Add("此教师负责的项目编号：" + reader["PNO"].ToString());
                        
                        listBox1.Items.Add("此教师负责的项目工作时间时间：" + reader["workdays"].ToString() + "天");
                        listBox1.Items.Add(" ");
                    }
              

            }

            catch (Exception ex)
            {
                MessageBox.Show("查询错误");
            }

            oracle.LinkClose();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.Clear();

            }
           // try
           // {
            oracle.LinkToOracle("orcl", "hui", "oracle");
            OracleCommand cmd = oracle.getConnection().CreateCommand();
            String pno = textBox4.Text;
            
                cmd.CommandText = String.Format("select  * from tm,myproject where myproject.pno=tm.pno and myproject.pno='{0}'", pno);
                OracleDataReader reader = cmd.ExecuteReader();

               

                    while (reader.Read())
                    {

                        listBox1.Items.Add("此教师的编号：" + reader["tno"].ToString());
                        listBox1.Items.Add("此教师负责的项目编号：" + reader["PNO"].ToString());

                        listBox1.Items.Add("此教师负责的项目工作时间时间：" + reader["workdays"].ToString() + "天");
                        listBox1.Items.Add(" ");
                    }


             //   }

               // catch (Exception ex)
            //    {
              //      MessageBox.Show("查询错误");
               // }
             oracle.LinkClose();
            
           
          

        }

     
    }
}
