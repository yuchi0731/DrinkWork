using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Test
{
    public class model
    {
        public string p1 {get; set;}
        public string p2 { get; set; }
        public string p3 { get; set; }
    }

    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["A"] += this.TextBox1.Text;
            Session["B"] += this.TextBox2.Text;
            Session["C"] += this.TextBox3.Text;

            var a = this.TextBox1.Text;
            var b = this.TextBox2.Text;
            var c = this.TextBox3.Text;


            Session["A"] += this.TextBox1.Text;
            Session["B"] += this.TextBox2.Text;
            Session["C"] += this.TextBox3.Text;

            this.Literal1.Text += a + b + c;



        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("/WebForm2.aspx");
        }
    }
}