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
            MainOp = new NodeOp(this);
        }

        NodeOp MainOp;

        public class Node
        {
            public bool flag = false;
            public int Value = 0;
            public List<Node> Set = new List<Node>();
            public Node(int val)
            {
                Value = val;
            }
        }

        public class NodeOp
        {
            public List<Node> AllNode = new List<Node>();
            public int Count;
            Form1 tf;

            public NodeOp(Form1 f_m)
            {
                tf = f_m;
            }

            public int FindIndx(Node first, int v, ref int vxod, int id = 0)
            {
                int res = 0;
                if (first.flag != true)
                {
                    first.flag = true;
                    if (first.Value == v)
                    {
                        vxod--;
                        res = id;
                    }
                    if (vxod == 0)
                    {
                        return res;
                    }
                    else
                    {
                        foreach (var t in first.Set)
                        {
                            id++;
                            if (t.flag != true)
                            {
                                t.flag = true;
                                if (t.Value == v)
                                {
                                    vxod--;
                                    res = id;
                                }
                                if (vxod == 0)
                                {
                                    break;
                                }
                                else
                                {
                                    FindIndx(first.Set[id], v, ref vxod, ++id);
                                }
                            }
                        }
                    }
                }
                return res;
            }
            public void AddType0(int val)
            {
                AllNode.Add(new Node(val));
            }
            public void AddType1(Node parent, int val)
            {
                if (AllNode.Count == 0)
                    AddType0(val);
                else
                {
                    parent.Set.Add(new Node(val));
                    AllNode.Add(parent.Set.Last());
                }
            }
            public void AddType2(Node parent, int val)
            {
                if (AllNode.Count == 0)
                    AddType0(val);
                else
                {
                    parent.Set.Add(new Node(val));
                    parent.Set.Last().Set.Add(parent);
                    AllNode.Add(parent.Set.Last());
                }
            }
            public void AddType1T(Node parent, Node obj)
            {
                    parent.Set.Add(obj);
                    AllNode.Add(parent.Set.Last());
                
            }
            public void AddType2T(Node parent, Node obj)
            {
                parent.Set.Add(obj);
                parent.Set.Last().Set.Add(parent);
                AllNode.Add(parent.Set.Last());
            }
            public void Obxod(Node obj)
            {
                obj.flag = true;
                tf.Logs.Text += obj.Value + " ";
                foreach (var t in obj.Set)
                {
                    if (t.flag != true)
                    {
                        Obxod(t);
                    }
                }
            }
            public void ObxodB(Node obj)
            {
                obj.flag = false;
                foreach (var t in obj.Set)
                {
                    if (t.flag != false)
                    {
                        ObxodB(t);
                    }
                }
            }
            public void Delete(List<Node> LN, int Ve)
            {

                for (int t = 0; t < LN.Count; t++)
                {
                    if (LN[t] != null)
                    {
                        if (LN[t].flag != true)
                        {
                            LN[t].flag = true;
                            for (int i = 0; i < LN[t].Set.Count; i++)
                            {
                                if (LN[t].Set[i] != null)
                                {
                                    if (LN[t].Set[i].Value == Ve)
                                    {
                                        LN[t].Set[i] = null;
                                    }
                                    if (LN[t].Set[i] == null)
                                    {
                                        LN[t].Set.RemoveAt(i);
                                        i--;

                                    }
                                }
                            }
                        }
                    }
                }

                for (int t = 0; t < LN.Count; t++)
                {
                    if (LN[t].Value == Ve)
                    {
                        LN[t] = null;
                    }
                    if (LN[t] == null)
                    {
                        LN.RemoveAt(t);
                        t--;
                    }
                }
            }
            public void RestartAllFlag()
            {
                ObxodB(AllNode[0]);
            }
        }

        private void AddType1_Click(object sender, EventArgs e)
        {
            try
            {
                int vx = 0; ;
                if (InTextBox.Text != "")
                {
                    vx = Convert.ToInt32(InTextBox.Text);
                }
                MainOp.AddType1(MainOp.AllNode[MainOp.FindIndx(MainOp.AllNode[0], Convert.ToInt32(ParentTextBox.Text), ref vx, 0)], Convert.ToInt32(AddTextBox.Text));
            }
            
            catch (FormatException)
            {
                Logs.Text = "error";
            }
            catch
            {
                MainOp.AddType0(Convert.ToInt32(AddTextBox.Text));
            }
            MainOp.RestartAllFlag();
            AddTextBox.Text = "";
        }

        private void AddType2_Click(object sender, EventArgs e)
        {
            try
            {
                int vx = 0;
                if (InTextBox.Text != "")
                {
                    vx = Convert.ToInt32(InTextBox.Text);
                }
                MainOp.AddType2(MainOp.AllNode[MainOp.FindIndx(MainOp.AllNode[0], Convert.ToInt32(ParentTextBox.Text), ref vx, 0)], Convert.ToInt32(AddTextBox.Text));
            }
            catch (FormatException)
            {
                Logs.Text = "error";
            }
            catch
            {
                MainOp.AddType0(Convert.ToInt32(AddTextBox.Text));
            }
            MainOp.RestartAllFlag();
            AddTextBox.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MainOp.AllNode.Count != 0)
            {
                Logs.Text = "";
                MainOp.Obxod(MainOp.AllNode[0]);
            }
            else
            {
                Logs.Text = "null";
            }
            MainOp.RestartAllFlag();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MainOp.Delete(MainOp.AllNode, Convert.ToInt32(AddTextBox.Text));
            }
            catch (FormatException)
            {
                Logs.Text = "error Arg";
            }
            catch
            {
                Logs.Text = "error";
            }
            MainOp.RestartAllFlag();
            AddTextBox.Text = "";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                int vx = 0; ;
                if (InTextBox.Text != "")
                {
                    vx = Convert.ToInt32(InTextBox.Text);
                }
                MainOp.AddType1T(MainOp.AllNode[MainOp.FindIndx(MainOp.AllNode[0], Convert.ToInt32(ParentTextBox.Text), ref vx, 0)], MainOp.AllNode[MainOp.FindIndx(MainOp.AllNode[0], Convert.ToInt32(ParentTextBox.Text), ref vx, 0)]);
            }

            catch (FormatException)
            {
                Logs.Text = "error";
            }
            catch
            {
                MainOp.AddType0(Convert.ToInt32(AddTextBox.Text));
            }
            MainOp.RestartAllFlag();
            AddTextBox.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int vx = 0; ;
                if (InTextBox.Text != "")
                {
                    vx = Convert.ToInt32(InTextBox.Text);
                }
                MainOp.AddType2T(MainOp.AllNode[MainOp.FindIndx(MainOp.AllNode[0], Convert.ToInt32(ParentTextBox.Text), ref vx, 0)], MainOp.AllNode[MainOp.FindIndx(MainOp.AllNode[0], Convert.ToInt32(ParentTextBox.Text), ref vx, 0)]);
            }

            catch (FormatException)
            {
                Logs.Text = "error";
            }
            catch
            {
                MainOp.AddType0(Convert.ToInt32(AddTextBox.Text));
            }
            MainOp.RestartAllFlag();
            AddTextBox.Text = "";

        }
    }
}
