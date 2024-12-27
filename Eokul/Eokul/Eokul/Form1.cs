using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace Eokul
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection yeni = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\user\\Desktop\\10-M\\Eokul\\Öğrenci Kayıt.mdb");
        public void görüntüle() 
        {
            yeni.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From OgrenciKayit", yeni);
            DataTable dt = new DataTable();
            adtr.Fill(dt);
            dataGridView1.DataSource = dt;
            yeni.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            görüntüle();
            MessageBox.Show("Liste Görüntülendi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yeni.Open();
            string cinsiyet;
            if (radioButton1.Checked)
            {
                cinsiyet = "erkek";
            }
            else 
            {
                cinsiyet = "kız";
            }
            OleDbCommand komut = new OleDbCommand("Insert into OgrenciKayit(OgrenciNo,OgrenciAdSoyad,OgrenciAlan,OgrenciCinsiyet) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + cinsiyet + "')", yeni);
            komut.ExecuteNonQuery();
            yeni.Close();
            görüntüle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            yeni.Open();
            OleDbCommand komut = new OleDbCommand("Delete From OgrenciKayit Where OgrenciAdSoyad ='" + textBox2.Text + "'", yeni);
            komut.ExecuteNonQuery();
            yeni.Close();
            görüntüle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            yeni.Open();
            string cinsiyet;
            if (radioButton1.Checked)
            {
                cinsiyet = "erkek";
            }
            else
            {
                cinsiyet = "kız";
            }
            OleDbCommand komut = new OleDbCommand("Update OgrenciKayit Set OgrenciAdSoyad='" + textBox2.Text + "',OgrenciAlan='" + comboBox1.Text + "' Where OgrenciNo='"+textBox1.Text+"'", yeni);
            komut.ExecuteNonQuery();
            yeni.Close();
            görüntüle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
