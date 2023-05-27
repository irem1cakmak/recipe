using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace PORTALTARİF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-HCVINC4P\\SQLEXPRESS;Initial Catalog=tarifPortalı;Integrated Security=True");
        SqlCommand komut = new SqlCommand();
        
        

        public object DateTimePicker2 { get; private set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tarifPortalıDataSet23.tarifler' table. You can move, or remove it, as needed.
            this.tariflerTableAdapter.Fill(this.tarifPortalıDataSet23.tarifler);


        }

        private void button1_Click(object sender, EventArgs e)

        {
            komut.CommandType = CommandType.StoredProcedure;

            komut.CommandText = "tarifler";
            //veri çekmek için ekledim.
            this.tariflerTableAdapter.Fill(this.tarifPortalıDataSet23.tarifler);
            
    }

        private void button2_Click(object sender, EventArgs e)
        {
            //Nesnesine ait komut nesnesi tanımladık.
            //kaydetmesi için
            //yukarıda kullandığım baglanti nesnemi kullanıyorum.
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "trfgrs";
            
            baglanti.Open();
            
           komut.Parameters.AddWithValue("@p1",textBox1.Text);
            komut.Parameters.AddWithValue("@p2",textBox2.Text);
            komut.Parameters.AddWithValue("@p3", textBox3.Text);
           komut.Parameters.AddWithValue("@p4", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p5", maskedTextBox2.Text);
            komut.Parameters.AddWithValue("@p6", textBox4.Text);
            komut.Parameters.AddWithValue("@p7", textBox5.Text.ToString());
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Tarif Eklendi");


        }

        private void button3_Click(object sender, EventArgs e)
        {
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "sil";
          
            baglanti.Open();
            
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Tarif Kayıt Sil.");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "Guncelle";
          
            baglanti.Open();
            
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            komut.Parameters.AddWithValue("@p3", textBox3.Text);
            komut.Parameters.AddWithValue("@p4", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p5",maskedTextBox2.Text);
           komut.Parameters.AddWithValue("@p6", textBox4.Text);
           komut.Parameters.AddWithValue("@p7", textBox5.Text.ToString());
          komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Tarif Kayıt Guncelle.");


        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            maskedTextBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString(); 
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
        }
    }
}
