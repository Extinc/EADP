<%@ Page Title="" Language="C#" MasterPageFile="~/mainMenu.Master" AutoEventWireup="true" CodeBehind="Schemes.aspx.cs" Inherits="EADP_Web_Dev.web.Finance.ADMIN.Schemes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
        .selectnohide {
            display:block;
        }
         .auto-style1 {
             height: 22px;
             width: 222px;
         }
         .auto-style2 {
             width: 222px;
         }
         </style>
    <h2 style="text-align:center;font-family:'Lucida Handwriting'">Schemes.</h2>
    <asp:Panel ID="backPanel" BackColor="#94b8b8" style="margin:auto;" Width="90%" Height="700px" runat="server">
        <table id="contentTable" style="width: 90%;margin:auto; height: 590px;">
            <tr>
                <td style="height: 23px; width: 426px;">&nbsp;</td>
                <td style="height: 23px; ">&nbsp;</td>
                <td style="height: 23px; width: 53%;">&nbsp;</td>
            </tr>
            <tr>
                <td style="height: 23px; width: 426px;">
                </td>
                <td style="height: 23px; "></td>
                <td style="height: 23px; width: 53%;">
                </td>
            </tr>
            <tr>
                <td style="height: 22px; width: 426px;">
                    <asp:Panel ID="insertPanel" runat="server" Height="500px" style="background-color:white;" Width="523px">
                         &nbsp;
                        <table id="inputTable" style="width:100%; width:95%;margin:auto; background-color:white;">
                            <tr>
                                <td style="width: 201px; height: 22px;">
                                    <asp:Label ID="Label1" runat="server" Text="Scheme Type : "></asp:Label>
                                </td>
                                <td style="height: 22px; width: 281px;">
                                    <asp:DropDownList ID="schemeTypeDropDownList" runat="server" CssClass="selectnohide">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem>Financial Assistance</asp:ListItem>
                                        <asp:ListItem>Employment &amp; Training Assistance</asp:ListItem>
                                        <asp:ListItem>Housing Loan/Grant</asp:ListItem>
                                        <asp:ListItem>Family Care</asp:ListItem>
                                        <asp:ListItem>Student Care Assistance</asp:ListItem>
                                        <asp:ListItem Value="Medical Bills Assistance"></asp:ListItem>
                                        <asp:ListItem>Disability Care</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 201px; height: 53px;">
                                    <asp:Label ID="Label2" runat="server" Text="Scheme Name :"></asp:Label>
                                </td>
                                <td style="width: 281px; height: 53px;">
                                    <asp:TextBox ID="schemeNameTextBox" runat="server" Width="178px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 201px">
                                    <asp:Label ID="Label7" runat="server" Text="Maximum Household Limit : "></asp:Label>
                                </td>
                                <td style="width: 281px">
                                    <asp:TextBox ID="maxLimitTextbox" runat="server" Width="175px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 201px; height: 128px;">
                                    <asp:Label ID="Label8" runat="server" Text="Scheme Details  : "></asp:Label>
                                </td>
                                <td style="width: 281px; height: 128px;">
                                    <asp:TextBox ID="detailsTextBox" runat="server" Height="100" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 201px">&nbsp;</td>
                                <td style="width: 281px">&nbsp;</td>
                                <td>
                                    <asp:Button ID="BtnCreate" runat="server" CssClass="btn btn-default" OnClick="BtnCreate_Click" Text="Create" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td style="height: 22px; "></td>
                <td style="height: 22px; width: 53%;">
                    <asp:Panel ID="outputPanel" runat="server" Height="500px" style="background-color:white;">
                         &nbsp;
                        <table style="width:100%; width:95%;margin:auto; background-color:white; height: 239px;">
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="Label4" runat="server" Text="Scheme Type : "></asp:Label>
                                </td>
                                <td style="height: 22px">
                                    <asp:Label ID="Lbl_TypeScheme" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label ID="Label3" runat="server" Text="Scheme Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Lbl_SchemeName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="Label5" runat="server" Text="Maximum HouseHold Limit : "></asp:Label>
                                </td>
                                <td style="height: 22px">
                                    <asp:Label ID="Lbl_MaxLimit" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label ID="Label6" runat="server" Text="Scheme Details  : "></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Lbl_Details" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1"></td>
                                <td style="height: 22px"></td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="height: 22px; width: 426px;"></td>
                <td style="height: 22px; "></td>
                <td style="height: 22px; width: 53%;"></td>
            </tr>
        </table>
        
           
    </asp:Panel>
</asp:Content>
