using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DrinkOrderSystem.ServerSide.UserControl
{
    public partial class ucPager : System.Web.UI.UserControl
    {
        public int Totaluser { get; set; }
        /// <summary>
        /// 總使用者
        /// </summary>
        public string Url { get; set; }
        /// <summary>頁面</summary>
        public int TotalSize { get; set; }
        /// <summary>總筆數</summary>
        public int PageSize { get; set; }
        /// <summary>頁面筆數</summary>
        public int CurrentPage { get; set; }
        /// <summary>目前頁數</summary>

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //取得當前頁數
        private int GetCurrentPage()
        {
            string pageText = this.Request.QueryString["page"];
            if (string.IsNullOrWhiteSpace(pageText))
                return 1;
            int pageIndex = 0;
            if (!int.TryParse(pageText, out pageIndex))
                return 1;
            return pageIndex;

        }


        public void Bind()
        {
            //檢查一頁筆數
            if (this.PageSize <= 0) //先檢查頁數是否小於0
                throw new DivideByZeroException();

            //算總頁數
            int totalPage = this.TotalSize / this.PageSize;
            if (this.TotalSize % this.PageSize > 0) //如果總筆數/頁數，相除後有餘數，總頁數+1
                totalPage += 1;

            //aaa.aspx?
            this.aLinkFirst.HRef = $"{this.Url}?page=1";
            this.aLinkLast.HRef = $"{ this.Url}?page={totalPage}";



            //依目前頁數計算
            this.CurrentPage = this.GetCurrentPage();
            this.ltlCurrentPage.Text = this.CurrentPage.ToString();


            //計算頁數
            int prevM1 = this.CurrentPage - 1; //頁數前一筆
            int prevM2 = this.CurrentPage - 2; //頁數前前一筆

            this.aLink2.HRef = $"{this.Url}?page={prevM1}";
            this.aLink2.InnerText = prevM1.ToString();
            this.aLink1.HRef = $"{this.Url}?page={prevM2}";
            this.aLink1.InnerText = prevM2.ToString();

            int nextP1 = this.CurrentPage + 1;
            int nextP2 = this.CurrentPage + 2;

            this.aLink4.HRef = $"{this.Url}?page={nextP1}";
            this.aLink4.InnerText = nextP1.ToString();
            this.aLink5.HRef = $"{this.Url}?page={nextP2}";
            this.aLink5.InnerText = nextP2.ToString();

            //this.ltlCurrentPage.Text = this.CurrentPage.ToString();


            //依頁數，決定是否隱藏超連結，並處理提示文字
            if (prevM2 <= 0)
                this.aLink1.Visible = false;       //如果上上一頁小於第一頁時做隱藏

            if (prevM1 <= 0)
                this.aLink2.Visible = false;       //如果上上一頁小於第一頁時做隱藏

            if (nextP1 > totalPage)
                this.aLink4.Visible = false;   //如果下一頁大於最後一頁時做隱藏

            if (nextP2 > totalPage)
                this.aLink5.Visible = false;  //如果下下一頁大於最後一頁時做隱藏

            this.ltPager.Text = $"共{this.TotalSize}筆，共{totalPage}頁，目前在第{this.GetCurrentPage()}頁<br/>";


        }

        public void BindUserList()
        {
            //檢查一頁筆數
            if (this.PageSize <= 0) //先檢查頁數是否小於0
                throw new DivideByZeroException();

            //算總頁數
            int totalPage = this.Totaluser / this.PageSize;
            if (this.Totaluser % this.PageSize > 0) //如果總筆數/頁數，相除後有餘數，總頁數+1
                totalPage += 1;

            //aaa.aspx?
            this.aLinkFirst.HRef = $"{this.Url}?page=1";
            this.aLinkLast.HRef = $"{ this.Url}?page={totalPage}";



            //依目前頁數計算
            this.CurrentPage = this.GetCurrentPage();
            this.ltlCurrentPage.Text = this.CurrentPage.ToString();


            //計算頁數
            int prevM1 = this.CurrentPage - 1; //頁數前一筆
            int prevM2 = this.CurrentPage - 2; //頁數前前一筆

            this.aLink2.HRef = $"{this.Url}?page={prevM1}";
            this.aLink2.InnerText = prevM1.ToString();
            this.aLink1.HRef = $"{this.Url}?page={prevM2}";
            this.aLink1.InnerText = prevM2.ToString();

            int nextP1 = this.CurrentPage + 1;
            int nextP2 = this.CurrentPage + 2;

            this.aLink4.HRef = $"{this.Url}?page={nextP1}";
            this.aLink4.InnerText = nextP1.ToString();
            this.aLink5.HRef = $"{this.Url}?page={nextP2}";
            this.aLink5.InnerText = nextP2.ToString();

            //this.ltlCurrentPage.Text = this.CurrentPage.ToString();


            //依頁數，決定是否隱藏超連結，並處理提示文字
            if (prevM2 <= 0)
                this.aLink1.Visible = false;       //如果上上一頁小於第一頁時做隱藏

            if (prevM1 <= 0)
                this.aLink2.Visible = false;       //如果上上一頁小於第一頁時做隱藏

            if (nextP1 > totalPage)
                this.aLink4.Visible = false;   //如果下一頁大於最後一頁時做隱藏

            if (nextP2 > totalPage)
                this.aLink5.Visible = false;  //如果下下一頁大於最後一頁時做隱藏

            this.ltPager.Text = $"共{this.Totaluser}筆，共{totalPage}頁，目前在第{this.GetCurrentPage()}頁<br/>";


        }


    }
}