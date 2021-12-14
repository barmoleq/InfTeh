using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt";

                if (openFileDialog.ShowDialog() == DialogResult.OK) //создание окна
                {
                    Form2(openFileDialog.FileName);
                }
                else
                {
                    Close();
                }
            }
        }

        public void Form2(string path)
        {
            Label l1 = new Label(); 
            l1.Dock = DockStyle.Fill;
            string text = "Ошибка выбора файла";
            if (path != "")
            {
                text = Program.GetFileText(path);
            }
            int key = Program.keySearch(text);
            if( key == -1)
            {
                l1.Text = text + "Недостаточно данных";
            }
            else
            {
                l1.Text = text + Environment.NewLine + Program.textAnswer(text, key);
            }

            Controls.Add(l1);
        }
    }
}
