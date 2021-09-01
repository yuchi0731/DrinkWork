using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Test
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string a = Session["A"] as string;
            string b = Session["B"] as string;
            string c = Session["C"] as string;

            

            this.Literal1.Text = a;
            this.Literal2.Text = b;
            this.Literal3.Text = c;

            DataTable dt = (DataTable)Session["A"];
            DataRow dr = (DataRow)Session["A"];


            //Session("A").Columns.Add(New DataColumn("Name", GetType(String)));

            //this.GridView1.DataSource = dt;
            //this.GridView1.DataBind();

        }
    }
}