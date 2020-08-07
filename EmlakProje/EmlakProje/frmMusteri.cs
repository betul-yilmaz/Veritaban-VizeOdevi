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
    public partial class frmMusteri : Form
    {
        private int id;
        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        private String sql = null;
        int[] array1 = new int[50000];
        int[] array2 = new int[50000];
        int[] array3 = new int[50000];
        int sayac1 = 0;
        int sayac2 = 0;
        int sayac3 = 0;
        public frmMusteri(int val)
        {
            InitializeComponent();
            this.id = val;
            conn = new NpgsqlConnection("Server = localhost; Port = 5432;Database=EmlakProje; User Id=postgres;Password=1234");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox1.Visible = true;  
            listBox2.Visible = false;
            listBox3.Visible = false;
            panel5.Visible = false;
            panel8.Visible = false;
            panel11.Visible = false;
            try
            {
                conn.Open();
                string sql = "SELECT * FROM homes";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {
                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        listBox1.Items.Add(reader[1].ToString() + "  " + reader[3].ToString()+ "/" + reader[4].ToString());
                        array1[sayac1] = Convert.ToInt32(reader[0].ToString());
                        sayac1++;
                    }
                }
                //MessageBox.Show(yetki1.ToString());



                conn.Close();

            }
            catch (Exception ex)
            {
                // something went wrong, and you wanna know why
                MessageBox.Show("Error:" + ex.ToString(), "something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            panel5.Width =840;
            panel5.Height =570;
            panel5.Visible = true;
            panel8.Visible = false;
            panel11.Visible = false;
            try
            {
                conn.Open();
                sql = @"select * from favorite_check_home(:_home_id,:_user_id)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_home_id", array1[listBox1.SelectedIndex]);
                cmd.Parameters.AddWithValue("_user_id", id);
                int result = (int)cmd.ExecuteScalar();
                if (result == 1)
                {                    
                    label5.Visible = true;
                    panel5.BackColor = Color.LightGreen;
                }
                else
                {
                    label5.Visible = false;
                    panel5.BackColor = Color.LemonChiffon;
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                // something went wrong, and you wanna know why
                MessageBox.Show("Error:" + ex.ToString(), "something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }

            try
            {
                conn.Open();
                string sql = "SELECT * FROM homes where homes_id= " + array1[listBox1.SelectedIndex];
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {
                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        textBox22.Text = reader[1].ToString();
                        textBox21.Text = reader[2].ToString();
                        comboBox25.Items.Add(reader[3].ToString());
                        comboBox25.SelectedIndex = 0;
                        comboBox24.Items.Add(reader[4].ToString());
                        comboBox24.SelectedIndex = 0;
                        comboBox23.Items.Add(reader[5].ToString());
                        comboBox23.SelectedIndex = 0;
                        comboBox22.Items.Add(reader[6].ToString());
                        comboBox22.SelectedIndex = 0;
                        textBox1.Text= reader[7].ToString();

                        if (reader[8].ToString() == "SATILIK DAİRE")
                        {
                            comboBox21.SelectedIndex = 0;
                        }
                        else
                        {
                            comboBox21.SelectedIndex = 1;
                        }
                        textBox20.Text = reader[9].ToString();  /// Brüt
                        textBox19.Text = reader[10].ToString(); /// Net
                        textBox18.Text = reader[11].ToString(); /// oda Sayısı
                        textBox17.Text = reader[12].ToString(); /// Bina Yaşı
                        textBox16.Text = reader[13].ToString(); /// Bulunduğu Kat
                        textBox15.Text = reader[14].ToString(); /// Kat Sayısı

                        // Isıtma Sistemi
                        if (reader[15].ToString() == "DOĞALGAZ")
                        {
                            comboBox20.SelectedIndex = 0;
                        }
                        else if (reader[15].ToString() == "SOBA")
                        {
                            comboBox20.SelectedIndex = 1;
                        }
                        else
                        {
                            comboBox20.SelectedIndex = 2;
                        }

                        //// Banyo sayısı
                        textBox14.Text = reader[16].ToString();

                        /////// Balkon
                        if (Convert.ToInt32(reader[17].ToString()) == 0)
                        {
                            comboBox19.SelectedIndex = 0;
                        }
                        else
                        {
                            comboBox19.SelectedIndex = 1;
                        }

                        //////  Eşya var mı
                        if (Convert.ToInt32(reader[18].ToString()) == 0)
                        {
                            comboBox18.SelectedIndex = 0;
                        }
                        else
                        {
                            comboBox18.SelectedIndex = 1;
                        }

                        //////  kullanım durumu
                        if (Convert.ToInt32(reader[19].ToString()) == 0)
                        {
                            comboBox17.SelectedIndex = 0;
                        }
                        else
                        {
                            comboBox17.SelectedIndex = 1;
                        }

                        /// Site içerisinde                         
                        if (Convert.ToInt32(reader[20].ToString()) == 0)
                        {
                            comboBox16.SelectedIndex = 0;
                        }
                        else
                        {
                            comboBox16.SelectedIndex = 1;
                        }

                        /// AİDAT
                        textBox13.Text = reader[21].ToString();

                        /// Krediye Uygun
                        if (Convert.ToInt32(reader[22].ToString()) == 0)
                        {
                            comboBox15.SelectedIndex = 0;
                        }
                        else
                        {
                            comboBox15.SelectedIndex = 1;
                        }

                        /// Takas
                        if (Convert.ToInt32(reader[23].ToString()) == 0)
                        {
                            comboBox14.SelectedIndex = 0;
                        }
                        else
                        {
                            comboBox14.SelectedIndex = 1;
                        }

                        /// Telefon
                        maskedTextBox4.Text = reader[24].ToString();

                        /// Açıklama
                        textBox12.Text = reader[25].ToString();

                        /// Ev Sahibi TC
                        //maskedTextBox3.Text = reader[26].ToString();
                    }
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

        private void frmMusteri_Load(object sender, EventArgs e)
        {
            conn.Open();
            sql = "SELECT * FROM users WHERE id=" + id;
            using (cmd = new NpgsqlCommand(sql, conn))
            {
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label1.Text = "Hoşgeldiniz : " + reader[3].ToString() + " " + reader[4].ToString();
                }
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox1.Visible = false;
            listBox2.Visible = true;
            listBox3.Visible = false;
            panel5.Visible = false;
            panel8.Visible = false;
            panel11.Visible = false;
            try
            {
                conn.Open();
                string sql = "SELECT * FROM lands";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {
                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        listBox2.Items.Add(reader[1].ToString() + "  " + reader[3].ToString() + "/" + reader[4].ToString());
                        array2[sayac2] = Convert.ToInt32(reader[0].ToString());
                        sayac2++;
                    }
                }
                //MessageBox.Show(yetki1.ToString());



                conn.Close();

            }
            catch (Exception ex)
            {
                // something went wrong, and you wanna know why
                MessageBox.Show("Error:" + ex.ToString(), "something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox1.Visible = false;
            listBox2.Visible = false;
            listBox3.Visible = true;
            panel5.Visible = false;
            panel8.Visible = false;
            panel11.Visible = false;
            try
            {
                conn.Open();
                string sql = "SELECT * FROM stores";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {
                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        listBox3.Items.Add(reader[1].ToString() + "  " + reader[3].ToString() + "/" + reader[4].ToString());
                        array3[sayac3] = Convert.ToInt32(reader[0].ToString());
                        sayac3++;
                    }
                }
                //MessageBox.Show(yetki1.ToString());



                conn.Close();

            }
            catch (Exception ex)
            {
                // something went wrong, and you wanna know why
                MessageBox.Show("Error:" + ex.ToString(), "something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            panel8.Width = 840;
            panel8.Height = 470;
            panel5.Visible = false;
            panel8.Visible = true;
            panel11.Visible = false;
            try
            {
                conn.Open();
                sql = @"select * from favorite_check_land(:_land_id,:_user_id)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_land_id", array2[listBox2.SelectedIndex]);
                cmd.Parameters.AddWithValue("_user_id", id);
                int result = (int)cmd.ExecuteScalar();
                if (result == 1)
                {
                    label6.Visible = true;
                    panel8.BackColor = Color.LightGreen;
                }
                else
                {
                    label6.Visible = false;
                    panel8.BackColor = Color.LemonChiffon;
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                // something went wrong, and you wanna know why
                MessageBox.Show("Error:" + ex.ToString(), "something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }


            try
            {
                conn.Open();
                string sql = "SELECT * FROM lands where lands_id= " + array2[listBox2.SelectedIndex];
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {
                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        textBox34.Text = reader[1].ToString();
                        textBox28.Text = reader[2].ToString();
                        comboBox43.Items.Add(reader[3].ToString());
                        comboBox43.SelectedIndex = 0;
                        comboBox42.Items.Add(reader[4].ToString());
                        comboBox42.SelectedIndex = 0;
                        comboBox41.Items.Add(reader[5].ToString());
                        comboBox41.SelectedIndex = 0;
                        comboBox40.Items.Add(reader[6].ToString());
                        comboBox40.SelectedIndex = 0;
                        textBox2.Text = reader[7].ToString();
                        if (reader[8].ToString() == "SATILIK ARSA")
                        {
                            comboBox39.SelectedIndex = 0;
                        }
                        else
                        {
                            comboBox39.SelectedIndex = 1;
                        }
                        textBox27.Text = reader[9].ToString();  /// Ada No
                        textBox26.Text = reader[10].ToString(); /// Parsel No
                        textBox25.Text = reader[11].ToString(); /// Pafta No                              
                        /////// İmar Durumu
                        if (Convert.ToInt32(reader[12].ToString()) == 0)
                        {
                            comboBox38.SelectedIndex = 0;
                        }
                        else
                        {
                            comboBox38.SelectedIndex = 1;
                        }

                        //////  Kat Karşlığı var mı
                        if (Convert.ToInt32(reader[13].ToString()) == 0)
                        {
                            comboBox32.SelectedIndex = 0;
                        }
                        else
                        {
                            comboBox32.SelectedIndex = 1;
                        }

                        /// Krediye Uygun
                        if (Convert.ToInt32(reader[13].ToString()) == 0)
                        {
                            comboBox29.SelectedIndex = 0;
                        }
                        else
                        {
                            comboBox29.SelectedIndex = 1;
                        }

                        /// Takas
                        if (Convert.ToInt32(reader[14].ToString()) == 0)
                        {
                            comboBox28.SelectedIndex = 0;
                        }
                        else
                        {
                            comboBox28.SelectedIndex = 1;
                        }

                        /// Telefon
                        maskedTextBox8.Text = reader[16].ToString();

                        /// Açıklama
                        textBox24.Text = reader[17].ToString();

                        
                    }
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

        private void listBox3_DoubleClick(object sender, EventArgs e)
        {
            panel11.Width = 840;
            panel11.Height = 500;
            panel5.Visible = false;
            panel8.Visible = false;
            panel11.Visible = true;
            try
            {
                conn.Open();
                sql = @"select * from favorite_check_store(:_store_id,:_user_id)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_store_id", array3[listBox3.SelectedIndex]);
                cmd.Parameters.AddWithValue("_user_id", id);
                int result = (int)cmd.ExecuteScalar();
                if (result == 1)
                {
                    label7.Visible = true;
                    panel11.BackColor = Color.LightGreen;
                }
                else
                {
                    label7.Visible = false;
                    panel11.BackColor = Color.LemonChiffon;
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                // something went wrong, and you wanna know why
                MessageBox.Show("Error:" + ex.ToString(), "something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }


            try
            {
                conn.Open();
                string sql = "SELECT * FROM stores where stores_id= " + array3[listBox3.SelectedIndex];
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {
                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        textBox52.Text = reader[1].ToString();
                        textBox51.Text = reader[2].ToString();
                        comboBox65.Items.Add(reader[3].ToString());
                        comboBox65.SelectedIndex = 0;
                        comboBox64.Items.Add(reader[4].ToString());
                        comboBox64.SelectedIndex = 0;
                        comboBox63.Items.Add(reader[5].ToString());
                        comboBox63.SelectedIndex = 0;
                        comboBox62.Items.Add(reader[6].ToString());
                        comboBox62.SelectedIndex = 0;
                        textBox3.Text = reader[7].ToString();
                        if (reader[8].ToString() == "SATILIK DÜKKAN")
                        {
                            comboBox61.SelectedIndex = 0;
                        }
                        else
                        {
                            comboBox61.SelectedIndex = 1;
                        }
                        textBox50.Text = reader[9].ToString();  /// Brüt
                        textBox49.Text = reader[10].ToString(); /// Net                        
                        textBox47.Text = reader[11].ToString(); /// Bina Yaşı                     

                        // Isıtma Sistemi
                        if (reader[12].ToString() == "DOĞALGAZ")
                        {
                            comboBox60.SelectedIndex = 0;
                        }
                        else if (reader[12].ToString() == "SOBA")
                        {
                            comboBox60.SelectedIndex = 1;
                        }
                        else
                        {
                            comboBox60.SelectedIndex = 2;
                        }

                        //////  kullanım durumu
                        if (Convert.ToInt32(reader[13].ToString()) == 0)
                        {
                            comboBox57.SelectedIndex = 0;
                        }
                        else
                        {
                            comboBox57.SelectedIndex = 1;
                        }


                        /// AİDAT
                        textBox38.Text = reader[14].ToString();

                        /// Krediye Uygun
                        if (Convert.ToInt32(reader[15].ToString()) == 0)
                        {
                            comboBox49.SelectedIndex = 0;
                        }
                        else
                        {
                            comboBox49.SelectedIndex = 1;
                        }

                        /// Takas
                        if (Convert.ToInt32(reader[16].ToString()) == 0)
                        {
                            comboBox46.SelectedIndex = 0;
                        }
                        else
                        {
                            comboBox46.SelectedIndex = 1;
                        }

                        /// Telefon
                        maskedTextBox12.Text = reader[17].ToString();

                        /// Açıklama
                        textBox37.Text = reader[18].ToString();

                       
                    }
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

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                sql = @"select * from favorite_check_home(:_home_id,:_user_id)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_home_id", array1[listBox1.SelectedIndex]);
                cmd.Parameters.AddWithValue("_user_id", id);
                int result = (int)cmd.ExecuteScalar();
                if (result == 1)
                {
                    MessageBox.Show("Daha önce favorilerinize eklenmiştir.");
                    
                }
                else
                {
                    
                    try
                    {
                        NpgsqlCommand command2 = new NpgsqlCommand("insert into favorite_homes (home_id, user_id)values(@home_id, @user_id)", conn);

                        //command2.Parameters.AddWithValue("@homes_id", home_id);
                        command2.Parameters.AddWithValue("@home_id", array1[listBox1.SelectedIndex]);
                        command2.Parameters.AddWithValue("@user_id", id);               

                        command2.ExecuteNonQuery();
                        label5.Visible = true;
                        panel5.BackColor = Color.LightGreen;
                        MessageBox.Show("Favorilerinize eklendi");

                    }
                    catch (Exception ex)
                    {
                        // something went wrong, and you wanna know why                           
                        MessageBox.Show(ex.Message.ToString());
                        conn.Close();
                    }
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

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                sql = @"select * from favorite_check_land(:_land_id,:_user_id)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_land_id", array2[listBox2.SelectedIndex]);
                cmd.Parameters.AddWithValue("_user_id", id);
                int result = (int)cmd.ExecuteScalar();
                if (result == 1)
                {
                    MessageBox.Show("Daha önce favorilerinize eklenmiştir.");
                    
                }
                else
                {

                    try
                    {
                        NpgsqlCommand command2 = new NpgsqlCommand("insert into favorite_lands (land_id, user_id)values(@land_id, @user_id)", conn);

                        //command2.Parameters.AddWithValue("@homes_id", home_id);
                        command2.Parameters.AddWithValue("@land_id", array2[listBox2.SelectedIndex]);
                        command2.Parameters.AddWithValue("@user_id", id);

                        command2.ExecuteNonQuery();
                        label6.Visible = true;
                        panel8.BackColor = Color.LightGreen;
                        MessageBox.Show("Favorilerinize eklendi");

                    }
                    catch (Exception ex)
                    {
                        // something went wrong, and you wanna know why                           
                        MessageBox.Show(ex.Message.ToString());
                        conn.Close();
                    }
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

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                sql = @"select * from favorite_check_store(:_store_id,:_user_id)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_store_id", array3[listBox3.SelectedIndex]);
                cmd.Parameters.AddWithValue("_user_id", id);
                int result = (int)cmd.ExecuteScalar();
                if (result == 1)
                {
                    MessageBox.Show("Daha önce favorilerinize eklenmiştir.");

                }
                else
                {

                    try
                    {
                        NpgsqlCommand command2 = new NpgsqlCommand("insert into favorite_stores (store_id, user_id)values(@store_id, @user_id)", conn);

                        //command2.Parameters.AddWithValue("@homes_id", home_id);
                        command2.Parameters.AddWithValue("@store_id", array3[listBox3.SelectedIndex]);
                        command2.Parameters.AddWithValue("@user_id", id);

                        command2.ExecuteNonQuery();
                        label7.Visible = true;
                        panel11.BackColor = Color.LightGreen;
                        MessageBox.Show("Favorilerinize eklendi");

                    }
                    catch (Exception ex)
                    {
                        // something went wrong, and you wanna know why                           
                        MessageBox.Show(ex.Message.ToString());
                        conn.Close();
                    }
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
