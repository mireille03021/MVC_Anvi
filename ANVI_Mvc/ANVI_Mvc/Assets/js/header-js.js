//這邊下面寫滾動卷軸動作
$(function () {
    $(window).scroll(function () {
        var scroll = $(window).scrollTop();

        if (scroll >= 15) {
            //$('#header').addClass('fixed');
            //$('#header').css(" position:", "fixed");
            $(".topnemu").css("background-color", "#ffffff");
            $(".topnemu").css("color", "#1C1B1B");
            $(".SListItem").css("color", "#1C1B1B");
            $(".username a").css("color", "#1C1B1B");
            $(".search a").css("color", "#1C1B1B");
            $(".topnemu a").css("color", "#1C1B1B");
            $(".topnemulinetwo ul").css("border-bottom", "#dddddd 1px solid");
            $(".LogoImage").css("background-image", "url('/Assets/images/Logo/ANVI-Logo-Black_140x@2x.png')");

            $("#header").hover(function () {
                $(".topnemu").css("background-color", "#ffffff");
                $(".topnemu").css("color", "#1C1B1B");
                $(".SListItem").css("color", "#1C1B1B");
                $(".username a").css("color", "#1C1B1B");
                $(".search a").css("color", "#1C1B1B");
                $(".topnemu a").css("color", "#1C1B1B");
                $(".topnemulinetwo ul").css("border-bottom", "#dddddd 1px solid");
                $(".LogoImage").css("background-image", "url('/Assets/images/Logo/ANVI-Logo-Black_140x@2x.png')");

            }, function () {
                $(".topnemu").css("background-color", "#ffffff");
                $(".topnemu").css("color", "#1C1B1B");
                $(".SListItem").css("color", "#1C1B1B");
                $(".username a").css("color", "#1C1B1B");
                $(".search a").css("color", "#1C1B1B");
                $(".topnemu a").css("color", "#1C1B1B");
                $(".topnemulinetwo ul").css("border-bottom", "#dddddd 1px solid");
                $(".LogoImage").css("background-image", "url('/Assets/images/Logo/ANVI-Logo-Black_140x@2x.png')");

            });



        } else if (scroll == 0) {
            //$('#header').removeClass('fixed');
            //$('#header').css(" position:", " absolute");
            $(".topnemu").css("background-color", "transparent");
            $(".topnemu").css("color", "#ffffff");
            $(".SListItem").css("color", "#ffffff");
            $(".username a").css("color", "#ffffff");
            $(".search a").css("color", "#ffffff");
            $(".topnemu a").css("color", "#ffffff");
            $(".topnemulinetwo ul").css("border-bottom", "#ffffff 1px solid");
            $(".LogoImage").css("background-image", "url('/Assets/images/Logo/ANVI-Logo-White_140x@2x.png')");
            $("#header").hover(function () {
                $(".topnemu").css("background-color", "#ffffff");
                $(".topnemu").css("color", "#1C1B1B");
                $(".SListItem").css("color", "#1C1B1B");
                $(".username a").css("color", "#1C1B1B");
                $(".search a").css("color", "#1C1B1B");
                $(".topnemu a").css("color", "#1C1B1B");
                $(".topnemulinetwo ul").css("border-bottom", "#dddddd 1px solid");
                $(".LogoImage").css("background-image", "url('/Assets/images/Logo/ANVI-Logo-Black_140x@2x.png')");

            }, function () {
                $(".topnemu").css("background-color", "transparent");
                $(".topnemu").css("color", "#ffffff");
                $(".SListItem").css("color", "#ffffff");
                $(".username a").css("color", "#ffffff");
                $(".search a").css("color", "#ffffff");
                $(".topnemu a").css("color", "#ffffff");
                $(".topnemulinetwo ul").css("border-bottom", "#ffffff 1px solid");
                $(".LogoImage").css("background-image", "url('/Assets/images/Logo/ANVI-Logo-White_140x@2x.png')");

            });


        } else {
            //$('#header').removeClass('fixed');
            //$('#header').css(" position:", " absolute");
            $("#header").hover(function () {
                $(".topnemu").css("background-color", "#ffffff");
                $(".topnemu").css("color", "#1C1B1B");
                $(".SListItem").css("color", "#1C1B1B");
                $(".username a").css("color", "#1C1B1B");
                $(".search a").css("color", "#1C1B1B");
                $(".topnemu a").css("color", "#1C1B1B");
                $(".topnemulinetwo ul").css("border-bottom", "#dddddd 1px solid");
                $(".LogoImage").css("background-image", "url('/Assets/images/Logo/ANVI-Logo-Black_140x@2x.png')");

            }, function () {
                    $(".topnemu").css("background-color", "#ffffff");
                    $(".topnemu").css("color", "#1C1B1B");
                    $(".SListItem").css("color", "#1C1B1B");
                    $(".username a").css("color", "#1C1B1B");
                    $(".search a").css("color", "#1C1B1B");
                    $(".topnemu a").css("color", "#1C1B1B");
                    $(".topnemulinetwo ul").css("border-bottom", "#dddddd 1px solid");
                    $(".LogoImage").css("background-image", "url('/Assets/images/Logo/ANVI-Logo-Black_140x@2x.png')");

            });


        }

    });
});








    $(function () {
        $(".shop").hover(function () {
            $(".MenuList").css("visibility", "visible");
           

        });
    });


$(function () {
    var scroll = $(window).scrollTop();
    if (scroll == 0) {
        $("#header").hover(function () {
            $(".topnemu").css("background-color", "#ffffff");
            $(".topnemu").css("color", "#1C1B1B");
            $(".SListItem").css("color", "#1C1B1B");
            $(".username a").css("color", "#1C1B1B");
            $(".search a").css("color", "#1C1B1B");
            $(".topnemu a").css("color", "#1C1B1B");
            $(".topnemulinetwo ul").css("border-bottom", "#dddddd 1px solid");
            $(".LogoImage").css("background-image", "url('/Assets/images/Logo/ANVI-Logo-Black_140x@2x.png')");

        }, function () {
            $(".topnemu").css("background-color", "transparent");
            $(".topnemu").css("color", "#ffffff");
            $(".SListItem").css("color", "#ffffff");
            $(".username a").css("color", "#ffffff");
            $(".search a").css("color", "#ffffff");
            $(".topnemu a").css("color", "#ffffff");
            $(".topnemulinetwo ul").css("border-bottom", "#ffffff 1px solid");
            $(".LogoImage").css("background-image", "url('/Assets/images/Logo/ANVI-Logo-White_140x@2x.png')");

        });
    }
});

    
        $(function () {
        $(".new").hover(function () {
            $(".MenuList").css("visibility", "hidden");
        });
    });
        $(function () {
        $(".about_us").hover(function () {
            $(".MenuList").css("visibility", "hidden");
        });
    });

$(function () {
        $(".MenuList").hover(function () {
            $(".MenuList").css("visibility", "visible");
        }, function () {
            $(".MenuList").css("visibility", "hidden");
        });
    });
        $(function () {
        $(".topnemu").hover(function () {

        }, function () {
            $(".MenuList").css("visibility", "hidden");
        });
    });
    //應該要寫一個語法合併上面
   
 