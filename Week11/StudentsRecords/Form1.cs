using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StudentsRecords
{
    public partial class Form1 : Form
    {
        // connection string
        private SQLiteConnection conn;
        // DataBase location
        private string dataSource;
        private BindingSource bindingSource1 = new BindingSource();

        // corresponds to table in DataBase
        DataTable dataTable;

        public Form1()
        {
            InitializeComponent();
            dataSource = "Data Source = databases/students.db";
            conn = new SQLiteConnection(dataSource);

            dataTable = new DataTable();

            dataGridView1.DataSource = bindingSource1;
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM Students", conn);

            // clear table for multiple LOAD use
            dataTable.Clear();
            // fill data to Datatable
            da.Fill(dataTable);

            // use data from DataTable in GridView
            bindingSource1.DataSource = dataTable;
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            Form studentForm = new CreateStudentForm(conn);
            studentForm.Show();
        }
    }
}
