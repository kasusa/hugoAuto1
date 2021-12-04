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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default.chromeCommand = button1.Text;
            Settings.Default.Save();
            this.Close();
        }
    }
}
