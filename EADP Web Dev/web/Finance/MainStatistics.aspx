<%@ Page Title="" Language="C#" MasterPageFile="~/mainMenu.Master" AutoEventWireup="true" CodeBehind="MainStatistics.aspx.cs" Inherits="EADP_Web_Dev.web.Finance.MainStatistics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="http://www.google.com/jsapi" type="text/javascript"></script>
    <script type="text/javascript">
        // Global variable to hold data
        // Load the Visualization API and the piechart package.
        google.load('visualization', '1', { packages: ['corechart'] });
    </script>
    <script type="text/javascript">
        $(function () {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                url: 'MainStatistics.aspx/GetColumnChartData',
                data: '{}',
                success: function (response) {
                    drawchart(response.d); // calling method
                },

                error: function () {
                    alert("Error loading data! Please try again.");
                }
            });
        })

        function drawchart(dataValues) {
            // Callback that creates and populates a data table,
            // instantiates the pie chart, passes in the data and
            // draws it.
            var data = new google.visualization.DataTable();

            data.addColumn('string', 'Spent On:');
            data.addColumn('number', 'Expense Amount');

            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].category, dataValues[i].expAmt]);
            }
            // Instantiate and draw our chart, passing in some options
            var chart = new google.visualization.ColumnChart(document.getElementById('ColumnChartdiv'));

            chart.draw(data,
                {
                    title: "Overview on Expense Spent",
                    position: "top",
                    fontsize: "14px",
                    chartArea: { width: '50%' },
                });
        }
    </script>



    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["corechart"] });
        google.setOnLoadCallback(drawOverviewChart);
        function drawOverviewChart() {
            var options = {
                title: 'Overview Expense',
                width: 600,
                height: 400,
                bar: { groupWidth: "95%" },
                legend: { position: "none" },
                isStacked: true
            };
            $.ajax({
                type: "POST",
                url: "MainStatistics.aspx/GetOverviewChartData",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    var chart = new google.visualization.LineChart($("#chart")[0]);
                    chart.draw(data, options);
                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });
        }
    </script>

    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["corechart"] });
        google.setOnLoadCallback(drawOverviewChart);
        function drawOverviewChart() {
            var options = {
                title: 'Overview Income',
                width: 600,
                height: 400,
                bar: { groupWidth: "95%" },
                legend: { position: "none" },
                isStacked: true
            };
            $.ajax({
                type: "POST",
                url: "MainStatistics.aspx/GetIncomeOverviewChartData",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    var chart = new google.visualization.LineChart($("#incomeChart")[0]);
                    chart.draw(data, options);
                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });
        }
    </script>
     <h2 style="font-family:'Lucida Handwriting';text-align:center">Statistics Overview.</h2>
            

    <div style="margin:auto;width:90%;">
    <table style="width:100%; height: 523px;">
        <tr>
            <td>
               <div id="ColumnChartdiv" style="width: 900px; height: 750px;">
                   </div>

            </td>
          
            <td>
                <div id="chart" style="width: 900px; height: 550px;">
                </div>
                <div id="incomeChart" style="width: 900px; height: 550px;">
                </div>
            </td>
        </tr>
      
      
        <tr>
            <td>
                &nbsp;</td>
          
            <td>
                <asp:Button ID="expenseStatBtn" runat="server" CssClass="btn btn-info" Text="View Expense" OnClick="expenseStatBtn_Click" />
                <asp:Button ID="statIncomeBtn" runat="server" CssClass="btn btn-info" OnClick="statIncomeBtn_Click" Text="View Income" />
            </td>
            
        </tr>
      
      
    </table>
        </div>
</asp:Content>
