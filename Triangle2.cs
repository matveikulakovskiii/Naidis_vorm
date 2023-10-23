using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Näidis_vorm
{
    internal class Triangle2 : Form
    {
        public double a;
        public double b;
        public double c;
        TreeView tree;
        TextBox txt_box;
        Label lbl;
        TextBox txt_box1;
        Label lbl1;
        TextBox txt_box2;
        Label lbl2;
        Label lbl3;
        Label lbl4;
        ListView lv;
        Button btn;
        Button btn2;
        Button btn3;
        Button btn4;
        PictureBox pb;
        ListBox lb;

        public Triangle2(double A, double B, double C)
        {
            c = C;
            a = A;
            b = B;
        }
        public Triangle2()
        {

            this.Height = 600;
            this.Width = 800;
            this.Text = "Oma Vorm";
            tree = new TreeView();
            tree.Dock = DockStyle.Right;
            tree.BorderStyle = BorderStyle.Fixed3D;
            tree.Width = 170;


            btn = new Button();
            btn.Height = 105;
            btn.Width = 100;
            btn.Text = "Käivitamine";
            btn.Location = new Point(600, 450);
            btn.Click += Run_button_Click;
            this.Controls.Add(btn);

            btn4 = new Button();
            btn4.Height = 40;
            btn4.Width = 154;
            btn4.Text = "Ajaloo puhustamine";
            btn4.Location = new Point(455, 350);
            btn4.Click += Run_button_Click4;
            this.Controls.Add(btn4);

            btn3 = new Button();
            btn3.Height = 40;
            btn3.Width = 154;
            btn3.Text = "Värskendada";
            btn3.Location = new Point(120, 490);
            btn3.Click += Run_button_Click3;
            this.Controls.Add(btn3);

            lbl = new Label { BackColor = Color.White };
            lbl.Text = "Külg a";
            lbl.Location = new Point(tree.Width, 0);
            lbl.Size = new Size(60, 20);
            lbl.Location = new Point(400, 450);
            this.Controls.Add(lbl);

            lbl4 = new Label { BackColor = Color.White };
            lbl4.Text = "";
            lbl4.Location = new Point(tree.Width, 0);
            lbl4.Size = new Size(155, 20);
            lbl4.Location = new Point(455, 300);
            lbl4.Visible = false;
            this.Controls.Add(lbl4);

            txt_box = new TextBox();
            txt_box.BorderStyle = BorderStyle.Fixed3D;
            txt_box.Height = 50;
            txt_box.Width = 100;
            txt_box.Text = "";
            txt_box.Location = new Point(480, 450);
            this.Controls.Add(txt_box);


            lbl1 = new Label { BackColor = Color.White };
            lbl1.Text = "Külg b";
            lbl1.ForeColor = Color.Black;
            lbl1.Location = new Point(tree.Width, 0);
            lbl1.Size = new Size(60, 20);
            lbl1.Location = new Point(400, 490);
            this.Controls.Add(lbl1);

            txt_box1 = new TextBox();
            txt_box1.BorderStyle = BorderStyle.Fixed3D;
            txt_box1.Height = 50;
            txt_box1.Width = 100;
            txt_box1.Text = "";
            txt_box1.Location = new Point(480, 490);
            this.Controls.Add(txt_box1);


            lbl2 = new Label { BackColor = Color.White };
            lbl2.Text = "Külg c";
            lbl2.ForeColor = Color.Black;
            lbl2.Location = new Point(tree.Width, 0);
            lbl2.Size = new Size(60, 20);
            lbl2.Location = new Point(400, 530);
            this.Controls.Add(lbl2);

            lbl3 = new Label { BackColor = Color.White };
            lbl3.Location = new Point(tree.Width, 0);
            lbl3.Size = new Size(180, 20);
            lbl3.Location = new Point(110, 450);
            lbl3.Text = "";
            this.Controls.Add(lbl3);


            txt_box2 = new TextBox();
            txt_box2.BorderStyle = BorderStyle.Fixed3D;
            txt_box2.Height = 50;
            txt_box2.Width = 100;
            txt_box2.Text = "";
            txt_box2.Location = new Point(480, 530);
            this.Controls.Add(txt_box2);


            lv = new ListView();
            lv.Location = new Point(50, 130);
            lv.Size = new Size(309, 300);
            lv.View = View.Details;
            lv.Columns.Add("Column1", 30);
            lv.Columns.Add("Column2", 30);
            this.Controls.Add(lv);


            pb = new PictureBox();
            pb.Location = new Point(440, 40);
            pb.Image = new Bitmap("../../../3.png");
            pb.Size = new Size(180, 180);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.BorderStyle = BorderStyle.Fixed3D;
            pb.Visible = false;
            this.Controls.Add(pb);


            lb = new ListBox();
            lb.Size = new Size(310, 100);
            lb.Location = new Point(50,20);
            this.Controls.Add(lb);
            lb.Visible = false;

            btn2 = new Button();
            btn2.Height = 40;
            btn2.Width = 154;
            btn2.Text = "Lugu";
            btn2.Location = new Point(455, 400);
            btn2.Click += Run_button_Click2;
            this.Controls.Add(btn2);

        }



        private void Run_button_Click(object sender, EventArgs e)
        {
            double a, b, c;
            a = Convert.ToDouble(txt_box.Text);
            b = Convert.ToDouble(txt_box1.Text);
            c = Convert.ToDouble(txt_box2.Text);
            Triangle triangle = new Triangle(a, b, c);
            if (triangle.ExistTriangle)
            {
                lv.Items.Add("Külg a");
                lv.Items.Add("Külg b");
                lv.Items.Add("Külg c");
                lv.Items.Add("Perimeter");
                lv.Items.Add("Piirkond");
                lv.Items.Add("Kolmnurga kõrgus");
                lv.Items.Add("Kas see on olemas?");
                lv.Items[0].SubItems.Add(triangle.outputA());
                lv.Items[1].SubItems.Add(triangle.outputB());
                lv.Items[2].SubItems.Add(triangle.outputC());
                lv.Items[3].SubItems.Add(Convert.ToString(triangle.Perimetr()));
                lv.Items[4].SubItems.Add(Convert.ToString(triangle.Surface()));
                lv.Items[5].SubItems.Add(Convert.ToString(triangle.Triangle_Heigth()));
                if (triangle.ExistTriangle)
                {
                    lv.Items[6].SubItems.Add("See on olemas");
                }
                else
                {
                    lv.Items[6].SubItems.Add("See ei ole olemas");
                }
                if (a != b & a != c & b != c)
                {
                    pb.Visible = true;
                    lbl4.Visible = true;
                    lbl4.Text = "Mitmekülgne";
                }
                if (a == b & a == c & b == c)
                {
                    pb.Image = new Bitmap("../../../1.png");
                    pb.Visible = true;
                    lbl4.Visible = true;
                    lbl4.Text = "Võrdkülgne";
                }
                if (a == b & a != c & b != c || b == c & b != a & a != c || c == a & a != b & b != c)
                {
                    pb.Image = new Bitmap("../../../2.png");
                    pb.Visible = true;
                    lbl4.Text = "Võrdhaarne";
                    lbl4.Visible = true;
                }  
                lb.Items.Add("Külg a = " + triangle.outputA());
                lb.Items.Add("Külg b = " + triangle.outputB());
                lb.Items.Add("Külg c = " + triangle.outputC());
                lb.Items.Add("Perimeter = " + Convert.ToString(triangle.Perimetr()));
                lb.Items.Add("Piirkond = " + Convert.ToString(triangle.Surface()));
                lb.Items.Add("Kolmnurga kõrgus = " + Convert.ToString(triangle.Triangle_Heigth()));
                lb.Items.Add("Tüüp = " + lbl4.Text);
                lb.Items.Add("");
                lb.Items.Add("");
            }
            else
            {
                lbl3.Text = "Sellist kolmnurka pole olemas.";
            }
            
        }

        private void Run_button_Click3(object sender, EventArgs e)
        {
            lv.Items.Clear();
            pb.Visible = false;
            lbl3.Text = "";
            lbl4.Visible = false;
        }
        private void Run_button_Click2(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Kas soovite näha oma taotluste ajalugu?", "Küsimus", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                lb.Visible = true;

            }
            else
            {
                lb.Visible = false;
            }
        }
        private void Run_button_Click4(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Kas soovite oma ajalugu puhustada ?", "Küsimus", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                lb.Items.Clear();
            }
            else
            {
                return;
            }
        }
        public string outputA()
        {
            return Convert.ToString(a);
        }
        public string outputB()
        {
            return Convert.ToString(b);
        }
        public string outputC()
        {
            return Convert.ToString(c);
        }

        public double Perimetr()
        {
            return a + b + c;
        }
        public double Surface()
        {
            double s = 0;
            double p = 0;
            p = (a + b + c) / 2;
            s = Math.Sqrt((p * (p - a) * (p - b) * (p - c)));
            return s;
        }
        public double Triangle_Heigth()
        {
            double s = 0;
            double p = 0;
            double h = 0;
            p = (a + b + c) / 2;
            s = Math.Sqrt((p * (p - a) * (p - b) * (p - c)));
            if (a > b & a > c)
                h = (s * 2) / a;
            else if (b > a & b > c)
                h = (s * 2) / b;
            else if (c > a & c > b)
                h = (s * 2) / c;
            else if (a > b & c > b & a == c)
                h = (s * 2) / a;
            else if (a > c & b > c & a == b)
                h = (s * 2) / a;
            else if (b > a & c > a & b == c)
                h = (s * 2) / b;
            else if (a == b & a == c & c == b)
                h = (s * 2) / a;
            return h;
        }

 
        public bool ExistTriangle
        {
            get
            {
                if ((a < b + c) && (b < a + c) && (c < a + b))
                    return true;
                else return false;
            }
        }

    }
}
