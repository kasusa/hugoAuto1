﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hugoAuto1.Properties;



namespace hugoAuto1
{
    public partial class Form1 : Form
    {
        string str_source = "";
        string str_output = "";
        string str_articles = "";
        string win_username = "";

        public Form1()
        {
            InitializeComponent();
            getsettings();
            textBox1.Text = Settings.Default.source;
            textBox2.Text = Settings.Default.output;
            textBox3.Text = Settings.Default.articles;
            textBox4.Text = Settings.Default.username;
        }

        private void getsettings()
        {
            str_source = Settings.Default.source;
            str_output = Settings.Default.output;
            str_articles = Settings.Default.articles;
            win_username = Settings.Default.username;
        }

        //保存设置
        private void button11_Click(object sender, EventArgs e)
        {
            Settings.Default.source = textBox1.Text;
            Settings.Default.output = textBox2.Text;
            Settings.Default.articles = textBox3.Text;
            Settings.Default.username = textBox4.Text;
            Settings.Default.Save();
            win_username = Settings.Default.username;
            toolStripStatusLabel1.Text = "设置已保存";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //刷新combox
                button4.PerformClick();
            }
            catch
            {
                MessageBox.Show("需要设置目录");
                //textBox1.Text = textBox2.Text = textBox3.Text = "";
            }
        }

        private void runincmd(string yourcommand)
        {
            string strCmdText;
            strCmdText = $"/C {yourcommand}";
            Process process = Process.Start("CMD.exe", strCmdText);
        }
        private void openinbrowser(string link)
        {
            string strCmdText;
            strCmdText = $"{link}";
            Process process = Process.Start($@"C:\Users\{win_username}\AppData\Local\Google\Chrome\Application\Chrome.exe", strCmdText);
        }



        #region openfloders
        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", textBox2.Text);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", textBox3.Text);
        }
        #endregion

        //hugo编译输出
        private void button6_Click(object sender, EventArgs e)
        {
            string outpath = textBox2.Text;
            string rawpath = textBox1.Text;
            string mycmd =
              $@"hugo -d {outpath} -s {rawpath}";
            runincmd(mycmd);
            toolStripStatusLabel1.Text = $"hugo编译输出完毕";

        }
        //开启github
        private void button7_Click(object sender, EventArgs e)
        {
            Process process = Process.Start($@"C:\Users\{win_username}\AppData\Local\GitHubDesktop\GitHubDesktop.exe", "");
            toolStripStatusLabel1.Text = $"已经命令Github启动";
        }
        //新建文章
        private void button8_Click(object sender, EventArgs e)
        {
            string filename = comboBox1.Text;
            string rawpath = textBox1.Text;

            if (filename!=string.Empty){
                string mycmd =
                     $@"hugo new -s {rawpath} -c content\zh-cn posts\{filename}.md";
                runincmd(mycmd);
                toolStripStatusLabel1.Text = $"创建【{filename}.md】";
            }
            else
                comboBox1.BackColor = Color.Red;
        }

        //打开文章
        private void button9_Click(object sender, EventArgs e)
        {
            string filename = comboBox1.Text;
            string rawpath = textBox1.Text;
            string filePath = $@"{rawpath}\content\zh-cn\posts\{filename}.md";
            Process.Start(@"C:\Program Files\Typora\Typora.exe", filePath);
            toolStripStatusLabel1.Text = $"已经命令typora打开【{filename}.md】";
        }
        //打开obsidian
        private void button12_Click(object sender, EventArgs e)
        {
            string mycmd =
                 $@"C:\Users\{win_username}\AppData\Local\Obsidian\Obsidian.exe";
            runincmd(mycmd);
            toolStripStatusLabel1.Text = $"已经命令打开Obsidian";
        }
        //刷新combobox
        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.BackColor = Color.White;
            string rawpath = textBox1.Text;
            string filePath = $@"{rawpath}\content\zh-cn\posts";

            comboBox1.Items.Clear();
            var files = Directory
              .GetFiles(filePath, "*.md");
            //提取路径地址+/为了在后面把完整路径剔除
            string pathstr = filePath + "\\";
            string pathstr2 = ".md";
            int count = 0;
            foreach (var file in files)
            {
                //逐个把文件名放在combox中
                comboBox1.Items.Add(file.ToString().Replace(pathstr, "").Replace(pathstr2, ""));
                count++;
            }
            toolStripStatusLabel1.Text = $"读取到了【{count}】个md文件。";
        }
        //开启server和浏览器
        private void button5_Click(object sender, EventArgs e)
        {
            string rawpath = textBox1.Text;
            string mycmd =
               $@"hugo server -t hugo-theme-bootstrap -p 51000 -s {rawpath}";
            runincmd(mycmd);
        }
        //本地浏览器打开博客
        private void button10_Click(object sender, EventArgs e)
        {
            openinbrowser("http://localhost:51000/hugo/");
            toolStripStatusLabel1.Text = $"Chrome已启动";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




    }
}
