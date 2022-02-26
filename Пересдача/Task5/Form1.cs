using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task5
{
    public partial class Form1 : Form
    {
        private TextBox tb = new TextBox();

        public Form1()
        {
            List<IMusicalInstrument> list = GetList(10);
            List<IMusicalInstrument> listSorted = GetSortedList(list);
            Font f = new Font("Times new roman", 30, Font.Style);
            tb.Font = f;
            tb.Width = 1530;
            tb.Height = 800;
            tb.Multiline = true;
            tb.AcceptsTab = true;
            tb.WordWrap = true;
            tb.ScrollBars =  ScrollBars.Vertical;
            tb.Text = "Список Гитар:" + Environment.NewLine + ListToString(list) + Environment.NewLine +
                      "Сортировка по сорту дерева:" + Environment.NewLine + ListToString(listSorted);
            Controls.Add(tb);
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Focus();
            InitializeComponent();
        }

        
        private List<IMusicalInstrument> GetSortedList(List<IMusicalInstrument> list)
        {
            List<IMusicalInstrument> output = new List<IMusicalInstrument>(list);
            output.Sort();
            return output;
        }

        private string ListToString(List<IMusicalInstrument> list)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                ElectricGuitar eg = (ElectricGuitar) list[i];
                sb.Append(eg.Material.ToString()).Append(" корпус, по цене = ").Append(eg.GetPriceCoefficient())
                    .Append(", длина грифа = ").Append(eg.GetLengthGrif()).Append(", длина корпуса = ").Append(eg.GetLengthBody()).Append(Environment.NewLine);
            }

            return sb.ToString();
        }

        private List<IMusicalInstrument> GetList(int length)
        {
            Random r = new Random();
            List<IMusicalInstrument> list = new List<IMusicalInstrument>();
            for (int i = 0; i < length; i++)
            {
                Material material = (Material) Enum.GetValues(typeof(Material)).GetValue(
                    r.Next(Enum.GetValues(typeof(Material)).Length));
                int lengthGrif = 50 + 10 * r.Next(5);
                int lengthBody = 40 + 10 * r.Next(6);
                int switchCount = r.Next(4);
                list.Add(new ElectricGuitar(material, lengthGrif, lengthBody, switchCount));
            }

            return list;
        }
    }
}