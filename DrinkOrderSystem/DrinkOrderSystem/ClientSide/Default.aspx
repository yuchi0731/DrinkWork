<%@ Page Title="" Language="C#" MasterPageFile="~/ClientSide/ClientSide.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DrinkOrderSystem.ClientSide.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
       div{
       
           float: left;

       }
     
     
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <h2>系統介紹</h2>

    <h3>您好，歡迎使用員工飲料團購系統!  </h3>

    <p>
        以下簡單介紹本系統的使用方式: </p>
    <p>
本系統為提供手搖飲料團購之用，提供使用者可以進行開啟團購(包含選定商家、設定團購結束時間等功能)、跟團(包含加入既有的開團選項、訂購飲料等功能)的各式功能。
    </p>

    <p>
        並且提供歷史紀錄，羅列過往所有訂單外，若您在團購時間結束前想要修改自己的訂單，從歷史紀錄中亦能讓您異動您目前的訂單，
於團購時間結束後，系統將通知開啟本團購的使用者，進行確認該筆訂單後，將訂購內容完整輸出，方便與店家進行訂購。 
    </p>
    <p>
        成功登入後將會自動呈現您的使用者資訊，若有誤，請向您的上層管理者反映，本系統只有擁有管理者權限的帳號，才能進行個別使用者的權限、資訊進行修改。
當然亦提供可以更新店家資訊和商品品項的功能 
    </p>
    <p>
        若有使用上的問題，亦歡迎聯繫開發者的信箱 123456789@gmail.com ，我們竭誠為您服務，謝謝您的使用!
    </p>

        </div>
</asp:Content>