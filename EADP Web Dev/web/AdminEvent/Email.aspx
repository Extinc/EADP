<%@ Page Title="" Language="C#" MasterPageFile="~/mainMenu.Master" AutoEventWireup="true" CodeBehind="Email.aspx.cs" Inherits="EADP_Web_Dev.web.AdminEvent.email" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<center><h1 style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">Booking Approval</h1></center>
	<asp:Panel ID="PanelEmail" runat="server" BackColor="#D0C4D5" Width="100%">
	<table style="">
            <tr>
                <td>To : </td>
                <td><asp:TextBox ID="to" runat="server" Width ="141%" BackColor="White" Height="34px" ></asp:TextBox></td>
                </tr>
            <tr>
                <td>From : </td>
                <td><asp:TextBox ID="from" runat="server" Width ="141%" Height="34px" ></asp:TextBox></td>
                </tr>
            <tr>
                <td>Subject : </td>
                <td><asp:TextBox ID="subject" runat="server" Width ="141%" Height="34px" ></asp:TextBox></td>
                </tr>
            <tr>
                <td> </td>
                <td><asp:Button ID="accept" runat="server" OnClick="accept_click" Text="Accept" Height="32px" Width="133px" BackColor="#00CC99" BorderColor="#669900" />
                    <asp:Button ID="decline" runat="server" Onclick="decline_click" Text="Decline" Height="32px" Width="133px" BackColor="#CC3300" BorderColor="Maroon" />
                </td>
                </tr>
            <tr>
                <td>Body : </td>
                <td><asp:TextBox ID="body" runat="server" Width ="168%" Height ="150px" TextMode ="MultiLine" ></asp:TextBox></td>
                </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="send" OnClick ="send_click" runat="server" text ="Send" BackColor="White" Height="32px" Width="133px" BorderColor="#003366" Font-Bold="True" ></asp:Button>
					<asp:Button ID="BtnBack" runat="server" BackColor="White" Height="32px" OnClick="BtnBack_Click" Text="Back" Width="133px" BorderColor="#003366" Font-Bold="True" />
				</td>
				 
                </tr>
            <tr>
				
                <td></td>
                <td><asp:Label ID="status" runat="server" Font-Bold="True"></asp:Label></td>
                </tr>

        </table>
        </asp:Panel>

</asp:Content>
