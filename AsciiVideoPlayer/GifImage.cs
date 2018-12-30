using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace AsciiVideoPlayer
{
    class GifImage
    {
        #region Variables
        private Image gifImage;
        private FrameDimension dimension;
        private readonly int frameCount;
        private int currentFrame = -1;
        private const int step = 1;
        #endregion

        public GifImage(string path)
        {
            gifImage = Image.FromFile(path); //Load file from path
            dimension = new FrameDimension(gifImage.FrameDimensionsList[0]); 
            //get frames in animation
            frameCount = gifImage.GetFrameCount(dimension);
        }

        public Bitmap GetNextFrame()
        {
            currentFrame += step;
            //if the animation reaches a boundary
            if (currentFrame >= frameCount || currentFrame < 1) currentFrame = 0;  //go first frame
            return AsciiGenerator.GetReSizedImage(new Bitmap(GetFrame(currentFrame)), 180); //return resized frame
        }

        public Image GetFrame(int index)
        {
            gifImage.SelectActiveFrame(dimension, index);
            //find the frame
            return (Image)gifImage.Clone();
            //return a copy of it
        }

        
    }
}