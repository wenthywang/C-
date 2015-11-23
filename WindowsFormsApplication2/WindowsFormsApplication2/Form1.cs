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
namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oracle.LinkToOracle("orcl", "cco", "oracle");
            OracleCommand hui = oracle.getConnection().CreateCommand();
            String tno = textBox1.Text;
            String pwd = textBox2.Text;
            hui.CommandText = String.Format("select * from teacher where tno='{0}'", tno);
            
           OracleDataReader reader = hui.ExecuteReader();
            

            reader.Read();
            if (reader["pwd"].ToString() == pwd)
            {
                MessageBox.Show("登录成功");
                oracle.LinkClose();
                this.Hide();
                Form2 form2 = new Form2();
                form2.Show();
                return;
            }
            MessageBox.Show("帐号或密码有误");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}