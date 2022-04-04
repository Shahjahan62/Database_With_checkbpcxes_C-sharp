using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Database_RadioButton_CRUD
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;

        string db = @"Data Source=DESKTOP-T2H5N7O;Initial Catalog=students;Integrated Security=true";

        DataTable data = new DataTable();
        public Form1()
        {
            InitializeComponent();
            data.Columns.Add("Name");
            data.Columns.Add("RollNo");
            data.Columns.Add("CNIC");
            data.Columns.Add("Gender");
            data.Columns.Add("Skills");

            dataGridView1.DataSource = data;

            read_database();

        }

        private void read_database()
        {
            string sql_connect = @"Data Source=DESKTOP-T2H5N7O;Initial Catalog=students;Integrated Security=true";
            connection = new SqlConnection(sql_connect);
            string sql = $"select *from std_table full join skills on Roll_No=textBox2";
            command = new SqlCommand(sql, connection);
            SqlDataReader dataReader;
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                DataRow row = this.data.NewRow();
                row["Name"] = dataReader.GetValue(0);
                row["RollNo"] = dataReader.GetValue(1);
                row["CNIC"] = dataReader.GetValue(2);
                row["Gender"] = dataReader.GetValue(3);
                row["Skills"] = dataReader.GetValue(4);

                this.data.Rows.Add(row);


            }
            dataGridView1.Refresh();
            connection.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void write_database()
        {
            string name = textBox1.Text;
            string roll = textBox2.Text;
            string cnic = textBox3.Text;

            string gender;
            if (radioButton1.Checked==true)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }

            string skills = "";

            if (checkBox1.Checked)
            {
                skills = checkBox1.Text;
            }
            if (checkBox2.Checked)
            {
                skills = skills + " " + checkBox2.Text;
            }
            if (checkBox3.Checked)
            {
                skills = skills + " " + checkBox3.Text;
            }




        }
    }
}
