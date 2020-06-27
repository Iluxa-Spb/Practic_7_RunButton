using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunButton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            coords = new Coords(Width, Height, button1.Width, button1.Height);
        }

        public static int d = 5;
        public struct Coords
        {
            public int formWidth;
            public int formHeight;
            public int Width;
            public int Height;
            public int MiddleX;
            public int MiddleY;
            public Coords(int formWidth, int formHeight, int Width, int Height)
            {
                this.formWidth = formWidth - 9 - d;
                this.formHeight = formHeight - 38 - d;
                this.Width = Width;
                this.Height = Height;
                MiddleX = Width / 2;
                MiddleY = Height / 2;
            }
        }
        System.Drawing.Point p = new System.Drawing.Point();
        Coords coords;
        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (button1.Left < d || button1.Right + d > coords.formWidth || button1.Top < d || button1.Bottom + d > coords.formHeight)
            {
                Random rd = new Random();
                button1.Left = rd.Next(0, coords.formWidth - coords.Width);
                button1.Top = rd.Next(0, coords.formHeight - coords.Height);
                return;
            }
            if (button1.Left > 0 && button1.Right < coords.formWidth)
                p.X = e.X < coords.MiddleX ? d : e.X == coords.MiddleX ? 0 : -d;
            if (button1.Top > 0 && button1.Bottom < coords.formHeight)
                p.Y = e.Y < coords.MiddleY ? d : e.Y == coords.MiddleY ? 0 : -d;
            if (DateTime.Now.Millisecond % 1 == 0)
            {
                button1.Left += p.X;
                button1.Top += p.Y;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Хорошо! =)");
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Мы так и думали! Хорошего Вам рабочего дня.");
        }
    }
}
