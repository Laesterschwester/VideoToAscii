using Emgu.CV;
using System;
using System.Threading.Tasks;
namespace VideoToAscii
{
    public partial class Form1 : Form
    {
        VideoCapture capture;
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Text = "videoOn";
            pictureBox1.Height = this.Height;
            pictureBox1.Width = this.Width;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private async void textBox1_startStream()
        {
            /*capture = new VideoCapture(0);

            for(int i = 0; i< 10 ; i++)
            {
                textBox1.Text = "hello";
                textBox1.Clear();
                textBox1.Text = VideoIn.startCapture(capture);

            }*/

            capture = new VideoCapture(0);

            while (checkBox1.Checked)
            {
                // Capture image asynchronously
                await Task.Run(() => VideoIn.startCapture(capture, pictureBox1));

                // Update UI on the UI thread
                /*textBox1.Invoke(new Action(() =>
                {
                    textBox1.Clear();
                    textBox1.Text = asciiImage;
                }));
                */

                // Add a delay between captures
                //await Task.Delay(50); // Adjust delay as needed
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1_startStream();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
