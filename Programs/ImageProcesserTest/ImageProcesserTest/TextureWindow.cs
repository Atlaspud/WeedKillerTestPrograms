using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ImageProcessorTest
{
    public class TextureWindow
    {
        private Image<Gray, Byte> _image;
        public Image<Gray, Byte> image
        {
            get { return _image; }
            set { _image = value; }
        }

        private double[] _data;
        public double[] data
        {
            get { return _data; }
            set { _data = value; }
        }

        private int _x;
        public int x
        {
            get { return _x; }
            set { _x = value; }
        }

        private int _y;
        public int y
        {
            get { return _y; }
            set { _y = value; }
        }

        private double _mean;
        public double mean
        {
            get { return _mean; }
            set { _mean = value; }
        }

        private double _variance;
        public double variance
        {
            get { return _variance; }
            set { _variance = value; }
        }

        private double[] _textureSignature;
        public double[] textureSignature
        {
            get { return _textureSignature; }
            set { _textureSignature = value; }
        }

        public TextureWindow(Image<Gray, Byte> input, int X, int Y)
        {
            image = input;
            x = X;
            y = Y;
        }

        public TextureWindow()
        {
        }

        /*public void CalculateStatistics()
        {
            Byte[, ,] imageData = image.Data;
            data = new double[image.Height * image.Width];
            unsafe
            {
                fixed (Byte* inputPointer = imageData)
                {
                    for (int i = 0; i < image.Height * image.Width; i++)
                    {
                        data[i] = (double)*(inputPointer + i);
                    }
                }
            }
            mean = data.Average();
            variance = data.Sum(d => Math.Pow(d - mean, 2)) / data.Length;
        }*/
    }
}