using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace Laba3
{
    public partial class Form1 : Form
    {
        Graphics g;
        string filename = @"Strings.txt";
        string[] sm = {"First Line", "Second Line", "Third line", "Fourth Line", "Fifth line", "Sixth line", "Seventh line", "Eight line", "Ninth line", "Tenth line", "Eleven line", "Twelve line", "Thirteen line", "Fourteenth line", "Fifteenth line"
        };
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }


        private void CreateFile_Click(object sender, EventArgs e)
        {
            g.Clear(Color.FromArgb(255, 255, 255));
            File.Delete(filename);
            MessageBox.Show("Файл Strings.txt удалён !");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter f = new StreamWriter(new FileStream(filename, FileMode.Create, FileAccess.Write));
            foreach (string s in sm) { f.WriteLine(s); }
            f.Close();
            MessageBox.Show("15 строк записано в файл !");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader f = new StreamReader(new FileStream(filename, FileMode.Open, FileAccess.Read));
                for (int i = 0; i < 15; i++) { sm[i] = f.ReadLine(); }
                f.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            pictureBox1.BackColor = Color.FromName("Azure");
            pictureBox1.Refresh();
            for (int i = 0; i < 15; i++)
            {
                if ((i >= 0) && (i < 8))
                {
                    Font fn = new Font("Magneto", 18, FontStyle.Bold);
                    StringFormat sf =
                        (StringFormat)StringFormat.GenericTypographic.Clone();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Far;
                    g.DrawString(sm[i], fn, Brushes.Blue, 
                        new RectangleF(0, 0 - i * 30, pictureBox1.Size.Width - 20, pictureBox1.Size.Height - 160), sf);
                    fn.Dispose();
                }
                if ((i >=8) && (i < 10))
                {
                   
                    Font fn = new Font("Perpetua", 24, FontStyle.Italic);
                    StringFormat sf =
                        (StringFormat)StringFormat.GenericTypographic.Clone();
                    sf.FormatFlags = StringFormatFlags.DirectionVertical;
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Far;
                    g.DrawString(sm[i], fn, Brushes.Black,
                        new RectangleF(0 - i * 70, 70, pictureBox1.Size.Width - 50, pictureBox1.Size.Height - 20), sf);
                    fn.Dispose();
                }
                if (i == 10)
                {
                    FontFamily fontFamily = new FontFamily("Cambria");
                    Font fn = new Font(fontFamily, 2, FontStyle.Regular, GraphicsUnit.Inch);
                    StringFormat sf =
                        (StringFormat)StringFormat.GenericTypographic.Clone();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Near;
                    g.DrawString(sm[i], fn, Brushes.Green,
                        new RectangleF(0, i*20, pictureBox1.Size.Width - 20,
                        pictureBox1.Size.Height - 20), sf);
                    fn.Dispose();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            g.Clear(Color.FromArgb(224, 224, 224));
        }
    }
}