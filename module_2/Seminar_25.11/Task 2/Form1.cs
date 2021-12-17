using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar_25._11
{
    public partial class Form1 : Form
    {
        private bool IsDisappeared;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IsDisappeared = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsDisappeared == false)
            {
                FormDisappearing();
            }
            else
            {
                FormAppearing();
            }
        }

        private void FormDisappearing()
        {
            if (label1.Text.Length != 0)
            {
                FadeAwayOneCharacter();
            }
            else if (Opacity > 0)
            {
                Opacity -= 0.2;
            }
            else
            {
                IsDisappeared = true;
                label1.Text = "Кот уже ушел!";
            }
        }

        private void FadeAwayOneCharacter()
        {
            StringBuilder line = new("");
            for (int i = 0; i < label1.Text.Length - 1; i++)
            {
                line.Append(label1.Text[i]);
            }

            label1.Text = line.ToString();
        }

        private void FormAppearing()
        {
            if (Opacity < 1)
            {
                Opacity += 0.2;
            }
            else
            {
                timer1.Enabled = false;
            }
        }
    }
}
