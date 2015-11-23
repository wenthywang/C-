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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            OracleCommand cmd = oracle.getConnection().CreateCommand();
            cmd.CommandText = "select tno,sum(workdays) from tm group by tno";
            cmd.ExecuteNonQuery();
            DataTable datatable = new DataTable();
            DataTable datatable1 = new DataTable();
            datatable.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = datatable;
            cmd.CommandText = "select dno,sum(pfund) from teacher,myproject  where teacher.tno=myproject.tno group by dno";
            cmd.ExecuteNonQuery();
            datatable1.Load(cmd.ExecuteReader());
            dataGridView2.DataSource = datatable1;
            cmd.CommandText = "select sum(tsalary),round(avg(tsalary),5),max(tsalary),min(tsalary) from teacher";
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            textBox8.Text = reader["sum(tsalary)"].ToString();
            textBox9.Text = reader["round(avg(tsalary),5)"].ToString();
            textBox10.Text = reader["max(tsalary)"].ToString();
            textBox11.Text = reader["min(tsalary)"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4_Load(sender,  e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
