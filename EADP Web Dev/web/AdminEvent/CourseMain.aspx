<%@ Page Title="" Language="C#" MasterPageFile="~/mainMenu.Master" AutoEventWireup="true" CodeBehind="CourseMain.aspx.cs" Inherits="EADP_Web_Dev.web.AdminEvent.CourseMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">
		.auto-style1 {
			width: 50px;
		}
		.auto-style2 {
			height: 20px;
			width: 50px;
		}
		.auto-style3 {
			height: 25px;
			width: 50px;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<h1 style="text-align:center; font-size:60px;font-family:'Tahoma'">Courses</h1>
	<div class="panel panel-primary">
        <div class="panel-heading" style="background-color: #D0C4D5; color: #FFFFFF;">
			<center>
            <table class="auto-style7">
                <tr>
                    <td class="auto-style6">
                        <asp:Label ID="Label7" Style="text-decoration: underline" runat="server" Font-Size="X-Large" Text="Upload course" ForeColor="White"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
			</center>
			</div>
		<asp:Panel ID="PanelAction" runat="server">
			<table class="auto-style11">
				<tr>
					<td class="auto-style1">
						<asp:Label ID="lblCourseName" runat="server" Text="Course name: "></asp:Label>
					</td>
					<td style="margin-left: 40px; width: 412px;">
						<asp:TextBox ID="tbName" runat="server" Height="28px" Width="203px"></asp:TextBox>
					</td>
					<tr>
						<td class="auto-style2">
							<asp:Label ID="lblLocation" runat="server" Text="Course description:"></asp:Label>
						</td>
						<td style="margin-left: 40px; height: 20px; width: 412px;">
							<asp:TextBox ID="tbDes" runat="server" Height="169px" Width="424px"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td class="auto-style3">
							<asp:Label ID="lblLocation0" runat="server" Text="Upload a picture:"></asp:Label>
						</td>
						<td style="margin-left: 40px; height: 25px; width: 412px;">
							<asp:FileUpload ID="FileUpload1" runat="server" Height="28px" />
						</td>
					</tr>
				</tr>
				<tr>
					<td class="auto-style3">&nbsp;</td>
					<td style="margin-left: 40px; height: 25px; width: 412px;">
						<asp:Button ID="btnUpload" runat="server" BackColor="White" BorderColor="#003366" Font-Bold="True" Height="32px" OnClick="Upload" Text="Upload" Width="133px" />
						<asp:Button ID="btnSubmit" runat="server" BackColor="White" BorderColor="#003366" Font-Bold="True" Height="32px" OnClick="btnSubmit_Click" Text="Submit" Width="133px" />
					</td>
				</tr>
			</table>
			<br />
			&nbsp;<hr />
			</asp:Panel>
		<div class="panel-heading" style="background-color: #D0C4D5; color: #FFFFFF;">
			<center>
            <table class="auto-style7">
                <tr>
                    <td class="auto-style6">
                        <asp:Label ID="Label1" Style="text-decoration: underline" runat="server" Font-Size="X-Large" Text="Courses" ForeColor="White"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
			</center>
				</div>
            
		<asp:Panel ID="PanelDsiplay" runat="server" >
    		<table style="width:100%;">
				<tr>
					<td style="width: 335px">
						<asp:GridView ID="GridViewData0" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Height="110px" Width="385px">
							<Columns>
								<asp:BoundField DataField="courseName" HeaderText="Course Name" SortExpression="courseName" />
								<asp:BoundField DataField="courseDes" HeaderText="Course Des" SortExpression="courseDes" />
							</Columns>
						</asp:GridView>
						<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStr %>" SelectCommand="SELECT [courseName], [courseDes] FROM [CourseMain]"></asp:SqlDataSource>
					</td>
					<td>
						<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Height="110px" ShowHeader="False" style="margin-top: 0px" Width="385px">
							<Columns>
								<asp:ImageField ControlStyle-Height="100" ControlStyle-Width="100" DataImageUrlField="Value">
									<ControlStyle Height="100px" Width="100px" />
								</asp:ImageField>
							</Columns>
						</asp:GridView>
					</td>
				</tr>
			</table>
				</asp:Panel>
</asp:Content>
