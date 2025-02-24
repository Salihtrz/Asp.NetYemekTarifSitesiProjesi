<%@ Page Title="" Language="C#" MasterPageFile="~/Kullanici.Master" AutoEventWireup="true" CodeBehind="Hakkimizda.aspx.cs" Inherits="Yemek_Tarifleri_Sitem_MasterPage.Hakkimizda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <asp:DataList ID="DataList2" runat="server" style="font-size: medium; text-align: center;" Width="450px">
            <ItemTemplate>
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("metin") %>' style="text-align: center"></asp:Label>
            </ItemTemplate>
        </asp:DataList>
        <br />
        <asp:Image ID="Image1" runat="server" Height="150px" ImageUrl="~/Resimler/blog.jpeg" Width="450px" />
    </p>
</asp:Content>
