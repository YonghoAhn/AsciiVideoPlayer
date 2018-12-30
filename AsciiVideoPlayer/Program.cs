using System;
using System.Drawing;
using System.Text;
using System.Threading;

namespace AsciiVideoPlayer
{
    class Program
    {
       
        private static string Path;
        private static GifImage gifImage;
        static void Main(string[] args)
        {
            //Program entry point
            Console.CursorSize = 8;
            Path = Console.ReadLine();
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.WindowHeight = Console.LargestWindowHeight;
            try
            {
                gifImage = new GifImage(Path);
                var t = new Timer(TimerTick, null, 0, 60);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();

        }
        private static void TimerTick(object o)
        {
            GenerateAscii(gifImage.GetNextFrame());
            GC.Collect();
        }

        private static void GenerateAscii(Bitmap i)
        {
            //Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.Write(AsciiGenerator.ConvertToAscii(i));
            i.Dispose();
        }

    }
}
