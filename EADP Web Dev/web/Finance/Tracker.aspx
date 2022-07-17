<%@ Page Title="" Language="C#" MasterPageFile="~/mainMenu.Master" AutoEventWireup="true" CodeBehind="Tracker.aspx.cs" Inherits="EADP_Web_Dev.web.Finance.Tracker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2 style="text-align:center;font-family:'Lucida Handwriting'">Financial Tracker.</h2>
     
    
    <style>
        .selectnohide {
            display:block;
        }
    </style>
    <div class ="panel panel-default" style="margin:auto;width:90%;"> 
         &nbsp;
        
        <asp:Panel ID="financialPanel" runat="server"  Width="100%" Height="114px" Visible="False">
            &nbsp;
            <h2 style="font-size:30px;text-align:center;color:red;">You are eligible for Financial Scheme!s</h2>
            &nbsp; &nbsp;
           
            <asp:HyperLink ID="financialHyperLink" runat="server" NavigateUrl="~/web/Finance/FinancialSchemes.aspx">Apply your financial schemes here!</asp:HyperLink>
           
      </asp:Panel>

         &nbsp;

    <asp:Panel style="margin:auto;" ID="backgroundPanel" runat="server" BackColor="#C0C0C0" Height="100%" Width="100%" >


&nbsp;<div class="panel panel-default" style="margin:auto; width:90%;">
        <asp:Panel ID="panelForDandB" runat="server" Height="75%" Width="100%" BackColor="white">
        <table style="width:100%;" id="contentTable">
            <tr>
                <td style="width: 121px; height: 44px">
                    &nbsp;</td>
                <td style="width: 133px; height: 44px">
                    <asp:Label ID="bLbl" runat="server" Text="Budget : "></asp:Label>
                </td>
                <td style="height: 44px">
                    <asp:TextBox ID="budgetTextBox" runat="server" Width="274px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 20px; width: 121px">
                    &nbsp;</td>
                <td style="height: 20px; width: 133px">
                    <asp:Label ID="dLbl" runat="server" Text="Date : "></asp:Label>
                </td>
                <td style="height: 20px">
                    <asp:Calendar ID="calendarForDate" runat="server" AutoPostBack="True" OnSelectionChanged="Page_Load"></asp:Calendar>
                     <asp:TextBox ID="monthTextBox" runat="server" Width="277px"></asp:TextBox>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                 <caption>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     </caption>
            </tr>
        </table>
            </asp:Panel>
            </div>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;

        &nbsp;
             <div style="margin:auto;">
            <table style="width:90%;margin:auto;">
                <tr>
                    <td style="width: 43%;">

                        <table id="expTable" style="width:100%;height:266px; background-color:white;" >
                           
                                <tr>
                                    <td colspan="3" style="height: 20px">
                                        <asp:HyperLink ID="expenseLink" style="" runat="server" NavigateUrl="~/web/Finance/ExpenseDetails.aspx">View Expense Details</asp:HyperLink>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="height: 20px">
                                        &nbsp;
                                        <asp:Label ID="expLbl" runat="server" style="font-family:'Lucida Handwriting';font-size:20px;" Text="Expense"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 130px; height: 40px">
                                        <asp:Label ID="amtLbl" runat="server" Text="Amount : "></asp:Label>
                                    </td>
                                    <td style="width: 300px; height: 40px">
                                        <asp:TextBox ID="expAmtTextBox" runat="server"></asp:TextBox>
                                    </td>
                                    <td style="height: 40px">
                                        <asp:Label ID="incomeTotalLbl" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 130px; height: 40px">
                                        <asp:Label ID="cLbl" runat="server" Text="Category : "></asp:Label>
                                    </td>
                                    <td style="width: 300px; height: 40px">
                                        <asp:DropDownList ID="expenseDropDownList" CssClass="selectnohide" runat="server">
                                            <asp:ListItem>--Select--</asp:ListItem>
                                            <asp:ListItem>Automotive Expenses</asp:ListItem>
                                            <asp:ListItem>Bank Activity</asp:ListItem>
                                            <asp:ListItem>Business</asp:ListItem>
                                            <asp:ListItem>Child/Dependent Expenses</asp:ListItem>
                                            <asp:ListItem>Debt</asp:ListItem>
                                            <asp:ListItem>Education</asp:ListItem>
                                            <asp:ListItem>Entertainment</asp:ListItem>
                                            <asp:ListItem>Gift/Donations</asp:ListItem>
                                            <asp:ListItem>Groceries</asp:ListItem>
                                            <asp:ListItem>Healthcare/Medical</asp:ListItem>
                                            <asp:ListItem>Housing</asp:ListItem>
                                            <asp:ListItem>Personal Care</asp:ListItem>
                                            <asp:ListItem>Personal/Family</asp:ListItem>
                                            <asp:ListItem>Shopping</asp:ListItem>
                                            <asp:ListItem>Taxes</asp:ListItem>
                                            <asp:ListItem>Travel</asp:ListItem>
                                            <asp:ListItem>Utilities</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="height: 40px">
                                        <asp:Label ID="lblTotalE" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 130px; height: 40px">
                                        <asp:Label ID="Label1" runat="server" Text="Spent On : "></asp:Label>
                                    </td>
                                    <td style="width: 300px; height: 40px">
                                        <asp:TextBox ID="itemTextBox" runat="server"></asp:TextBox>
                                    </td>
                                    <td style="height: 40px">
                                        <asp:Label ID="maxLbl" runat="server" Enabled="False" ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 130px">&nbsp;</td>
                                    <td class="modal-sm">&nbsp;</td>
                                    <td>
                                       
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 130px">&nbsp;</td>
                                    <td class="modal-sm">&nbsp;</td>
                                    <td>
                                        <asp:Button ID="expenseAddBtn" runat="server" CssClass="btn btn-info" OnClick="expenseAddBtn_Click" Text="+" Width="69px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 130px">&nbsp;</td>
                                    <td class="modal-sm">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            
                        </table>
                    </td>
                    <td style="width: 4%;"></td>
                    <td style="width: 43%;">
                         <table id="incomeTable" style="width:100%;background-color:white; height: 264px;">
                            
                                 <tr>
                                     <td colspan="3">
                                         <asp:HyperLink ID="incomeLink" style="" runat="server"  NavigateUrl="~/web/Finance/incomeDetails.aspx">View Income Details</asp:HyperLink>
                                         &nbsp;
                                     </td>
                                 </tr>
                                 <tr>
                                     <td colspan="3">
                                         &nbsp;
                                         <asp:Label ID="incomeLbl" runat="server" style="font-family:'Lucida Handwriting';font-size:20px;" Text="Income"></asp:Label>
                                     </td>
                                 </tr>
                                 <tr>
                                     <td style="width: 130px; height: 40px">
                                         <asp:Label ID="amountLbl" runat="server" Text="Amount : "></asp:Label>
                                     </td>
                                     <td style="width: 300px; height: 40px">
                                         <asp:TextBox ID="incomeTextBox" runat="server"></asp:TextBox>
                                     </td>
                                     <td style="height: 40px"></td>
                                 </tr>
                                 <tr>
                                     <td style="width: 130px; height: 40px">
                                         <asp:Label ID="categoryLbl" runat="server" Text="Category : "></asp:Label>
                                     </td>
                                     <td style="width: 300px; height: 40px">
                                         <asp:DropDownList ID="incomeDropDownList" CssClass="selectnohide" runat="server">
                                             <asp:ListItem>--Select--</asp:ListItem>
                                             <asp:ListItem>Salary</asp:ListItem>
                                             <asp:ListItem>Investments</asp:ListItem>
                                         </asp:DropDownList>
                                     </td>
                                     <td style="height: 40px"></td>
                                 </tr>
                                 <tr>
                                     <td style="width: 130px; height: 40px">
                                         <asp:Label ID="spentON" runat="server" Text="Other Income (Please Specify)  : "></asp:Label>
                                     </td>
                                     <td style="width: 300px; height: 40px">
                                         <asp:TextBox ID="otherIncomeTextBox" runat="server"></asp:TextBox>
                                     </td>
                                     <td style="height: 40px"></td>
                                 </tr>
                                 <tr>
                                     <td style="width: 130px">&nbsp;</td>
                                     <td class="modal-sm">&nbsp;</td>
                                     <td>&nbsp;</td>
                                 </tr>
                                 <tr>
                                     <td style="width: 130px; height: 36px;"></td>
                                     <td class="modal-sm" style="height: 36px"></td>
                                     <td style="height: 36px">
                                         <asp:Button ID="incomeAddBtn" runat="server" CssClass="btn btn-info" Text="+" Width="69px" OnClick="incomeAddBtn_Click" />
                                     </td>
                                 </tr>
                                 <tr>
                                     <td style="width: 130px">&nbsp;</td>
                                     <td class="modal-sm">&nbsp;</td>
                                     <td>&nbsp;</td>
                                 </tr>
                          
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 43%;"></td>
                    <td style="width: 4%;">&nbsp;</td>
                    <td style="width: 43%;">&nbsp;</td>
                </tr>
            </table>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </div>
    </asp:Panel>
    </div>

    </asp:Panel>
   
  
</asp:Content>
