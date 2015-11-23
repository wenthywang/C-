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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            oracle.LinkToOracle("orcl", "test", "test");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = oracle.getConnection().CreateCommand();
            cmd.CommandText = "insert into teacher(tno, dno, tname, tsex, tbirthday,tsalary,pwd) values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', ' " + textBox4.Text + "', To_date('" + textBox6.Text + "', 'DD-mon-yyyy'), " + textBox5.Text + ",'" + textBox7.Text + "')";
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("添加成功！");
                }
                catch (Exception ee) {
                    MessageBox.Show("出现错误", ee.Message);
                }
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = oracle.getConnection().CreateCommand();
            cmd.CommandText = "update  teacher set tname=( '" + textBox3.Text + "'),tsex=( '" + textBox4.Text + "'),tsalary=(" + textBox5.Text + "),tbirthday=( To_date('" + textBox6.Text + "', 'DD-mon-yyyy')),dno=( '" + textBox2.Text + "'),pwd=('" + textBox7.Text + "') where tno=('" + textBox1.Text + "')";
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("修改成功！");
                }
                catch(Exception  ee){
                MessageBox.Show("出现错误",ee.Message);
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = oracle.getConnection().CreateCommand();
            String tno = textBox1.Text;
            cmd.CommandText = String.Format("select * from teacher where tno='{0}'", tno);//从数据库中选出行
            {
                try
                {
                    OracleDataReader reader = cmd.ExecuteReader();//把数据赋给reader
                    reader.Read();
                    textBox2.Text = reader["dno"].ToString();
                    textBox3.Text = reader["tname"].ToString();
                    textBox4.Text = reader["tsex"].ToString();
                    textBox5.Text = reader["tsalary"].ToString();
                    textBox6.Text = reader["tbirthday"].ToString();
                    textBox7.Text = reader["pwd"].ToString();
                }
                catch (Exception ee) {
                    MessageBox.Show("出现错误",ee.Message);
                }
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = oracle.getConnection().CreateCommand();
            cmd.CommandText = "delete from teacher where tno=('" + textBox1.Text + "') ";
            cmd.ExecuteNonQuery();
            MessageBox.Show("删除成功！");
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
                catch (Exception ee) {
                    MessageBox.Show("出现错误",ee.Message);
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = oracle.getConnection().CreateCommand();
            cmd.CommandText = "update  myproject set parentpno=( '" + textBox13.Text + "'),tno=('" + textBox12.Text + "'),pbegindate=( To_date('" + textBox9.Text + "', 'DD-mon-yyyy')),pfund=( " + textBox10.Text + "),ptimespan=('" + textBox8.Text + "'),pname=('" + textBox11.Text + "') where pno=('" + textBox14.Text + "')";
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("修改成功");
                }
                catch (Exception ee) {
                    MessageBox.Show("出现错误",ee.Message );
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
            OracleCommand cmd = oracle.getConnection().CreateCommand();
            String pno = textBox14.Text;
            cmd.CommandText = String.Format("select * from myproject where pno='{0}'", pno);//从数据库中选出行
            {
                try
                {
                    OracleDataReader reader = cmd.ExecuteReader();//把数据赋给reader
                    reader.Read();
                    textBox13.Text = reader["parentpno"].ToString();
                    textBox12.Text = reader["tno"].ToString();
                    textBox11.Text = reader["pname"].ToString();
                    textBox10.Text = reader["pfund"].ToString();
                    textBox9.Text = reader["pbegindate"].ToString();
                    textBox8.Text = reader["ptimespan"].ToString();
                }
                catch (Exception ee) {
                    MessageBox.Show("出现错误",ee.Message);
                }
            }
        }
    }
}
