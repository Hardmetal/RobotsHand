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
using System.Threading;

namespace RobotsHand
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
            loadBox();
        }

        public void loadBox()
        {
            measure();
            label2.Text = Properties.Settings.Default.hand_base;
            label3.Text = Properties.Settings.Default.hand_shoulder;
            label4.Text = Properties.Settings.Default.hand_cubit;
            label5.Text = Properties.Settings.Default.hand_arm;
            label6.Text = Properties.Settings.Default.hand_turn;
            label7.Text = Properties.Settings.Default.hand_finger;
            angle_get();
            comboBox1.Items.AddRange(SerialPort.GetPortNames());
            comboBox1.Text = Properties.Settings.Default.port;
            Port = Properties.Settings.Default.port;
            label8.Text = "Загрузить ранее использованый файл: " + Properties.Settings.Default.last_file;
            openFileDialog1.Filter = "Файлы координат(*.crd)|*.crd|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Файлы координат(*.crd)|*.crd|All files(*.*)|*.*";
            Column_a.HeaderText = Properties.Settings.Default.hand_base;
            Column_b.HeaderText = Properties.Settings.Default.hand_shoulder;
            Column_c.HeaderText = Properties.Settings.Default.hand_cubit;
            Column_d.HeaderText = Properties.Settings.Default.hand_arm;
            Column_e.HeaderText = Properties.Settings.Default.hand_turn;
            Column_f.HeaderText = Properties.Settings.Default.hand_finger;
        }

        public void measure()
        {
            numericUpDown1.Maximum = Properties.Settings.Default.a_max;
            numericUpDown1.Minimum = Properties.Settings.Default.a_min;
            trackBar1.Maximum = Properties.Settings.Default.a_max;
            trackBar1.Minimum = Properties.Settings.Default.a_min;
            numericUpDown1.Value = (Properties.Settings.Default.a_min + Properties.Settings.Default.a_max) / 2;
            trackBar1.Value = (Properties.Settings.Default.a_min + Properties.Settings.Default.a_max) / 2;
            //
            numericUpDown2.Maximum = Properties.Settings.Default.b_max;
            numericUpDown2.Minimum = Properties.Settings.Default.b_min;
            trackBar2.Maximum = Properties.Settings.Default.b_max;
            trackBar2.Minimum = Properties.Settings.Default.b_min;
            numericUpDown2.Value = (Properties.Settings.Default.b_min + Properties.Settings.Default.b_max) / 2;
            trackBar2.Value = (Properties.Settings.Default.b_min + Properties.Settings.Default.b_max) / 2;
            //
            numericUpDown3.Maximum = Properties.Settings.Default.c_max;
            numericUpDown3.Minimum = Properties.Settings.Default.c_min;
            trackBar3.Maximum = Properties.Settings.Default.c_max;
            trackBar3.Minimum = Properties.Settings.Default.c_min;
            numericUpDown3.Value = (Properties.Settings.Default.c_min + Properties.Settings.Default.c_max) / 2;
            trackBar3.Value = (Properties.Settings.Default.c_min + Properties.Settings.Default.c_max) / 2;
            //
            numericUpDown4.Maximum = Properties.Settings.Default.d_max;
            numericUpDown4.Minimum = Properties.Settings.Default.d_min;
            trackBar4.Maximum = Properties.Settings.Default.d_max;
            trackBar4.Minimum = Properties.Settings.Default.d_min;
            numericUpDown4.Value = (Properties.Settings.Default.d_min + Properties.Settings.Default.d_max) / 2;
            trackBar4.Value = (Properties.Settings.Default.d_min + Properties.Settings.Default.d_max) / 2;
            //
            numericUpDown5.Maximum = Properties.Settings.Default.e_max;
            numericUpDown5.Minimum = Properties.Settings.Default.e_min;
            trackBar5.Maximum = Properties.Settings.Default.e_max;
            trackBar5.Minimum = Properties.Settings.Default.e_min;
            numericUpDown5.Value = (Properties.Settings.Default.e_min + Properties.Settings.Default.e_max) / 2;
            trackBar5.Value = (Properties.Settings.Default.e_min + Properties.Settings.Default.e_max) / 2;
            //
            numericUpDown6.Maximum = Properties.Settings.Default.f_max;
            numericUpDown6.Minimum = Properties.Settings.Default.f_min;
            trackBar6.Maximum = Properties.Settings.Default.f_max;
            trackBar6.Minimum = Properties.Settings.Default.f_min;
            numericUpDown6.Value = (Properties.Settings.Default.f_min + Properties.Settings.Default.f_max) / 2;
            trackBar6.Value = (Properties.Settings.Default.f_min + Properties.Settings.Default.f_max) / 2;

        }

        public string ch_a = Properties.Settings.Default.ch_a;
        public string ch_b = Properties.Settings.Default.ch_b;
        public string ch_c = Properties.Settings.Default.ch_c;
        public string ch_d = Properties.Settings.Default.ch_d;
        public string ch_e = Properties.Settings.Default.ch_e;
        public string ch_f = Properties.Settings.Default.ch_f;

        public int[] angle = new int[6];

        bool handler = false;

        public string Port { get; set; }
        /// <summary>
        /// Открывает порт
        /// </summary>
        private SerialPort OpenPort()
        {
            SerialPort sPort;
            sPort = new SerialPort();
            sPort.PortName = Port;
            sPort.WriteTimeout = 500; sPort.ReadTimeout = 3000;
            sPort.BaudRate = 115200;
            sPort.Parity = Parity.None;
            sPort.DataBits = 8;
            sPort.StopBits = StopBits.One;
            sPort.Handshake = Handshake.None;
            sPort.DtrEnable = false;
            sPort.RtsEnable = false;
            sPort.NewLine = System.Environment.NewLine;
            sPort.Open();
            return sPort;
        }

        private void OnKeyDownHandler(object sender, EventArgs e)
        {

        }

        private void angle_get()
        {
            angle[0] = trackBar1.Value;
            angle[1] = trackBar2.Value;
            angle[2] = trackBar3.Value;
            angle[3] = trackBar4.Value;
            angle[4] = trackBar5.Value;
            angle[5] = trackBar6.Value;
            angle_info();
        }

        private void angle_set()
        {
            trackBar1.Value = angle[0];
            trackBar2.Value = angle[1];
            trackBar3.Value = angle[2];
            trackBar4.Value = angle[3];
            trackBar5.Value = angle[4];
            trackBar6.Value = angle[5];
            numericUpDown1.Value = angle[0];
            numericUpDown2.Value = angle[1];
            numericUpDown3.Value = angle[2];
            numericUpDown4.Value = angle[3];
            numericUpDown5.Value = angle[4];
            numericUpDown6.Value = angle[5];
            angle_info();
        }
        public void handTabl()
        {
            //label1.Text = dataGridView1[1, 1].Value.ToString();
            int num = dataGridView1.RowCount - 2;
            do
            {
                for (int i = 0; i <= num; i++)
                {
                    for (int j = 0; j <= 5; j++)
                    {
                        angle[j] = Convert.ToInt32(dataGridView1[j, i].Value);
                    }
                    angle_set();
                    handIO(' ');
                    Thread.Sleep(Properties.Settings.Default.delay_time);
                    if (checkBox1.CheckState == CheckState.Checked)
                    {
                        Thread.Sleep((Properties.Settings.Default.delay_time) * 5);
                    }
                }
            } while (checkBox1.CheckState == CheckState.Checked);
        }

        public void saveTabl()
        {
            int[,] Cord = new int[100,6];
            string csvToSave = null;
            int num = dataGridView1.RowCount - 2;
            for (int i = 0; i <= num; i++)
            {
                for (int j = 0; j <= 5; j++)
                {
                    Cord[i, j] = Convert.ToInt32(dataGridView1[j, i].Value);
                }
            }
            for(int i = 0; i <= num; i++)
            {
                csvToSave +=/* i.ToString() + ", " + */Cord[i, 0].ToString() + ", " + Cord[i, 1].ToString() + 
                ", " + Cord[i, 2].ToString() + ", " + Cord[i, 3].ToString() + ", " + Cord[i, 4].ToString() + 
                ", " + Cord[i, 5].ToString() + ";\n";
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            Properties.Settings.Default.last_file = filename;
            Properties.Settings.Default.Save();
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, csvToSave);
            MessageBox.Show("Файл сохранен");
        }

        public void getTable(string filename)
        {
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            MessageBox.Show("Файл открыт");
            String[] substrings = fileText.Split(';');
            string[][] Cord = new string[100][];
            
            foreach (var substring in substrings)
            {
                dataGridView1.Rows.Add(substring.Split(','));
            }
            dataGridView1.Rows.RemoveAt(dataGridView1.RowCount - 2);
        }

        public void handIO(char msg)
        {
            if (handler) {
                string data = null;
                switch (msg)
                {
                    case ('a'): data = ch_a + angle[0].ToString() + "!"; break;
                    case ('b'): data = ch_b + angle[1].ToString() + "!"; break;
                    case ('c'): data = ch_c + angle[2].ToString() + "!"; break;
                    case ('d'): data = ch_d + angle[3].ToString() + "!"; break;
                    case ('e'): data = ch_e + angle[4].ToString() + "!"; break;
                    case ('f'): data = ch_f + angle[5].ToString() + "!"; break;
                    case (' '):
                        data = "a" + angle[0].ToString() + "!";
                        data += "b" + angle[1].ToString() + "!";
                        data += "c" + angle[2].ToString() + "!";
                        data += "d" + angle[3].ToString() + "!";
                        data += "e" + angle[4].ToString() + "!";
                        data += "f" + angle[5].ToString() + "!";
                        break;
                }
                SerialPort port = null;
                try
                {
                    port = OpenPort();
                    port.Write(data);
                    //if ((port.ReadLine().Trim() != response) || (response == null)) port.Write(data);
                    label1.Text = "Ok";
                }
                catch (System.TimeoutException)
                {
                    label1.Text = "Ошибка";
                    MessageBox.Show("Выбранный порт не отвечает");
                }
                finally
                {
                    if (port != null)
                        port.Close();
                }
            }
        }

        private void angle_info()
        {
            label1.Text = "Текущее положение: " + angle[0] + "; " + angle[1] + "; " + angle[2] + "; " + angle[3] + "; " + angle[4] + "; " + angle[5];
        }
        
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            numericUpDown1.Value = trackBar1.Value;
            angle_get();
            handIO('a');
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            numericUpDown2.Value = trackBar2.Value;
            angle_get();
            handIO('b');
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            numericUpDown3.Value = trackBar3.Value;
            angle_get();
            handIO('c');
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            numericUpDown4.Value = trackBar4.Value;
            angle_get();
            handIO('d');
        }
        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            numericUpDown5.Value = trackBar5.Value;
            angle_get();
            handIO('e');
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            numericUpDown6.Value = trackBar6.Value;
            angle_get();
            handIO('f');
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            trackBar1.Value = (int)numericUpDown1.Value;
            angle_get();
            handIO('a');
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            trackBar2.Value = (int)numericUpDown2.Value;
            angle_get();
            handIO('b');
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            trackBar3.Value = (int)numericUpDown3.Value;
            angle_get();
            handIO('c');
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            trackBar4.Value = (int)numericUpDown4.Value;
            angle_get();
            handIO('d');
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            trackBar5.Value = (int)numericUpDown5.Value;
            angle_get();
            handIO('e');
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            trackBar6.Value = (int)numericUpDown6.Value;
            angle_get();
            handIO('f');
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            angle_get();
            dataGridView1.Rows.Add(angle[0].ToString(), angle[1].ToString(), angle[2].ToString(), angle[3].ToString(), angle[4].ToString(), angle[5].ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int num = dataGridView1.RowCount - 2;
            //label1.Text = num.ToString();
            if (num >= 0)
                dataGridView1.Rows.RemoveAt(num);
            else MessageBox.Show("Таблица пустая");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            saveTabl();
            label8.Text = "Загрузить ранее использованый файл: " + Properties.Settings.Default.last_file;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            Properties.Settings.Default.last_file = filename;
            Properties.Settings.Default.Save();
            getTable(filename);
            label8.Text = "Загрузить ранее использованый файл: " + Properties.Settings.Default.last_file;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            handTabl();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            measure();
            angle_get();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Port = comboBox1.SelectedItem.ToString();
            Properties.Settings.Default.port = Port;
            Properties.Settings.Default.Save();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.port != "")
            {
                handler = false;
                if (checkBox2.CheckState == CheckState.Checked)
                {
                    //Port = null;
                    handler = true;
                    
                    SerialPort port = null;
                    try
                    {
                        port = OpenPort();
                    }
                    catch
                    {
                        label1.Text = "Ошибка!";
                    }
                    finally
                    {
                        label1.Text = "Подключено!";
                        if (port != null)
                            port.Close();
                    }
                }
                if (checkBox2.CheckState == CheckState.Unchecked)
                {
                    handler = false;
                    label1.Text = "Отключен!";
                }
            }
            else
            {
                MessageBox.Show("Порт не указан");
                checkBox2.CheckState = CheckState.Unchecked;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.last_file != "")
                getTable(Properties.Settings.Default.last_file);
            else MessageBox.Show("Файл отсутствует");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
            loadBox();
            string ch_a = Properties.Settings.Default.ch_a;
            string ch_b = Properties.Settings.Default.ch_b;
            string ch_c = Properties.Settings.Default.ch_c;
            string ch_d = Properties.Settings.Default.ch_d;
            string ch_e = Properties.Settings.Default.ch_e;
            string ch_f = Properties.Settings.Default.ch_f;
        }
    }
}
