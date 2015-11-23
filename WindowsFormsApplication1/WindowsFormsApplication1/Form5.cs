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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        public Form5(string text)
            :this()
        {
            textBox1.Text = text ;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            oracle.LinkToOracle("orcl", "test", "test");
            OracleCommand cmd = oracle.getConnection().CreateCommand();
            cmd.CommandText = "select * from myproject where tno='"+textBox1.Text+"'";
            DataTable datatable = new DataTable();
            DataTable datatable1 = new DataTable();
            datatable.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = datatable;
            cmd.CommandText = "select * from tm where  tno='" + textBox1.Text + "'";
            datatable1.Load(cmd.ExecuteReader());
            dataGridView2.DataSource = datatable1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6(textBox1.Text);
            form6.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            oracle.LinkClose();
            Application.Exit();
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            oracle.LinkClose();
            Application.Exit();
        }
    }
}
