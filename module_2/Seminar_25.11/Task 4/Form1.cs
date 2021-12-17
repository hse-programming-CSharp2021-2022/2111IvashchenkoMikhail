using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_4
{
    public partial class Form1 : Form
    {
        private static readonly List<string> Items = new List<string>
        {
            "один", "два", "три", "четыре", "пять", "шесть", "семь"
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var item in Items)
            {
                listBox1.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Список пуст или\nнет выбранного элемента","", MessageBoxButtons.OK);
                return;
            }

            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
    }
}
