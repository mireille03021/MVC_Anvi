


 /* 網頁變數 */
 //browser_window();
 //window.addEventListener("resize", browser_window);
 //function browser_window() {
 //    document.documentElement.style.setProperty("--window-height", window.innerHeight + "px");
 //   // document.documentElement.style.setProperty("--announcement-bar-height", document.getElementsByClassName("topnews")[0].offsetHeight + "px");
 //     document.documentElement.style.setProperty("--header-height", 150 + "px");
 //}



 $(function() {
   $("#section-end").click(function(){

       $("html,body").animate({ scrollTop: $('#section-slideshow-end').offset().top},800);
  });
});
