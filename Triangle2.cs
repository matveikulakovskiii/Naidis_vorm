using System;
using System.Collections.Generic;
using System.Linq;
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
        ListView lb;
        Button btn;
        PictureBox pb;
        PictureBox pb1;
        PictureBox pb2;

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
            btn.Height = 85;
            btn.Width = 100;
            btn.Text = "Käivitamine";
            btn.Location = new Point(260, 40);
            btn.Click += Run_button_Click;
            this.Controls.Add(btn);

            lbl = new Label { BackColor = Color.White };
            lbl.Text = "Külg a";
            lbl.ForeColor = Color.Black;
            lbl.Location = new Point(tree.Width, 0);
            lbl.Size = new Size(60, 20);
            lbl.Location = new Point(50, 40);
            this.Controls.Add(lbl);

            txt_box = new TextBox();
            txt_box.BorderStyle = BorderStyle.Fixed3D;
            txt_box.Height = 50;
            txt_box.Width = 100;
            txt_box.Text = "";
            txt_box.Location = new Point(140, 40);
            this.Controls.Add(txt_box);


            lbl1 = new Label { BackColor = Color.White };
            lbl1.Text = "Külg b";
            lbl1.ForeColor = Color.Black;
            lbl1.Location = new Point(tree.Width, 0);
            lbl1.Size = new Size(60, 20);
            lbl1.Location = new Point(50, 70);
            this.Controls.Add(lbl1);

            txt_box1 = new TextBox();
            txt_box1.BorderStyle = BorderStyle.Fixed3D;
            txt_box1.Height = 50;
            txt_box1.Width = 100;
            txt_box1.Text = "";
            txt_box1.Location = new Point(140, 70);
            this.Controls.Add(txt_box1);


            lbl2 = new Label { BackColor = Color.White };
            lbl2.Text = "Külg c";
            lbl2.ForeColor = Color.Black;
            lbl2.Location = new Point(tree.Width, 0);
            lbl2.Size = new Size(60, 20);
            lbl2.Location = new Point(50, 100);
            this.Controls.Add(lbl2);


            txt_box2 = new TextBox();
            txt_box2.BorderStyle = BorderStyle.Fixed3D;
            txt_box2.Height = 50;
            txt_box2.Width = 100;
            txt_box2.Text = "";
            txt_box2.Location = new Point(140, 100);
            this.Controls.Add(txt_box2);


            lb = new ListView();
            lb.Location = new Point(50, 130);
            lb.Size = new Size(309, 300);
            lb.View = View.Details;
            lb.Columns.Add("Column1", 30);
            lb.Columns.Add("Column2", 30);
            this.Controls.Add(lb);


            pb = new PictureBox();
            pb.Location = new Point(500, 130);
            pb.Image = new Bitmap("../../../3.png");
            pb.Size = new Size(180, 180);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.BorderStyle = BorderStyle.Fixed3D;
            pb.Visible = false;
            this.Controls.Add(pb);

            pb1 = new PictureBox();
            pb1.Location = new Point(500, 130);
            pb1.Image = new Bitmap("../../../2.png");
            pb1.Size = new Size(180, 180);
            pb1.SizeMode = PictureBoxSizeMode.Zoom;
            pb1.BorderStyle = BorderStyle.Fixed3D;
            pb1.Visible = false;
            this.Controls.Add(pb1);

            pb2 = new PictureBox();
            pb2.Location = new Point(500, 130);
            pb2.Image = new Bitmap("../../../1.png");
            pb2.Size = new Size(180, 180);
            pb2.SizeMode = PictureBoxSizeMode.Zoom;
            pb2.BorderStyle = BorderStyle.Fixed3D;
            pb2.Visible = false;
            this.Controls.Add(pb2);
        }



        private void Run_button_Click(object sender, EventArgs e)
        {
            double a, b, c;
            a = Convert.ToDouble(txt_box.Text);
            b = Convert.ToDouble(txt_box1.Text);
            c = Convert.ToDouble(txt_box2.Text);
            Triangle triangle = new Triangle(a, b, c);
            lb.Items.Add("Külg a");
            lb.Items.Add("Külg b");
            lb.Items.Add("Külg c");
            lb.Items.Add("Perimeter");
            lb.Items.Add("Piirkond");
            lb.Items.Add("Kolmnurga kõrgus");
            lb.Items.Add("Kas see on olemas?");
            lb.Items[0].SubItems.Add(triangle.outputA());
            lb.Items[1].SubItems.Add(triangle.outputB());
            lb.Items[2].SubItems.Add(triangle.outputC());
            lb.Items[3].SubItems.Add(Convert.ToString(triangle.Perimetr()));
            lb.Items[4].SubItems.Add(Convert.ToString(triangle.Surface()));
            lb.Items[5].SubItems.Add(Convert.ToString(triangle.Triangle_Heigth()));
            if (triangle.ExistTriangle)
            {
                lb.Items[6].SubItems.Add("See on olemas");
            }
            else
            {
                lb.Items[6].SubItems.Add("See ei ole olemas");
            }
            if (a != b & a != c & b != c)
                pb.Visible = true;
            if (a == b & a == c & b == c)
                pb2.Visible = true;
            if (a == b & a != c & b != c || b == c & b != a & a != c || c == a & a != b & b != c)
                pb1.Visible = true;
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
            if ((a > b & a > c))
                h = (s * 2) / a;
            else if (b > a & b > c)
                h = (s * 2) / b;
            else if (c > a & c > b)
                h = (s * 2) / c;
            return h;
        }

        public double GetSetA
        {
            get { return a; }
            set { a = value; }
        }
        public double GetSetB
        {
            get { return b; }
            set { b = value; }
        }
        public double GetSetC
        {
            get { return c; }
            set { c = value; }
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
