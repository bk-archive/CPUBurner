using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPUBurner
{
    public partial class _default : System.Web.UI.Page
    {
        Label lbl;
        Label lblalt;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl = new Label();
            lblalt = new Label();

            
            calculatePI(10);
            calculatePIAlt(10);

            form1.Controls.Clear();
            form1.Controls.Add(lbl);
            form1.Controls.Add(lblalt);
        }

        public void calculatePI(int n)
        {
            // Nilakantha formula
            // π = 3 + 4/(2*3*4) - 4/(4*5*6) + 4/(6*7*8) - 4/(8*9*10) + 4/(10*11*12) - (4/(12*13*14) etc
            // Based on http://stackoverflow.com/questions/39395/how-do-i-calculate-pi-in-c/25638402#25638402

            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            decimal pie = 0;
            decimal a = 2;
            decimal b = 3;
            decimal c = 4;
            decimal e = 1;

            string result = "";

            for (decimal f = (e += 1); f < n; f++)
            {

                pie += 4 / (a * b * c);

                a += 2;
                b += 2;
                c += 2;

                pie -= 4 / (a * b * c);

                a += 2;
                b += 2;
                c += 2;

                e += 1;
            }

            decimal finalDisplayString = (pie + 3);

            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;

            result = "pie = " + finalDisplayString + "<br>";
            result += "Accuracy resulting from " + e + "<br>";
            result += "Time to calculate result: " + ts;

            lbl.Text = result;
        }

        public void calculatePIAlt(int n)
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            string piNumber = "3,";
            int dividedBy = 11080585;
            int divisor = 78256779;
            int result;

            string resultstring = "";

            for (int i = 0; i<n; i++)
            {
                if (dividedBy<divisor)
                    dividedBy *= 10;

                result = dividedBy / divisor;

                string resultString = result.ToString();
                piNumber += resultString;

                dividedBy = dividedBy - divisor* result;
            }

            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;

            
            resultstring = "<br>pie = " + piNumber + "<br>";
            resultstring += "Accuracy resulting from " + n + "<br>";
            resultstring += "Time to calculate result: " + ts;

            lblalt.Text = resultstring;
        }
    }
}
