using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

// Prepares image for Classification
// Threshold Image for Green colour
// Morphological open and close to clean Thresholded image

namespace TextureClassificationTestProgram
{
    class ImageProcessor
    {
        // Constants

        private const int IMAGE_HEIGHT = 1024;
        private const int IMAGE_WIDTH = 1280;
        private const int MORPHOLOGY_SIZE = 40;
        private const int BINARY_THRESHOLD = 20;

        public ImageProcessor()
        {
            
        }

        // Thresholds image to single out green colour

        public Image<Gray,Byte> thresholdImage(Image<Bgr, Byte> image)
        {
            Image<Gray, Byte> outputImage = new Image<Gray, Byte>(IMAGE_WIDTH, IMAGE_HEIGHT);
            Image<Gray, Byte>[] channel = image.Split();
            outputImage = channel[1] - channel[2];
            outputImage._ThresholdBinary(new Gray(BINARY_THRESHOLD), new Gray(255));
            return outputImage;
        }

        // Clean up images using Morphological open and close

        public Image<Gray,Byte> morphology(Image<Gray, Byte> image)
        {
            
            StructuringElementEx kernel = new StructuringElementEx(MORPHOLOGY_SIZE, MORPHOLOGY_SIZE, MORPHOLOGY_SIZE / 2, MORPHOLOGY_SIZE / 2, CV_ELEMENT_SHAPE.CV_SHAPE_RECT);
            image._MorphologyEx(kernel, CV_MORPH_OP.CV_MOP_OPEN, 1);
            //image._MorphologyEx(kernel, CV_MORPH_OP.CV_MOP_CLOSE, 1);
            return image;
        }

        // Label Connected Components

        public Image<Gray, Byte> LabelConnectedComponents(Image<Gray, Byte> binary, int startLabel)
        {
            Contour<Point> contours = binary.FindContours(
                CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE,
                RETR_TYPE.CV_RETR_EXTERNAL);

            int count = startLabel;
            for (Contour<Point> cont = contours; cont != null; cont = cont.HNext)
            {
                CvInvoke.cvDrawContours(binary, cont, new MCvScalar(count), new MCvScalar(0), 2, -1, LINE_TYPE.FOUR_CONNECTED, new Point(0, 0));
                ++count;
            }
            return binary;
        }

    }
}
