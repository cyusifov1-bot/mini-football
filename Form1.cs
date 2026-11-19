namespace mini_football
{
    public partial class Form1 : Form
    {
        int topX = 6;
        int topY = 6;
        int xal = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && panel1.Left > 0)
            {
                panel1.Left -= 20;
            }

            if (e.KeyCode == Keys.Right && panel1.Right < ClientSize.Width)
            {
                panel1.Left += 20;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Left += topX;
            pictureBox1.Top += topY;

            // Sağ və sol divardan qayıtma
            if (pictureBox1.Left <= 0 || pictureBox1.Right >= ClientSize.Width)
            {
                topX = -topX;
            }

            // Yuxarı divardan qayıtma
            if (pictureBox1.Top <= 0)
            {
                topY = -topY;
            }

            // Platformaya toxunduqda geri qayıtma
            if (pictureBox1.Bounds.IntersectsWith(panel1.Bounds) && topY > 0)
            {
                topY = -topY;

                xal++;
                lblXal.Text = "Xal: " + xal;
            }

            // Top aşağı düşdükdə
            if (pictureBox1.Top >= ClientSize.Height)
            {
                timer1.Stop();

                DialogResult cavab = MessageBox.Show(
                    "Məğlub oldunuz! Oyuna təkrar başlayaqmı?",
                    "Oyun bitdi",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (cavab == DialogResult.Yes)
                {
                    pictureBox1.Left = ClientSize.Width / 2 - pictureBox1.Width / 2;
                    pictureBox1.Top = 50;

                    topX = 5;
                    topY = 5;

                    timer1.Start();

                    xal = 0;
                    lblXal.Text = "Xal: 0";
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
