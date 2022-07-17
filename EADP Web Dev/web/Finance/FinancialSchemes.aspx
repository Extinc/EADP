<%@ Page Title="" Language="C#" MasterPageFile="~/mainMenu.Master" AutoEventWireup="true" CodeBehind="FinancialSchemes.aspx.cs" Inherits="EADP_Web_Dev.web.Finance.FinancialSchemes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
        .selectnohide {
            display:block;
        }
         .auto-style1 {
             height: 22px;
             width: 88px;
         }
         .auto-style2 {
             width: 88px;
         }
    .auto-style3 {
        height: 23px;
    }
    </style>
     <h2 style="text-align:center;font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif">Financial Schemes.</h2>
     &nbsp;
    <div style="width:90%;margin:auto;">
     <table id="schemeTable" style="width:100%;margin:auto;">
        <tr>
            <td colspan="2">
                <asp:Label ID="instructionslbl" runat="server" ForeColor="Black" Text="* Please fill in all the necessary details. This will take about 10 mins." Font-Size="22px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 25px; width: 178px">
                <asp:Label ID="typeLbl" runat="server" Text="Financial Type : "></asp:Label>
                <asp:RequiredFieldValidator ID="schemeTypeRequired" runat="server" ControlToValidate="typeDdList" ErrorMessage="Please select your scheme type" ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
            </td>
            <td style="width: 571px; height: 25px">
                <asp:DropDownList ID="typeDdList" runat="server" CssClass="selectnohide">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 178px">
                <asp:Label ID="fNameLbl" runat="server" Text="Financial Scheme Name :"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="schemeDdList" ErrorMessage="Scheme name is required" ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
            </td>
            <td style="width: 571px">
                <asp:DropDownList ID="schemeDdList" runat="server" CssClass="selectnohide">
                </asp:DropDownList>
            </td>
        </tr>
    </table>

     <table id="schemeDetailsTable" style="width:100%;margin:auto;">
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style3">
                <asp:Label ID="sectionLbl" runat="server" Text="Section I : Particulars Of Applicant."></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="personDetailsLbl" runat="server" Text="Personal Details : "></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 270px">
                <asp:Label ID="applicantNameLbl" runat="server" Text="Applicant's Name : "></asp:Label>
                <asp:RequiredFieldValidator ID="namer" runat="server" ControlToValidate="applicantNameTextbox" ErrorMessage="Please enter your name" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="applicantNameTextbox" runat="server" Height="16px" Width="414px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 270px; height: 26px;">
                <asp:Label ID="addLbl" runat="server" Text="Address : "></asp:Label>
                <asp:RequiredFieldValidator ID="addresR" runat="server" ControlToValidate="addressTextbox" ErrorMessage="Address is required" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
            <td style="height: 26px">
                <asp:TextBox ID="addressTextbox" runat="server" Width="414px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 270px">
                <asp:Label ID="contactNoLbl" runat="server" Text="Contact Number : "></asp:Label>
                <asp:RegularExpressionValidator ID="mobileR" runat="server" ControlToValidate="contactNoTextBox" ErrorMessage="Enter a valid mobile number" ForeColor="Red" ValidationExpression="^[89]\d{7}$">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="mobile" runat="server" ControlToValidate="contactNoTextBox" ErrorMessage="Please enter your contact no." ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="contactNoTextBox" runat="server" Width="414px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 270px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
    <br />
    <table id="detailsTable" style="width:100%;margin:auto;">
        <tr>
            <td colspan="6" style="height: 20px">
                <asp:Label ID="section2Lbl" runat="server" Text="Section II : Information On Household Members . "></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 22px">
                <asp:Label ID="nameLbl" runat="server" Text="Family Members (In NRIC) : "></asp:Label>
            </td>
            <td style="width: 230px; height: 22px;">
                <asp:Label ID="relationshipLbl" runat="server" Text="Relationship With Applicant : "></asp:Label>
            </td>
            <td class="modal-sm" style="width: 225px; height: 22px;">
                <asp:Label ID="occupationLbl" runat="server" Text="Occupation : "></asp:Label>
            </td>
            <td style="height: 22px" colspan="2">
                <asp:Label ID="incomeEarnedLbl" runat="server" Text="Gross Monthly Income ($) : "></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 20px; width: 42px">
                <asp:Label ID="oneLbl" runat="server" Text="1."></asp:Label>
            </td>
            <td style="height: 20px; width: 230px">
                <asp:TextBox ID="member1Textbox" runat="server"></asp:TextBox>
            </td>
            <td style="height: 20px; width: 230px">
                <asp:TextBox ID="relation1TextBox" runat="server"></asp:TextBox>
            </td>
            <td style="height: 20px; width: 225px">
                <asp:TextBox ID="occupation1TextBox" runat="server"></asp:TextBox>
            </td>
            <td style="height: 20px" colspan="2">
                <asp:TextBox ID="income1TextBox" runat="server" AutoPostBack="True" OnTextChanged="income1TextBox_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 42px; height: 22px">
                <asp:Label ID="twoLbl" runat="server" Text="2."></asp:Label>
            </td>
            <td style="width: 230px; height: 22px">
                <asp:TextBox ID="member2TextBox" runat="server"></asp:TextBox>
            </td>
            <td style="width: 230px; height: 22px">
                <asp:TextBox ID="relation2TextBox" runat="server"></asp:TextBox>
            </td>
            <td class="modal-sm" style="width: 225px; height: 22px">
                <asp:TextBox ID="occupation2TextBox" runat="server"></asp:TextBox>
            </td>
            <td style="height: 22px" colspan="2">
                <asp:TextBox ID="income2TextBox" runat="server" AutoPostBack="True" OnTextChanged="income2TextBox_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 42px">
                <asp:Label ID="threeLbl" runat="server" Text="3."></asp:Label>
            </td>
            <td style="width: 230px">
                <asp:TextBox ID="member3TextBox" runat="server"></asp:TextBox>
            </td>
            <td style="width: 230px">
                <asp:TextBox ID="relation3TextBox" runat="server"></asp:TextBox>
            </td>
            <td class="modal-sm" style="width: 225px">
                <asp:TextBox ID="occupation3TextBox" runat="server"></asp:TextBox>
            </td>
            <td colspan="2">
                <asp:TextBox ID="income3TextBox" runat="server" AutoPostBack="True" OnTextChanged="income3TextBox_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 42px">
                <asp:Label ID="fourLbl" runat="server" Text="4."></asp:Label>
            </td>
            <td style="width: 230px">
                &nbsp;</td>
            <td style="width: 230px">
                &nbsp;</td>
            <td class="modal-sm" style="width: 225px">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 42px">
                <asp:Label ID="fiveLbl" runat="server" Text="5."></asp:Label>
            </td>
            <td style="width: 230px">&nbsp;</td>
            <td style="width: 230px">&nbsp;</td>
            <td class="modal-sm" style="width: 225px">&nbsp;</td>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 42px; height: 22px;">
                <asp:Label ID="sixLbl" runat="server" Text="6."></asp:Label>
            </td>
            <td style="width: 230px; height: 22px;"></td>
            <td style="width: 230px; height: 22px;"></td>
            <td class="modal-sm" style="width: 225px; height: 22px;"></td>
            <td class="auto-style1"></td>
            <td style="height: 22px"></td>
        </tr>
        <tr>
            <td colspan="3" style="height: 22px"></td>
            <td class="modal-sm" style="width: 225px; height: 22px;">
                <asp:Label ID="grossHouseHoldIncomeLbl" runat="server" Text="Gross Household Income ($) : "></asp:Label>
            </td>
            <td class="auto-style1">
                &nbsp;</td>
            <td style="height: 22px">
                <asp:Label ID="totalIncomeLbl" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;</td>
            <td class="modal-sm" style="width: 225px">
                <asp:Label ID="capitaLbl" runat="server" Text="Per Capita Income ($) : "></asp:Label>
            </td>
            <td class="auto-style2">
                &nbsp;</td>
            <td>
                <asp:Label ID="perCapitaLbl" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;</td>
            <td class="modal-sm" style="width: 225px">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" HeaderText="Please resolve data entry error" ShowMessageBox="True" ShowSummary="False" />
            </td>
            <td class="modal-sm" style="width: 225px">&nbsp;</td>
            <td class="auto-style2">
                &nbsp;</td>
            <td>
                <asp:Button ID="submitBtn" runat="server" Text="Submit" OnClick="submitBtn_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;</td>
            <td class="modal-sm" style="width: 225px">&nbsp;</td>
            <td class="auto-style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;</td>
            <td class="modal-sm" style="width: 225px">&nbsp;</td>
            <td class="auto-style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;</td>
            <td class="modal-sm" style="width: 225px">&nbsp;</td>
            <td class="auto-style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;</td>
            <td class="modal-sm" style="width: 225px">&nbsp;</td>
            <td class="auto-style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;</td>
            <td class="modal-sm" style="width: 225px">&nbsp;</td>
            <td class="auto-style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
        </div>
</asp:Content>
