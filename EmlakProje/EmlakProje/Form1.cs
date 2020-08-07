using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmlakProje
{
    public partial class Form1 : Form
    {
        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        private String sql = null;
        public Form1()
        {
            InitializeComponent();
            conn = new NpgsqlConnection("Server = localhost; Port = 5432;Database=EmlakProje; User Id=postgres;Password=1234");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                MessageBox.Show("Caps Lock açık dikkat ediniz!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="" || textBox2.Text=="")
            {
                MessageBox.Show("KULLANICI ADI VEYA PAROLA BOŞ GEÇİLEMEZ");
            }else
            {
                try
                {
                    conn.Open();
                    sql = @"select * from emlakci_login(:_username,:_password)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("_username", textBox1.Text);
                    cmd.Parameters.AddWithValue("_password", textBox2.Text);
                    int result = (int)cmd.ExecuteScalar();
                    if (result == 1)
                    {
                        MessageBox.Show("Emlakçı girişi başarılı");
                        string sql = "SELECT id FROM users WHERE username='" + textBox1.Text + "' and passwords='"+textBox2.Text+"'";
                        using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
                        {
                            int val;
                            NpgsqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                val = Int32.Parse(reader[0].ToString());
                                //do whatever you like
                                this.Hide();                               
                                    new frmEmlakci(val).Show();                              
                               
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı Adı veya Parola hatalı girilmiştir.", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    // something went wrong, and you wanna know why
                    MessageBox.Show("Error:" + ex.ToString(), "something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            panel3.Visible = false;
            panel2.Visible = true;            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            panel2.Visible = false;
            panel3.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("KULLANICI ADI VEYA PAROLA BOŞ GEÇİLEMEZ");
            }
            else
            {
                try
                {
                    conn.Open();
                    sql = @"select * from musteri_login(:_username,:_password)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("_username", textBox3.Text);
                    cmd.Parameters.AddWithValue("_password", textBox4.Text);
                    int result = (int)cmd.ExecuteScalar();
                    if (result == 1)
                    {
                        MessageBox.Show("Müşteri girişi başarılı");
                        string sql = "SELECT id FROM users WHERE username='" + textBox3.Text + "' and passwords='" + textBox4.Text + "'";
                        using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
                        {
                            int val;
                            NpgsqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                val = Int32.Parse(reader[0].ToString());
                                //do whatever you like
                                this.Hide();
                                new frmMusteri(val).Show();

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı Adı veya Parola hatalı girilmiştir.", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    // something went wrong, and you wanna know why
                    MessageBox.Show("Error:" + ex.ToString(), "something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
            }
        }
    }
}
