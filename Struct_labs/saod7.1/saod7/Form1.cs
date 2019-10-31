using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace saod7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MyTable = new TableM(this);
        }

        TableM MyTable;

        public class TableM
        {
            int n = 10;
            bool[,] ls;
            Form1 f_m;
            List<int> AllList = new List<int>();
            int[] flag;
            public TableM(Form1 f)
            {
                f_m = f;
                ls = new bool[n, n];
                ReloadFlags();
            }
            public void ReloadFlags()
            {
                flag = new int[AllList.Count];
                for (int t = 0; t < flag.Length; t++)
                {
                    flag[t] = 0;
                }
            }
            public void ResizeUp(bool[,] a1)
            {
                bool[,] a2 = new bool[a1.Length + 10, a1.Length + 10];
                for (int i = 0; i < a1.Length; i++)
                {
                    for (int j = 0; j < a1.Length; j++)
                    {
                        a2[i, j] = a1[i, j];
                    }
                }
                ls = a2;
            }
            public void Obxod()
            {
                ReloadFlags();
                for (int i = 0; i < AllList.Count; i++)
                {
                    if (flag[i] == 1)
                    {
                        continue;
                    }
                    flag[i] = 1;
                    for (int j = i; j < AllList.Count; j++)
                    {
                        if (ls[i, j] == true)
                        {
                            if (ls[i, j] == ls[j, i])
                            {
                                f_m.Logs.Text += $" |{AllList[i]} <> {AllList[j]}| ";
                            }
                            else
                            {
                                f_m.Logs.Text += $" |{AllList[i]} > {AllList[j]}| ";
                            }
                        }
                    }
                }
            }
            public int FindMYIndx(List<int> l, int val)
            {
                for (int i = 0; i < l.Count; i++)
                {
                    if (l[i] == val)
                    {
                        return i;
                    }
                }
                return -1;
            }
            public void AddZero(int val)
            {
                AllList.Add(val);
            }
            public void AddNode(string val_t, string parent_t, int mode)
            {
                int val, parent;
                try
                {
                    val = Convert.ToInt32(val_t);
                }
                catch
                {
                    f_m.Logs.Text = "Error val";
                    return;
                }
                if (AllList.Count == 0)
                {
                    AddZero(val);
                    return;
                }
                try
                {
                    parent = Convert.ToInt32(parent_t);
                }
                catch
                {
                    f_m.Logs.Text = "Error parent";
                    return;
                }
                int X = FindMYIndx(AllList, parent);
                if (X == -1)
                {
                    if (AllList.Count != 0)
                        f_m.Logs.Text = "Parent not found";
                    else
                    {
                        AddZero(val);
                    }
                    return;
                }
                int Y;
                if (!AllList.Contains(val))
                {
                    AllList.Add(val);
                }
                Y = FindMYIndx(AllList, val);
                if (X > ls.Length - 1 && Y > ls.Length - 1)
                {
                    ResizeUp(ls);
                }
                if (mode == 1)
                    ls[X, Y] = true;
                else
                {
                    ls[X, Y] = true;
                    ls[Y, X] = true;
                }
            }
            public void DeleteNode(int val)
            {
                int Y = FindMYIndx(AllList, val);
                if (Y == -1)
                {
                    f_m.Logs.Text = "Parent not found";
                    return;
                }
                if (Y > ls.Length - 1)
                {
                    ResizeUp(ls);
                }
                else
                {
                    for (int i = 0; i < AllList.Count; i++)
                    {
                        ls[i, Y] = false;
                        ls[Y, i] = false;
                    }
                    AllList.Remove(Y);
                }
            }
        }
        private void AddType1_Click(object sender, EventArgs e)
        {
            Logs.Text = "";
            MyTable.AddNode(AddTextBox.Text, ParentTextBox.Text, 1);
            AddTextBox.Text = "";
        }

        private void AddType2_Click(object sender, EventArgs e)
        {
            Logs.Text = "";
            MyTable.AddNode(AddTextBox.Text, ParentTextBox.Text, 2);
            AddTextBox.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logs.Text = "";
            MyTable.Obxod();
            AddTextBox.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Logs.Text = "";
            MyTable.DeleteNode(Convert.ToInt32(AddTextBox.Text));
            AddTextBox.Text = "";
        }

        private void button2_Click_1(object sender, EventArgs e)
        { }

        private void button3_Click(object sender, EventArgs e)
        {
        }
    }
}
/*
 Меню File должно иметь пункты New, Open и 
 Save As для создания, сохранения и загрузки сетей.
     Расширьте программу, добавив в нее инструмент,
     который ищет и отображает дерево кратчайшего пути с
     установкой меток. Его корень должен находиться в узле,
     по которому щелкнул пользователь.
     */
