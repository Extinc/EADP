<%@ Page Title="" Language="C#" MasterPageFile="~/mainMenu.Master" AutoEventWireup="true" CodeBehind="BookingAdmin.aspx.cs" EnableEventValidation = "false" Inherits="EADP_Web_Dev.web.AdminEvent.BookingAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<center><h1 style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">Booking Details</h1></center>
	<asp:Panel ID="PanelDetails" runat="server" BackColor="#D0C4D5" Width="100%">
		<br />
		<br />
	<center>
	<asp:GridView ID="bookingDetails" runat="server" AutoGenerateColumns="False" DataKeyNames="bookID" DataSourceID="SqlDataSource1" Width="978px" AllowPaging="True" BackColor="White" BorderColor="#FF6666" OnSelectedIndexChanged="bookingDetails_SelectedIndexChanged">
		<Columns>
			<asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
			<asp:BoundField DataField="bookID" HeaderText="Booking ID" InsertVisible="False" ReadOnly="True" SortExpression="bookID" />
			<asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
			<asp:BoundField DataField="contact" HeaderText="Contact" SortExpression="contact" />
			<asp:BoundField DataField="date" HeaderText="Date" SortExpression="date" />
			<asp:BoundField DataField="facility" HeaderText="Facility" SortExpression="facility" />
			<asp:BoundField DataField="time" HeaderText="Time" SortExpression="time" />
			<asp:BoundField DataField="location" HeaderText="Location" SortExpression="location" />
			<asp:BoundField DataField="price" HeaderText="Price ($)" SortExpression="price" />
			<asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
			<asp:BoundField HeaderText="Status" DataField="status" SortExpression="status" />
		</Columns>
	</asp:GridView>
		<br />
		<br />
		<asp:Button ID="ButtonPDF" runat="server" BackColor="White" BorderColor="#003366" Font-Bold="True" Font-Italic="True" Height="32px" Text="Print PDF" Width="113px" OnClick ="ButtonPDF_Click" />
		<br />
	<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStr %>" DeleteCommand="DELETE FROM [Booking] WHERE [bookID] = @bookID" InsertCommand="INSERT INTO [Booking] ([name], [contact], [date], [facility], [time], [location], [price], [email], [status]) VALUES (@name, @contact, @date, @facility, @time, @location, @price, @email, @status)" SelectCommand="SELECT [bookID], [name], [contact], [date], [facility], [time], [location], [price], [email], [status] FROM [Booking]" UpdateCommand="UPDATE [Booking] SET [name] = @name, [contact] = @contact, [date] = @date, [facility] = @facility, [time] = @time, [location] = @location, [price] = @price, [email] = @email, [status] = @status WHERE [bookID] = @bookID">
		<DeleteParameters>
			<asp:Parameter Name="bookID" Type="Int32" />
		</DeleteParameters>
		<InsertParameters>
			<asp:Parameter Name="name" Type="String" />
			<asp:Parameter Name="contact" Type="String" />
			<asp:Parameter Name="date" Type="String" />
			<asp:Parameter Name="facility" Type="String" />
			<asp:Parameter Name="time" Type="String" />
			<asp:Parameter Name="location" Type="String" />
			<asp:Parameter Name="price" Type="String" />
			<asp:Parameter Name="email" Type="String" />
			<asp:Parameter Name="status" Type="String" />
		</InsertParameters>
		<UpdateParameters>
			<asp:Parameter Name="name" Type="String" />
			<asp:Parameter Name="contact" Type="String" />
			<asp:Parameter Name="date" Type="String" />
			<asp:Parameter Name="facility" Type="String" />
			<asp:Parameter Name="time" Type="String" />
			<asp:Parameter Name="location" Type="String" />
			<asp:Parameter Name="price" Type="String" />
			<asp:Parameter Name="email" Type="String" />
			<asp:Parameter Name="status" Type="String" />
			<asp:Parameter Name="bookID" Type="Int32" />
		</UpdateParameters>
	</asp:SqlDataSource>
		</asp:Panel>
</asp:Content>
