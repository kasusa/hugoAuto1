using hugoAuto1.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hugoAuto1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = Settings.Default.chromeCommand.ToString();
            textBox2.Text = Settings.Default.typoraCommand.ToString();
            textBox3.Text = Settings.Default.vscCommand.ToString();
            textBox4.Text = Settings.Default.githubCommand.ToString();
            textBox5.Text = Settings.Default.hugotheme.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default.chromeCommand = textBox1.Text;
            Settings.Default.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Settings.Default.typoraCommand = textBox2.Text;
            Settings.Default.Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Settings.Default.vscCommand = textBox3.Text;
            Settings.Default.Save();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Settings.Default.githubCommand = textBox4.Text;
            Settings.Default.Save();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Settings.Default.hugotheme = textBox5.Text;
            Settings.Default.Save();
        }
    }
}
