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
    public partial class frmEmlakci : Form
    {
        private int id;
        private int secilmisil;
        private int secilmisilce;
        private int secilmisbolge;
        private string username;
        private int home_id;
        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        private String sql = null;
        public frmEmlakci(int val)
        {
            InitializeComponent();
            this.id = val;
            conn = new NpgsqlConnection("Server = localhost; Port = 5432;Database=EmlakProje; User Id=postgres;Password=1234");
        }

        private void frmEmlakci_Load(object sender, EventArgs e)
        {
            conn.Open();
            sql = "SELECT * FROM users WHERE id=" + id;                 
            using (cmd = new NpgsqlCommand(sql, conn))
            {
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label1.Text = "Hoşgeldiniz : " + reader[3].ToString()+" "+ reader[4].ToString();                  
                }
            }
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel13.Visible = false;
            panel12.Visible = false;
            panel10.Visible = false;
            panel7.Visible = false;
            panel5.Visible = false;
            panel4.Visible = false;
            panel3.Visible = false;
            panel1.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel9.Visible = false;
            panel6.Visible = false;
            panel2.Visible = true;          
            
            panel2.Width = 900;
            panel2.Height = 800;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear(); 
            comboBox4.Items.Clear();

            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";            

            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";


            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
            comboBox8.SelectedIndex = 0;
            comboBox9.SelectedIndex = 0;
            comboBox10.SelectedIndex = 0;
            comboBox11.SelectedIndex = 0;
            comboBox12.SelectedIndex = 0;

            try
            {
                conn.Open();
                string sql = "SELECT * FROM cities ";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader[2].ToString());
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            comboBox3.Items.Clear();
            comboBox3.Text = "";
            comboBox4.Items.Clear();
            comboBox4.Text = "";

            secilmisil = comboBox1.SelectedIndex + 1;
            try
            {
                conn.Open();
                string sql = "SELECT * FROM counties where cityid= " + secilmisil;
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox2.Items.Add(reader[2].ToString());                        
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            comboBox3.Text = "";
            comboBox4.Items.Clear();
            comboBox4.Text = "";

            try
            {
                conn.Open();
                string sql = "SELECT countyid FROM counties where countyname= '"+ comboBox2.Text+"'";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        secilmisilce= Convert.ToInt32(reader[0].ToString());

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

            try
            {
                conn.Open();
                string sql = "SELECT * FROM areas where countyid= " + secilmisilce;
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader[2].ToString());

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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            comboBox4.Text = "";

            try
            {
                conn.Open();
                string sql = "SELECT areaid FROM areas where areaname= '" + comboBox3.Text + "'";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        secilmisbolge = Convert.ToInt32(reader[0].ToString());

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

            try
            {
                conn.Open();
                string sql = "SELECT * FROM neighborhoods where areaid= " + secilmisbolge;
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox4.Items.Add(reader[2].ToString());

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
            if (textBox1.Text=="")
            {
                MessageBox.Show("LÜTFEN BAŞLIK GİRİNİZ.");
            }
            else if (textBox2.Text=="")
            {
                MessageBox.Show("LÜTFEN FİYAT GİRİNİZ.");
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("LÜTFEN İL SEÇİNİZ.");
            }
            else if (comboBox2.Text == "")
            {
                MessageBox.Show("LÜTFEN İLÇE SEÇİNİZ.");
            }
            else if (comboBox3.Text == "")
            {
                MessageBox.Show("LÜTFEN BÖLGE SEÇİNİZ.");
            }
            else if (comboBox4.Text == "")
            {
                MessageBox.Show("LÜTFEN MAHALLE SEÇİNİZ.");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("LÜTFEN BRÜT ALAN GİRİNİZ.");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("LÜTFEN NET ALAN GİRİNİZ.");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("LÜTFEN ODA SAYISI GİRİNİZ.");
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("LÜTFEN BİNA YAŞI GİRİNİZ.");
            }
            else if (textBox7.Text == "")
            {
                MessageBox.Show("LÜTFEN BULUNDUĞU KATI GİRİNİZ.");
            }
            else if (textBox8.Text == "")
            {
                MessageBox.Show("LÜTFEN KAT SAYISI GİRİNİZ.");
            }
            else if (textBox9.Text == "")
            {
                MessageBox.Show("LÜTFEN BANYO SAYISI GİRİNİZ.");
            }
            else if (textBox10.Text == "")
            {
                MessageBox.Show("LÜTFEN AİDAT GİRİNİZ.");
            }
            else if (maskedTextBox1.Text == "(   )    -  -")
            {
                MessageBox.Show("LÜTFEN TELEFON NO GİRİNİZ.");
            }
            else if (textBox11.Text == "")
            {
                MessageBox.Show("LÜTFEN AÇIKLAMA GİRİNİZ.");
            }
            else if (maskedTextBox2.Text == "")
            {
                MessageBox.Show("LÜTFEN EV SAHİBİ TC NO GİRİNİZ.");
            }
            else
            {
                try
                {
                    conn.Open();
                    sql = @"select * from owner_tc_check(:_tcno)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("_tcno", Convert.ToInt64(maskedTextBox2.Text));
                    int result = (int)cmd.ExecuteScalar();
                    if (result == 1)
                    {
                        MessageBox.Show("Emlakçı sahibi sistemde bulundu.");
                        
                        try
                        {
                            NpgsqlCommand command2 = new NpgsqlCommand("insert into homes ( title, price, city, county, area, neighborhood, release_date, property_type, gross, clear, number_of_rooms, building_age, floor_location, number_of_floors, heating, number_of_bathrooms, balcony, furnished, using_status, within_the_site, dues, available_for_loan, swap, phone_number, explanation, home_owner, user_id)values(@title, @price, @city, @county, @area, @neighborhood, @release_date, @property_type, @gross, @clear, @number_of_rooms, @building_age, @floor_location, @number_of_floors, @heating, @number_of_bathrooms, @balcony, @furnished, @using_status, @within_the_site, @dues, @available_for_loan, @swap, @phone_number, @explanation, @home_owner, @user_id)", conn);
                                             
                            //command2.Parameters.AddWithValue("@homes_id", home_id);
                            command2.Parameters.AddWithValue("@title", textBox1.Text);
                            command2.Parameters.AddWithValue("@price",Convert.ToDouble(textBox2.Text));
                            command2.Parameters.AddWithValue("@city", comboBox1.Text);
                            command2.Parameters.AddWithValue("@county", comboBox2.Text);
                            command2.Parameters.AddWithValue("@area", comboBox3.Text);
                            command2.Parameters.AddWithValue("@neighborhood", comboBox4.Text); 
                            command2.Parameters.AddWithValue("@release_date", Convert.ToDateTime(monthCalendar1.SelectionRange.Start.ToShortDateString()));
                            // emlak_tipi;
                            command2.Parameters.AddWithValue("@property_type", comboBox5.Text);
                            // brüt
                            command2.Parameters.AddWithValue("@gross", Convert.ToInt32(textBox3.Text));
                            // net
                            command2.Parameters.AddWithValue("@clear", Convert.ToInt32(textBox4.Text));
                            // number_of_rooms
                            command2.Parameters.AddWithValue("@number_of_rooms", textBox5.Text);
                            // building_age
                            command2.Parameters.AddWithValue("@building_age", Convert.ToInt32(textBox6.Text));
                            // floor_location
                            command2.Parameters.AddWithValue("@floor_location", Convert.ToInt32(textBox7.Text));
                            // number_of_floors
                            command2.Parameters.AddWithValue("@number_of_floors", Convert.ToInt32(textBox8.Text));
                            // heating
                            command2.Parameters.AddWithValue("@heating", comboBox6.Text);
                            // number_of_bathrooms
                            command2.Parameters.AddWithValue("@number_of_bathrooms", Convert.ToInt32(textBox9.Text));
                            //balcony 0-Balkon yok , 1- Balkon var                            
                            if (comboBox7.SelectedIndex==0)
                            {
                                command2.Parameters.AddWithValue("@balcony", 0);
                            }
                            else
                            {
                                command2.Parameters.AddWithValue("@balcony", 1);
                            }
                            // furnished Eşya var mı? 0-Hayır , 1-Evet
                            if (comboBox8.SelectedIndex == 0)
                            {
                                command2.Parameters.AddWithValue("@furnished", 0);
                            }
                            else
                            {
                                command2.Parameters.AddWithValue("@furnished", 1);
                            }
                            // using_status Kullanım Durumu 0-BOŞ , 1-DOLU
                            if (comboBox9.SelectedIndex == 0)
                            {
                                command2.Parameters.AddWithValue("@using_status", 0);
                            }
                            else
                            {
                                command2.Parameters.AddWithValue("@using_status", 1);
                            }
                            // within_the_site Site içerisinde 0-Hayır 1-Evet
                            if (comboBox10.SelectedIndex == 0)
                            {
                                command2.Parameters.AddWithValue("@within_the_site", 0);
                            }
                            else
                            {
                                command2.Parameters.AddWithValue("@within_the_site", 1);
                            }
                            // dues Aidat
                            command2.Parameters.AddWithValue("@dues", Convert.ToDouble(textBox10.Text));
                            // available_for_loan Krediye uygun 0-Hayır 1-Evet
                            if (comboBox11.SelectedIndex == 0)
                            {
                                command2.Parameters.AddWithValue("@available_for_loan", 0);
                            }
                            else
                            {
                                command2.Parameters.AddWithValue("@available_for_loan", 1);
                            }
                            // swap Takas Durumu 0-Hayır 1-Evet
                            if (comboBox12.SelectedIndex == 0)
                            {
                                command2.Parameters.AddWithValue("@swap", 0);
                            }
                            else
                            {
                                command2.Parameters.AddWithValue("@swap", 1);
                            }
                            // phone_number
                            command2.Parameters.AddWithValue("@phone_number", maskedTextBox1.Text);
                            // explanation
                            command2.Parameters.AddWithValue("@explanation", textBox11.Text);
                            // home_owner
                            command2.Parameters.AddWithValue("@home_owner", Convert.ToInt64(maskedTextBox2.Text));
                            // user_id
                            command2.Parameters.AddWithValue("@user_id", id);
                            command2.ExecuteNonQuery();
                            MessageBox.Show("İLAN YAYINLANDI.");
                            panel1.Visible = false;
                            panel2.Visible = false;
                        }
                        catch (Exception ex)
                        {
                            // something went wrong, and you wanna know why
                            MessageBox.Show("Error:" + ex.ToString(), "something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            conn.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Emlakçı sahibi sistemde bulunamadı.Lütfen ilk önce emlak sahibini sisteme ekleyniz.");
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

        private void button9_Click(object sender, EventArgs e)
        {
            panel10.Visible = false;
            panel7.Visible = false;
            panel5.Visible = false;
            panel4.Visible = true;
            panel4.Width = 900;
            panel4.Height = 36;
            comboBox13.Items.Clear();
            comboBox13.Text = "";

            textBox22.Text = "";
            textBox21.Text = "";

            comboBox25.Items.Clear();
            comboBox25.Text = "";
            comboBox24.Items.Clear();
            comboBox24.Text = "";
            comboBox23.Items.Clear();
            comboBox23.Text = "";
            comboBox22.Items.Clear();
            comboBox22.Text = "";



            try
            {
                conn.Open();
                string sql = "SELECT * FROM homes where user_id= " + id+"order by homes_id";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {
                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {                        
                         comboBox13.Items.Add(reader[0].ToString());

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

        private void button6_Click(object sender, EventArgs e)
        {
            panel13.Visible = false;
            panel12.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel6.Visible = false;
            panel9.Visible = false;
            panel3.Visible = true;
        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel4.Height = 690;
            comboBox25.Items.Clear();
            comboBox25.Text = "";
            comboBox24.Items.Clear();
            comboBox24.Text = "";
            comboBox23.Items.Clear();
            comboBox23.Text = "";
            comboBox22.Items.Clear();
            comboBox22.Text = "";
            panel5.Visible = true;

            try
            {
                conn.Open();
                string sql = "SELECT * FROM homes where homes_id= " + Convert.ToInt32(comboBox13.Text);
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {
                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        textBox22.Text =  reader[1].ToString();
                        textBox21.Text =  reader[2].ToString();
                        comboBox25.Items.Add(reader[3].ToString());
                        comboBox25.SelectedIndex = 0;
                        comboBox24.Items.Add(reader[4].ToString());
                        comboBox24.SelectedIndex = 0;
                        comboBox23.Items.Add(reader[5].ToString());
                        comboBox23.SelectedIndex = 0;
                        comboBox22.Items.Add(reader[6].ToString());
                        comboBox22.SelectedIndex = 0;
                        
                        if (reader[8].ToString()=="SATILIK DAİRE")
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
                        else if(reader[15].ToString() == "SOBA")
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
                        if (Convert.ToInt32(reader[17].ToString())==0)
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
                        textBox13.Text= reader[21].ToString();

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
                        maskedTextBox3.Text = reader[26].ToString();
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

        private void comboBox25_Click(object sender, EventArgs e)
        {
            comboBox25.Items.Clear();
            comboBox25.Text = "";
            comboBox24.Items.Clear();
            comboBox24.Text = "";
            comboBox23.Items.Clear();
            comboBox23.Text = "";
            comboBox22.Items.Clear();
            comboBox22.Text = "";
            try
            {
                conn.Open();
                string sql = "SELECT * FROM cities ";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox25.Items.Add(reader[2].ToString());
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
        private void comboBox24_Click(object sender, EventArgs e)
        {
            comboBox24.Items.Clear();
            comboBox24.Text = "";
            comboBox23.Items.Clear();
            comboBox23.Text = "";
            comboBox22.Items.Clear();
            comboBox22.Text = "";
            secilmisil = comboBox25.SelectedIndex + 1;
            try
            {
                conn.Open();
                string sql = "SELECT * FROM counties where cityid= " + secilmisil;
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox24.Items.Add(reader[2].ToString());
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

        private void comboBox23_Click(object sender, EventArgs e)
        {
            comboBox23.Items.Clear();
            comboBox23.Text = "";
            comboBox22.Items.Clear();
            comboBox22.Text = "";
            try
            {
                conn.Open();
                string sql = "SELECT countyid FROM counties where countyname= '" + comboBox24.Text + "'";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        secilmisilce = Convert.ToInt32(reader[0].ToString());

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

            try
            {
                conn.Open();
                string sql = "SELECT * FROM areas where countyid= " + secilmisilce;
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox23.Items.Add(reader[2].ToString());

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

        private void comboBox22_Click(object sender, EventArgs e)
        {
            comboBox22.Items.Clear();
            comboBox22.Text = "";

            try
            {
                conn.Open();
                string sql = "SELECT areaid FROM areas where areaname= '" + comboBox23.Text + "'";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        secilmisbolge = Convert.ToInt32(reader[0].ToString());

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

            try
            {
                conn.Open();
                string sql = "SELECT * FROM neighborhoods where areaid= " + secilmisbolge;
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox22.Items.Add(reader[2].ToString());

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

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox22.Text == "")
            {
                MessageBox.Show("LÜTFEN BAŞLIK GİRİNİZ.");
            }
            else if (textBox21.Text == "")
            {
                MessageBox.Show("LÜTFEN FİYAT GİRİNİZ.");
            }
            else if (comboBox25.Text == "")
            {
                MessageBox.Show("LÜTFEN İL SEÇİNİZ.");
            }
            else if (comboBox24.Text == "")
            {
                MessageBox.Show("LÜTFEN İLÇE SEÇİNİZ.");
            }
            else if (comboBox23.Text == "")
            {
                MessageBox.Show("LÜTFEN BÖLGE SEÇİNİZ.");
            }
            else if (comboBox22.Text == "")
            {
                MessageBox.Show("LÜTFEN MAHALLE SEÇİNİZ.");
            }
            else if (textBox20.Text == "")
            {
                MessageBox.Show("LÜTFEN BRÜT ALAN GİRİNİZ.");
            }
            else if (textBox19.Text == "")
            {
                MessageBox.Show("LÜTFEN NET ALAN GİRİNİZ.");
            }
            else if (textBox18.Text == "")
            {
                MessageBox.Show("LÜTFEN ODA SAYISI GİRİNİZ.");
            }
            else if (textBox17.Text == "")
            {
                MessageBox.Show("LÜTFEN BİNA YAŞI GİRİNİZ.");
            }
            else if (textBox16.Text == "")
            {
                MessageBox.Show("LÜTFEN BULUNDUĞU KATI GİRİNİZ.");
            }
            else if (textBox15.Text == "")
            {
                MessageBox.Show("LÜTFEN KAT SAYISI GİRİNİZ.");
            }
            else if (textBox14.Text == "")
            {
                MessageBox.Show("LÜTFEN BANYO SAYISI GİRİNİZ.");
            }
            else if (textBox13.Text == "")
            {
                MessageBox.Show("LÜTFEN AİDAT GİRİNİZ.");
            }
            else if (maskedTextBox4.Text == "(   )    -  -")
            {
                MessageBox.Show("LÜTFEN TELEFON NO GİRİNİZ.");
            }
            else if (textBox12.Text == "")
            {
                MessageBox.Show("LÜTFEN AÇIKLAMA GİRİNİZ.");
            }
            else if (maskedTextBox3.Text == "")
            {
                MessageBox.Show("LÜTFEN EV SAHİBİ TC NO GİRİNİZ.");
            }
            else
            {
                try
                {
                    conn.Open();
                    sql = @"select * from owner_tc_check(:_tcno)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("_tcno", Convert.ToInt64(maskedTextBox3.Text));
                    int result = (int)cmd.ExecuteScalar();
                    if (result == 1)
                    {
                        MessageBox.Show("Emlakçı sahibi sistemde bulundu.");

                        try
                        {                            
                            NpgsqlCommand command2 = new NpgsqlCommand("UPDATE homes SET title=@title, price=@price, city=@city, county=@county, area=@area, neighborhood=@neighborhood, release_date=@release_date, property_type=@property_type, gross=@gross, clear=@clear, number_of_rooms=@number_of_rooms, building_age=@building_age, floor_location=@floor_location, number_of_floors=@number_of_floors, heating=@heating, number_of_bathrooms=@number_of_bathrooms, balcony=@balcony, furnished=@furnished, using_status=@using_status, within_the_site=@within_the_site, dues=@dues, available_for_loan=@available_for_loan, swap=@swap, phone_number=@phone_number, explanation=@explanation, home_owner=@home_owner, user_id=@user_id where homes_id=@homes_id", conn);
                            command2.Parameters.AddWithValue("@homes_id", Convert.ToInt32(comboBox13.Text));
                            command2.Parameters.AddWithValue("@title", textBox22.Text);
                            command2.Parameters.AddWithValue("@price", Convert.ToDouble(textBox21.Text));
                            command2.Parameters.AddWithValue("@city", comboBox25.Text);
                            command2.Parameters.AddWithValue("@county", comboBox24.Text);
                            command2.Parameters.AddWithValue("@area", comboBox23.Text);
                            command2.Parameters.AddWithValue("@neighborhood", comboBox22.Text);
                            command2.Parameters.AddWithValue("@release_date", Convert.ToDateTime(monthCalendar2.SelectionRange.Start.ToShortDateString()));
                            // emlak_tipi;
                            command2.Parameters.AddWithValue("@property_type", comboBox21.Text);
                            // brüt
                            command2.Parameters.AddWithValue("@gross", Convert.ToInt32(textBox20.Text));
                            // net
                            command2.Parameters.AddWithValue("@clear", Convert.ToInt32(textBox19.Text));
                            // number_of_rooms
                            command2.Parameters.AddWithValue("@number_of_rooms", textBox18.Text);
                            // building_age
                            command2.Parameters.AddWithValue("@building_age", Convert.ToInt32(textBox17.Text));
                            // floor_location
                            command2.Parameters.AddWithValue("@floor_location", Convert.ToInt32(textBox16.Text));
                            // number_of_floors
                            command2.Parameters.AddWithValue("@number_of_floors", Convert.ToInt32(textBox15.Text));
                            // heating
                            command2.Parameters.AddWithValue("@heating", comboBox20.Text);
                            // number_of_bathrooms
                            command2.Parameters.AddWithValue("@number_of_bathrooms", Convert.ToInt32(textBox14.Text));
                            //balcony 0-Balkon yok , 1- Balkon var                            
                            if (comboBox19.SelectedIndex == 0)
                            {
                                command2.Parameters.AddWithValue("@balcony", 0);
                            }
                            else
                            {
                                command2.Parameters.AddWithValue("@balcony", 1);
                            }
                            // furnished Eşya var mı? 0-Hayır , 1-Evet
                            if (comboBox18.SelectedIndex == 0)
                            {
                                command2.Parameters.AddWithValue("@furnished", 0);
                            }
                            else
                            {
                                command2.Parameters.AddWithValue("@furnished", 1);
                            }
                            // using_status Kullanım Durumu 0-BOŞ , 1-DOLU
                            if (comboBox17.SelectedIndex == 0)
                            {
                                command2.Parameters.AddWithValue("@using_status", 0);
                            }
                            else
                            {
                                command2.Parameters.AddWithValue("@using_status", 1);
                            }
                            // within_the_site Site içerisinde 0-Hayır 1-Evet
                            if (comboBox16.SelectedIndex == 0)
                            {
                                command2.Parameters.AddWithValue("@within_the_site", 0);
                            }
                            else
                            {
                                command2.Parameters.AddWithValue("@within_the_site", 1);
                            }
                            // dues Aidat
                            command2.Parameters.AddWithValue("@dues", Convert.ToDouble(textBox13.Text));
                            // available_for_loan Krediye uygun 0-Hayır 1-Evet
                            if (comboBox15.SelectedIndex == 0)
                            {
                                command2.Parameters.AddWithValue("@available_for_loan", 0);
                            }
                            else
                            {
                                command2.Parameters.AddWithValue("@available_for_loan", 1);
                            }
                            // swap Takas Durumu 0-Hayır 1-Evet
                            if (comboBox14.SelectedIndex == 0)
                            {
                                command2.Parameters.AddWithValue("@swap", 0);
                            }
                            else
                            {
                                command2.Parameters.AddWithValue("@swap", 1);
                            }
                            // phone_number
                            command2.Parameters.AddWithValue("@phone_number", maskedTextBox4.Text);
                            // explanation
                            command2.Parameters.AddWithValue("@explanation", textBox12.Text);
                            // home_owner
                            command2.Parameters.AddWithValue("@home_owner", Convert.ToInt64(maskedTextBox3.Text));
                            // user_id
                            command2.Parameters.AddWithValue("@user_id", id);
                            command2.ExecuteNonQuery();
                            MessageBox.Show("İLAN GÜNCELLENDİ.");
                            panel5.Visible = false;
                            panel4.Visible = false;
                            panel3.Visible = false;
                        }
                        catch (Exception ex)
                        {
                            // something went wrong, and you wanna know why
                            MessageBox.Show("Error:" + ex.ToString(), "something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            conn.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Emlakçı sahibi sistemde bulunamadı.Lütfen ilk önce emlak sahibini sisteme ekleyniz.");
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

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                NpgsqlCommand command = new NpgsqlCommand("Delete from homes where homes_id=@homes_id", conn);
                command.Parameters.AddWithValue("@homes_id", Convert.ToInt32(comboBox13.Text));
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("İLAN SİLİNDİ.");
                panel5.Visible = false;
                panel4.Visible = false;
                panel3.Visible = false;
            }
            catch (Exception ex)
            {
                // something went wrong, and you wanna know why
                MessageBox.Show("Error:" + ex.ToString(), "something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel9.Visible = false;
            panel2.Visible = false;
            panel6.Visible = true;
            
            panel6.Width = 900;
            panel6.Height = 700;

            textBox33.Text = "";
            textBox32.Text = "";
            textBox31.Text = "";
            textBox30.Text = "";
            textBox29.Text = "";
            textBox23.Text = "";

            maskedTextBox6.Text = "";
            maskedTextBox5.Text = "";

            comboBox37.Items.Clear();
            comboBox36.Items.Clear();
            comboBox35.Items.Clear();
            comboBox34.Items.Clear();

            comboBox37.Text = "";
            comboBox36.Text = "";
            comboBox35.Text = "";
            comboBox34.Text = "";

            comboBox33.SelectedIndex = 0;
            comboBox31.SelectedIndex = 0;
            comboBox30.SelectedIndex = 0;
            comboBox27.SelectedIndex = 0;
            comboBox26.SelectedIndex = 0;
            try
            {
                conn.Open();
                string sql = "SELECT * FROM cities ";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox37.Items.Add(reader[2].ToString());
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

        private void comboBox37_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox36.Items.Clear();
            comboBox36.Text = "";
            comboBox35.Items.Clear();
            comboBox35.Text = "";
            comboBox34.Items.Clear();
            comboBox34.Text = "";

            secilmisil = comboBox37.SelectedIndex + 1;
            try
            {
                conn.Open();
                string sql = "SELECT * FROM counties where cityid= " + secilmisil;
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox36.Items.Add(reader[2].ToString());
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

        private void comboBox36_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox35.Items.Clear();
            comboBox35.Text = "";
            comboBox34.Items.Clear();
            comboBox34.Text = "";

            try
            {
                conn.Open();
                string sql = "SELECT countyid FROM counties where countyname= '" + comboBox36.Text + "'";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        secilmisilce = Convert.ToInt32(reader[0].ToString());

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

            try
            {
                conn.Open();
                string sql = "SELECT * FROM areas where countyid= " + secilmisilce;
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox35.Items.Add(reader[2].ToString());

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

        private void comboBox35_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox34.Items.Clear();
            comboBox34.Text = "";

            try
            {
                conn.Open();
                string sql = "SELECT areaid FROM areas where areaname= '" + comboBox35.Text + "'";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        secilmisbolge = Convert.ToInt32(reader[0].ToString());

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

            try
            {
                conn.Open();
                string sql = "SELECT * FROM neighborhoods where areaid= " + secilmisbolge;
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox34.Items.Add(reader[2].ToString());

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

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox33.Text == "")
            {
                MessageBox.Show("LÜTFEN BAŞLIK GİRİNİZ.");
            }
            else if (textBox32.Text == "")
            {
                MessageBox.Show("LÜTFEN FİYAT GİRİNİZ.");
            }
            else if (comboBox37.Text == "")
            {
                MessageBox.Show("LÜTFEN İL SEÇİNİZ.");
            }
            else if (comboBox36.Text == "")
            {
                MessageBox.Show("LÜTFEN İLÇE SEÇİNİZ.");
            }
            else if (comboBox35.Text == "")
            {
                MessageBox.Show("LÜTFEN BÖLGE SEÇİNİZ.");
            }
            else if (comboBox34.Text == "")
            {
                MessageBox.Show("LÜTFEN MAHALLE SEÇİNİZ.");
            }
            else if (textBox31.Text == "")
            {
                MessageBox.Show("LÜTFEN ADA NO GİRİNİZ.");
            }
            else if (textBox30.Text == "")
            {
                MessageBox.Show("LÜTFEN PARSEL NO GİRİNİZ.");
            }
            else if (textBox29.Text == "")
            {
                MessageBox.Show("LÜTFEN PAFTA NO GİRİNİZ.");
            }            
            else if (maskedTextBox6.Text == "(   )    -  -")
            {
                MessageBox.Show("LÜTFEN TELEFON NO GİRİNİZ.");
            }
            else if (textBox23.Text == "")
            {
                MessageBox.Show("LÜTFEN AÇIKLAMA GİRİNİZ.");
            }
            else if (maskedTextBox5.Text == "")
            {
                MessageBox.Show("LÜTFEN ARSA SAHİBİ TC NO GİRİNİZ.");
            }
            else
            {
                try
                {
                    conn.Open();
                    sql = @"select * from owner_tc_check(:_tcno)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("_tcno", Convert.ToInt64(maskedTextBox5.Text));
                    int result = (int)cmd.ExecuteScalar();
                    if (result == 1)
                    {
                        MessageBox.Show("Arsa sahibi sistemde bulundu.");

                        try
                        {
                            NpgsqlCommand command2 = new NpgsqlCommand("insert into lands (title, price, city, county, area, neighborhood, release_date, property_type, island_no, parcel_no, threader_no, zoning_status, provision_for_floor, available_for_loan, swap, phone_number, explanation, land_owner, user_id)values(@title, @price, @city, @county, @area, @neighborhood, @release_date, @property_type, @island_no, @parcel_no, @threader_no, @zoning_status, @provision_for_floor, @available_for_loan, @swap, @phone_number, @explanation, @land_owner, @user_id)", conn);

                            //command2.Parameters.AddWithValue("@lands_id", lands_id);
                            command2.Parameters.AddWithValue("@title", textBox33.Text);
                            command2.Parameters.AddWithValue("@price", Convert.ToDouble(textBox32.Text));
                            command2.Parameters.AddWithValue("@city", comboBox37.Text);
                            command2.Parameters.AddWithValue("@county", comboBox36.Text);
                            command2.Parameters.AddWithValue("@area", comboBox35.Text);
                            command2.Parameters.AddWithValue("@neighborhood", comboBox34.Text);
                            command2.Parameters.AddWithValue("@release_date", Convert.ToDateTime(monthCalendar3.SelectionRange.Start.ToShortDateString()));
                            // emlak_tipi;
                            command2.Parameters.AddWithValue("@property_type", comboBox33.Text);
                            // Ada No 
                            command2.Parameters.AddWithValue("@island_no", Convert.ToInt32(textBox31.Text));
                            // Parsel No
                            command2.Parameters.AddWithValue("@parcel_no", Convert.ToInt32(textBox30.Text));
                            // Pafta No
                            command2.Parameters.AddWithValue("@threader_no", Convert.ToInt32(textBox29.Text));

                           
                            //İmar Durumu 0-yok , 1-var                            
                            if (comboBox31.SelectedIndex == 0)
                            {
                                command2.Parameters.AddWithValue("@zoning_status", 0);
                            }
                            else
                            {
                                command2.Parameters.AddWithValue("@zoning_status", 1);
                            }

                            // Kat Karşılığı mı? 0-Hayır , 1-Evet
                            if (comboBox30.SelectedIndex == 0)
                            {
                                command2.Parameters.AddWithValue("@provision_for_floor", 0);
                            }
                            else
                            {
                                command2.Parameters.AddWithValue("@provision_for_floor", 1);
                            }
                           
                            // available_for_loan Krediye uygun 0-Hayır 1-Evet
                            if (comboBox27.SelectedIndex == 0)
                            {
                                command2.Parameters.AddWithValue("@available_for_loan", 0);
                            }
                            else
                            {
                                command2.Parameters.AddWithValue("@available_for_loan", 1);
                            }

                            // swap Takas Durumu 0-Hayır 1-Evet
                            if (comboBox26.SelectedIndex == 0)
                            {
                                command2.Parameters.AddWithValue("@swap", 0);
                            }
                            else
                            {
                                command2.Parameters.AddWithValue("@swap", 1);
                            }

                            // phone_number
                            command2.Parameters.AddWithValue("@phone_number", maskedTextBox6.Text);
                            // explanation
                            command2.Parameters.AddWithValue("@explanation", textBox23.Text);
                            // land_owner
                            command2.Parameters.AddWithValue("@land_owner", Convert.ToInt64(maskedTextBox5.Text));
                            // user_id
                            command2.Parameters.AddWithValue("@user_id", id);
                            command2.ExecuteNonQuery();
                            MessageBox.Show("İLAN YAYINLANDI.");
                            panel1.Visible = false;
                            panel6.Visible = false;
                        }
                        catch (Exception ex)
                        {
                            // something went wrong, and you wanna know why
                            MessageBox.Show("Error:" + ex.ToString(), "something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            conn.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Emlakçı sahibi sistemde bulunamadı.Lütfen ilk önce emlak sahibini sisteme ekleyniz.");
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

        private void button8_Click(object sender, EventArgs e)
        {
            panel10.Visible = false;
            panel4.Visible = false;
            panel8.Visible = false;
            panel7.Visible = true;            
            panel7.Width = 900;
            panel7.Height = 36;
            comboBox47.Items.Clear();
            comboBox47.Text = "";
            try
            {
                conn.Open();
                string sql = "SELECT * FROM lands where user_id= " + id + "order by lands_id";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {
                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox47.Items.Add(reader[0].ToString());

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

        private void comboBox47_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel7.Height = 560;
            comboBox43.Items.Clear();
            comboBox43.Text = "";
            comboBox42.Items.Clear();
            comboBox42.Text = "";
            comboBox41.Items.Clear();
            comboBox41.Text = "";
            comboBox40.Items.Clear();
            comboBox40.Text = "";
            panel8.Visible = true;
            try
            {
                conn.Open();
                string sql = "SELECT * FROM lands where lands_id= " + Convert.ToInt32(comboBox47.Text);
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

                        /// Ev Sahibi TC
                        maskedTextBox7.Text = reader[18].ToString();
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

        private void comboBox43_Click(object sender, EventArgs e)
        {
            comboBox43.Items.Clear();
            comboBox43.Text = "";
            comboBox42.Items.Clear();
            comboBox42.Text = "";
            comboBox41.Items.Clear();
            comboBox41.Text = "";
            comboBox40.Items.Clear();
            comboBox40.Text = "";
            try
            {
                conn.Open();
                string sql = "SELECT * FROM cities ";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox43.Items.Add(reader[2].ToString());
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

        private void comboBox42_Click(object sender, EventArgs e)
        {
            comboBox42.Items.Clear();
            comboBox42.Text = "";
            comboBox41.Items.Clear();
            comboBox41.Text = "";
            comboBox40.Items.Clear();
            comboBox40.Text = "";
            secilmisil = comboBox43.SelectedIndex + 1;
            try
            {
                conn.Open();
                string sql = "SELECT * FROM counties where cityid= " + secilmisil;
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox42.Items.Add(reader[2].ToString());
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

        private void comboBox41_Click(object sender, EventArgs e)
        {
            comboBox41.Items.Clear();
            comboBox41.Text = "";
            comboBox40.Items.Clear();
            comboBox40.Text = "";
            try
            {
                conn.Open();
                string sql = "SELECT countyid FROM counties where countyname= '" + comboBox42.Text + "'";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        secilmisilce = Convert.ToInt32(reader[0].ToString());

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

            try
            {
                conn.Open();
                string sql = "SELECT * FROM areas where countyid= " + secilmisilce;
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox41.Items.Add(reader[2].ToString());

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

        private void comboBox40_Click(object sender, EventArgs e)
        {
            comboBox40.Items.Clear();
            comboBox40.Text = "";

            try
            {
                conn.Open();
                string sql = "SELECT areaid FROM areas where areaname= '" + comboBox41.Text + "'";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        secilmisbolge = Convert.ToInt32(reader[0].ToString());

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

            try
            {
                conn.Open();
                string sql = "SELECT * FROM neighborhoods where areaid= " + secilmisbolge;
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox40.Items.Add(reader[2].ToString());

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

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox34.Text == "")
            {
                MessageBox.Show("LÜTFEN BAŞLIK GİRİNİZ.");
            }
            else if (textBox28.Text == "")
            {
                MessageBox.Show("LÜTFEN FİYAT GİRİNİZ.");
            }
            else if (comboBox43.Text == "")
            {
                MessageBox.Show("LÜTFEN İL SEÇİNİZ.");
            }
            else if (comboBox42.Text == "")
            {
                MessageBox.Show("LÜTFEN İLÇE SEÇİNİZ.");
            }
            else if (comboBox41.Text == "")
            {
                MessageBox.Show("LÜTFEN BÖLGE SEÇİNİZ.");
            }
            else if (comboBox40.Text == "")
            {
                MessageBox.Show("LÜTFEN MAHALLE SEÇİNİZ.");
            }
            else if (textBox27.Text == "")
            {
                MessageBox.Show("LÜTFEN ADA NO GİRİNİZ.");
            }
            else if (textBox26.Text == "")
            {
                MessageBox.Show("LÜTFEN PARSEL NO GİRİNİZ.");
            }
            else if (textBox25.Text == "")
            {
                MessageBox.Show("LÜTFEN PAFTA NO GİRİNİZ.");
            }            
            else if (maskedTextBox8.Text == "(   )    -  -")
            {
                MessageBox.Show("LÜTFEN TELEFON NO GİRİNİZ.");
            }
            else if (textBox24.Text == "")
            {
                MessageBox.Show("LÜTFEN AÇIKLAMA GİRİNİZ.");
            }
            else if (maskedTextBox7.Text == "")
            {
                MessageBox.Show("LÜTFEN ARSA SAHİBİ TC NO GİRİNİZ.");
            }
            else
            {
                try
                {
                    conn.Open();
                    sql = @"select * from owner_tc_check(:_tcno)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("_tcno", Convert.ToInt64(maskedTextBox7.Text));
                    int result = (int)cmd.ExecuteScalar();
                    if (result == 1)
                    {
                        MessageBox.Show("Arsa sahibi sistemde bulundu.");

                        try
                        {
                            NpgsqlCommand command2 = new NpgsqlCommand("UPDATE lands SET title=@title, price=@price, city=@city, county=@county, area=@area, neighborhood=@neighborhood, release_date=@release_date, property_type=@property_type, island_no=@island_no, parcel_no=@parcel_no, threader_no=@threader_no, zoning_status=@zoning_status, provision_for_floor=@provision_for_floor, available_for_loan=@available_for_loan, swap=@swap, phone_number=@phone_number, explanation=@explanation, land_owner=@land_owner, user_id=@user_id where lands_id=@lands_id", conn);
                            command2.Parameters.AddWithValue("@lands_id", Convert.ToInt32(comboBox47.Text));
                            command2.Parameters.AddWithValue("@title", textBox34.Text);
                            command2.Parameters.AddWithValue("@price", Convert.ToDouble(textBox28.Text));
                            command2.Parameters.AddWithValue("@city", comboBox43.Text);
                            command2.Parameters.AddWithValue("@county", comboBox42.Text);
                            command2.Parameters.AddWithValue("@area", comboBox41.Text);
                            command2.Parameters.AddWithValue("@neighborhood", comboBox40.Text);
                            command2.Parameters.AddWithValue("@release_date", Convert.ToDateTime(monthCalendar4.SelectionRange.Start.ToShortDateString()));
                            // emlak_tipi;
                            command2.Parameters.AddWithValue("@property_type", comboBox39.Text);
                            // ada no
                            command2.Parameters.AddWithValue("@island_no", Convert.ToInt32(textBox27.Text));
                            // parsel no
                            command2.Parameters.AddWithValue("@parcel_no", Convert.ToInt32(textBox26.Text));
                            // pafta no
                            command2.Parameters.AddWithValue("@threader_no", Convert.ToInt32(textBox25.Text));                            

                            //imar durumu                           
                            if (comboBox38.SelectedIndex == 0)
                            {
                                command2.Parameters.AddWithValue("@zoning_status", 0);
                            }
                            else
                            {
                                command2.Parameters.AddWithValue("@zoning_status", 1);
                            }

                            // kat karşılığı
                            if (comboBox32.SelectedIndex == 0)
                            {
                                command2.Parameters.AddWithValue("@provision_for_floor", 0);
                            }
                            else
                            {
                                command2.Parameters.AddWithValue("@provision_for_floor", 1);
                            }

                            // krediye uygun
                            if (comboBox29.SelectedIndex == 0)
                            {
                                command2.Parameters.AddWithValue("@available_for_loan", 0);
                            }
                            else
                            {
                                command2.Parameters.AddWithValue("@available_for_loan", 1);
                            }

                            // takas
                            if (comboBox28.SelectedIndex == 0)
                            {
                                command2.Parameters.AddWithValue("@swap", 0);
                            }
                            else
                            {
                                command2.Parameters.AddWithValue("@swap", 1);
                            }                          
                            // phone_number
                            command2.Parameters.AddWithValue("@phone_number", maskedTextBox8.Text);
                            // explanation
                            command2.Parameters.AddWithValue("@explanation", textBox24.Text);
                            // land_owner
                            command2.Parameters.AddWithValue("@land_owner", Convert.ToInt64(maskedTextBox7.Text));
                            // user_id
                            command2.Parameters.AddWithValue("@user_id", id);
                            command2.ExecuteNonQuery();
                            MessageBox.Show("İLAN GÜNCELLENDİ.");
                            panel8.Visible = false;
                            panel7.Visible = false;
                            panel3.Visible = false;
                        }
                        catch (Exception ex)
                        {
                            // something went wrong, and you wanna know why
                            MessageBox.Show("Error:" + ex.ToString(), "something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            conn.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Arsa sahibi sistemde bulunamadı.Lütfen ilk önce arsa sahibini sisteme ekleyniz.");
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

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                NpgsqlCommand command = new NpgsqlCommand("Delete from lands where lands_id=@lands_id", conn);
                command.Parameters.AddWithValue("@lands_id", Convert.ToInt32(comboBox47.Text));
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("İLAN SİLİNDİ.");
                panel8.Visible = false;
                panel7.Visible = false;
                panel3.Visible = false;
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
            panel2.Visible = false;
            panel6.Visible = false;
            panel9.Visible = true;

            panel9.Width = 910;
            panel9.Height = 690;

            textBox45.Text = "";
            textBox44.Text = "";
            textBox43.Text = "";
            textBox42.Text = "";
            textBox40.Text = "";
            textBox36.Text = "";
            textBox35.Text = "";

            maskedTextBox10.Text = "";
            maskedTextBox9.Text = "";


            comboBox56.Items.Clear();
            comboBox55.Items.Clear();
            comboBox54.Items.Clear();
            comboBox53.Items.Clear();

            comboBox56.Text = "";
            comboBox55.Text = "";
            comboBox54.Text = "";
            comboBox53.Text = "";



            comboBox52.SelectedIndex = 0;
            comboBox51.SelectedIndex = 0;
            comboBox48.SelectedIndex = 0;
            comboBox45.SelectedIndex = 0;
            comboBox44.SelectedIndex = 0;

            try
            {
                conn.Open();
                string sql = "SELECT * FROM cities ";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox56.Items.Add(reader[2].ToString());
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

        private void comboBox56_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox55.Items.Clear();
            comboBox55.Text = "";
            comboBox54.Items.Clear();
            comboBox54.Text = "";
            comboBox53.Items.Clear();
            comboBox53.Text = "";

            secilmisil = comboBox56.SelectedIndex + 1;
            try
            {
                conn.Open();
                string sql = "SELECT * FROM counties where cityid= " + secilmisil;
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox55.Items.Add(reader[2].ToString());
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

        private void comboBox55_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox54.Items.Clear();
            comboBox54.Text = "";
            comboBox53.Items.Clear();
            comboBox53.Text = "";

            try
            {
                conn.Open();
                string sql = "SELECT countyid FROM counties where countyname= '" + comboBox55.Text + "'";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        secilmisilce = Convert.ToInt32(reader[0].ToString());

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

            try
            {
                conn.Open();
                string sql = "SELECT * FROM areas where countyid= " + secilmisilce;
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox54.Items.Add(reader[2].ToString());

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

        private void comboBox54_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox53.Items.Clear();
            comboBox53.Text = "";

            try
            {
                conn.Open();
                string sql = "SELECT areaid FROM areas where areaname= '" + comboBox54.Text + "'";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        secilmisbolge = Convert.ToInt32(reader[0].ToString());

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

            try
            {
                conn.Open();
                string sql = "SELECT * FROM neighborhoods where areaid= " + secilmisbolge;
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox53.Items.Add(reader[2].ToString());

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

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox45.Text == "")
            {
                MessageBox.Show("LÜTFEN BAŞLIK GİRİNİZ.");
            }
            else if (textBox44.Text == "")
            {
                MessageBox.Show("LÜTFEN FİYAT GİRİNİZ.");
            }
            else if (comboBox56.Text == "")
            {
                MessageBox.Show("LÜTFEN İL SEÇİNİZ.");
            }
            else if (comboBox55.Text == "")
            {
                MessageBox.Show("LÜTFEN İLÇE SEÇİNİZ.");
            }
            else if (comboBox54.Text == "")
            {
                MessageBox.Show("LÜTFEN BÖLGE SEÇİNİZ.");
            }
            else if (comboBox53.Text == "")
            {
                MessageBox.Show("LÜTFEN MAHALLE SEÇİNİZ.");
            }
            else if (textBox43.Text == "")
            {
                MessageBox.Show("LÜTFEN BRÜT ALAN GİRİNİZ.");
            }
            else if (textBox42.Text == "")
            {
                MessageBox.Show("LÜTFEN NET ALAN GİRİNİZ.");
            }
            else if (textBox40.Text == "")
            {
                MessageBox.Show("LÜTFEN BİNA YAŞI GİRİNİZ.");
            }
            else if (textBox36.Text == "")
            {
                MessageBox.Show("LÜTFEN AİDAT GİRİNİZ.");
            }
            else if (maskedTextBox10.Text == "(   )    -  -")
            {
                MessageBox.Show("LÜTFEN TELEFON NO GİRİNİZ.");
            }
            else if (textBox35.Text == "")
            {
                MessageBox.Show("LÜTFEN AÇIKLAMA GİRİNİZ.");
            }
            else if (maskedTextBox9.Text == "")
            {
                MessageBox.Show("LÜTFEN EV SAHİBİ TC NO GİRİNİZ.");
            }
            else
            {
                try
                {
                    conn.Open();
                    sql = @"select * from owner_tc_check(:_tcno)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("_tcno", Convert.ToInt64(maskedTextBox9.Text));
                    int result = (int)cmd.ExecuteScalar();
                    if (result == 1)
                    {
                        MessageBox.Show("Dükkan sahibi sistemde bulundu.");

                        try
                        {
                            NpgsqlCommand command2 = new NpgsqlCommand("insert into stores ( title, price, city, county, area, neighborhood, release_date, property_type, gross, clear, building_age, heating, using_status, dues, available_for_loan, swap, phone_number, explanation, store_owner, user_id)values(@title, @price, @city, @county, @area, @neighborhood, @release_date, @property_type, @gross, @clear, @building_age, @heating, @using_status, @dues, @available_for_loan, @swap, @phone_number, @explanation, @store_owner, @user_id)", conn);

                            //command2.Parameters.AddWithValue("@homes_id", home_id);
                            command2.Parameters.AddWithValue("@title", textBox45.Text);
                            command2.Parameters.AddWithValue("@price", Convert.ToDouble(textBox44.Text));
                            command2.Parameters.AddWithValue("@city", comboBox56.Text);
                            command2.Parameters.AddWithValue("@county", comboBox55.Text);
                            command2.Parameters.AddWithValue("@area", comboBox54.Text);
                            command2.Parameters.AddWithValue("@neighborhood", comboBox53.Text);
                            command2.Parameters.AddWithValue("@release_date", Convert.ToDateTime(monthCalendar5.SelectionRange.Start.ToShortDateString()));
                            // emlak_tipi;
                            command2.Parameters.AddWithValue("@property_type", comboBox52.Text);
                            // brüt
                            command2.Parameters.AddWithValue("@gross", Convert.ToInt32(textBox43.Text));
                            // net
                            command2.Parameters.AddWithValue("@clear", Convert.ToInt32(textBox42.Text));
                           
                            // building_age
                            command2.Parameters.AddWithValue("@building_age", Convert.ToInt32(textBox40.Text));                            
                            // heating
                            command2.Parameters.AddWithValue("@heating", comboBox51.Text);                      
                            
                            // using_status Kullanım Durumu 0-BOŞ , 1-DOLU
                            if (comboBox48.SelectedIndex == 0)
                            {
                                command2.Parameters.AddWithValue("@using_status", 0);
                            }
                            else
                            {
                                command2.Parameters.AddWithValue("@using_status", 1);
                            }                            
                            // dues Aidat
                            command2.Parameters.AddWithValue("@dues", Convert.ToDouble(textBox36.Text));
                            // available_for_loan Krediye uygun 0-Hayır 1-Evet
                            if (comboBox45.SelectedIndex == 0)
                            {
                                command2.Parameters.AddWithValue("@available_for_loan", 0);
                            }
                            else
                            {
                                command2.Parameters.AddWithValue("@available_for_loan", 1);
                            }
                            // swap Takas Durumu 0-Hayır 1-Evet
                            if (comboBox44.SelectedIndex == 0)
                            {
                                command2.Parameters.AddWithValue("@swap", 0);
                            }
                            else
                            {
                                command2.Parameters.AddWithValue("@swap", 1);
                            }
                            // phone_number
                            command2.Parameters.AddWithValue("@phone_number", maskedTextBox10.Text);
                            // explanation
                            command2.Parameters.AddWithValue("@explanation", textBox35.Text);
                            // store_owner
                            command2.Parameters.AddWithValue("@store_owner", Convert.ToInt64(maskedTextBox9.Text));
                            // user_id
                            command2.Parameters.AddWithValue("@user_id", id);
                            command2.ExecuteNonQuery();
                            MessageBox.Show("İLAN YAYINLANDI.");
                            panel1.Visible = false;
                            panel9.Visible = false;
                        }
                        catch (Exception ex)
                        {
                            // something went wrong, and you wanna know why
                            MessageBox.Show("Error:" + ex.ToString(), "something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            conn.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dükkan sahibi sistemde bulunamadı.Lütfen ilk önce dükkan sahibini sisteme ekleyniz.");
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

        private void button7_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
            panel4.Visible = false;
            panel11.Visible = false;
            panel10.Visible = true;
            panel10.Width = 900;
            panel10.Height = 36;
            comboBox66.Items.Clear();
            comboBox66.Text = "";
            try
            {
                conn.Open();
                string sql = "SELECT * FROM stores where user_id= " + id + "order by stores_id";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {
                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox66.Items.Add(reader[0].ToString());

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

        private void comboBox66_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel10.Height = 600;
            comboBox65.Items.Clear();
            comboBox65.Text = "";
            comboBox64.Items.Clear();
            comboBox64.Text = "";
            comboBox63.Items.Clear();
            comboBox63.Text = "";
            comboBox62.Items.Clear();
            comboBox62.Text = "";
            panel11.Visible = true;
            try
            {
                conn.Open();
                string sql = "SELECT * FROM stores where stores_id= " + Convert.ToInt32(comboBox66.Text);
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

                        /// Ev Sahibi TC
                        maskedTextBox11.Text = reader[19].ToString();
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

        private void comboBox65_Click(object sender, EventArgs e)
        {
            comboBox65.Items.Clear();
            comboBox65.Text = "";
            comboBox64.Items.Clear();
            comboBox64.Text = "";
            comboBox63.Items.Clear();
            comboBox63.Text = "";
            comboBox62.Items.Clear();
            comboBox62.Text = "";
            try
            {
                conn.Open();
                string sql = "SELECT * FROM cities ";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox65.Items.Add(reader[2].ToString());
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

        private void comboBox64_Click(object sender, EventArgs e)
        {
            comboBox64.Items.Clear();
            comboBox64.Text = "";
            comboBox63.Items.Clear();
            comboBox63.Text = "";
            comboBox62.Items.Clear();
            comboBox62.Text = "";
            secilmisil = comboBox65.SelectedIndex + 1;
            try
            {
                conn.Open();
                string sql = "SELECT * FROM counties where cityid= " + secilmisil;
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox64.Items.Add(reader[2].ToString());
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

        private void comboBox63_Click(object sender, EventArgs e)
        {
            comboBox63.Items.Clear();
            comboBox63.Text = "";
            comboBox62.Items.Clear();
            comboBox62.Text = "";
            try
            {
                conn.Open();
                string sql = "SELECT countyid FROM counties where countyname= '" + comboBox64.Text + "'";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        secilmisilce = Convert.ToInt32(reader[0].ToString());

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

            try
            {
                conn.Open();
                string sql = "SELECT * FROM areas where countyid= " + secilmisilce;
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox63.Items.Add(reader[2].ToString());

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

        private void comboBox62_Click(object sender, EventArgs e)
        {
            comboBox62.Items.Clear();
            comboBox62.Text = "";

            try
            {
                conn.Open();
                string sql = "SELECT areaid FROM areas where areaname= '" + comboBox63.Text + "'";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        secilmisbolge = Convert.ToInt32(reader[0].ToString());

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

            try
            {
                conn.Open();
                string sql = "SELECT * FROM neighborhoods where areaid= " + secilmisbolge;
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox62.Items.Add(reader[2].ToString());

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

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox52.Text == "")
            {
                MessageBox.Show("LÜTFEN BAŞLIK GİRİNİZ.");
            }
            else if (textBox51.Text == "")
            {
                MessageBox.Show("LÜTFEN FİYAT GİRİNİZ.");
            }
            else if (comboBox65.Text == "")
            {
                MessageBox.Show("LÜTFEN İL SEÇİNİZ.");
            }
            else if (comboBox64.Text == "")
            {
                MessageBox.Show("LÜTFEN İLÇE SEÇİNİZ.");
            }
            else if (comboBox63.Text == "")
            {
                MessageBox.Show("LÜTFEN BÖLGE SEÇİNİZ.");
            }
            else if (comboBox62.Text == "")
            {
                MessageBox.Show("LÜTFEN MAHALLE SEÇİNİZ.");
            }
            else if (textBox50.Text == "")
            {
                MessageBox.Show("LÜTFEN BRÜT ALAN GİRİNİZ.");
            }
            else if (textBox49.Text == "")
            {
                MessageBox.Show("LÜTFEN NET ALAN GİRİNİZ.");
            }
            else if (textBox47.Text == "")
            {
                MessageBox.Show("LÜTFEN BİNA YAŞI GİRİNİZ.");
            }
            else if (textBox38.Text == "")
            {
                MessageBox.Show("LÜTFEN AİDAT GİRİNİZ.");
            }
            else if (maskedTextBox12.Text == "(   )    -  -")
            {
                MessageBox.Show("LÜTFEN TELEFON NO GİRİNİZ.");
            }
            else if (textBox37.Text == "")
            {
                MessageBox.Show("LÜTFEN AÇIKLAMA GİRİNİZ.");
            }
            else if (maskedTextBox11.Text == "")
            {
                MessageBox.Show("LÜTFEN EV SAHİBİ TC NO GİRİNİZ.");
            }
            else
            {
                try
                {
                    conn.Open();
                    sql = @"select * from owner_tc_check(:_tcno)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("_tcno", Convert.ToInt64(maskedTextBox11.Text));
                    int result = (int)cmd.ExecuteScalar();
                    if (result == 1)
                    {
                        MessageBox.Show("Dükkan sahibi sistemde bulundu.");

                        try
                        {
                            NpgsqlCommand command2 = new NpgsqlCommand("UPDATE stores SET title=@title, price=@price, city=@city, county=@county, area=@area, neighborhood=@neighborhood, release_date=@release_date, property_type=@property_type, gross=@gross, clear=@clear, building_age=@building_age, heating=@heating, using_status=@using_status, dues=@dues, available_for_loan=@available_for_loan, swap=@swap, phone_number=@phone_number, explanation=@explanation, store_owner=@store_owner, user_id=@user_id where stores_id=@stores_id", conn);
                            command2.Parameters.AddWithValue("@stores_id", Convert.ToInt32(comboBox66.Text));
                            command2.Parameters.AddWithValue("@title", textBox52.Text);
                            command2.Parameters.AddWithValue("@price", Convert.ToDouble(textBox51.Text));
                            command2.Parameters.AddWithValue("@city", comboBox65.Text);
                            command2.Parameters.AddWithValue("@county", comboBox64.Text);
                            command2.Parameters.AddWithValue("@area", comboBox63.Text);
                            command2.Parameters.AddWithValue("@neighborhood", comboBox62.Text);
                            command2.Parameters.AddWithValue("@release_date", Convert.ToDateTime(monthCalendar6.SelectionRange.Start.ToShortDateString()));
                            // emlak_tipi;
                            command2.Parameters.AddWithValue("@property_type", comboBox61.Text);
                            // brüt
                            command2.Parameters.AddWithValue("@gross", Convert.ToInt32(textBox50.Text));
                            // net
                            command2.Parameters.AddWithValue("@clear", Convert.ToInt32(textBox49.Text));                            
                            // building_age
                            command2.Parameters.AddWithValue("@building_age", Convert.ToInt32(textBox47.Text));                            
                            // heating
                            command2.Parameters.AddWithValue("@heating", comboBox60.Text);                         
                                                       
                            // using_status Kullanım Durumu 0-BOŞ , 1-DOLU
                            if (comboBox57.SelectedIndex == 0)
                            {
                                command2.Parameters.AddWithValue("@using_status", 0);
                            }
                            else
                            {
                                command2.Parameters.AddWithValue("@using_status", 1);
                            }
                            
                            // dues Aidat
                            command2.Parameters.AddWithValue("@dues", Convert.ToDouble(textBox38.Text));

                            // available_for_loan Krediye uygun 0-Hayır 1-Evet
                            if (comboBox49.SelectedIndex == 0)
                            {
                                command2.Parameters.AddWithValue("@available_for_loan", 0);
                            }
                            else
                            {
                                command2.Parameters.AddWithValue("@available_for_loan", 1);
                            }
                            // swap Takas Durumu 0-Hayır 1-Evet
                            if (comboBox46.SelectedIndex == 0)
                            {
                                command2.Parameters.AddWithValue("@swap", 0);
                            }
                            else
                            {
                                command2.Parameters.AddWithValue("@swap", 1);
                            }
                            // phone_number
                            command2.Parameters.AddWithValue("@phone_number", maskedTextBox12.Text);
                            // explanation
                            command2.Parameters.AddWithValue("@explanation", textBox37.Text);
                            // store_owner
                            command2.Parameters.AddWithValue("@store_owner", Convert.ToInt64(maskedTextBox11.Text));
                            // user_id
                            command2.Parameters.AddWithValue("@user_id", id);
                            command2.ExecuteNonQuery();
                            MessageBox.Show("İLAN GÜNCELLENDİ.");
                            panel11.Visible = false;
                            panel10.Visible = false;
                            panel3.Visible = false;
                        }
                        catch (Exception ex)
                        {
                            // something went wrong, and you wanna know why
                            MessageBox.Show("Error:" + ex.ToString(), "something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            conn.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dükkan sahibi sistemde bulunamadı.Lütfen ilk önce dükkan sahibini sisteme ekleyniz.");
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

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                NpgsqlCommand command = new NpgsqlCommand("Delete from stores where stores_id=@stores_id", conn);
                command.Parameters.AddWithValue("@stores_id", Convert.ToInt32(comboBox66.Text));
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("İLAN SİLİNDİ.");
                panel11.Visible = false;
                panel10.Visible = false;
                panel3.Visible = false;
            }
            catch (Exception ex)
            {
                // something went wrong, and you wanna know why
                MessageBox.Show("Error:" + ex.ToString(), "something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            panel13.Visible = false;
            panel1.Visible = false;
            panel3.Visible = false;
            panel2.Visible = false;
            panel6.Visible = false;
            panel9.Visible = false;
            panel4.Visible = false;
            panel7.Visible = false;
            panel10.Visible = false;
            panel5.Visible = false;
            panel8.Visible = false;
            panel11.Visible = false;
            panel12.Visible = true;
            try
            {
                conn.Open();
                string sql = "SELECT * FROM users where id= " + id;
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                using (command)
                {
                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        username= reader[1].ToString();
                        textBox39.Text = reader[1].ToString();
                        textBox41.Text = reader[2].ToString();
                        textBox46.Text = reader[3].ToString();
                        textBox48.Text = reader[4].ToString();
                        maskedTextBox13.Text = reader[5].ToString();
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

        private void button19_Click(object sender, EventArgs e)
        {
            if (textBox39.Text == "")
            {
                MessageBox.Show("LÜTFEN KULLANICI ADI GİRİNİZ.");
            }
            else if (textBox41.Text == "")
            {
                MessageBox.Show("LÜTFEN ŞİFRE GİRİNİZ.");
            }
            else if (textBox46.Text == "")
            {
                MessageBox.Show("LÜTFEN AD GİRİNİZ.");
            }
            else if (textBox48.Text == "")
            {
                MessageBox.Show("LÜTFEN SOYAD GİRİNİZ.");
            }
            else if (maskedTextBox13.Text == "")
            {
                MessageBox.Show("LÜTFEN TELEFON GİRİNİZ.");
            }
            else
            { 
                conn.Open();               
                if (username==textBox39.Text)
                {
                    try
                    {
                        
                        NpgsqlCommand command2 = new NpgsqlCommand("UPDATE users SET username=@username, passwords=@passwords, namess=@namess, surname=@surname, phone_number=@phone_number where id=@id", conn);
                        command2.Parameters.AddWithValue("@id", id);
                        command2.Parameters.AddWithValue("@username", textBox39.Text);
                        command2.Parameters.AddWithValue("@passwords", textBox41.Text);
                        command2.Parameters.AddWithValue("@namess", textBox46.Text);
                        command2.Parameters.AddWithValue("@surname", textBox48.Text);
                        command2.Parameters.AddWithValue("@phone_number", maskedTextBox13.Text);
                        command2.ExecuteNonQuery();
                        MessageBox.Show("BİLGİLERİNİZ GÜNCELLENDİ.");
                        
                        panel12.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        // something went wrong, and you wanna know why
                        MessageBox.Show("Error:" + ex.ToString(), "something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        conn.Close();
                    }
                }
                else
                {
                    try
                    {
                       
                        sql = @"select * from username_check(:_username)";
                        cmd = new NpgsqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("_username", textBox39.Text);
                        int result = (int)cmd.ExecuteScalar();
                        if (result == 1)
                        {
                            MessageBox.Show("Kullanıcı adı başka birisi tarafından  kullanılıyor.Lütfen başka bir kullanıcı adı giriniz.");
                           
                        }                         
                        else
                        {
                            try
                            {
                                
                                NpgsqlCommand command2 = new NpgsqlCommand("UPDATE users SET username=@username, passwords=@passwords, namess=@namess, surname=@surname, phone_number=@phone_number where id=@id", conn);
                                command2.Parameters.AddWithValue("@id", id);
                                command2.Parameters.AddWithValue("@username", textBox39.Text);
                                command2.Parameters.AddWithValue("@passwords", textBox41.Text);
                                command2.Parameters.AddWithValue("@namess", textBox46.Text);
                                command2.Parameters.AddWithValue("@surname", textBox48.Text);
                                command2.Parameters.AddWithValue("@phone_number", maskedTextBox13.Text);
                                command2.ExecuteNonQuery();
                                MessageBox.Show("BİLGİLERİNİZ GÜNCELLENDİ.");
                                panel12.Visible = false;
                                
                            }
                            catch (Exception ex)
                            {
                                // something went wrong, and you wanna know why
                                MessageBox.Show("Error:" + ex.ToString(), "something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                conn.Close();
                            }
                            conn.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        // something went wrong, and you wanna know why
                        MessageBox.Show("Error:" + ex.ToString(), "something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       
                    }
                    
                } 
                conn.Close();
                
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            panel12.Visible = false;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (maskedTextBox14.Text == "")
            {
                MessageBox.Show("LÜTFEN TC NO GİRİNİZ.");
            }
            else if (textBox53.Text == "")
            {
                MessageBox.Show("LÜTFEN AD GİRİNİZ.");
            }
            else if (textBox54.Text == "")
            {
                MessageBox.Show("LÜTFEN SOYAD GİRİNİZ.");
            }
            else if (textBox55.Text == "")
            {
                MessageBox.Show("LÜTFEN MAİL GİRİNİZ.");
            }
            else if (maskedTextBox15.Text == "(   )    -  -")
            {
                MessageBox.Show("LÜTFEN TELEFON NO GİRİNİZ.");
            }
            
            else
            {
                try
                {
                    conn.Open();
                    sql = @"select * from owner_tc_check(:_tcno)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("_tcno", Convert.ToInt64(maskedTextBox14.Text));
                    int result = (int)cmd.ExecuteScalar();
                    if (result == 1)
                    {
                        MessageBox.Show("Bu TC NO'lu mal sahibi sistemde zaten kayıtlıdır.");
                      
                    }
                    else
                    {
                        try
                        {
                            NpgsqlCommand command2 = new NpgsqlCommand("insert into owners (owner_tc, owner_name, owner_surname, owner_mail, owner_phone)values(@owner_tc, @owner_name, @owner_surname, @owner_mail, @owner_phone)", conn);

                            //command2.Parameters.AddWithValue("@homes_id", home_id);
                            command2.Parameters.AddWithValue("@owner_tc",Convert.ToInt64(maskedTextBox14.Text));
                            command2.Parameters.AddWithValue("@owner_name", textBox53.Text);
                            command2.Parameters.AddWithValue("@owner_surname", comboBox54.Text);
                            command2.Parameters.AddWithValue("@owner_mail", comboBox55.Text);
                            command2.Parameters.AddWithValue("@owner_phone", maskedTextBox15.Text);                     
                            
                            command2.ExecuteNonQuery();
                            MessageBox.Show("Mal sahibi sisteme eklendi.");
                            panel1.Visible = false;
                            panel2.Visible = false;
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

        private void button21_Click(object sender, EventArgs e)
        {                      
            panel1.Visible = false;
            panel3.Visible = false;
            panel2.Visible = false;
            panel6.Visible = false;
            panel9.Visible = false;
            panel4.Visible = false;
            panel7.Visible = false;
            panel10.Visible = false;
            panel5.Visible = false;
            panel8.Visible = false;
            panel11.Visible = false;
            panel12.Visible = false;            
            panel13.Visible = true;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
