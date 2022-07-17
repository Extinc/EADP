<%@ Page Title="" Language="C#" MasterPageFile="~/mainMenu.Master" AutoEventWireup="true" CodeBehind="incomeDetails.aspx.cs" Inherits="EADP_Web_Dev.web.Finance.incomeDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        width: 114px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2 style="font-family:'Lucida Handwriting';text-align:center;">Financial Tracker.</h2>
    <div style="margin:auto;width:90%;">
        <h3 style="font-family:'Lucida Handwriting';">Income Details<table style="width:100%;">
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="Search By:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="searchTextbox" runat="server" Height="24px" Width="200px"></asp:TextBox>
                    <asp:Button ID="GoBtn" runat="server" Height="26px" CssClass="btn btn-default" OnClick="GoBtn_Click" Text="GO!" Width="94px" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            </table>
        </h3>
        
    <asp:GridView style="margin:auto;width:100%;height:90%;" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="incomeID" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">  
                    <Columns>  
                        <asp:BoundField DataField="incomeID" HeaderText="S.No." />  
                        <asp:BoundField DataField="date" HeaderText="Date" DataFormatString="{0:d}" />  
                         <asp:BoundField DataField="incomeType" HeaderText="Income Type" />  
                        <asp:BoundField DataField="incomeAmt" HeaderText="Income Amount" DataFormatString="{0:c}" />  
                        <asp:CommandField ShowEditButton="true" />  
                        <asp:CommandField ShowDeleteButton="true" /> </Columns>  
                </asp:GridView>
              </asp:Panel>
    </div>
       
</asp:Content>
