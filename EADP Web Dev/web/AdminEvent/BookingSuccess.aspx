<%@ Page Title="" Language="C#" MasterPageFile="~/mainMenu.Master" AutoEventWireup="true" CodeBehind="BookingSuccess.aspx.cs" Inherits="EADP_Web_Dev.web.AdminEvent.BookingSuccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<h1 style="text-align:center; font-size:60px;font-family:'Tahoma'">
		Booking</h1>
	<br />
	<asp:Panel ID="PanelMain" runat="server" BackColor="#D0C4D5" Height="1500px" Width="100%">
		<br />
	
			<br />
			<div style="text-align:center;">
			<asp:Label ID="Label2" runat="server" style="font-size:40px;" Text="Submission Details" Font-Bold="True"></asp:Label>
				</div>
				<table style="width:100%;">
					<tr>
						<td style="width: 135px; height: 45px;">
							<h3 style="text-align:center;">Name: </h3>
						</td>
						<td style="height: 45px">
							<asp:Label ID="LabelName" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
						</td>
					</tr>
					<tr>
						<td style="width: 135px; height: 45px;">
							<h3 style="text-align:center;">Contact: </h3>
						</td>
						<td>
							<asp:Label ID="LabelContact" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
						</td>
					</tr>
					<tr>
						<td style="width: 135px; height: 45px;">
							<h3 style="text-align:center;">Date: </h3>

						</td>
						<td>
							<asp:Label ID="LabelDate" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
						</td>
					</tr>
					<tr>
						<td style="width: 135px; height: 45px;">
							<h3 style="text-align:center;">Time Slot: </h3>
						</td>
						<td>
							<asp:Label ID="LabelTime" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
						</td>
					</tr>
					<tr>
						<td style="width: 135px; height: 45px;">
							<h3 style="text-align:center;">Facilities: </h3></td>
						<td>
							<asp:Label ID="LabelFacility" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
						</td>
					</tr>
					<tr>
						<td style="width: 135px; height: 45px;">
							<h3 style="text-align:center;">Location: </h3></td>
						<td>
							<asp:Label ID="LabelLocation" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
						</td>
					</tr>
					<tr>
						<td style="width: 135px; height: 45px;">
							<h3 style="text-align:center;">Price: </h3></td>
						<td>
							<asp:Label ID="LabelPrice" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
						</td>
					</tr>
					<tr>
						<td style="width: 135px; height: 45px;">
							<h3 style="text-align:center;">Email: </h3></td>
						<td>
							<asp:Label ID="LabelEmail" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
						</td>
					</tr>

				</table>
				
		</asp:Panel>
		<br />
		<br />
		<br />
		<br />
	<br />
	<br />
	<br />
</asp:Content>

