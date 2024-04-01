using Emgu.CV;
using System.Drawing;
using System;
namespace VideoToAscii
{
    internal class VideoIn
    {
        public static void startCapture(VideoCapture captureCaller, PictureBox pictureBox1)
        {

            VideoCapture capture = captureCaller;

            
            Mat frame = new Mat();
            Bitmap map;
            capture.Read(frame);
            map = frame.ToBitmap();
            frame.Dispose();
            //Thread.Sleep(1000);
            string s = VideoToAscii.imageToAscii.toAscii(map);

            //
            
            
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.Clear(Color.Black);
            graphics.DrawString(s, new Font("Consolas", 5, FontStyle.Regular), new SolidBrush(Color.White), new Point(10, 10));
            pictureBox1.Image = bmp;
            //

            
        }
    }
}
