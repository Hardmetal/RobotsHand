using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace RobotsHand
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadBox();
        }

        public void loadBox()
        {
            comboBox1.Items.AddRange(portnames);
            comboBox1.Text = Properties.Settings.Default.port;
            textBox1.Text = Properties.Settings.Default.hand_base;
            textBox2.Text = Properties.Settings.Default.hand_shoulder;
            textBox3.Text = Properties.Settings.Default.hand_cubit;
            textBox4.Text = Properties.Settings.Default.hand_arm;
            textBox5.Text = Properties.Settings.Default.hand_turn;
            textBox6.Text = Properties.Settings.Default.hand_finger;
            textBox7.Text = Properties.Settings.Default.delay_time.ToString();
            numericUpDown1.Value = Properties.Settings.Default.a_min;
            numericUpDown2.Value = Properties.Settings.Default.a_max;
            numericUpDown3.Value = Properties.Settings.Default.b_min;
            numericUpDown4.Value = Properties.Settings.Default.b_max;
            numericUpDown5.Value = Properties.Settings.Default.c_min;
            numericUpDown6.Value = Properties.Settings.Default.c_max;
            numericUpDown7.Value = Properties.Settings.Default.d_min;
            numericUpDown8.Value = Properties.Settings.Default.d_max;
            numericUpDown9.Value = Properties.Settings.Default.e_min;
            numericUpDown10.Value = Properties.Settings.Default.e_max;
            numericUpDown11.Value = Properties.Settings.Default.f_min;
            numericUpDown12.Value = Properties.Settings.Default.f_max;
            comboBox2.Items.AddRange(chan);
            comboBox3.Items.AddRange(chan);
            comboBox4.Items.AddRange(chan);
            comboBox5.Items.AddRange(chan);
            comboBox6.Items.AddRange(chan);
            comboBox7.Items.AddRange(chan);
            comboBox2.Text = Properties.Settings.Default.ch_a;
            comboBox3.Text = Properties.Settings.Default.ch_b;
            comboBox4.Text = Properties.Settings.Default.ch_c;
            comboBox5.Text = Properties.Settings.Default.ch_d;
            comboBox6.Text = Properties.Settings.Default.ch_e;
            comboBox7.Text = Properties.Settings.Default.ch_f;

        }

        public string[] chan = {"a","b","c","d","e","f" };
        public string[] portnames = SerialPort.GetPortNames();
        public string selectedState = " ";
        public string Port { get; set; }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Port = comboBox1.SelectedItem.ToString();
            Properties.Settings.Default.port = Port;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            loadBox();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.hand_base = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.hand_shoulder = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.hand_cubit = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.hand_arm = textBox4.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.hand_turn = textBox5.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.hand_finger = textBox6.Text;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.delay_time = Convert.ToInt32(textBox7.Text);
        }

        private void numericUpDown12_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.f_max = Convert.ToInt32(numericUpDown12.Value);
        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.f_min = Convert.ToInt32(numericUpDown11.Value);
        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.e_max = Convert.ToInt32(numericUpDown10.Value);
        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.e_min = Convert.ToInt32(numericUpDown9.Value);
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.d_max = Convert.ToInt32(numericUpDown8.Value);
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.d_min = Convert.ToInt32(numericUpDown7.Value);
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.c_max = Convert.ToInt32(numericUpDown6.Value);
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.c_min = Convert.ToInt32(numericUpDown5.Value);
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.b_max = Convert.ToInt32(numericUpDown4.Value);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.b_min = Convert.ToInt32(numericUpDown3.Value);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.a_max = Convert.ToInt32(numericUpDown2.Value);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.a_min = Convert.ToInt32(numericUpDown1.Value);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ch_a = comboBox2.SelectedItem.ToString();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ch_b = comboBox3.SelectedItem.ToString();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ch_c = comboBox4.SelectedItem.ToString();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ch_d = comboBox5.SelectedItem.ToString();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ch_e = comboBox6.SelectedItem.ToString();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ch_f = comboBox7.SelectedItem.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = new System.Windows.Forms.DialogResult();
            result = MessageBox.Show("Ты уверен?\nПрограмма будет перезагружена", "Внимание",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                Properties.Settings.Default.port = null;
                Properties.Settings.Default.delay_time = 1000;
                Properties.Settings.Default.hand_base = "База";
                Properties.Settings.Default.hand_shoulder = "Плечо";
                Properties.Settings.Default.hand_cubit = "Локоть";
                Properties.Settings.Default.hand_arm = "Кисть";
                Properties.Settings.Default.hand_turn = "Наклон";
                Properties.Settings.Default.hand_finger = "Пальцы";
                Properties.Settings.Default.last_file = null;
                Properties.Settings.Default.a_max = 180;
                Properties.Settings.Default.b_max = 180;
                Properties.Settings.Default.c_max = 180;
                Properties.Settings.Default.d_max = 180;
                Properties.Settings.Default.e_max = 180;
                Properties.Settings.Default.f_max = 100;
                Properties.Settings.Default.a_min = 0;
                Properties.Settings.Default.b_min = 0;
                Properties.Settings.Default.c_min = 0;
                Properties.Settings.Default.d_min = 0;
                Properties.Settings.Default.e_min = 0;
                Properties.Settings.Default.f_min = 20;
                Properties.Settings.Default.ch_a = "a";
                Properties.Settings.Default.ch_b = "b";
                Properties.Settings.Default.ch_c = "c";
                Properties.Settings.Default.ch_d = "d";
                Properties.Settings.Default.ch_e = "e";
                Properties.Settings.Default.ch_f = "f";
                Properties.Settings.Default.Save();
                Application.Restart();
            }
        }
    }
    
}
