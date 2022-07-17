<%@ Page Title="" Language="C#" MasterPageFile="~/mainMenu.Master" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="EADP_Web_Dev.web.Medicine.Confirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="Label1" runat="server" Font-Italic="True" Font-Names="Bahnschrift Light" Text="Checkout Complete" Font-Size="Medium"></asp:Label>
    <div style="font-family: 'Bodoni MT'; font-size: medium; font-weight: bold; font-style: italic; font-variant: normal; background-color: #C0C0C0">
    <br />
    <asp:Label ID="Label2" runat="server" Text="Customer Name:"></asp:Label>
    <asp:Label ID="lblName" runat="server"></asp:Label>
        <br />
    <br />
    <asp:Label ID="Label4" runat="server" Text="Payment ID:"></asp:Label>
    <asp:Label ID="lblID" runat="server"></asp:Label>
        <br />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Items bought:"></asp:Label>
    <asp:Label ID="lblItems" runat="server"></asp:Label>
        <br />
    <br />
    <asp:Label ID="Label6" runat="server" Text="Total amount paid:$ "></asp:Label>
    <asp:Label ID="lbltotal" runat="server"></asp:Label>
        <br />
        <br />
    </div>
</asp:Content>
