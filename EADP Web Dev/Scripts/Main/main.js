$(function() {
    $(".nav-menu li").on("click",
        function() {
            $("li").removeClass("menu-active");
            $(this).addClass("menu-active");
            console.log($(this).cssClass);
        });


    var notification = $.connection.notificationHub;
    var chathub1 = $.connection.chatHub;
    $.connection.hub.start();
    notification.client.addNotificationMessage = function (message) {
        if (message.type === "noti") {
            alert(message.sender + " invited you to " + message.message);
            console.log("email : " + message.sender);
        } else if (message.type === "chat") {

        }
    };
});