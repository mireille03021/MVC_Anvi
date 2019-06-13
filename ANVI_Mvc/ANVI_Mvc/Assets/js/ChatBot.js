$(function () {
    var options = {
        line: "//line.me/R/ti/p/%40545nfrgg", // Line QR code URL
       // call_to_action: "QRCode", // Call to action
        position: "right", // Position may be 'right' or 'left'
    };
    var proto = document.location.protocol,
        host = "whatshelp.io",
        url = proto + "//static." + host;
    var s = document.createElement('script');
    s.type = 'text/javascript';
    s.async = true;
    s.src = url + '/widget-send-button/js/init.js';
    s.onload = function () { WhWidgetSendButton.init(host, proto, options); };
    var x = document.getElementsByTagName('script')[0];
    x.parentNode.insertBefore(s, x);
});