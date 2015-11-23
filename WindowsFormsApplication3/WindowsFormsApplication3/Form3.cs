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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            oracle.LinkToOracle("orcl", "hui", "oracle");
            OracleCommand cmd = oracle.getConnection().CreateCommand();
            cmd.CommandText = String.Format("select * from tm");
            OracleDataAdapter sda = new OracleDataAdapter(cmd);
            DataTable query = new DataTable();
            sda.Fill(query);
            dataGridView1.DataSource = query;
            oracle.LinkClose();
            cmd.Dispose();
        }
       /* private void button1_Click(object sender, EventArgs e)
        {  //string Afieldname = "tno";//得到列的名字
            //listBox1.Items.Clear();
            oracle.LinkToOracle("orcl", "hui", "oracle");
            OracleCommand cmd = oracle.getConnection().CreateCommand();
            cmd.CommandText = String.Format("select * from tm");
            OracleDataAdapter sda =new  OracleDataAdapter(cmd);
            DataTable query = new DataTable();
            sda.Fill(query);
            dataGridView1.DataSource = query;
            oracle.LinkClose();
            cmd.Dispose();
            
            
        }/*

       /* private void button2_Click(object sender, EventArgs e)
        {
            oracle.LinkToOracle("orcl", "hui", "oracle");
            OracleCommand cmd = oracle.getConnection().CreateCommand();
            String pno = textBox1.Text;
            String parentpno = textBox2.Text;
            String tno = textBox3.Text;
            String pname = textBox4.Text ;
            String  pfund = textBox5.Text;
            String pbegindate = textBox6.Text;
            String ptimespan = textBox7.Text;
            cmd.CommandText = String.Format("insert into myproject (pno,parentpno,tno,pname,pfund,pbegindate,ptimespan)values(:pno,:parentpno,:tno,:pname,:pfund,:pbegindate,:ptimespan)");
            cmd.CommandType = CommandType.Text;
                   cmd.Parameters.AddWithValue("pno", pno);
                cmd.Parameters.AddWithValue("parentpno", parentpno);
                cmd.Parameters.AddWithValue("tno", tno);
                cmd.Parameters.AddWithValue("pname", pname);
                cmd.Parameters.AddWithValue("pfund", pfund);
                cmd.Parameters.AddWithValue("pbegindate", pbegindate);
                cmd.Parameters.AddWithValue("ptimespan", ptimespan);
                cmd.ExecuteNonQuery();
               
                
            oracle.LinkClose();
            cmd.Dispose();
   

        }*/

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
                          
                            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows) //遍历所选中的dataGridView记录行
                            {
                                
                                string strName = row.Cells[0].Value.ToString();  //取dataGridView1中的第三列的值
                                cmd.CommandText = string.Format("delete from tm where tno='{0}'", strName); //SQL语句
                               
                                cmd.ExecuteNonQuery();  //执行删除操作
                                cmd.CommandText = String.Format("select * from tm");
                                OracleDataAdapter sda = new OracleDataAdapter(cmd);
                                DataTable query = new DataTable();
                                sda.Update(query);
                                query.Clear();
                                sda.Fill(query);
                                dataGridView1.DataSource = query;
                                cmd.Dispose();
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
            oracle.LinkToOracle("orcl", "hui", "oracle");
            OracleCommand cmd = oracle.getConnection().CreateCommand();

            OracleDataAdapter sda = new OracleDataAdapter("select * from tm",oracle.getConnection ());
            DataTable query = new DataTable();
            query =(DataTable )dataGridView1 .DataSource ;
          OracleCommandBuilder sb=new OracleCommandBuilder (sda);
            sda.Update (query );
            query.Clear();
            sda.Fill(query);
            oracle.LinkClose();
            cmd.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
