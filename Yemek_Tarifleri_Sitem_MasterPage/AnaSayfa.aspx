<%@ Page Title="" Language="C#" MasterPageFile="~/Kullanici.Master" AutoEventWireup="true" CodeBehind="AnaSayfa.aspx.cs" Inherits="Yemek_Tarifleri_Sitem_MasterPage.AnaSayfa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style4 {
        width: 100%;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:DataList ID="DataList3" runat="server">
            <ItemTemplate>
                <table class="auto-style4">
                    <tr>
                        <td style="background-color: #FFFF99">
                           <a href="YemekDetay.aspx?YemekID=3"><asp:Label ID="Label8" runat="server" style="font-weight: 700; font-size: x-large; color: #FF5050" Text='<%# Eval("YemekAd") %>'></asp:Label></a>
                        </td>
                    </tr>
                    <tr>
                        <td><strong>Malzemeler: </strong>
                            <asp:Label ID="Label9" runat="server" Text='<%# Eval("YemekMalzeme") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td><strong>Yemek Tarifi:</strong><asp:Label ID="Label10" runat="server" Text='<%# Eval("YemekTarif") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td><em><strong>Eklenme Tarihi:</strong></em><asp:Label ID="Label11" runat="server" style="color: #FFFFFF" Text='<%# Eval("YemekTarih") %>'></asp:Label>
                            &nbsp;- <strong><em>Puan:</em></strong><asp:Label ID="Label12" runat="server" Text='<%# Eval("YemekPuan") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-bottom: thick groove #333333; background-color: #FFFF99;">&nbsp;</td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </p>
</asp:Content>
