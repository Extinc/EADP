<%@ Page Title="" Language="C#" MasterPageFile="~/mainMenu.Master" AutoEventWireup="true" CodeBehind="Consultation.aspx.cs" Inherits="EADP_Web_Dev.web.Consultation.Consultation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .title::before {
            content: " ";
            position: absolute;
            background: #fff;
            bottom: -6px;
            width: 220px;
            height: 30px;
            z-index: -1;
            left: 50%;
            margin-left: -110px;
        }

        .title::after {
            content: " ";
            position: absolute;
            border: 1px solid #f5f5f5;
            bottom: 8px;
            left: 0;
            width: 100%;
            height: 0;
            z-index: -2;
        }

        .title {
            color: #FE980F;
            font-family: 'Roboto', sans-serif;
            font-size: 18px;
            font-weight: 700;
            text-transform: uppercase;
            margin-bottom: 30px;
            position: relative;
        }
    </style>
    <script type="text/javascript">
        function Confirm(who, fullname) {

                var chathub = $.connection.chatHub;
                $.connection.hub.start().done(function() {
                    chathub.server.send("have invited you to a conversation"+',"' +
                        who +
                        '","' +
                        fullname +
                        '"');
                    console.log("CONFIRM + " + fullname);
                });

        }
    </script>
    <div class="container">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="col-sm-4">
                        <h2 class="title text-center">Available</h2>
                        <div class="row" id="divdocAvail" runat="server"></div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>