namespace Näidis_vorm
{
    public partial class MyForms : Form
    {
        Button btn;
        public MyForms()
        {
            InitializeComponent();
            this.Height = 200;
            this.Width = 200;
            btn = new Button();
            btn.Height = 40;
            btn.Width = 100;
            btn.Text = "Valjuta mind";
            btn.Location = new Point(10, 20);
            this.Controls.Add(btn);
        }

        public MyForms(int x, int y, string nimetus)
        {
            InitializeComponent();
            this.Height = y;
            this.Width = x;
            this.Text = nimetus;
            btn = new Button();
            btn.Height = 40;
            btn.Width = 100;
            btn.Text = "Valjuta mind";
            btn.Location = new Point(10, 20);
            this.Controls.Add(btn);
            btn.Click += Btn_Click;
        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            MyForms form = new MyForms();
            form.ShowDialog();
        }
    }
}