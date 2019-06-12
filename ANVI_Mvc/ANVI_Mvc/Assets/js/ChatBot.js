//$(function () {
//    var options = {
//        facebook: "232472107265920", // Facebook page ID
//        line: "//line.me/ti/p/2Y-7aApB8d", // Line QR code URL
//        call_to_action: "點這跟我們聊聊！", // Call to action
//        button_color: "#F0E68C", // Color of button
//        position: "right", // Position may be 'right' or 'left'
//        order: "facebook,line", // Order of buttons
//    };
//    var proto = document.location.protocol, host = "whatshelp.io", url = proto + "//static." + host;
//    var s = document.createElement('script'); s.type = 'text/javascript'; s.async = true; s.src = url + '/widget-send-button/js/init.js';
//    s.onload = function () { WhWidgetSendButton.init(host, proto, options); };
//    var x = document.getElementsByTagName('script')[0]; x.parentNode.insertBefore(s, x);
//})();

$(function () {
    var options = {
        line: "//line.me/R/ti/p/%40286yoxxl", // Line QR code URL
        call_to_action: "與我們聯絡!", // Call to action
        position: "right", // Position may be 'right' or 'left'
    };
    var proto = document.location.protocol,
        host = "whatshelp.io",
        url = proto + "//static." + host;
    var s = document.createElement('script');
    s.type = 'text/javascript'; s.async = true;
    s.src = url + '/widget-send-button/js/init.js';
    s.onload = function () { WhWidgetSendButton.init(host, proto, options); };
    var x = document.getElementsByTagName('script')[0];
    x.parentNode.insertBefore(s, x);
    //$("<p></p>").text("@286yoxxl").prependTo(".LyWrap");
}
