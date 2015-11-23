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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(string a)
        {
            a = this.textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oracle.LinkToOracle("orcl", "test", "test");//连接数据库
            OracleCommand cmd = oracle.getConnection().CreateCommand();
            String tno = textBox1.Text;
            String pwd = textBox2.Text;
            if (radioButton1.Checked == true)
            {
                cmd.CommandText = String.Format("select * from teacher where tno='{0}'", tno);//从数据库中选出行
                OracleDataReader reader = cmd.ExecuteReader();//把数据赋给reader
                reader.Read();
                if (reader.HasRows)
                    if (reader["pwd"].ToString() == pwd)
                    {
                        MessageBox.Show("登录成功");
                        oracle.LinkClose();
                        Form5 form5 = new Form5(textBox1.Text);
                        this.Hide();
                        form5.Show();
                        //return;
                    }
                    else
                    {
                        MessageBox.Show("用户名不存在或者密码错误");
                        oracle.LinkClose();
                    }
            }
            else{
                cmd.CommandText = String.Format("select * from teacher where tno='{0}'", "m123");//从数据库中选出行
                OracleDataReader reader = cmd.ExecuteReader();//把数据赋给reader
                reader.Read();
                if (reader.HasRows)
                    if (reader["pwd"].ToString() == pwd)
                    {
                        MessageBox.Show("登录成功");
                        oracle.LinkClose();
                        Form2 form2 = new Form2();
                        this.Hide();
                        form2.Show();
                        //return;
                    }
                    else
                    {
                        MessageBox.Show("用户名不存在或者密码错误");
                        oracle.LinkClose();
                    }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }
    }
}
