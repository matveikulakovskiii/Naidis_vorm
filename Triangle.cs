using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Näidis_vorm
{
    internal class Triangle : Form
    {
        public double a;
        public double b;
        public double c;
        TreeView tree;
        TextBox txt_box;

        public Triangle(double A, double B, double C)
        {
            c = C;
            a = A;
            b = B;
        }
        public Triangle()
        {
            this.Height = 600;
            this.Width = 800;
            this.Text = "Kolmnurk";
            tree = new TreeView();
            tree.Dock = DockStyle.Right;
            tree.BorderStyle = BorderStyle.Fixed3D;
            tree.Width = 170;


            txt_box = new TextBox();
            txt_box.BorderStyle = BorderStyle.Fixed3D;
            txt_box.Height = 50;
            txt_box.Width = 100;
            txt_box.Text = "";
            txt_box.Location = new Point(200, 40);
            this.Controls.Add(txt_box);
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
            s = Math.Sqrt((p *(p - a) * (p - b) * (p - c)));
            return s;
        }
        public double Triangle_Heigth()
        {
            double s = 0;
            double p = 0;
            double h = 0;
            p = (a + b + c) / 2;
            s = Math.Sqrt((p * (p - a) * (p - b) * (p - c)));
            h = (s * 2) / 2;
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
                if((a < b + c) && (b < a + c) && (c < a + b))
                return true;
                else return false;
            }
        }


    }
}
