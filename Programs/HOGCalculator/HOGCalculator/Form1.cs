using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOGCalculator
{
    public partial class Form1 : Form
    {
        Stopwatch stopwatch = new Stopwatch();

        Image<Bgr, byte> patch;

        static readonly Size WINDOW_SIZE = new Size(96, 96);
        static readonly Size BLOCK_SIZE = new Size(16, 16);
        static readonly Size BLOCK_STRIDE = new Size(8, 8);
        static readonly Size CELL_SIZE = new Size(8, 8);
        const int NUMBER_OF_BINS = 9;
        const int DERIVATIVE_APERTURE = 3;
        const HOGDescriptor.DerivativeMask DERIVATIVE_MASK = HOGDescriptor.DerivativeMask.Sobel3D;
        const int SPATIAL_SMOOTHING_SIZE = 8;
        const double L2_HYS_THRESHOLD = 0.2;
        const bool GAMMA_CORRECTION = false;
        const bool SIGNED_GRADIENT = false;
        const bool DOWNWEIGHT_EDGES = true;
        const bool ROTATION_INVARIANT = false;

        HOGDescriptor myHOGDescriptor = new HOGDescriptor(
            96,
            2,
            0.5,
            8,
            NUMBER_OF_BINS,
            SIGNED_GRADIENT,
            DOWNWEIGHT_EDGES,
            L2_HYS_THRESHOLD,
            ROTATION_INVARIANT,
            GAMMA_CORRECTION,
            DERIVATIVE_MASK);

        Emgu.CV.HOGDescriptor theirHOGDescriptor = new Emgu.CV.HOGDescriptor(
            WINDOW_SIZE,
            BLOCK_SIZE,
            BLOCK_STRIDE,
            CELL_SIZE,
            NUMBER_OF_BINS,
            DERIVATIVE_APERTURE,
            SPATIAL_SMOOTHING_SIZE,
            L2_HYS_THRESHOLD,
            GAMMA_CORRECTION);

        public Form1()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                patch = new Image<Bgr, byte>(ofd.FileName);
                pictureBox1.Image = patch.Bitmap;
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            stopwatch.Restart();
            float[] myDescriptor = myHOGDescriptor.compute(patch);
            textBox.AppendText("My HOG descriptor (" + myDescriptor.Length + ") extracted in " + stopwatch.ElapsedMilliseconds + " ms." + Environment.NewLine);
            string text = myDescriptor[0] + "";
            for (int i = 1; i < myDescriptor.Length; i++)
            {
                text += Environment.NewLine + myDescriptor[i];
            }
            File.WriteAllText(Environment.CurrentDirectory + "\\myDescriptor.csv", text);
            
            stopwatch.Restart();
            float[] theirDescriptor = theirHOGDescriptor.Compute(patch, new Size(patch.Height, patch.Width), new Size(0, 0), null);
            textBox.AppendText("Emgu CV HOG descriptor (" + theirDescriptor.Length + ") extracted in " + stopwatch.ElapsedMilliseconds + " ms." + Environment.NewLine);
            text = theirDescriptor[0] + "";
            for (int i = 1; i < theirDescriptor.Length; i++)
            {
                text += Environment.NewLine + theirDescriptor[i];
            }
            File.WriteAllText(Environment.CurrentDirectory + "\\theirDescriptor.csv", text);

            stopwatch.Restart();
            Image<Bgr, byte> myVisualisation = myHOGDescriptor.visualise(patch, myDescriptor, 16);
            textBox.AppendText("My HOG descriptor (" + myDescriptor.Length + ") visualised in " + stopwatch.ElapsedMilliseconds + " ms." + Environment.NewLine);
            myVisualisation.Save(Environment.CurrentDirectory + "\\myVisualisation.tif");
            pictureBox2.Image = myVisualisation.Bitmap;

            stopwatch.Restart();
            Image<Bgr, byte> theirVisualisation = myHOGDescriptor.visualise(patch, theirDescriptor, 16);
            textBox.AppendText("Emgu CV HOG descriptor (" + theirDescriptor.Length + ") visualised in " + stopwatch.ElapsedMilliseconds + " ms." + Environment.NewLine);
            theirVisualisation.Save(Environment.CurrentDirectory + "\\theirVisualisation.tif");
            pictureBox3.Image = theirVisualisation.Bitmap;
        }
    }
}
