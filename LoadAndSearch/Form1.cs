using System;
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

namespace LoadAndSearch
{
    
    public partial class Form1 : Form
    {

        string fileText;
        string filename;
        string found;
        int count = 0;
        


        public Form1()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string[] inStr = textBox1.Text.Split(' ');
            string[] arrString = fileText.Replace(')', ' ').Replace('(', ' ').Split(' '); //разбиваем строчку по разделителю
            foreach (string inputWord in inStr)
            {
                foreach (string searchWord in arrString)
                {
                    if (searchWord == inputWord)
                    {
                        count++;
                        break;
                    }
                }
            }

            if (count == inStr.Length)
            {
                count = 0;
                found += $"Запрос {textBox1.Text} возвращает [{filename}] \n";
                richTextBox1.Text = found;
            }
            else
            {
                count = 0;
                found += $"Запрос {textBox1.Text} возвращает [] \n";
                richTextBox1.Text = found;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            filename = openFileDialog.FileName;
            // читаем файл в строку
            fileText = File.ReadAllText(filename);
            
            MessageBox.Show("Файл открыт");

            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        
    }
}
