<%@ Page Title="" Language="C#" MasterPageFile="~/mainMenu.Master" AutoEventWireup="true" CodeBehind="CourseAdmin.aspx.cs" Inherits="EADP_Web_Dev.web.AdminEvent.AdminDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<style>
        select {
            display: block;
        }
		.auto-style2 {
			height: 20px;
			width: 40px;
		}
		.auto-style3 {
			height: 25px;
			width: 40px;
		}
		.auto-style4 {
			width: 40px;
		}
		.auto-style5 {
			width: 370px;
		}
		.auto-style6 {
			height: 20px;
			width: 370px;
		}
		.auto-style7 {
			height: 25px;
			width: 370px;
		}
	</style>
    <div class="panel panel-primary">
        <div class="panel-heading" style="background-color: #D0C4D5; color: #FFFFFF;">
            <table class="auto-style7">
                <tr>
                    <td class="auto-style6">
                        <asp:Label ID="Label7" Style="text-decoration: underline" runat="server" Font-Size="X-Large" Text="Create Course" ForeColor="White"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <div class="panel-body">
            <table class="auto-style11">
                </tr>
                <tr>
                    <td class="auto-style4">


                        <asp:Label ID="lblCourseName" runat="server" Text="Course Name :"></asp:Label>

                    </td>
                    <td style="margin-left: 40px; " class="auto-style5">

                        <asp:TextBox ID="TB_CourseName" runat="server" Width="203px" Height="28px"></asp:TextBox>

                    </td>
                	<tr>
						<td class="auto-style2">
							<asp:Label ID="lblLocation" runat="server" Text="Location :"></asp:Label>
						</td>
						<td style="margin-left: 40px; " class="auto-style6">
							<asp:DropDownList ID="DDL_Location" runat="server" AutoPostBack="True" Height="30px" Width="158px">
								<asp:ListItem Selected="True" Value="-1">--Select a location--</asp:ListItem>
								<asp:ListItem Value="0">Music Room</asp:ListItem>
								<asp:ListItem Value="1">Computer Room</asp:ListItem>
								<asp:ListItem Value="2">MultiPurpose Room</asp:ListItem>
							</asp:DropDownList>
						</td>
					</tr>
					<tr>
						<td class="auto-style3">
							<asp:Label ID="lblDay" runat="server" Text="Day :"></asp:Label>
						</td>
						<td style="margin-left: 40px; " class="auto-style7">
							<asp:DropDownList ID="DDL_Days" runat="server" AutoPostBack="True" CssClass="CenterTextBox" Height="30px" Width="158px">
								<asp:ListItem Selected="True" Text="--Select the day---" Value="-1"></asp:ListItem>
								<asp:ListItem Value="0">Monday</asp:ListItem>
								<asp:ListItem Value="1">Tuesday</asp:ListItem>
								<asp:ListItem Value="2">Wednesday</asp:ListItem>
								<asp:ListItem Value="3">Thursday</asp:ListItem>
								<asp:ListItem Value="4">Friday</asp:ListItem>
								<asp:ListItem Value="5">Saturday</asp:ListItem>
							</asp:DropDownList>
						</td>
					</tr>
					<tr>
						<td class="auto-style4">
							<asp:Label ID="lblTiming" runat="server" Text="Timing :"></asp:Label>
						</td>
						<td style="margin-left: 40px; " class="auto-style5">
							<asp:DropDownList ID="DDL_Timing" runat="server" AutoPostBack="True" Height="30px" Width="158px">
								<asp:ListItem Value="-1">--Select a timing--</asp:ListItem>
								<asp:ListItem Value="0">9am - 11am</asp:ListItem>
								<asp:ListItem Value="1">11am - 1pm</asp:ListItem>
								<asp:ListItem Value="2">3pm - 5pm</asp:ListItem>
							</asp:DropDownList>
							<br />
						</td>
					</tr>
					<tr>
						<td class="auto-style4">
							<asp:Label ID="lblSignUp" runat="server" Text="Sign-Up limit :"></asp:Label>
						</td>
						<td style="margin-left: 40px; " class="auto-style5">
							<asp:TextBox ID="TB_SignUpLimit" runat="server" Height="22px" Width="49px"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td class="auto-style4">&nbsp;</td>
						<td class="auto-style5">&nbsp;</td>
					</tr>
                </tr>
                </table>


            <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create " BackColor="White" BorderColor="#080E85" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style9" Height="35px" Width="150px" Font-Bold="True" />
            <br />
			<asp:Label ID="LabelMsg" runat="server" Font-Bold="True"></asp:Label>
            <br />
            <br />
        </div>
    </div>

    <div class="panel panel-primary">
        <div class="auto-style8"  style="background-color:#D0C4D5;">

            <asp:Label ID="Label1" Style="text-decoration: underline" runat="server" Font-Size="X-Large" Text="Course Detail " ForeColor="White"></asp:Label>
        </div>
        <div class="panel-body">
            <asp:Panel ID="PanelFinancialInfo" runat="server" Height="100px">
                <asp:FileUpload ID="FileUpload1" runat="server" Height="35px" />
                <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload File" BackColor="White" BorderColor="#080E85" BorderStyle="Solid" BorderWidth="2px" CssClass="auto-style10" Height="30px" Width="150px" Font-Bold="True" />
                <br />
                <br />
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                <br />
                <br />
            </asp:Panel>
        </div>
    </div>

</asp:MultiView>
</asp:Content>
