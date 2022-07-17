<%@ Page Title="" Language="C#" MasterPageFile="~/mainMenu.Master" AutoEventWireup="true"  EnableEventValidation = "false" CodeBehind="ExpenseDetails.aspx.cs" Inherits="EADP_Web_Dev.web.Finance.ExpenseDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">  

        function DeleteConfirm() 
        {  
            var Ans = confirm("Do you want to Delete Selected Expense Record?");  
            if (Ans)
            {  
                return true;  
            }  
            else 
            {  
                return false;  
            }  
        }  
</script>  

    <!-- internal style sheet -->
    <style type="text/css">

        .auto-style1 {
            height: 22px;
        }

        .auto-style2 {
            height: 22px;
            width: 147px;
        }
        .auto-style3 {
            width: 147px;
        }

        .auto-style4 {
            width: 100%;
            height: 123px;
        }
        .auto-style5 {
            height: 34px;
            width: 147px;
        }
        .auto-style6 {
            height: 34px;
        }

        .auto-style7 {
            position: relative;
            display: flex;
            -webkit-box-orient: vertical;
            -webkit-box-direction: normal;
            -ms-flex-direction: column;
            flex-direction: column;
            min-width: 0;
            word-wrap: break-word;
            background-clip: border-box;
            border-radius: .3rem;
            font-weight: 400;
            width: 90%;
            left: 0px;
            top: 0px;
            height: 1049px;
            background-color: #fff;
        }

        </style>

    <h2 style="text-align:center;font-family:'Lucida Handwriting'">Financial Tracker.</h2> 
    <div class="panel panel-default" style="margin:auto;width:90%;height:auto;">
          <!-- background panel -->
        <asp:Panel ID="backgroundPanel" runat="server" BackColor="#C0C0C0" style="margin:auto;" Height="1228px">
             &nbsp;
               <asp:Panel ID="PanelErrorResult" Visible="false" runat="server" CssClass="alert alert-dismissable alert-danger" Width="90%" style="margin:auto;">
                    <button type="button" class="close" data-dismiss="alert">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <asp:Label ID="Lbl_err" runat="server"></asp:Label>
                </asp:Panel>
            &nbsp;

            <div class="auto-style7" style="margin:auto;">
    <div class="card-body" style="margin:auto;width:90%;">
                <div role="tabpanel" class="tab-pane active" id="expense">
                     <!-- Expense Table -->
            <!---------<div class="panel panel-default">---------->
                        <!-- Default panel contents -->
                     &nbsp;
                    <div class="panel-heading" style="font-family:'Lucida Handwriting';font-size:20px;">Expenses Details</div>
                    &nbsp;
                    <table class="auto-style4">
                      
                        <tr>
                            <td class="auto-style5"> <asp:HyperLink NavigateUrl="~/web/Finance/MainStatistics.aspx" runat="server" Text="View Your Statistics Now!     "/></td>
                            
                            <td class="auto-style6"></td>
                        </tr>
                        <tr>
                            <td class="auto-style2">
                                <asp:Label ID="searchLbl" runat="server" Text="Search : "></asp:Label>
                            </td>
                            <td class="auto-style1">
                                
                                <asp:TextBox ID="searchTextBox" runat="server" Width="203px"></asp:TextBox>
                                
                                <asp:Button ID="BtnGo" runat="server" CssClass="btn btn-default" OnClick="BtnGo_Click" Text="Go!" Width="93px" />
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">&nbsp;</td>
                           
                            <td>
                                <asp:Button ID="exporthtml" runat="server" class="btn btn-default" OnClick="exportHTML_Click" style="margin-left:80%;width:250px;" Text="Export To HTML" />
                                <asp:Button ID="exportDetails" runat="server" class="btn btn-default" OnClick="exportDetails_Click" style="margin-left:80%;width:250px;" Text="Export To Excel" />
                            </td>
                        </tr>
                    </table>
                    &nbsp;<br />
                     <asp:Panel ID="updatepanel" runat="server">
                     </asp:Panel>
                     <br />
                     <br />

                     <asp:GridView ID="GridView1" runat="server" AllowPaging="True" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" AutoGenerateColumns="False" ShowFooter="True" DataKeyNames="expenseID" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDataBound="GridView1_RowDataBound">
                          <Columns>  
                        <asp:BoundField DataField="expenseID" HeaderText="S.No." HtmlEncode = "false"/>  
                        <asp:BoundField DataField="date" HtmlEncode = "false" HeaderText="Date" DataFormatString="{0:d}" />  
                        <asp:BoundField DataField="expAmt" HtmlEncode = "false" HeaderText="Expense Amount" DataFormatString="{0:c}" />  
                        <asp:BoundField DataField="category"  HtmlEncode = "false" HeaderText="Category" /> 
                        <asp:BoundField DataField="expenseItem"  HtmlEncode = "false" HeaderText="Expense Item" />  
                        <asp:CommandField ShowEditButton="true" />  
                        <asp:CommandField ShowDeleteButton="true" />
                          </Columns>  
                         <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                         <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                         <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                         <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                         <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                         <SortedAscendingCellStyle BackColor="#F1F1F1" />
                         <SortedAscendingHeaderStyle BackColor="#594B9C" />
                         <SortedDescendingCellStyle BackColor="#CAC9C9" />
                         <SortedDescendingHeaderStyle BackColor="#33276A" />
                     </asp:GridView>
                     <br />
                     <br />

                    
                   
                    <!-- grid view -->

                </div>
        </div>
                   </div>
</div>      
        </asp:Panel>   
</asp:Content>


