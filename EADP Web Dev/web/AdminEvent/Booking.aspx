<%@ Page Title="" Language="C#" MasterPageFile="~/mainMenu.Master" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="EADP_Web_Dev.web.AdminEvent.Booking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<style>
        select {
            display: block;
        }
    </style>
    <h1 style="text-align:center; font-size:60px;font-family:'Tahoma'">
		Booking</h1>
	<br />
	<asp:Panel ID="PanelMain" runat="server" BackColor="#D0C4D5" Height="1528px" Width="100%" position="absolute">
		<br />
			
			<br />
			<div style="text-align:center;">
			<asp:Label ID="Label2" runat="server" style="font-size:40px;" Text="Booking Form" Font-Bold="True"></asp:Label>
				</div>
				<table style="width:100%;">
					<tr>
						<td style="width: 135px; height: 45px;">
							<h3 style="text-align:center;">Name: </h3>
						</td>
						<td style="height: 45px">
							<asp:TextBox ID="TB_Name" runat="server" Height="26px" Width="210px"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td style="width: 135px; height: 45px;">
							<h3 style="text-align:center;">Contact: </h3>
						</td>
						<td>
							<asp:TextBox ID="TB_Contact" runat="server" Height="26px" Width="210px"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td style="width: 135px; height: 45px;">
							<h3 style="text-align:center;">Date: </h3>

						</td>
						<td>
		<asp:Calendar ID="calendar1" runat="server" OnSelectionChanged="calendar1_SelectionChanged" BackColor="White" BorderColor="White" BorderWidth="2px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="200px" NextPrevFormat="FullMonth" Width="400px" CssClass="calanderfk" ShowGridLines="True">
        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" HorizontalAlign="Center" Wrap="True"/>
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
        <TitleStyle BackColor="White" BorderColor="#080E85" BorderWidth="2px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" CssClass="headerOff" BorderStyle="Solid" />
        <TodayDayStyle BackColor="#CCCCCC" />
		</asp:Calendar>
						</td>
					</tr>
					<tr>
						<td style="width: 135px; height: 45px;">
							<h3 style="text-align:center;">Time Slot: </h3>
						</td>
						<td>
							<asp:DropDownList ID="DDL_Time" runat="server" Height="30px" Width="210px">
								<asp:ListItem Value="0">--Select a time slot--</asp:ListItem>
								<asp:ListItem Value="1">Morning, 9am - 1pm</asp:ListItem>
								<asp:ListItem Value="2">Afternoon, 1pm - 5pm</asp:ListItem>
								<asp:ListItem Value="3">Evening, 5pm - 9pm</asp:ListItem>
							</asp:DropDownList>
						</td>
					</tr>
					<tr>
						<td style="width: 135px; height: 45px;">
							<h3 style="text-align:center;">Facilities: </h3></td>
						<td>
							<asp:DropDownList ID="DDL_Facility" runat="server" Height="30px" Width="210px" AutoPostBack="True" OnSelectedIndexChanged="DDL_Facility_SelectedIndexChanged">
								<asp:ListItem Value="0">--Select a facility--</asp:ListItem>
								<asp:ListItem Value="1">BBQ Pit</asp:ListItem>
								<asp:ListItem Value="2">Badminton Court</asp:ListItem>
								<asp:ListItem Value="3">Karaoke Lounge</asp:ListItem>
								<asp:ListItem Value="4">Music Room</asp:ListItem>
							</asp:DropDownList>
						</td>
					</tr>
					<tr>
						<td style="width: 135px; height: 45px;">
							<h3 style="text-align:center;">Location: </h3></td>
						<td>
							<asp:DropDownList ID="DDL_Location" runat="server" Height="30px" OnSelectedIndexChanged="DDL_Location_SelectedIndexChanged" Width="210px">
								<asp:ListItem Value="0">--Select a location--</asp:ListItem>
								<asp:ListItem Value="1">AMK Hub</asp:ListItem>
								<asp:ListItem Value="2">AMK Ave 5</asp:ListItem>
								<asp:ListItem Value="3">AMK Ave 8</asp:ListItem>
								<asp:ListItem Value="4">AMK Ave 10</asp:ListItem>
							</asp:DropDownList>
						</td>
					</tr>
					<tr>
						<td style="width: 135px; height: 45px;">
							<h3 style="text-align:center;">Price: </h3></td>
						<td>
							$<asp:Label ID="DisplayPrice" runat="server"></asp:Label>
						</td>
					</tr>
					<tr>
						<td style="width: 135px; height: 45px;">
							<h3 style="text-align:center;">Email: </h3></td>
						<td>
							<asp:TextBox ID="TB_Email" runat="server" Height="26px" Width="290px"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td style="width: 135px; height: 45px;">
						<td>
							<asp:Button ID="BtnSubmit" runat="server" BackColor="White" BorderColor="#003366" Font-Bold="True" Height="32px" OnClick="BtnSubmit_Click" Text="Submit" Width="113px" />
							</td>
					</tr>
					<tr>
						<td style="width: 135px; height: 45px;">&nbsp;</td>
						<td>
							&nbsp;</td>
					</tr>

				</table>
			<br />
			<br />

				
		</asp:Panel>
		<br />
		<br />
		<br />
		<br />

	<br />
	<br />


</asp:Content>
