<%@ Page Title="Title" Language="C#" MasterPageFile="/mainMenu.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="/Scripts/jquery-3.2.1.min.js"></script>
    <script src="/Scripts/jquery.signalR-2.2.2.js"></script>
    <script src="/signalr/hubs"> </script>
    <script type="text/javascript">
        $(function () {
            var chat = $.connection.chatHub;
            var messages = "";
            chat.client.broadcastMessage = function (name, message) {
                // HTML Encode display name and message
                var encodedName = $('<div />').text(name).html();
                var encodedMsg = $('<div />').text(message).html();
                $(".chatlogs").append("<div> <p>" + message + name + " </p> </div>");
            };

            $.connection.hub.start().done(function () {
                $("#sendmessage").click(function () {
                    chat.server.send("test", $("#messages").val());
                    console.log("On CLICK : " + $("#messages").val());
                });
            });
        })
    </script>
    <div class="chatbox">
        <div class="chatlogs" id="clChat">
        </div>
    </div>
    <div class="chatform">
        <textarea id="messages"></textarea>
        <button id="sendmessage">Send</button>
    </div>

</asp:Content>