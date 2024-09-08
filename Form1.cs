using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintBrush
{
    public partial class Form1 : Form
    {
        //Чи натиснута ліва кнопка миші
        bool isMouse = false;
        //Кісточка для малювання
        Pen pen = new Pen(Color.Black, 1f);
        Bitmap map;
        //Масив точок для малювання
        ArrayPoints arrayPoints = new ArrayPoints(2);
        //Об'єкт графііки
        Graphics graphics;
        //Розмір кісточки
        float prev = 1f;
        public Form1()
        {
            InitializeComponent();
            InitSize();
        }

        private void InitSize()
        {
            Rectangle rectangle = Screen.PrimaryScreen.Bounds;
            map = new Bitmap(rectangle.Width, rectangle.Height);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            float penSize = (float)trackBar1.Value;
            pen.Width = penSize;
            prev = pen.Width;
            label1.Text = trackBar1.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Color color = btn.BackColor;
            pen.Color = color;
            panel1.BackColor = color;
            if (btn.Name == "btn_erase")
            {
                btn.BackColor = Color.LightGreen;
                prev = pen.Width;
                pen.Width = (float)trackBar1.Maximum;
                trackBar1.Value = trackBar1.Maximum;
                label1.Text = "Гумка: " + trackBar1.Value.ToString();
            }
            else
            {
                btn_erase.BackColor = Color.Silver;
                pen.Width = prev;
                trackBar1.Value = (int)pen.Width;
                label1.Text = trackBar1.Value.ToString();
            }
        }
        //Виклик діалогу з палітрою
        private void btn_palitra_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            { 
                pen.Color = cd.Color;
                panel1 .BackColor = cd.Color;
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            graphics.Clear(pictureBox1.BackColor);
            pictureBox1.Refresh();
        }
    }
}
