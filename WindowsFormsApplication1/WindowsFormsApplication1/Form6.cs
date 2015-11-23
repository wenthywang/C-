using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
namespace WindowsFormsApplication1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        public Form6(string text)
            :this()
        {
            textBox12.Text = text;
            textBox1.Text = text;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = oracle.getConnection().CreateCommand();
            cmd.CommandText = "insert into myproject(pno, parentpno, tno, pname, pfund,pbegindate,ptimespan) values( '" + textBox14.Text + "',  " + textBox13.Text + ",  '" + textBox12.Text + "','" + textBox11.Text + "', " + textBox10.Text + ",To_date('" + textBox9.Text + "', 'DD-mon-yyyy')," + textBox8.Text + ")";
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("添加成功");
                }
                catch (Exception ee)
                {
                    MessageBox.Show("出现错误", ee.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = oracle.getConnection().CreateCommand();
            cmd.CommandText = "update  myproject set parentpno=( '" + textBox13.Text + "'),pbegindate=( To_date('" + textBox9.Text + "', 'DD-mon-yyyy')),pfund=( " + textBox10.Text + "),ptimespan=('" + textBox8.Text + "'),pname=('" + textBox11.Text + "') where tno=('" + textBox12.Text + "')and pno=('" + textBox14.Text + "'),";
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("修改成功");
                }
                catch (Exception ee)
                {
                    MessageBox.Show("出现错误", ee.Message);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = oracle.getConnection().CreateCommand();
            cmd.CommandText = "delete from myproject where pno=('" + textBox14.Text + "') ";
            cmd.ExecuteNonQuery();
            MessageBox.Show("删除成功");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = oracle.getConnection().CreateCommand();
            cmd.CommandText = "insert into tm(tno,pno,workdays) values( '" + textBox1.Text + "',  " + textBox2.Text + ",  '" + textBox3.Text + "')";
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("添加成功");
                }
                catch (Exception ee)
                {
                    MessageBox.Show("出现错误", ee.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = oracle.getConnection().CreateCommand();
            cmd.CommandText = "update  tm set pno=( '" + textBox2.Text + "'),workdats=('" + textBox3.Text + "') where tno=('" + textBox1.Text + "')";
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("修改成功");
                }
                catch (Exception ee)
                {
                    MessageBox.Show("出现错误", ee.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = oracle.getConnection().CreateCommand();
            cmd.CommandText = "delete from myproject where pno=('" + textBox2.Text + "') ";
            cmd.ExecuteNonQuery();
            MessageBox.Show("删除成功");
        }
    }
}
