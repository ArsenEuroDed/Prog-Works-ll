using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Zadanie_14
{
    static class Program
    {
        /// Главная точка входа для приложения.
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
            public partial class Form1 : Form
        {

            //переменная для отслеживания, сколько CheckBox уже установлено
            private int checkBoxIndex = 0;


            //обработчик события двойного клика
            private void Form1_DoubleClick(object sender, EventArgs e)
            {
                //если все CheckBox (6) заполнены, сбрасываем их
                if (checkBoxIndex >= 6)
                {
                    ResetCheckBoxes();
                    checkBoxIndex = -1; //сбрасываем индекс для нового цикла
                }

                //если checkboxindex меньше нуля, это означает, что никакие checkbox'ы не нужно выделять
                if (checkBoxIndex >= 0)
                {
                    //включаем следующий CheckBox
                    CheckBox currentCheckBox = (CheckBox)this.Controls["checkBox" + (checkBoxIndex + 1)];
                    currentCheckBox.Checked = true;
                }

                //увеличиваем индекс для следующего CheckBox
                checkBoxIndex++;
            }

            //метод для сброса всех CheckBox
            private void ResetCheckBoxes()
            {
                //проходим в цикле все checkbox'ы, и устанавливаем свойство checked в false
                for (int i = 1; i <= 6; i++)
                {
                    CheckBox checkBox = (CheckBox)this.Controls["checkBox" + i];
                    checkBox.Checked = false;
                }
            }

            private void Form1_Load(object sender, EventArgs e)
            {

            }
        }

    }
}

