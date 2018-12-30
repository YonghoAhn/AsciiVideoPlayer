using System;
using System.Drawing;
using System.Text;
using System.Threading;

namespace AsciiVideoPlayer
{
    class Program
    {
       
        private static string _Content;
        private static string Path;
        private static GifImage a;
        static void Main(string[] args)
        {
            //Program entry point
            Console.CursorSize = 8;
            Path = Console.ReadLine();
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.WindowHeight = Console.LargestWindowHeight;
            try
            {
                a = new GifImage(Path);
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
            GenerateAscii(a.GetNextFrame());
            GC.Collect();
        }

        private static void GenerateAscii(Bitmap i)
        {
            //Console.Clear();
            Console.SetCursorPosition(0, 0);
            _Content = AsciiGenerator.ConvertToAscii(i);
            Console.Write(_Content);
            i.Dispose();
        }

    }
}
