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
using System.Drawing.Imaging;
using System.Drawing.Printing;

namespace SystematicCodeGen
{
    public partial class Form1 : Form
    {
        static int dee;
        static string d3;
        static string check;
        public static string send2;
        public static string send4;
        public static string line;
        public static int col1;
        public static bool isChecked = false;
        public static bool isNamed = false;
        public static bool isSelected = false;
        public static string name;
        public Form1()
        {
            InitializeComponent();

            try
            {
                string theDate = dateTimePicker1.Value.ToString("-dd-MM-yyyy");
                textBox1.Text = theDate;
                d3 = theDate;
            }
            catch
            {
                MessageBox.Show("Ohwww");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.SelectedText))
            {
                isSelected = false;
            } else
            {
                isSelected = true;
            }
                if (comboBox1.SelectedItem.ToString() == "เสื้อผ้า")
            {
                textBox2.Text = "1";
            }
            else if (comboBox1.SelectedItem.ToString() == "รองเท้า")
            {
                textBox2.Text = "3";
            }
            else if (comboBox1.SelectedItem.ToString() == "กระเป๋า")
            {
                textBox2.Text = "2";
            }
            else if (comboBox1.SelectedItem.ToString() == "เครื่องประดับ")
            {
                textBox2.Text = "4";
            }
            else if (comboBox1.SelectedItem.ToString() == "ตุ๊กตา")
            {
                textBox2.Text = "5";
            }
            else if (comboBox1.SelectedItem.ToString() == "หนังสือ")
            {
                textBox2.Text = "6";
            }
            else if (comboBox1.SelectedItem.ToString() == "เครื่องใช้ไฟฟ้า")
            {
                textBox2.Text = "7";
            }
            else if (comboBox1.SelectedItem.ToString() == "เบ็ดเตล็ด")
            {
                textBox2.Text = "8";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            isChecked = false;
            if (radioButton1.Checked)
            {
                textBox3.Text = "C";
                isChecked = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            isChecked = false;
            if (radioButton2.Checked)
            {
                isChecked = true;
                textBox3.Text = "F";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            isChecked = false;
            if (radioButton3.Checked)
            {
                isChecked = true;
                textBox3.Text = "DN";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (name.Length <= 0)
            {
                isNamed = false;
            } else if (name.Length > 1)
            {
                isNamed = true;
            }
            if (isChecked == false || isSelected == false || isNamed == false)
            {
                label4.Text = ("ไม่สามารถสร้างรหัสให้ได้");
                MessageBox.Show("ไม่สามารถสร้างให้ได้เนื่องจาก \nระบบไม่พบการติ๊กประเภทอย่างถูกต้อง");
            } else if (isChecked == true || isSelected == true || isNamed == true)
            {
            dee = dee+1;
            textBox4.Text = dee.ToString();
            name = textBox5.Text;
            //MessageBox.Show(textBox2.Text + d3 + "-" + textBox3.Text + "-" + dee.ToString("D4"));
            label4.Text = (textBox2.Text + d3 + "-" + textBox3.Text + "-" + dee.ToString("D4"));
            MessageBox.Show(name + "\n" + textBox2.Text + d3 + "-" + textBox3.Text + "-" + dee.ToString("D4"),"รายการวันนี้ ประจำวันที่" + d3);

            try {
                do
                {
                    StreamWriter wx = new StreamWriter("inventory" + d3 + ".dsm", true);
                    {
                        wx.WriteLine(textBox2.Text + d3 + "-" + textBox3.Text + "-" + dee.ToString("D4"));
                        wx.Close();
                    }
                    StreamWriter wx2 = new StreamWriter("inventory_full" + d3 + ".dsm", true);
                    {
                        wx2.WriteLine(name);
                        wx2.WriteLine(textBox2.Text + d3 + "-" + textBox3.Text + "-" + dee.ToString("D4"));
                        wx2.Close();
                    }
                } while (check == "END");

            } catch(Exception)
            {
                MessageBox.Show("Error Na Ja !");
            }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Name.Length <= 0)
            {
                isNamed = false;
            }
            else if (Name.Length >= 1)
            {
                isNamed = true;
            }
            if (isChecked == false)
                {
                label4.Text = ("ไม่สามารถสร้างรหัสให้ได้");
                MessageBox.Show("ไม่สามารถสร้างให้ได้เนื่องจาก \nระบบไม่พบการติ๊กประเภทอย่างถูกต้อง");
            }
            else if (isChecked == true)
            {
                string ncode = (textBox2.Text + d3 + "-" + textBox3.Text + "-" + dee.ToString("D4"));
                string barCode = ncode;
                Bitmap bitMap = new Bitmap(barCode.Length * 40, 80);

                using (Graphics graphics = Graphics.FromImage(bitMap))
                {
                    Font oFont = new Font("IDAHC39M Code 39 Barcode", 16);
                    PointF point = new PointF(1f, 1f);
                    SolidBrush blackBrush = new SolidBrush(Color.Black);
                    SolidBrush whiteBrush = new SolidBrush(Color.White);
                    graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
                    graphics.DrawString("*" + barCode + "*", oFont, blackBrush, point);
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, ImageFormat.Png);
                    pictureBox2.Image = bitMap;
                    pictureBox2.Height = bitMap.Height;
                    pictureBox2.Width = bitMap.Width;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                check = "END";
                MessageBox.Show("จบการทำงานแล้วนะครับ ขอสรุปยอดเลยแล้วกันนะ วันนี้บันทึกไปได้ " + dee.ToString() + " รายการ");
            }
        }

        public static void SetFileReadAccess(string FileName, bool SetReadOnly)
        {
            FileAttributes yourFile = File.GetAttributes("inventory" + d3 + ".dsm");
        }

        public void button3_Click(object sender, EventArgs e)
        {

            try
            {
                    StreamReader wr = new StreamReader("inventory_full" + d3 + ".dsm", true);
                    {
                        while(!wr.EndOfStream)
                    {
                        MessageBox.Show(wr.ReadToEnd() + Environment.NewLine , "ผลการอ่าน");
                        send2 = wr.ReadToEnd();
                    }
                    }

            }
            catch (Exception)
            {
                MessageBox.Show("Error Na Ja !");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ขอบคุณแหล่งบาร์โค้ด : https://www.aspsnippets.com/Articles/Generate-Barcode-in-Windows-Forms-WinForms-Application-using-C-and-VBNet.aspx");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            PrintDocument p = new PrintDocument();
            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                StreamReader wr = new StreamReader("inventory" + d3 + ".dsm", true);
                {
                    while (!wr.EndOfStream)
                    {
                        send4 = wr.ReadLine();
                        send2 = wr.ReadToEnd();
                    }
                }
                line = string.Empty;
                e1.Graphics.DrawString(line +send2 , new Font("IDAHC39M Code 39 Barcode", 16), new SolidBrush(Color.Black), new RectangleF(0, 0, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));

            };
            try
            {
                p.Print();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Occured While Printing", ex);
            }
        }
    }
}
