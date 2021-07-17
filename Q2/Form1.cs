using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q2
{
    public partial class Form1 : Form
    {
        OpenFileDialog openFileDialog;
        List<Employee> employees = new List<Employee>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files(*.txt)|*.txt";
            openFileDialog.InitialDirectory = "D:\\";
            openFileDialog.Multiselect = false;
            try
            {
                openFileDialog.ShowDialog();
                textBox1.Text = openFileDialog.FileName;
           
                using (var streamReader = new StreamReader(textBox1.Text))
                {
                    
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        string[] data = line.Split('|');
                        bool male = data[1].Equals("Male");
                        employees.Add(new Employee(data[0], male, Convert.ToInt32(data[2]), data[3]));
                    }
                    dataGridView1.DataSource = employees;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Employee es in employees)
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbContext"].ConnectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Employee VALUES(@Name, @Male,@Salary, @Phone)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("Name", es.EmpoyeeName);
                        command.Parameters.AddWithValue("Male", es.Male);
                        command.Parameters.AddWithValue("Salary",es.Salary);
                        command.Parameters.AddWithValue("Phone", es.Moblie);
                        command.ExecuteNonQuery();
                       
                    }
                }
            }
        }
    }
}
