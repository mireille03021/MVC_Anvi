//這邊下面寫滾動卷軸動作
//$(function () {
//    $(window).scroll(function () {
//        var scroll = $(window).scrollTop();





//        if (scroll >= 15) {
         
//            $('#header').addClass('fixed');
           
//            $(".topnemu").css("background-color", "#ffffff");
//            $(".topnemu").css("color", "#1C1B1B");
//            $(".SListItem").css("color", "#1C1B1B");
//            $(".username a").css("color", "#1C1B1B");
//            $(".search a").css("color", "#1C1B1B");
//            $(".topnemu a").css("color", "#1C1B1B");
//            $(".topnemulinetwo ul").css("border-bottom", "#dddddd 1px solid");
//            $(".LogoImage").css("background-image", "url('/Assets/images/Logo/ANVI-Logo-Black_140x@2x.png')");


//        } else if (scroll == 0) {
//            $('#header').removeClass('fixed');
            
//            $(".topnemu").css("background-color", "transparent");
//            $(".topnemu").css("color", "#ffffff");
//            $(".SListItem").css("color", "#ffffff");
//            $(".username a").css("color", "#ffffff");
//            $(".search a").css("color", "#ffffff");
//            $(".topnemu a").css("color", "#ffffff");
//            $(".topnemulinetwo ul").css("border-bottom", "#ffffff 1px solid");
//            $(".LogoImage").css("background-image", "url('/Assets/images/Logo/ANVI-Logo-White_140x@2x.png')");



//        } else {
//            $('#header').removeClass('fixed');
          
//        }

//    });
//});


//function scroll() {
//    //console.log("打印log日志");实时看下效果
//    console.log("开始滚动！");
//}

//var scrollFunc = function (e) {
//    e = e || window.event;
//    if (e.wheelDelta) {  //第一步：先判断浏览器IE，谷歌滑轮事件               
//        if (e.wheelDelta > 0) { //当滑轮向上滚动时  
//            console.log("滑轮向上滚动");
//        }
//        if (e.wheelDelta < 0) { //当滑轮向下滚动时  
//            console.log("滑轮向下滚动");
//        }
//    } else if (e.detail) {  //Firefox滑轮事件  
//        if (e.detail > 0) { //当滑轮向上滚动时  
//            console.log("滑轮向上滚动");
//        }
//        if (e.detail < 0) { //当滑轮向下滚动时  
//            console.log("滑轮向下滚动");
//        }
//    }
//}

window.onscroll = function () {
    var clientHeight = document.documentElement.clientHeight;
    var scrollTop = document.body.scrollTop;
    var scrollHeight = document.body.scrollHeight;

    if (scrollTop == 0) {
        //document.getElementById("header").className = "";
        //document.getElementById("header").style.position = "absolute";
    } else if (scrollTop >= 15) {

        //document.getElementById("header").className = "fixed";
        //document.getElementById("header").style.position = "fixed";
        var topmenu = document.getElementsByClassName("topnemu")[0];
        topmenu.style.backgroundColor = "#ffffff";
        topmenu.style.color = "#1C1B1B";
        var SListItem = document.getElementsByClassName("SListItem")[0];
        SListItem.style.color = "#1C1B1B";
        //var usernamea = document.getElementsByClassName("username a")[0];
        //usernamea.style.color = "#1C1B1B";
        //var searcha = document.getElementsByClassName("search a")[0];
        //searcha.style.color = "#1C1B1B";
        //var topnemua = document.getElementsByClassName("topnemu a")[0];
        //topnemua.style.color = "#1C1B1B";

        //var topnemulinetwoul = document.getElementsByClassName("topnemulinetwo ul")[0];
        //topnemulinetwoul.style.borderbottom = "#dddddd 1px solid";
        //var LogoImage = document.getElementsByClassName("LogoImage")[0];
        //LogoImage.style.backgroundimage = "url('/Assets/images/Logo/ANVI-Logo-Black_140x@2x.png')";
     
      


    }
    else {
        //document.getElementById("header").className = "";
        //document.getElementById("header").style.position = "absolute";
    }


}

////给页面绑定滑轮滚动事件  
//if (document.addEventListener) {//firefox  
//    document.addEventListener('DOMMouseScroll', scrollFunc, false);
//}
////滚动滑轮触发scrollFunc方法  //ie 谷歌  
//window.onmousewheel = document.onmousewheel = scrollFunc;

