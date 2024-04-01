using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace VideoToAscii
{
    internal class imageToAscii
    {
        public static char getAsciiChar(int value)
        {
            
            char[] asciiCharacters = {'.', ',', '-', '~','*', ':', ';', '=', '!','%', '&', '8', '$','W','#', '@', 'N' };

            int index = 0;

            if (value < 30)
            {
                index = 0;
            }
            else
            {
                index = value / (250 / asciiCharacters.Length) - 1;
            }
            if (index >= asciiCharacters.Length)
            {
                index = asciiCharacters.Length - 1;
            }
            return asciiCharacters[index];
            


            /*
            char[] a = ("$@B%8&WM#*oahkbdpqwmZO0QLCJUYXzcvunxrjft/\\|()1{}[]?-_+~<>i!lI;:,\"^`'. ").ToCharArray();
            Array.Reverse(a);
            string s = new string(a);
            //string s = " `.-':_,^=;><+!rc*\/z?sLTv)J7(|Fi{C}fI31tlu[neoZ5Yxjya]2ESwqkP6h9d4VpOGbUAKXHm8RD#$Bg0MNWQ%&@";
            int index = 0;
            int cutoff = 20;
            if (value < cutoff)
            {
                index = 0;
            }
            else
            {
                double d = ((double)value-cutoff) / (250- cutoff);
                index = (int)(d*s.Length);
            }
            if (index >= s.Length)
            {
                index = s.Length - 1;
            }

            return s[index];
            */
        }
        public static string toAscii(Bitmap bm)
        {

            Bitmap bitmap = bm;
            int bitmapWidth = bitmap.Width;
            int bitmapHeight = bitmap.Height;
            int numberOfAsciiInColumn = 100;

            int scaleFactor = bitmapWidth / numberOfAsciiInColumn;
            int newWidth = bitmapWidth / scaleFactor;
            int newHeight = bitmapHeight / scaleFactor;

            bitmap = new Bitmap(bitmap, new Size(newWidth, newHeight));

            char[] buffer = new char[(newWidth * newHeight * 2) + 2*newHeight + 100];
            int bufferIndex = 0;

            for (int row = 0; row < newHeight; row++)
            {
                for (int column = 0; column < newWidth; column++)
                {
                    Color color = bitmap.GetPixel(column, row);
                    int grey = (color.R + color.G + color.B) / 3;
                    color = Color.FromArgb(grey, grey, grey);
                    bitmap.SetPixel(column, row, color);

                    char c = getAsciiChar(grey);
                    buffer[bufferIndex++] = c;
                    buffer[bufferIndex++] = c;


                    //Console.Write(chooseAsciiChar(grey));
                    //Console.Write(chooseAsciiChar(grey));

                    //chooseAsciiChar(grey);
                }
                buffer[bufferIndex++] = '\r';
                buffer[bufferIndex++] = '\n';
                //Console.WriteLine();
            }
            return (new String(buffer));
        }
    }
}
