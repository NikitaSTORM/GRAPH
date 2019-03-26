using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GRAF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            double Xmin = double.Parse(textBoxXmin.Text);
            double Xmax = double.Parse(textBoxXmax.Text);
            double Ampl = double.Parse(textBoxAmpl0.Text);
            double ChastSobstColeb = double.Parse(textBoxChatSobstColeb.Text);
            double AmplV = double.Parse(textBoxAmplV.Text);
            double chastV = double.Parse(textBoxChatV.Text); 
            int count = (int)Math.Ceiling((Xmax - Xmin) *Math.Max(chastV,ChastSobstColeb)) + 1;
            double[] x = new double[count];
            double[] y1 = new double[count];
            double[] y2 = new double[count];
            for (int i = 0; i < count; i++)
            {
                x[i] = Xmin +  (Xmax-Xmin) * i/ (count - 1);
                y1[i] = Ampl*Math.Cos(ChastSobstColeb*x[i])+AmplV/(Math.Pow(ChastSobstColeb,2)-Math.Pow(chastV, 2))*Math.Cos(chastV*x[i]);
                //y2[i] = Math.Cos(x[i]);
            }
            chart1.ChartAreas[0].AxisX.Minimum = Xmin;
            chart1.ChartAreas[0].AxisX.Maximum = Xmax;

            //chart1.ChartAreas[0].AxisX.MajorGrid.Interval = ;

            chart1.Series[0].Points.DataBindXY(x, y1);
            //chart1.Series[0].Points.DataBindXY(x, y2);

        }
    }
}
