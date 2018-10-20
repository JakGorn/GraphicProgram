using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphic_Program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
        }

        bool startPaint = false;
        Graphics g;
        int? initX = null;
        int? initY = null;
        bool drawSquare = false;
        bool drawRectangle = false;
        bool drawCircle = false;
        private void pnl_Draw_MouseMove(object sender, MouseEventArgs e)
        {
            if (startPaint)
            {

                Pen p = new Pen(button1.BackColor, float.Parse(numericUpDown1.Text));

                g.DrawLine(p, new Point(initX ?? e.X, initY ?? e.Y), new Point(e.X, e.Y));
                initX = e.X;
                initY = e.Y;
            }
        }
        private void pnl_Draw_MouseDown(object sender, MouseEventArgs e)
        {
            startPaint = true;
            if (drawSquare)
            {
                
                SolidBrush sb = new SolidBrush(button1.BackColor);
                 
                g.FillRectangle(sb, e.X, e.Y, int.Parse(numericUpDown2.Text), int.Parse(numericUpDown2.Text));
                  
                startPaint = false;
                drawSquare = false;
            }
            if (drawRectangle)
            {
                SolidBrush sb = new SolidBrush(button1.BackColor);
                 
                g.FillRectangle(sb, e.X, e.Y, 2 * int.Parse(numericUpDown2.Text), int.Parse(numericUpDown2.Text));
                startPaint = false;
                drawRectangle = false;
            }
            if (drawCircle)
            {
                SolidBrush sb = new SolidBrush(button1.BackColor);
                g.FillEllipse(sb, e.X, e.Y, int.Parse(numericUpDown2.Text), int.Parse(numericUpDown2.Text));
                startPaint = false;
                drawCircle = false;
            }
        }
        private void pnl_Draw_MouseUp(object sender, MouseEventArgs e)
        {
            startPaint = false;
            initX = null;
            initY = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = c.Color;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g.Clear(panel1.BackColor);
            panel1.BackColor = Color.White;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            drawSquare = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            drawRectangle = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            drawCircle = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Simple Graphic Program made by Jakub Górniak from class 3B";
            string caption = "About";
            MessageBoxButtons buttons = MessageBoxButtons.OK;

            MessageBox.Show(message, caption, buttons);
        }

        
    }
}
