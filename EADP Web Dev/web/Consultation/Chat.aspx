<%@ Page Title="" Language="C#" MasterPageFile="~/mainMenu.Master" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="EADP_Web_Dev.web.Consultation.Chat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function() {
            var chathubs = $.connection.chatHub;
            var qString = "?" + window.location.href.split("?")[1];
            $.connection.hub.start();
            chathubs.client.getPmessages = function(message) {
                console.log("Test Chathub in chat");
                $.ajax({
                    type: "POST",
                    url: "Chat.aspx/MethodAppendLi",
                    data: "{}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg) {
                        // Do something interesting here.
                        console.log("Success YO HE");

                    }
                });
            }
        })

    </script>
    <div class="container">

        <div class="row" style="margin-bottom: 0px !important;">
            <div class="col-sm-10 row" style="margin-bottom: 0px !important;">
                <div class="row col-sm-12" style="margin-bottom: 0px !important;">
                    <asp:UpdatePanel ID="chatUpdatePanel" UpdateMode="Conditional" style="width: 100%; height: 500px" runat="server">
                        <ContentTemplate>
                            <asp:Timer ID="Timer1" runat="server" Interval="3000" OnTick="Timer1_Tick"></asp:Timer>
                            <asp:Panel ID="chatPanel" runat="server" Width="100%" ScrollBars="Auto" Height="500px">
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="row col-sm-12">
                    <div class="input-field col-sm-10">
                        <asp:TextBox runat="server" ID="tb_Message"></asp:TextBox>
                        <asp:Label runat="server" CssClass="" Text="Enter your Message" AssociatedControlID="tb_Message"></asp:Label>
                    </div>
                    <div class="col-sm-2">
                        <asp:Button runat="server" CssClass="waves-effect waves-light btn" ID="btnSend" Text="Send" OnClick="btnSend_OnClick"/>
                    </div>
                </div>
            </div>
            <div class="col-sm-2">
                <div class="row">
                    <asp:Button runat="server" CssClass="waves-effect waves-light btn" Text="Go back" ID="btnReturn"/>
                </div>
                <div class="row">
                    <ul id="userUL" class="collection" runat="server"></ul>
                </div>
            </div>
        </div>

        <%--            <Triggers>
$1$                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />#1#
            </Triggers>--%>

    </div>
</asp:Content>