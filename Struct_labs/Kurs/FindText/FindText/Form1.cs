using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                button1.Text = "String Null";
            }
            else if (richTextBox1.Text.Length < textBox1.Text.Length)
            {
                button1.Text = "Key very large";
            }
            else
            {
                richTextBox1.SelectAll();
                richTextBox1.SelectionColor = Color.Black;
                Etap2_Search(richTextBox1.Text, textBox1.Text);
            }
        }

        int[] Etap1_Table(string key)
        {
            int[] Table = new int[key.Length];
            for (int t = 0; t < Table.Length; t++)
            {
                Table[t] = Table.Length;
            }
            //Для всех элементов
            for (int i = key.Length - 2; i >= 0; i--)
            {
                if (Table[i] == Table.Length)
                {
                    Table[i] = Table.Length - i - 1;
                    for (int j = 0; j < i; j++)
                    {
                        if (key[i] == key[j])
                        {
                            Table[j] = Table[i];
                        }
                    }
                }
            }
            //Прописание последнего элемента
            for (int i = 0; i < Table.Length - 2; i++)
            {
                if (key[i] == key[Table.Length - 1])
                {
                    Table[Table.Length - 1] = Table[i];
                    break;
                }
            }
            return Table;
        }

        private int FindInKey(string line, string key, int k)
        {
            for (int i = 0; i < key.Length; i++)
            {
                if (line[k] == key[i])
                {
                    return i;
                }
            }
            return key.Length;
        }
        private void ViewText(string line, string key, int k)
        {
            richTextBox1.Select(k+1, key.Length);
            richTextBox1.SelectionColor = Color.Red;
            button1.Text = "Found!";
        }

        void Etap2_Search(string line, string key)
        {
            int[] Table = Etap1_Table(key);

            int k = key.Length - 1;
            int l = key.Length - 1;
            bool ut = true;
            for (; ut == true;)
            {
                for (l = key.Length - 1; ;)
                {
                    if (k >= line.Length)
                    {
                        button1.Text = "Not Found!";
                        ut = false;
                        break;
                    }
                    if (l < 0)
                    {
                        ViewText(line, key, k);
                        ut = false;
                        break;
                    }
                    if (key[l] != line[k])
                    {
                        if (key[l] == key[key.Length - 1])
                        {
                            if (FindInKey(line, key, k) == Table.Length)
                            {
                                k += Table.Length;
                            }
                            else
                                k += Table[FindInKey(line, key, k)];
                        }
                        else
                            k += Table[Table.Length - 1];
                        break;
                    }
                    else if (key[l] == line[k])
                    {
                        l--;
                        k--;
                    }
                }
            }
        }
    }
}
