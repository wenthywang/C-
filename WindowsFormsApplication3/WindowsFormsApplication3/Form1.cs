using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;
namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oracle.LinkToOracle("orcl","hui","oracle");
            OracleCommand cmd = oracle.getConnection().CreateCommand();
            String tno = textBox1.Text;
            String pwd = textBox2.Text;
            if (tno == "hui" & pwd == "123")
            {
                MessageBox.Show("登录成功");

                Form4 form4 = new Form4();
                this.Hide();
                form4.Show();
                return;
            }
            cmd.CommandText = String.Format("select * from teacher where tno='{0}'", tno);
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            try
            {
                if (reader["pwd"].ToString() == pwd)
                {
                    MessageBox.Show("登录成功");

                    Form3 form3 = new Form3();
                    this.Hide();
                    form3.Show();
                    return;
                }
                if (tno == "hui" & pwd == "123")
                {
                    MessageBox.Show("登录成功");

                    Form4 form4 = new Form4();
                    this.Hide();
                    form4.Show();
                    return;
                }

                //MessageBox.Show("密码错误");
            }
            catch (Exception ex)
            {
                MessageBox.Show("登录帐号或密码错误");
            }
                
            oracle.LinkClose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       
    }
}
