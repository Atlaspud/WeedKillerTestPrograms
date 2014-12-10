using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessorTest
{
    public delegate void ImageProcessedEventHandler(object sender, ImageProcessedEventArgs e);

    public class ImageProcessedEventArgs : EventArgs
    {
        public int processingTime { get; set; }
        public Bitmap processedImage { get; set; }
        public uint serial { get; set; }

        public ImageProcessedEventArgs(int processingTime, Bitmap processedImage, uint serial)
        {
            this.processingTime = processingTime;
            this.processedImage = processedImage;
            this.serial = serial;
        }
    }
}
