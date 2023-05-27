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
using System.Data;


namespace PORTALTARİF
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-HCVINC4P\\SQLEXPRESS;Initial Catalog=tarifPortalı;Integrated Security=True");
        SqlCommand komut = new SqlCommand();

             
        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tarifPortalıDataSet24.içindekiler' table. You can move, or remove it, as needed.
            this.içindekilerTableAdapter.Fill(this.tarifPortalıDataSet24.içindekiler);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.içindekilerTableAdapter.Fill(this.tarifPortalıDataSet24.içindekiler);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "kaydet";

            baglanti.Open();

            komut.Parameters.AddWithValue("@a1", textBox1.Text);
            komut.Parameters.AddWithValue("@a2", textBox2.Text);
            komut.Parameters.AddWithValue("@a3", textBox3.Text);
             komut.Parameters.AddWithValue("@p1", textBox4.Text);
            komut.Parameters.AddWithValue("@a5", textBox5.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İçindekiler  Eklendi");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "ıçındekınısıl";

            baglanti.Open();

            komut.Parameters.AddWithValue("@a1", textBox1.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İçindekiler Silindi.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "ıçındekiniguncelle";

            baglanti.Open();

            komut.Parameters.AddWithValue("@a1", textBox1.Text);
            komut.Parameters.AddWithValue("@a2", textBox2.Text);
            komut.Parameters.AddWithValue("@a3", textBox3.Text);
            komut.Parameters.AddWithValue("@p1", textBox4.Text);
            komut.Parameters.AddWithValue("@a5", textBox5.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("içindekini  Guncelle.");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
