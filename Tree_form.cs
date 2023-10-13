using Microsoft.VisualBasic;
using Näidis_vorm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Näiteks
{
    public partial class FarmTree : Form
    {
        TreeView tree;
        Button btn;
        Button btn2;
        Label lbl;
        TextBox txt_box;
        RadioButton r1, r2;
        CheckBox c1, c2;
        PictureBox pb;
        ListBox lb;
        public FarmTree()
        {
            

            this.Height = 600;
            this.Width = 800;
            this.Text = "Vorm põhielementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.BorderStyle = BorderStyle.Fixed3D;
            tree.Width = 170;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode treeNode = new TreeNode("Elemendid");



            treeNode.Nodes.Add(new TreeNode("Nupp-Button"));
            btn = new Button();
            btn.Height = 40;
            btn.Width = 100;
            btn.Text = "Valjuta mind!";
            btn.Location = new Point(150, 50);
            btn.Click += Btn_Click;
            btn.MouseHover += Btn_MouseHover;
            btn.MouseLeave += Btn_MouseLeave;
            btn.Visible = false;
            this.Controls.Add(btn);



            treeNode.Nodes.Add(new TreeNode("Silt-Label"));
            lbl = new Label { BackColor = Color.White };
            lbl.Text = "Pealkiri";
            lbl.ForeColor = Color.Black;
            lbl.Location = new Point(tree.Width, 0);
            lbl.Size = new Size(this.Width, btn.Location.Y);
            lbl.Visible = false;
            this.Controls.Add(lbl);



            treeNode.Nodes.Add(new TreeNode("Tekstkast-Textbox"));
            txt_box = new TextBox();
            txt_box.BorderStyle = BorderStyle.Fixed3D;
            txt_box.Height = 50;
            txt_box.Width = 100;
            txt_box.Text = "";
            txt_box.Location = new Point(tree.Width, btn.Top + btn.Height + 5);
            txt_box.KeyDown += new KeyEventHandler(Txt_box_KeyDown);
            this.Controls.Add(txt_box);
            




            treeNode.Nodes.Add(new TreeNode("Radionupp-RadioButton"));
            r1 = new RadioButton();
            r1.Text = "valik 1";
            r1.Location = new Point(tree.Width + txt_box.Location.Y + txt_box.Height);
            r2 = new RadioButton();
            r2.Text = "valik 2";
            r2.Location = new Point(r1.Location.X + r1.Width, txt_box.Location.Y + txt_box.Height);
            r1.CheckedChanged += new EventHandler(RadioButtons_Changed);
            r2.CheckedChanged += new EventHandler(RadioButtons_Changed);
            txt_box.Visible = false;
            r1.Visible = false;
            r2.Visible = false;
            this.Controls.Add(r1);
            this.Controls.Add(r2);


            treeNode.Nodes.Add(new TreeNode("Checknupp-CheckBox"));
            c1 = new CheckBox();
            c1.Text = "valik 1";
            c1.Location = new Point(tree.Width + r2.Location.Y + r2.Height);
            c2 = new CheckBox();
            c2.Text = "valik 2";
            c2.Location = new Point(tree.Width, c1.Location.Y + c1.Height);
            c1.CheckedChanged += new EventHandler(CheckButtons_Changed);
            c2.CheckedChanged += new EventHandler(CheckButtons_Changed);
            c1.Visible = false;
            c2.Visible = false;
            this.Controls.Add(c1);
            this.Controls.Add(c2);

            treeNode.Nodes.Add(new TreeNode("Image"));
            pb = new PictureBox();
            pb.Location = new Point(tree.Width, c2.Location.Y + c2.Height);
            pb.Image = new Bitmap("../../../Cute.png");
            pb.Size = new Size(300, 300);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(pb);
            pb.Visible = false;

            tree.Nodes.Add(treeNode);
            this.Controls.Add(tree);


            //Loetelu
            treeNode.Nodes.Add(new TreeNode("ListBox"));
            lb = new ListBox();
            lb.Items.Add("Roheline");
            lb.Items.Add("Sinine");
            lb.Items.Add("Hall");
            lb.Items.Add("Kollane");
            lb.Location = new Point(tree.Width, pb.Location.Y + pb.Height);
            this.Controls.Add(lb); 
            lb.Visible = false;


            //Data
            treeNode.Nodes.Add(new TreeNode("DataGridView"));
            DataSet ds = new DataSet("XML file");
            ds.ReadXml(@"..\..\..\aa.xml");
            DataGridView DataGrip = new DataGridView();
            DataGrip.Location= new Point(tree.Width + pb.Width, pb.Location.Y);
            DataGrip.Height = 200;
            DataGrip.Width = 500;
            DataGrip.DataSource= ds;
            DataGrip.AutoGenerateColumns= true;
            DataGrip.AutoSize=true;
            DataGrip.Visible = false;
            DataGrip.DataMember = "customer";
            this.Controls.Add(DataGrip);


            treeNode.Nodes.Add(new TreeNode("Kolmnurk"));
            btn2 = new Button();
            btn2.Height = 40;
            btn2.Width = 100;
            btn2.Text = "Kolmnurk";
            btn2.Location = new Point(200, 50);
            btn2.Click += Btn_Click2;
            btn2.Visible = false;
            this.Controls.Add(btn2);



        }
        
    private void Txt_box_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult result = MessageBox.Show("Kas sa tahad kustutada(Yes) või lisandada(No)?", "Küsimus", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    lb.Items.Add(txt_box.Text);
                    
                }
                else
                {
                     lb.Items.Remove(txt_box.Text);
                }
            }
        }
        

        private void CheckButtons_Changed(object? sender, EventArgs e)
        {
            if (c1.Checked = true && c2.Checked == true)
            {
                c1.ForeColor = Color.Purple;
                c2.ForeColor = Color.Purple;
            }
            else if (c1.Checked == true && c2.Checked == false)
            {
                c1.ForeColor = Color.Red;
            }
            else if (c1.Checked == false && c2.Checked == true)
            {
                c1.ForeColor = Color.Blue;
            }
            else if (c1.Checked = false && c2.Checked == false)
            {
                c1.ForeColor = Color.White;
                c2.ForeColor = Color.White;
            }
        }

        private void RadioButtons_Changed(object? sender, EventArgs e)
        {
            if (r1.Checked)
            {
                r1.ForeColor = Color.Green;
            }
            else if (r2.Checked)
            {
                r2.ForeColor = Color.Red;
            }
            else
            {
                r1.ForeColor = Color.White;
                r2.ForeColor = Color.White;
            }
        }

        private void Btn_MouseLeave(object? sender, EventArgs e)
        {
            btn.Text = "Valjuta mind!";
            btn.BackColor = Color.White;
            btn.Height = 40;
            btn.Width = 100;
        }

        private void Btn_MouseHover(object? sender, EventArgs e)
        {
            btn.Text = "Your mouse on button";
            btn.BackColor = Color.Aqua;
            btn.Height = 80;
            btn.Width = 200;
        }

        private void Tree_AfterSelect(object? sender, TreeViewEventArgs e)
        {

            if (e.Node.Text == "Nupp-Button" && btn.Visible == true)
            {
                btn.Visible = false;
            }
            else if (e.Node.Text == "Nupp-Button" && btn.Visible == false)
            {
                btn.Visible = true;
            }
            if (e.Node.Text == "Kolmnurk" && btn2.Visible == true)
            {
                btn2.Visible = false;
            }
            else if (e.Node.Text == "Kolmnurk" && btn2.Visible == false)
            {
                btn2.Visible = true;
            }

            if (e.Node.Text == "Silt-Label" && lbl.Visible == true)
            {
                lbl.Visible = false;
            }
            else if (e.Node.Text == "Silt-Label" && lbl.Visible == false)
            {
                lbl.Visible = true;
            }

            if (e.Node.Text == "Tekstkast-Textbox" && txt_box.Visible == true)
            {
                txt_box.Visible = false;
            }
            else if (e.Node.Text == "Tekstkast-Textbox" && txt_box.Visible == false)
            {
                txt_box.Visible = true;
            }
            if (e.Node.Text == "Radionupp-RadioButton" && r1.Visible == true)
            {
                r1.Visible = false;
                r2.Visible = false;
            }
            else if (e.Node.Text == "Radionupp-RadioButton" && r2.Visible == false)
            {
                r1.Visible = true;
                r2.Visible = true;
            }
            if (e.Node.Text == "Checknupp-CheckBox" && c1.Visible == true)
            {
                c1.Visible = false;
                c2.Visible = false;
            }
            else if (e.Node.Text == "Checknupp-CheckBox" && c2.Visible == false)
            {
                c1.Visible = true;
                c2.Visible = true;
            }
            if (e.Node.Text == "Image" && pb.Visible == true)
            {
                pb.Visible = false;
            }
            else if (e.Node.Text == "Image" && pb.Visible == false)
            {
                pb.Visible = true;
            }
            if (e.Node.Text == "ListBox" && lb.Visible == true)
            {
                lb.Visible = false;
            }
            else if (e.Node.Text == "ListBox" && lb.Visible == false)
            {
                lb.Visible = true;
            }

           
            
            tree.SelectedNode = null;

        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            if (btn.BackColor == Color.Aqua)
            {
                btn.BackColor = Color.Chocolate;
            }
            else
            {
                btn.BackColor = Color.Aqua;
            }
        }

        private void Btn_Click2(object? sender, EventArgs e)
        {
            Triangle triangle = new Triangle();
            triangle.Show();
            
        }
    }
}