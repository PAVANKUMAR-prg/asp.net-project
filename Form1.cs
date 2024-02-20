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

namespace StudentDataProject
{
    public partial class Form1 : Form
    {
      
        DataTable table = new DataTable("table");
        int index;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*table.Columns.Add("Sl_no", Type.GetType("System.Int32"));
            table.Columns.Add("USN", Type.GetType("System.String"));
            table.Columns.Add("Name",Type.GetType("System.String"));
            table.Columns.Add("Address", Type.GetType("System.String"));
            table.Columns.Add("DOB", Type.GetType("System.String"));
            //dataGridView1.CurrentCell.Value = dtp.Text.ToString();
            table.Columns.Add("Gender", Type.GetType("System.String"));
            table.Columns.Add("Course", Type.GetType("System.String"));*/


            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           try
            {
                String radio = radioButton();
                //table.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text,richTextBox1.Text,dateTimePicker1.Text,radio,comboBox1.Text);
                String catalog = @"Data Source=PAVANAKUMARA\SQLEXPRESS;Initial Catalog=ICCADVG;Integrated Security=True";
                                    
                SqlConnection connection = new SqlConnection(catalog);
                connection.Open();
                String query = "Insert into StudentData values(" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + richTextBox1.Text + "','" + dateTimePicker1.Text + "','" + radio + "','" + comboBox1.Text + "')";
                SqlCommand command = new SqlCommand(query, connection);
                int result = command.ExecuteNonQuery();

                bindData();
                if (result == 1)
                {
                    MessageBox.Show("Data submitted successfully 👍😍🤩😁😘");
                }
                else
                {
                    MessageBox.Show("Data not submitted 👎😒🥲");
                }
           }
            

            catch(Exception )
            {
                
               MessageBox.Show("Enter data to 'Submit' and that data need to be right type!");

            }
          
               
            finally
            {

            }

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            richTextBox1.Text = String.Empty;
            dateTimePicker1.Text = String.Empty;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            comboBox1.Text = String.Empty;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[index];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            richTextBox1.Text = row.Cells[3].Value.ToString();
            dateTimePicker1.Text = row.Cells[4].Value.ToString();
            String h = row.Cells[5].Value.ToString();
            if (h == "MALE")
            {
                radioButton1.Checked =  true;
            }
            else if (h == "FEMALE")
            {
                radioButton2.Checked = true;
            }
            else
            {
                radioButton3.Checked = true;
                
            }
            comboBox1.Text = row.Cells[6].Value.ToString();

        }
        public String radioButton()
        {
            if (radioButton1.Checked)
            {
                return "MALE";
            }
            else if (radioButton2.Checked)
            {
                return "FEMALE";
            }
            else
            {
                return "OTHERS";
                
            }
               
        }
        public void bindData()
        {
            String catalog = @"Data Source=PAVANAKUMARA\SQLEXPRESS;Initial Catalog=ICCADVG;Integrated Security=True";
            SqlConnection connection = new SqlConnection(catalog);
            connection.Open();
            string query = "SELECT Sl_no,USN,Name,Address,DOB,Gender,Course from StudentData";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable tb = new DataTable();
            SqlDataAdapter sqlAdp = new SqlDataAdapter(command);
            sqlAdp.Fill(tb);
            dataGridView1.DataSource = tb;
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            bindData();
        }

      

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                String bb = radioButton();
                String catalog = @"Data Source=PAVANAKUMARA\SQLEXPRESS;Initial Catalog=ICCADVG;Integrated Security=True";
                SqlConnection connection = new SqlConnection(catalog);
                connection.Open();
                String query = "UPDATE StudentData set Name ='" + textBox3.Text + "' ,USN ='" + textBox2.Text + "',Address ='" + richTextBox1.Text + "',DOB ='" + dateTimePicker1.Text + "',Gender = '" + bb + "',Course = '" + comboBox1.Text + "' where Sl_no = " + textBox1.Text + "";
                SqlCommand command = new SqlCommand(query, connection);
                int result = command.ExecuteNonQuery();
                bindData();
                if (result == 1)
                {
                    MessageBox.Show("Data updated successfully 👍😍🤩😁😘");
                }
                else
                {
                    MessageBox.Show("Data not updated  👎😒🥲");

                }
            }

            catch
            {
                MessageBox.Show("Need to have data to update");
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                String catalog = @"Data Source=PAVANAKUMARA\SQLEXPRESS;Initial Catalog=ICCADVG;Integrated Security=True";
                SqlConnection connection = new SqlConnection(catalog);
                connection.Open();
                String query = "delete from studentdata where Sl_no=" + textBox1.Text + "";
                SqlCommand command = new SqlCommand(query, connection);
                int result = command.ExecuteNonQuery();
                textBox1.Text = String.Empty;
                textBox2.Text = String.Empty;
                textBox3.Text = String.Empty;
                richTextBox1.Text = String.Empty;
                dateTimePicker1.Text = String.Empty;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                comboBox1.Text = String.Empty;
                bindData();
                if (result == 1)
                {
                    MessageBox.Show("Data deleted successfull 👍😍🤩😁😘");
                }
                else
                {
                    MessageBox.Show("Data not deleted 👎😒🥲");
                }

            }
            catch
            {
                MessageBox.Show("Before clicking 'Delete' button you need to have data in data fields !");
            }

            
        }

       

       
    }
}
