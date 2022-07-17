<%@ Page Title="" Language="C#" MasterPageFile="~/mainMenu.Master" AutoEventWireup="true" CodeBehind="CommunityEvent.aspx.cs" Inherits="EADP_Web_Dev.web.CommunityEvent.CommunityEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(document).ready(function() {
            $('.tooltipped').tooltip();
        });
    </script>
    <div class="container" style="padding-left: 0px !important; padding-right: 0px !important;">
        <!--Container start-->
        <!--Top Row-->
        <div class="row #1a237e indigo darken-2 z-depth-3" style="padding-top: 10px; padding-bottom: 10px; padding-left: 15px !important; padding-right: 15px !important;">
            <div class="col-sm-10" style="padding-top: 5px; border-bottom-color: gainsboro; border-width: 1px">
                <asp:Label runat="server" Text="Community Event" CssClass="white-text align-left" Font-Bold="True" Font-Size="18"></asp:Label>
            </div>
            <div class="col-sm-2 text-center">
                <asp:HyperLink runat="server" CssClass="btn-floating btn-large waves-effect waves-light indigo accent-4" Text="+ Event" NavigateUrl="~/web/CommunityEvent/CreateCommEvent.aspx"></asp:HyperLink>
            </div>
        </div>
        <!--Top Row End-->
        <!--Bottom Row-->
        <div class="row">
            <div class="col-sm-10 row" id="CEHolder" runat="server">
                <%--                <div class="card col s5">
                    <div class="card-panel activator teal waves-effect waves-block waves-light">
                        $1$<a class="btn activator">#1#
                        <asp:Label runat="server" ID="eventTitle" CssClass="white-text " Text="Test"></asp:Label>
                        $1$</a>#1#
                        </div>
                    <div class="card-content">
$1$                        <span class="card-title activator grey-text text-darken-4">Card Title<i class="material-icons right">more_vert</i></span>#1#
                        <asp:Label runat="server" CssClass="card-title activator grey-text text-darken-4" ID="eventDate" ></asp:Label>
                        <asp:Label runat="server" ID="eventCreator"></asp:Label>
                    </div>
                    <div class="card-reveal">
                        <asp:Label runat="server" CssClass="card-title grey-text text-darken-4" ID="Label1" Text="" />
$1$                        <span class="card-title grey-text text-darken-4">Card Title<i class="material-icons right">close</i></span>#1#
                        <p>Here is some more information about this product that is only revealed once clicked on.</p>
                    </div>
                </div>--%>
            </div>

            <!--Event Recommendation Row-->
            <div class="col-sm-2">

            </div>
            <!--Event Recommendation Row End-->

        </div>
        <!--Bottom Row End-->

    </div><!--Container end-->
</asp:Content>