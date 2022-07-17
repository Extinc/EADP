<%@ Page Title="" Language="C#" MasterPageFile="~/mainMenu.Master" AutoEventWireup="true" CodeBehind="Statistics.aspx.cs" Inherits="EADP_Web_Dev.web.Finance.Statistics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <script src="http://code.jquery.com/jquery-1.8.2.js"></script>  
    <script src="http://www.google.com/jsapi" type="text/javascript"></script>
         <script type="text/javascript">           
        google.load('visualization', '1', { packages: ['corechart'] });  
    </script> 

    <script type="text/javascript">
        $(function () {  
            $.ajax({  
                type: 'POST',  
                dataType: 'json',  
                contentType: 'application/json',  
                url: 'Statistics.aspx/GetChartData',  
                data: '{}',  
                success:  
                function (response) {  
                    drawchart(response.d);  
                },  
  
                error: function () {  
                    alert("Error loading data!");  
                }  
            });  
        })  

        function drawchart(dataValues) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Column Name');
            data.addColumn('number', 'Column Value');
            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].expenseItem, dataValues[i].totalExpAmt]);
            }
            new google.visualization.PieChart(document.getElementById('myChartDiv')).
                draw(data, { title: "Expense Details" });
        }
    </script>  
       <h2 style="text-align:center;font-family:'Lucida Handwriting'">&nbsp;Statistics.</h2>
   
    <div style ="margin:auto;">
        <table style="width: 100%;">
            <tr>
                <td style="width:60%;">
                     <div id="myChartDiv" style="height: 500px;">  
        </div>
                   
                </td>
                <td style="width:40%;">
                    <table style="width: 100%;;">
                        <tr>
                            <td style="width: 329px">&nbsp;</td>
                            <td style="width: 238px">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 329px">&nbsp;</td>
                            <td style="width: 238px">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 329px">&nbsp;</td>
                            <td style="width: 238px">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 329px">
                                <asp:Label ID="Label1" runat="server" Text="Total Number Of Expenses Maded :" Font-Bold="False" Font-Size="Medium"></asp:Label>
                            </td>
                            <td style="width: 238px">
                                <asp:Label ID="LblNumber" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="height: 22px; width: 329px">
                                &nbsp;</td>
                            <td style="width: 238px; height: 22px">
                                &nbsp;</td>
                            <td style="height: 22px"></td>
                        </tr>
                        <tr>
                            <td style="width: 329px">
                                <asp:Label ID="Label2" runat="server" Text="Total Expenses : " Font-Bold="False" Font-Size="Medium"></asp:Label>
                            </td>
                            <td style="width: 238px">
                                <asp:Label ID="LblTotalExpenses" runat="server" Text="" Font-Bold="true" Font-Size="Medium"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 329px">&nbsp;</td>
                            <td style="width: 238px">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 329px">
                                &nbsp;</td>
                            <td style="width: 238px">
                                <asp:Button ID="incomeStatBtn" runat="server" CssClass="btn btn-info" OnClick="incomeStatBtn_Click" Text="View Income" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 329px">&nbsp;</td>
                            <td style="width: 238px">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>

                </td>
               
            </tr>
            <tr>
                <td style="width:60%;">
                     &nbsp;</td>
                <td style="width:40%;">
                    &nbsp;</td>
               
            </tr>
        </table>
                  
        </div>
      

</asp:Content>

