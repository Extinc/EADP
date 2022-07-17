<%@ Page Title="" Language="C#" MasterPageFile="~/mainMenu.Master" AutoEventWireup="true" CodeBehind="SignUpCourse.aspx.cs" Inherits="EADP_Web_Dev.web.AdminEvent.SignUpCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<style>
        select {
            display: block;
        }
    </style>
		<h1 style="text-align:center; font-size:60px;font-family:'Tahoma'">
		Course</h1>
	<br />
	<asp:Panel ID="PanelMain" runat="server" BackColor="#D0C4D5" Height="1628px" Width="100%" position="absolute">
		<br />
			
			<br />
			<div style="text-align:center;">
			<asp:Label ID="Label2" runat="server" style="font-size:40px;" Text="Course Sign Up" Font-Bold="True"></asp:Label>
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
							<h3 style="text-align:center;">Course: </h3>
						</td>
						<td>
							<asp:DropDownList ID="DDL_Course" runat="server" Height="30px" Width="210px" DataSourceID="SqlDataSource3" DataTextField="courseName" DataValueField="courseName" OnSelectedIndexChanged="DDL_Course_SelectedIndexChanged">
								<asp:ListItem Selected="True">--Select a course--</asp:ListItem>
								<asp:ListItem></asp:ListItem>
								<asp:ListItem></asp:ListItem>
								<asp:ListItem></asp:ListItem>
							</asp:DropDownList>
							<asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStr %>" SelectCommand="SELECT [courseName] FROM [AdminCourse]"></asp:SqlDataSource>
						</td>
					</tr>
					<tr>
						<td style="width: 135px; height: 45px;">
							<h3 style="text-align:center;">Date/Time: </h3>
						</td>
						<td>
							<asp:DropDownList ID="DDL_Time" runat="server" Height="30px" Width="210px" DataSourceID="SqlDataSource4" DataTextField="timing" DataValueField="timing" OnSelectedIndexChanged="DDL_Time_SelectedIndexChanged">
								<asp:ListItem Value="0">--Select a time--</asp:ListItem>
							</asp:DropDownList>
							<asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStr %>" SelectCommand="SELECT [timing] FROM [AdminCourse]"></asp:SqlDataSource>
							<br />
							<asp:DropDownList ID="DDL_Date" runat="server" DataSourceID="SqlDataSource5" DataTextField="day" DataValueField="day" Height="30px" Width="210px" OnSelectedIndexChanged="DDL_Date_SelectedIndexChanged">
								<asp:ListItem Value="0">--Select a date--</asp:ListItem>
							</asp:DropDownList>
							<asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStr %>" SelectCommand="SELECT [day] FROM [AdminCourse]"></asp:SqlDataSource>
						</td>
					</tr>
					<tr>
						<td style="width: 135px; height: 45px;">
							<h3 style="text-align:center;">Location: </h3></td>
						<td>
							<asp:DropDownList ID="DDL_Location" runat="server" Height="30px" Width="210px" OnSelectedIndexChanged="DDL_Facility_SelectedIndexChanged" DataSourceID="SqlDataSource6" DataTextField="location" DataValueField="location">
								<asp:ListItem Value="0">--Select a location--</asp:ListItem>
							</asp:DropDownList>
							<asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStr %>" SelectCommand="SELECT [location] FROM [AdminCourse]"></asp:SqlDataSource>
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
							<asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label>
						</td>
					</tr>

				</table>
			<br />
			<br />
			<br />

				
		</asp:Panel>
		<br />
		<br />
		<br />
		<br />

	</asp:Panel>
	<br />
	<br />
</asp:Content>
