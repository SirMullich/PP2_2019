using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Week11
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
            dataSource = "Data Source = databases/northwindEF.db";
            conn = new SQLiteConnection(dataSource);

            dataTable = new DataTable();      
        }

        private void loadDataButton_Click(object sender, EventArgs e)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM Customers", conn);

            // fill data to Datatable
            da.Fill(dataTable);

            // use data from DataTable in GridView
            bindingSource1.DataSource = dataTable;

            dataGridView1.DataSource = bindingSource1;
        }
    }
}
