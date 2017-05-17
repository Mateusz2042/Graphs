using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Rysowanie_grafu
{
    public partial class Form2 : Form
    {
        int[] tab = new int[4];
        int[] tabSort = new int[4];
        int j = 0, l = 0;
        string[] liczby;
        int sum = 0;
        int quantity = 0;
        StreamWriter save;
        StreamReader load;
        int summ = 0;
        int y = 1;
        int x = 0;
        int[] min = new int[2];
        int suma = 0;
        bool[] sprawdzenie = new bool[3];
        int z = 0;

        static private Brush aBrush = (Brush)Brushes.Black;
        static private Graphics g;
        static private Pen p = new Pen(Color.Red, 2);

        Label label;

        Point a = new Point(244, 130);
        Point b = new Point(194, 240);
        Point c = new Point(88, 240);
        Point d = new Point(28, 130);

        void clearing_matrix()
        {
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
            button10.Text = "";
            button11.Text = "";
            button12.Text = "";
            button13.Text = "";
            button14.Text = "";
            button15.Text = "";
            button16.Text = "";
            button17.Text = "";
            button18.Text = "";
            button19.Text = "";
            button20.Text = "";
            button21.Text = "";
            button22.Text = "";
        }

        void clearing_textboxow()
        {
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }

        void new_label(Point p, string name)
        {
            label = new Label();
            if (name == "a")
            {
                label.Location = new System.Drawing.Point(p.X + 10, p.Y - 5);
            }
            if (name == "b")
            {
                label.Location = new System.Drawing.Point(p.X + 2, p.Y + 5);
            }
            if (name == "c")
            {
                label.Location = new System.Drawing.Point(p.X - 10, p.Y + 5);
            }
            if (name == "d")
            {
                label.Location = new System.Drawing.Point(p.X - 20, p.Y - 5);
            }

            label.Name = name;
            label.Text = name;
            label.Size = new System.Drawing.Size(20, 20);
            label.Visible = true;
            pictureBox1.Controls.Add(label);
            label.Tag = label;
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void autorzyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Twórcy programu:\r\nMateusz Przybyło\t047915\r\nArkadiusz Zwardoń\t047953\r\nPiotr Waleczek\t045860\r\n\r\nKierunek: Informatyka\r\nRok: 3\r\nSemestr: V");
        }

        private void oProgramieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Program służący do całkowitego przeszukiwania grafów z podanego ciągu.\r\nMiejsce i data utworzenia: Bielsko-Biała, 25-26 listopada 2016r.");
        }

        private void wierzchołkówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            form1.Location = new Point(250, 200);
            Visible = false;
        }

        private void wierzchołkówToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            form2.Location = new Point(250, 200);
            Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (textBox3.TextLength != 0 && textBox4.TextLength != 0 && textBox5.TextLength != 0 && textBox6.TextLength != 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8) || e.KeyChar == '4' || e.KeyChar == '5' || e.KeyChar == '6' || e.KeyChar == '7' || e.KeyChar == '8' || e.KeyChar == '9')
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8) || e.KeyChar == '4' || e.KeyChar == '5' || e.KeyChar == '6' || e.KeyChar == '7' || e.KeyChar == '8' || e.KeyChar == '9')
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8) || e.KeyChar == '4' || e.KeyChar == '5' || e.KeyChar == '6' || e.KeyChar == '7' || e.KeyChar == '8' || e.KeyChar == '9')
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8) || e.KeyChar == '4' || e.KeyChar == '5' || e.KeyChar == '6' || e.KeyChar == '7' || e.KeyChar == '8' || e.KeyChar == '9')
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            clearing_textboxow();
            clearing_matrix();
            listBox1.Items.Clear();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox9.Text = listBox1.SelectedItem.ToString();
            textBox2.Text = "";
            //pictureBox1.Invalidate();
            g.Clear(Color.White);

            //
            j = 3;

            button3.Text = "0";
            button8.Text = "0";
            button13.Text = "0";
            button18.Text = "0";

            button4.Text = textBox9.Text[0].ToString();
            button7.Text = textBox9.Text[0].ToString();

            button5.Text = textBox9.Text[1].ToString();
            button11.Text = textBox9.Text[1].ToString();

            button6.Text = textBox9.Text[2].ToString();
            button15.Text = textBox9.Text[2].ToString();

            button9.Text = textBox9.Text[3].ToString();
            button12.Text = textBox9.Text[3].ToString();

            button10.Text = textBox9.Text[4].ToString();
            button16.Text = textBox9.Text[4].ToString();

            button14.Text = textBox9.Text[5].ToString();
            button17.Text = textBox9.Text[5].ToString();

            //
            button19.Text = Convert.ToString(Convert.ToInt32(button3.Text) + Convert.ToInt32(button4.Text) + Convert.ToInt32(button5.Text) + Convert.ToInt32(button6.Text));
            button20.Text = Convert.ToString(Convert.ToInt32(button7.Text) + Convert.ToInt32(button8.Text) + Convert.ToInt32(button9.Text) + Convert.ToInt32(button10.Text));
            button21.Text = Convert.ToString(Convert.ToInt32(button11.Text) + Convert.ToInt32(button12.Text) + Convert.ToInt32(button13.Text) + Convert.ToInt32(button14.Text));
            button22.Text = Convert.ToString(Convert.ToInt32(button15.Text) + Convert.ToInt32(button16.Text) + Convert.ToInt32(button17.Text) + Convert.ToInt32(button18.Text));


            tab[0] = Convert.ToInt32(button19.Text);
            tab[1] = Convert.ToInt32(button20.Text);
            tab[2] = Convert.ToInt32(button21.Text);
            tab[3] = Convert.ToInt32(button22.Text);

            //
            System.Array.Sort(tab);

            for (int i = 0; i < tabSort.Length; i++)
            {
                tabSort[i] = tab[j];
                j--;
            }

            for (int i = 0; i < tabSort.Length; i++)
            {
                if (i != 3)
                {
                    textBox2.Text += tabSort[i] + ", ";
                }
                else
                {
                    textBox2.Text += tabSort[i];
                }
            }

            //-------------------------------------------
            g.FillRectangle(aBrush, a.X, a.Y, 5, 5);
            g.FillRectangle(aBrush, b.X, b.Y, 5, 5);
            g.FillRectangle(aBrush, c.X, c.Y, 5, 5);
            g.FillRectangle(aBrush, d.X, d.Y, 5, 5);

            if (button4.Text == "1")
            {
                g.DrawLine(p, b, a);
            }
            if (button5.Text == "1")
            {
                g.DrawLine(p, c, a);
            }
            if (button6.Text == "1")
            {
                g.DrawLine(p, d, a);
            }
            if (button9.Text == "1")
            {
                g.DrawLine(p, c, b);
            }
            if (button10.Text == "1")
            {
                g.DrawLine(p, d, b);
            }
            if (button14.Text == "1")
            {
                g.DrawLine(p, d, c);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);

            new_label(a, "a");
            new_label(b, "b");
            new_label(c, "c");
            new_label(d, "d");

            listBox1.Items.Clear();
            textBox8.Text = "";
            j = 3;
            l = 3;
            sum = 0;
            quantity = 0;
            int[] main = new int[4];
            int[] main_sort = new int[4];

            main[0] = Convert.ToInt32(textBox3.Text);
            main[1] = Convert.ToInt32(textBox4.Text);
            main[2] = Convert.ToInt32(textBox5.Text);
            main[3] = Convert.ToInt32(textBox6.Text);

            System.Array.Sort(main);

            for (int i = 0; i < main_sort.Length; i++)
            {
                main_sort[i] = main[j];
                j--;
            }

            for (int i = 0; i < main_sort.Length; i++)
            {
                if (i != 3)
                {
                    textBox8.Text += main_sort[i] + ", ";
                }
                else
                {
                    textBox8.Text += main_sort[i];
                }
            }

            //
            for (int i = 0; i < main_sort.Length; i++)
            {
                sum += main_sort[i];
            }

            if (sum % 2 != 0)
            {
                MessageBox.Show("Aby powstał graf suma cyfr ciągu musi być parzysta!!! Spróbuj ponownie.");
                clearing_matrix();
                clearing_textboxow();
            }
            else
            {
                //////////////////////////////////////////////
                summ = 0;
                y = 1;
                x = 0;
                min = new int[2];
                suma = 0;
                sprawdzenie = new bool[3];
                z = 0;

                for (int i = 0; i < main_sort.Length - 1; i++)
                {
                    summ += main_sort[i];

                    suma = 0;

                    for (int k = y; k <= main_sort.Length - 1; k++)
                    {
                        min[0] = y;
                        min[1] = main_sort[k];
                        System.Array.Sort(min);
                        suma += min[0];
                    }

                    x = y * (y - 1) + suma;
                    y++;

                    if (summ <= x)
                    {
                        sprawdzenie[z] = true;
                        z++;
                    }
                    else
                    {
                        sprawdzenie[z] = false;
                        z++;
                    }
                }

                if (sprawdzenie[0] != true || sprawdzenie[1] != true || sprawdzenie[2] != true)
                {
                    MessageBox.Show("Suma ciągu jest parzysta lecz ciąg nie spełnia twierdzenia Erdos Gallai. Wybierz inny ciąg.");
                    clearing_matrix();
                    clearing_textboxow();
                }
                else
                {
                    //searching
                    for (int m = 0; m < liczby.Length; m++)
                    {
                        textBox1.Text = liczby[m];

                        l = 3;

                        button3.Text = "0";
                        button8.Text = "0";
                        button13.Text = "0";
                        button18.Text = "0";

                        button4.Text = textBox1.Text[0].ToString();
                        button7.Text = textBox1.Text[0].ToString();

                        button5.Text = textBox1.Text[1].ToString();
                        button11.Text = textBox1.Text[1].ToString();

                        button6.Text = textBox1.Text[2].ToString();
                        button15.Text = textBox1.Text[2].ToString();

                        button9.Text = textBox1.Text[3].ToString();
                        button12.Text = textBox1.Text[3].ToString();

                        button10.Text = textBox1.Text[4].ToString();
                        button16.Text = textBox1.Text[4].ToString();

                        button14.Text = textBox1.Text[5].ToString();
                        button17.Text = textBox1.Text[5].ToString();

                        //
                        button19.Text = Convert.ToString(Convert.ToInt32(button3.Text) + Convert.ToInt32(button4.Text) + Convert.ToInt32(button5.Text) + Convert.ToInt32(button6.Text));
                        button20.Text = Convert.ToString(Convert.ToInt32(button7.Text) + Convert.ToInt32(button8.Text) + Convert.ToInt32(button9.Text) + Convert.ToInt32(button10.Text));
                        button21.Text = Convert.ToString(Convert.ToInt32(button11.Text) + Convert.ToInt32(button12.Text) + Convert.ToInt32(button13.Text) + Convert.ToInt32(button14.Text));
                        button22.Text = Convert.ToString(Convert.ToInt32(button15.Text) + Convert.ToInt32(button16.Text) + Convert.ToInt32(button17.Text) + Convert.ToInt32(button18.Text));


                        tab[0] = Convert.ToInt32(button19.Text);
                        tab[1] = Convert.ToInt32(button20.Text);
                        tab[2] = Convert.ToInt32(button21.Text);
                        tab[3] = Convert.ToInt32(button22.Text);

                        //sort 
                        System.Array.Sort(tab);

                        for (int i = 0; i < tabSort.Length; i++)
                        {
                            tabSort[i] = tab[l];
                            l--;
                        }

                        for (int i = 0; i < tabSort.Length; i++)
                        {
                            if (i != 3)
                            {
                                textBox2.Text += tabSort[i] + ", ";
                            }
                            else
                            {
                                textBox2.Text += tabSort[i];
                            }
                        }

                        //
                        if (main_sort[0] == tabSort[0] && main_sort[1] == tabSort[1] && main_sort[2] == tabSort[2] && main_sort[3] == tabSort[3])
                        {
                            listBox1.Items.Add(textBox1.Text);
                            quantity++;
                        }
                    }
                    textBox1.Text = "";
                    clearing_matrix();
                    MessageBox.Show("Przeszukiwanie zakończone. Znaleziono " + quantity + " elementów.");
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Location = new Point(250, 200);
            timer1.Start();

            textBox1.Visible = false;

            g = pictureBox1.CreateGraphics();

            //create file txt with binary codes (0 do 63)
            string liczba_bin;

            if (!File.Exists(@"C:\Users\" + Environment.UserName + @"\Desktop\LiczbyBinarne2.txt"))
            {
                save = new StreamWriter(@"C:\Users\" + Environment.UserName + @"\Desktop\LiczbyBinarne2.txt");

                for (int i = 0; i < 64; i++)
                {
                    if (i != 63)
                    {
                        liczba_bin = Convert.ToString(i, 2).PadLeft(6, '0');
                        save.WriteLine(liczba_bin);
                    }
                    else
                    {
                        liczba_bin = Convert.ToString(i, 2).PadLeft(6, '0');
                        save.Write(liczba_bin);
                    }
                }
                save.Close();
            }

            //loading numbers from file and save them to table
            string liczba;
            int k = 0;
            liczby = new string[64];

            load = File.OpenText(@"C:\Users\" + Environment.UserName + @"\Desktop\LiczbyBinarne2.txt");

            while (!load.EndOfStream)
            {
                liczba = load.ReadLine().ToString();
                liczby[k] = liczba;
                k++;
            }
            load.Close();
        }
    }
}
