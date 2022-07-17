<%@ Page Title="" Language="C#" MasterPageFile="~/mainMenu.Master" AutoEventWireup="true" CodeBehind="Approval.aspx.cs" Inherits="EADP_Web_Dev.web.Finance.ADMIN.Approval" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        input#ContentPlaceHolder1_GridView1_chkDel_0
        {
            pointer-events :auto;
            opacity:1.0 !important;   
            
            
            
        }
    </style>

    <script type="text/javascript">  


        function UpdateConfirm() 
        {  
            var Ans = confirm("Approve?");  
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
     <h2 style="font-family:'Lucida Handwriting';text-align:center;">Approval</h2>
    <div style="margin:auto;width:90%;">  
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" >  
            <AlternatingRowStyle BackColor="White" />
            <Columns>  
                <asp:TemplateField>  
                    <ItemTemplate >  
                        <asp:CheckBox ID="chkDel" runat="server"/>  
                    </ItemTemplate>  
                </asp:TemplateField>  
                <asp:BoundField DataField="financialSchemeID" HeaderText="No." />  
                <asp:BoundField DataField="applicantName" HeaderText="Applicant Name" />  
                <asp:BoundField DataField="schemeName" HeaderText="Scheme Applied" />  
                <asp:BoundField DataField="totalGross" HeaderText="Total Gross Income" />  
                <asp:BoundField DataField="perCapitalIncome" HeaderText="Per Capita Income" /> 
                 <asp:BoundField DataField="status" HeaderText="Status" />
            </Columns>  
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" ForeColor="#ffffff" Font-Bold="True" />  
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>  
        <br /> 
        
        <asp:Button ID="btnUpdateRecord" CssClass="btn btn-info" runat="server" Height="32px" OnClick="btnUpdateRecord_Click" Text="Approve" />  
        
    </div>  
</asp:Content>
