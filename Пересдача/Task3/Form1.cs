using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3
{
    public partial class Form1 : Form
    {
        private Label l = new Label();
        private TextBox[] boxes = new TextBox[2];
        private List<Мusic> list = new List<Мusic>();
        private List<МusicStyle> style_filter = new List<МusicStyle>();
        private List<Мusician> musician_filter = new List<Мusician>();

        public Form1()
        {
            Font f = new Font("Times new roman", 30, Font.Style);

            string[] labels = {"Исполнитель", "Стиль",  "Мин с", "Макc с"};
            for (int i = 0; i < labels.Length; i++)
            {
                Label l1 = new Label();
                l1.Font = f;
                l1.Location = new Point(10 + 250 * i, 10);
                l1.Size = new Size(250, 50);
                l1.Text = labels[i];
                Controls.Add(l1);
            }

            var styles = Enum.GetValues(typeof(МusicStyle));
            for (int i = 0; i < styles.Length; i++)
            {
                style_filter.Add((МusicStyle)styles.GetValue(i));
                CheckBox cb_type = new CheckBox();
                cb_type.Font = f;
                cb_type.Location = new Point(10, 60 + 50 * i);
                cb_type.Size = new Size(250, 50);
                cb_type.Text = styles.GetValue(i).ToString();
                cb_type.Checked = true;
                cb_type.CheckedChanged += cb_style_changed;
                Controls.Add(cb_type);
            }

            var musicians = Enum.GetValues(typeof(Мusician));
            for (int i = 0; i < musicians.Length; i++)
            {
                musician_filter.Add((Мusician)musicians.GetValue(i));
                CheckBox cb_transport = new CheckBox();
                cb_transport.Font = f;
                cb_transport.Location = new Point(10 + 250, 60 + 50 * i);
                cb_transport.Size = new Size(250, 50);
                cb_transport.Text = musicians.GetValue(i).ToString();
                cb_transport.Checked = true;
                cb_transport.CheckedChanged += cb_musician_changed;
                Controls.Add(cb_transport);
            }

            for (int i = 0; i < 2; i++)
            {
                TextBox tb = new TextBox();
                tb.Font = f;
                tb.Location = new Point(10 + 250 * (i + 2), 60);
                tb.Size = new Size(200, 50);
                tb.MaxLength = 4;
                tb.KeyPress += tb_KeyPress;
                boxes[i] = tb;
                Controls.Add(tb);
            }

            Button b = new Button();
            b.Font = f;
            b.Location = new Point(10 + 250 * 4, 10 + Math.Max(styles.Length, musicians.Length) * 50);
            b.Size = new Size(200, 50);
            b.Text = "Поиск";
            b.Click += b_click;
            Controls.Add(b);


            string[] path = {Application.StartupPath, "..\\..\\tests\\input01.txt"};
            list = Program.GetMusicsFromFile(Path.Combine(path));

            l.Font = f;
            l.Location = new Point(10, 60 + Math.Max(styles.Length, musicians.Length) * 50);
            l.Size = new Size(10 + labels.Length * 250, 500);
            l.Text = Program.getMusicsToText(list);
            Controls.Add(l);
            WindowState = FormWindowState.Maximized;
            Focus();
            // InitializeComponent();
        }

        private void b_click(object sender, EventArgs e)
        {
            int[] nums = new int[boxes.Length];
            for (int i = 0; i < boxes.Length; i++)
            {
                if (boxes[i].Text != "")
                {
                    nums[i] = Int32.Parse(boxes[i].Text);
                }
                else
                {
                    nums[i] = -1;
                }
            }
            
            l.Text = Program.getMusicsToText(Program.getMusicsByFilters(list, musician_filter, style_filter, nums)) + 
                Program.getMusicsLong(Program.getMusicsByFilters(list, musician_filter, style_filter, nums)).ToString();
            
        }

        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            char num = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(num))
            {
                e.Handled = true;
            }
        }

        private void cb_style_changed(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox) sender;
            string s = checkBox.Text;
            МusicStyle type = (МusicStyle) Enum.Parse(typeof(МusicStyle), s);
            if (checkBox.Checked)
            {
                style_filter.Add(type);
            }
            else
            {
                style_filter.Remove(type);
            }
        }

        private void cb_musician_changed(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox) sender;
            string s = checkBox.Text;
            Мusician musician = (Мusician) Enum.Parse(typeof(Мusician), s);
            if (checkBox.Checked)
            {
                musician_filter.Add(musician);
            }
            else
            {
                musician_filter.Remove(musician);
            }
        }
    }
}