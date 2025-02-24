<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="YemekDuzenle.aspx.cs" Inherits="Yemek_Tarifleri_Sitem_MasterPage.YemekDuzenle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            height: 26px;
        }
        .auto-style3 {
            font-weight: bold;
        }
        .auto-style4 {
            text-align: center;
        }
        .auto-style5 {
            text-align: right;
        }
        .auto-style6 {
            height: 26px;
            text-align: right;
        }
        .auto-style7 {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">YEMEĞİN ADI:</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="218px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">YEMEĞİN MALZEMELERİ:</td>
            <td class="auto-style2">
                <asp:TextBox ID="TextBox2" runat="server" Height="50px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">YEMEĞİN TARİFİ:</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" Height="200px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">YEMEĞİN YENİ KATEGORİSİ:</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Height="19px" Width="224px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">YEMEĞİN RESMİ:</td>
            <td class="auto-style7">
                <asp:FileUpload ID="FileUpload1" runat="server" Width="250px" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style4"><strong>
                <asp:Button ID="Button1" runat="server" CssClass="auto-style3" OnClick="Button1_Click" Text="Güncelle" Width="225px" />
                </strong></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style4"><strong>
                <asp:Button ID="Button2" runat="server" CssClass="auto-style3" OnClick="Button2_Click" Text="Günün Yemeği Seç" />
                </strong></td>
        </tr>
    </table>
</asp:Content>
