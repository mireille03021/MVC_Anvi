//CART
$(function() {
    
    var count = 0;
    $('#cart').click(cartpart);
    $('#carticon').click(cartpart);

    function cartpart() {
        count++;
        if (count % 2 == 1) {
            $('#PageOverBlack').addClass("is-visible");
            $('#sidebar-cart').attr("aria-hidden", "false");
            $('#html').addClass("no-scroll");
        }
        if (count % 2 == 0) {
            $('#PageOverBlack').removeClass("is-visible");
        }
        return false;
    }

    $('#PageOverBlack').click(function() {
        $('#sidebar-cart').attr("aria-hidden", "true");
        $('#PageOverBlack').removeClass("is-visible");
        $('#html').removeClass("no-scroll");
    })

    $('#closecart').click(function() {
        $('#sidebar-cart').attr("aria-hidden", "true");
        $('#PageOverBlack').removeClass("is-visible");
        $('#html').removeClass("no-scroll");
    })

    //點擊空白處隱藏彈出視窗
    // $(document).click(function(event){
    //     var _con = $('#PageOverBlack');   // 設置目標區域
    //     if(!_con.is(event.target) && _con.has(event.target).length === 0){ // Mark 1
    //       //$('#divTop').slideUp('slow');   //滑動消失
    //       $('#PageOverBlack').removeClass("is-visible");          //淡出消失
    //     }
    // });
})