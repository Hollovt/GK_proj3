using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK_proj3
{
    public partial class Form1 : Form
    {
        private Matrix<double> BradfordMatrix = Matrix<double>.Build.DenseOfArray(new double[,] { { 0.8951000,  0.2664000, - 0.1614000 }, { -0.7502000,  1.7135000,  0.0367000 }, { 0.0389000, - 0.0685000,  1.0296000 } });
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
            {
                textBox1.Text = "2.2";
                textBox2.Text = "0.3127";
                textBox3.Text = "0.329";
                textBox4.Text = "0.64";
                textBox5.Text = "0.33";
                textBox6.Text = "0.3";
                textBox7.Text = "0.6";
                textBox8.Text = "0.15";
                textBox9.Text = "0.06";

            }
            else if (listBox1.SelectedIndex == 1)
            {
                textBox1.Text = "1.2";
                textBox2.Text = "0.3457";
                textBox3.Text = "0.3585";
                textBox4.Text = "0.7347";
                textBox5.Text = "0.2653";
                textBox6.Text = "0.1152";
                textBox7.Text = "0.8264";
                textBox8.Text = "0.1566";
                textBox9.Text = "0.0177";
            }
            else if(listBox1.SelectedIndex==2)
            {
                textBox1.Text = "1.8";
                textBox2.Text = "0.3127";
                textBox3.Text = "0.3290";
                textBox4.Text = "0.6250";
                textBox5.Text = "0.3400";
                textBox6.Text = "0.2800";
                textBox7.Text = "0.5950";
                textBox8.Text = "0.1550";
                textBox9.Text = "0.0700";
            }
            else if(listBox1.SelectedIndex==3)
            {
                textBox1.Text = "2.2";
                textBox2.Text = "0.3333";
                textBox3.Text = "0.3333";
                textBox4.Text = "0.7350";
                textBox5.Text = "0.2650";
                textBox6.Text = "0.2740";
                textBox7.Text = "0.7170";
                textBox8.Text = "0.1670";
                textBox9.Text = "0.0090";
            }
            else if(listBox1.SelectedIndex == 4)
            {
                textBox1.Text = "2.2";
                textBox2.Text = "0.3127";
                textBox3.Text = "0.3290";
                textBox4.Text = "0.6400";
                textBox5.Text = "0.3300";
                textBox6.Text = "0.2100";
                textBox7.Text = "0.7100";
                textBox8.Text = "0.1500";
                textBox9.Text = "0.0600";
            }
            else if (listBox1.SelectedIndex == 5)
            {
                textBox1.Text = "1.95";
                textBox2.Text = "0.3127";
                textBox3.Text = "0.3290";
                textBox4.Text = "0.6400";
                textBox5.Text = "0.3300";
                textBox6.Text = "0.2900";
                textBox7.Text = "0.6000";
                textBox8.Text = "0.1500";
                textBox9.Text = "0.0600";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            List<string> profiles = new List<string>();
            List<string> targetProfiles = new List<string>();
            profiles.Add("sRGB");
            profiles.Add("Wide Gamut");
            profiles.Add("Apple RGB");
            profiles.Add("CIE RGB");
            profiles.Add("Adobe RGB");
            profiles.Add("PAL/SECAM");
            targetProfiles.Add("sRGB");
            targetProfiles.Add("Wide Gamut");
            targetProfiles.Add("Apple RGB");
            targetProfiles.Add("CIE RGB");
            targetProfiles.Add("Adobe RGB");
            targetProfiles.Add("PAL/SECAM");
            listBox1.DataSource = profiles;
            listBox2.DataSource = targetProfiles;
            pictureBox1.Image = Image.FromFile("final-curves-adjusted.jpg");

        }

        private void load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Application.StartupPath;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void AveragingMethod_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = pictureBox1.Image;
            if (pictureBox1.Image == null)
                return;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            for (int i = 0; i < pictureBox2.Image.Width; i++)
            {
                for (int j = 0; j < pictureBox2.Image.Height; j++)
                {
                    int R = bmp.GetPixel(i, j).R;
                    int G = bmp.GetPixel(i, j).G;
                    int B = bmp.GetPixel(i, j).B;

                    bmp.SetPixel(i, j, Color.FromArgb((int)(1.0 / 3 * (R + B + G)), (int)(1.0 / 3 * (R + B + G)), (int)(1.0 / 3 * (R + B + G))));
                }
            }
            pictureBox2.Image = bmp;
            pictureBox2.Refresh();
        }

        private void EyeSensitivityMethod_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = pictureBox1.Image;
            if (pictureBox1.Image == null)
                return;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            for (int i = 0; i < pictureBox2.Image.Width; i++)
            {
                for (int j = 0; j < pictureBox2.Image.Height; j++)
                {
                    int R = bmp.GetPixel(i, j).R;
                    int G = bmp.GetPixel(i, j).G;
                    int B = bmp.GetPixel(i, j).B;

                    bmp.SetPixel(i, j, Color.FromArgb((int)(1.0 / 9 * (3*R + 5*G + 1*B)), (int)(1.0 / 9 * (3 * R + 5 * G + 1 * B)), (int)(1.0 / 9 * (3 * R + 5 * G + 1 * B))));
                }
            }
            pictureBox2.Image = bmp;
            pictureBox2.Refresh();
        }

        private void StandardMethod_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = pictureBox1.Image;
            if (pictureBox1.Image == null)
                return;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            for (int i = 0; i < pictureBox2.Image.Width; i++)
            {
                for (int j = 0; j < pictureBox2.Image.Height; j++)
                {
                    int R = bmp.GetPixel(i, j).R;
                    int G = bmp.GetPixel(i, j).G;
                    int B = bmp.GetPixel(i, j).B;

                    bmp.SetPixel(i, j, Color.FromArgb((int)(0.299 * R + 0.587 * G + 0.114 * B), (int)(0.299 * R + 0.587 * G + 0.114 * B), (int)(0.299 * R + 0.587 * G + 0.114 * B)));
                }
            }
            pictureBox2.Image = bmp;
            pictureBox2.Refresh();
        }

        private void SpreadMethod_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = pictureBox1.Image;
            if (pictureBox1.Image == null)
                return;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            for (int i = 0; i < pictureBox2.Image.Width; i++)
            {
                for (int j = 0; j < pictureBox2.Image.Height; j++)
                {
                    int R = bmp.GetPixel(i, j).R;
                    int G = bmp.GetPixel(i, j).G;
                    int B = bmp.GetPixel(i, j).B;

                    bmp.SetPixel(i, j, Color.FromArgb((int)(0.5*(Math.Max(Math.Max(R,G),B) + Math.Min(Math.Min(R, G), B))), (int)(0.5 * (Math.Max(Math.Max(R, G), B) + Math.Min(Math.Min(R, G), B))), (int)(int)(0.5 * (Math.Max(Math.Max(R, G), B) + Math.Min(Math.Min(R, G), B)))));
                }
            }
            pictureBox2.Image = bmp;
            pictureBox2.Refresh();
        }

        private void generate_Click(object sender, EventArgs e)
        {

            var M = Matrix<double>.Build;
           
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberGroupSeparator = ".";
           
            var matrix1 = findRGBtoXYZMatrix();
            var matrix2 = findXYZtoRGMMatrix();


            double GammaSource = Convert.ToDouble(textBox1.Text, provider);
            double GammaDestiny = Convert.ToDouble(textBox18.Text, provider);

            if (pictureBox1.Image == null)
                return;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            for (int i=0; i<pictureBox1.Image.Width; i++)
            {
                for(int j=0; j<pictureBox1.Image.Height; j++)
                {

                    Color a = bmp.GetPixel(i, j);
                    (double, double, double) temp = ScaleRGB((a.R, a.G, a.B));
                    double[,] m3 ={ { temp.Item1}, { temp.Item2 }, { temp.Item3 } };
                    Matrix<double> matrix3 = M.DenseOfArray(m3);
                    Matrix<double> XYZ = matrix1*matrix3;
                    XYZ = changeIluminate(XYZ);
                    Matrix<double> RGB =matrix2 *XYZ;
                    var tmp = RGB.ToArray();

                    //bmp.SetPixel(i, j, (Color.FromArgb(Math.Max(Math.Min((int)(tmp[0, 0] * 255),255), 0), Math.Max(Math.Min((int)(tmp[1, 0] * 255),255),0), Math.Max(Math.Min((int)(tmp[2, 0] * 255),255),0))));
                    bmp.SetPixel(i, j, (Color.FromArgb(Math.Max(Math.Min((int)(Math.Pow(tmp[0, 0], GammaSource / GammaDestiny) * 255),255), 0), Math.Max(Math.Min((int)(Math.Pow(tmp[1, 0], GammaSource / GammaDestiny) * 255),255),0), Math.Max(Math.Min((int)(Math.Pow(tmp[2, 0], GammaSource / GammaDestiny) * 255),255),0))));
                }
            }
            pictureBox2.Image = bmp;
            pictureBox2.Refresh();
        }
        private (double, double, double) ScaleRGB((int, int, int) a )
        {
            return (a.Item1 / 255.0, a.Item2 / 255.0, a.Item3 / 255.0);
        }
        private Matrix<double> findRGBtoXYZMatrix()
        {
            var M = Matrix<double>.Build;
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberGroupSeparator = ".";
            double xr = Convert.ToDouble(textBox4.Text, provider);
            double yr = Convert.ToDouble(textBox5.Text, provider);
            double zr = 1 - xr - yr;

            double xg = Convert.ToDouble(textBox6.Text, provider);
            double yg = Convert.ToDouble(textBox7.Text, provider);
            double zg = 1 - xg - yg;

            double xb = Convert.ToDouble(textBox8.Text, provider);
            double yb = Convert.ToDouble(textBox9.Text, provider);
            double zb = 1 - xb - yb;

            double xn = Convert.ToDouble(textBox2.Text, provider);
            double yn = Convert.ToDouble(textBox3.Text, provider);
            double zn = 1 - xn - yn;

            
            double Xw = xn / yn;
            double Yw = 1;
            double Zw = zn / yn;
            var sMatrix = M.DenseOfArray(new double[,] { { xr / yr, xg / yg, xb / yb }, { 1, 1, 1 }, { zr / yr, zg / yg, zb / yb } }).Inverse()* M.DenseOfArray(new double[,] { { Xw }, { Yw }, { Zw } });
            var arraySMatrix = sMatrix.ToArray();

            double sr = arraySMatrix[0, 0];
            double sg = arraySMatrix[1, 0];
            double sb = arraySMatrix[2, 0];

            return M.DenseOfArray(new double[,] { { sr * xr / yr, sg * xg / yg, sb * xb / yb }, { sr, sg, sb }, { sr * zr / yr, sg * zg / yg, sb * zb / yb } });
            
        }
        private Matrix<double> findXYZtoRGMMatrix()
        {
            var M = Matrix<double>.Build;
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberGroupSeparator = ".";
            double xr = Convert.ToDouble(textBox15.Text, provider);
            double yr = Convert.ToDouble(textBox14.Text, provider);
            double zr = 1 - xr - yr;

            double xg = Convert.ToDouble(textBox13.Text, provider);
            double yg = Convert.ToDouble(textBox12.Text, provider);
            double zg = 1 - xg - yg;

            double xb = Convert.ToDouble(textBox11.Text, provider);
            double yb = Convert.ToDouble(textBox10.Text, provider);
            double zb = 1 - xb - yb;

            double xn = Convert.ToDouble(textBox17.Text, provider);
            double yn = Convert.ToDouble(textBox16.Text, provider);
            double zn = 1 - xn - yn;

           
            double Xw = xn / yn;
            double Yw = 1;
            double Zw = zn / yn;
            var sMatrix = M.DenseOfArray(new double[,] { { xr / yr, xg / yg, xb / yb }, { 1, 1, 1 }, { zr / yr, zg / yg, zb / yb } }).Inverse() * M.DenseOfArray(new double[,] { { Xw }, { Yw }, { Zw } });
            var arraySMatrix = sMatrix.ToArray();

            double sr = arraySMatrix[0, 0];
            double sg = arraySMatrix[1, 0];
            double sb = arraySMatrix[2, 0];

            return M.DenseOfArray(new double[,] { { sr * xr / yr, sg * xg / yg, sb * xb / yb }, { sr, sg, sb }, { sr * zr / yr, sg * zg / yg, sb * zb / yb } }).Inverse();

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex == 0)
            {
                textBox18.Text = "2.2";
                textBox17.Text = "0.3127";
                textBox16.Text = "0.329";
                textBox15.Text = "0.64";
                textBox14.Text = "0.33";
                textBox13.Text = "0.3";
                textBox12.Text = "0.6";
                textBox11.Text = "0.15";
                textBox10.Text = "0.06";

            }
            else if (listBox2.SelectedIndex == 1)
            {
                textBox18.Text = "1.2";
                textBox17.Text = "0.3457";
                textBox16.Text = "0.3585";
                textBox15.Text = "0.7347";
                textBox14.Text = "0.2653";
                textBox13.Text = "0.1152";
                textBox12.Text = "0.8264";
                textBox11.Text = "0.1566";
                textBox10.Text = "0.0177";
            }
            else if (listBox2.SelectedIndex == 2)
            {
                textBox18.Text = "1.8";
                textBox17.Text = "0.3127";
                textBox16.Text = "0.3290";
                textBox15.Text = "0.6250";
                textBox14.Text = "0.3400";
                textBox13.Text = "0.2800";
                textBox12.Text = "0.5950";
                textBox11.Text = "0.1550";
                textBox10.Text = "0.0700";
            }
            else if (listBox2.SelectedIndex == 3)
            {
                textBox18.Text = "2.2";
                textBox17.Text = "0.3333";
                textBox16.Text = "0.3333";
                textBox15.Text = "0.7350";
                textBox14.Text = "0.2650";
                textBox13.Text = "0.2740";
                textBox12.Text = "0.7170";
                textBox11.Text = "0.1670";
                textBox10.Text = "0.0090";
            }
            else if (listBox2.SelectedIndex == 4)
            {
                textBox18.Text = "2.2";
                textBox17.Text = "0.3127";
                textBox16.Text = "0.3290";
                textBox15.Text = "0.6400";
                textBox14.Text = "0.3300";
                textBox13.Text = "0.2100";
                textBox12.Text = "0.7100";
                textBox11.Text = "0.1500";
                textBox10.Text = "0.0600";
            }
            else if (listBox2.SelectedIndex == 5)
            {
                textBox18.Text = "1.95";
                textBox17.Text = "0.3127";
                textBox16.Text = "0.3290";
                textBox15.Text = "0.6400";
                textBox14.Text = "0.3300";
                textBox13.Text = "0.2900";
                textBox12.Text = "0.6000";
                textBox11.Text = "0.1500";
                textBox10.Text = "0.0600";
            }
        }
        private Matrix<double> changeIluminate(Matrix<double> XYZs)
        {
            var M = Matrix<double>.Build;
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberGroupSeparator = ".";

            double xs = Convert.ToDouble(textBox2.Text, provider);
            double ys = Convert.ToDouble(textBox3.Text, provider);
            double zs = 1 - xs - ys;

            double Xs = xs / ys;
            double Ys = 1;
            double Zs = zs / ys;

            double xd = Convert.ToDouble(textBox17.Text, provider);
            double yd = Convert.ToDouble(textBox16.Text, provider);
            double zd = 1 - xd - yd;

            double Xd = xd / yd;
            double Yd = 1;
            double Zd = zd / yd;

            var temp = BradfordMatrix*M.DenseOfArray(new double[,] { { Xs }, { Ys }, { Zs } });
            var temp2 = BradfordMatrix * M.DenseOfArray(new double[,] { { Xd }, { Yd }, { Zd } });
            double ps = temp.ToArray()[0, 0];
            double gs = temp.ToArray()[1, 0];
            double bs = temp.ToArray()[2, 0];

            double pd = temp2.ToArray()[0, 0];
            double gd = temp2.ToArray()[1, 0];
            double bd = temp2.ToArray()[2, 0];


            return BradfordMatrix.Inverse() * M.DenseOfArray(new double[,] { { pd / ps, 0, 0 }, { 0, gd / gs, 0 }, { 0, 0, bd / bs } })* BradfordMatrix * XYZs;

           
        }

        private void save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog(); 
            saveFileDialog.Filter = "png files (*.png)|*.png|jpgfiles (*.jpg)|*.jpg| All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image.Save(saveFileDialog.FileName, ImageFormat.Png);
            }
        }
    }
}
