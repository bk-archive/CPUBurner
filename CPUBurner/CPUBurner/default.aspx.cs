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

        protected void Page_Load(object sender, EventArgs e)
        {
            lbl = new Label();

            calculatePI(1);

            form1.Controls.Clear();
            form1.Controls.Add(lbl);
        }

        public void calculatePI(int n)
        {
            lbl.Text = "Hello Again";
        }
    }
}