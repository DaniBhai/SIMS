using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaveInfo
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactData"].ConnectionString);
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string Query = "INSERT INTO ContactInfo(FirstName,LastName,PhoneNo,Email,Catagory,DateTime) VALUES (@FirstName,@LastName,@PhoneNo,@Email,@Catagory,@DateTime)";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@Firstname", textBox1.Text);
            cmd.Parameters.AddWithValue("@LastName", textBox2.Text);
            cmd.Parameters.AddWithValue("@PhoneNo", textBox3.Text);
            cmd.Parameters.AddWithValue("@Email", textBox4.Text);
            cmd.Parameters.AddWithValue("@Catagory", comboBox1.Text);
            cmd.Parameters.AddWithValue("@DateTime", dtp.Value);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            refresh();
            Display();
            MessageBox.Show("Data Has Been Inserted Successfully");
         

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("DELETE FROM ContactInfo WHERE PhoneNo=@PhoneNo", con);
            cmd.Parameters.AddWithValue("@PhoneNo", textBox3.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            refresh();
            MessageBox.Show("Data Has Been Deleted Successfully");

        }

        // Changed COmment dfg fgf ff gfgf  t
        // this is second commit
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string Query = "UPDATE ContactInfo set FirstName=@FirstName,LastName=@LastName,Email=@Email,Catagory=@Catagory,DateTime=@DateTime  WHERE PhoneNo=@PhoneNo";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@Firstname", textBox1.Text);
            cmd.Parameters.AddWithValue("@LastName", textBox2.Text);
            cmd.Parameters.AddWithValue("@PhoneNo", textBox3.Text);
            cmd.Parameters.AddWithValue("@Email", textBox4.Text);
            cmd.Parameters.AddWithValue("@Catagory", comboBox1.Text);
            cmd.Parameters.AddWithValue("@DateTime", dtp.Value);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            refresh();
            MessageBox.Show("Data Has Been Updated Successfully");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void refresh()
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox3.Text = "";
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
            textBox1.Focus();

        }

        public void Display()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select *  FROM [ContactData].[dbo].[ContactInfo] ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["PhoneNo"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item[5].ToString();

            }


        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text= dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            dtp.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

      
    }
}

