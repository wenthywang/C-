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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            oracle.LinkToOracle("orcl", "test", "test");
            OracleCommand cmd = oracle.getConnection().CreateCommand();
            cmd.CommandText = "select * from teacher";
            DataTable datatable = new DataTable();
            DataTable datatable1 = new DataTable();
            datatable.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = datatable;
            cmd.CommandText = "select * from myproject";
            datatable1.Load(cmd.ExecuteReader());
            dataGridView2.DataSource = datatable1;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            oracle.LinkClose();
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            OracleCommand cmd = oracle.getConnection().CreateCommand();
            cmd.CommandText = "select * from teacher";
            DataTable datatable = new DataTable();
            DataTable datatable1 = new DataTable();
            datatable.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = datatable;
            cmd.CommandText = "select * from myproject";
            datatable1.Load(cmd.ExecuteReader());
            dataGridView2.DataSource = datatable1;
        }
    }
}
