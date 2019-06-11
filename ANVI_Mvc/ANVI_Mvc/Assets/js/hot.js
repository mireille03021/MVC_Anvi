


var ShopTheLook__ProductList, i=0, j, x = "";
ShopTheLook__ProductList = {
    "ShopTheLook_P": [
        {
            "view": "IMG_0734_1200x.progressive.jpg",
            "product1photo": [
                "Bracelets/C_900x.jpg",
                "Bracelets/B19403_900x.jpg"
            ],
            "product2photo": [
                "Necklaces/4_5400f2af-b2e2-4fc0-9d7a-14cd08bec319_900x.jpg",
                "Necklaces/N19403_900x.jpg"
            ],
            "product1nameprice": [
                "經典開口設計手環",
                "$3,300 TWD"
            ],
            "product2nameprice": [
                "八芒星圓片吊飾純銀項鍊",
                "$3,050 TWD"
            ],
            "productsrc": [
                "/Home/ProductDetailPage/15",
                "/Home/ProductDetailPage/19"
            ],
            "pickset1": [
                "73%",
                "57%"
                
            ],
            "pickset2": [
                "66%",
                "37%"
            ]
        },
        {
            "view": "123_1200x.progressive.jpg",
            "product1photo": [
                "Rings/R_2_254969e1-1c77-4080-97c5-2c01f726250b_900x.jpg",
                "Rings/R19301_900x.jpg"
            ],
            "product2photo": [
                "Rings/R_5_1_900x.jpg",
                "Rings/R19303_900x.jpg"
            ],
            "product1nameprice": [
                "雙圈純銀戒指",
                "$1,800 TWD"
            ],
            "product2nameprice": [
                "五顆鋯石戒指",
                "$1,100 TWD"
            ],
            "productsrc": [
                "/Home/ProductDetailPage/6",
                "/Home/ProductDetailPage/20"
            ],
            "pickset1": [
                "40%",
                "66%"
            ],
            "pickset2": [
                "57%",
                "72%"
            ]
        },
        {
            "view": "IMG_1273_3_1200x.progressive.jpg",
            "product1photo": [
                "Necklaces/N_LOVE_G_1_900x.jpg",
                "Necklaces/N19303-1G_900x.png"
            ],
            "product1nameprice": [
                "LOVE字樣項鍊",
                "$2,600 TWD"
            ],
            "productsrc": [
                "/Home/ProductDetailPage/21"
            ],
            "pickset1": [
                "45%",
                "56%"
            ]
        }
    ]
}


$("#ShopTheLook__Dot1,#dottodot1").click(function () {
    if (Math.abs(i % 3) != 2) {
    $('#ShopTheLook__Dot2').removeClass('is--active');
    $('#ShopTheLook__Dot1').addClass('is--active');
    $('#dottodot2').removeClass('is-selected');
    $('#dottodot1').addClass('is-selected');



    $(".ProductItem__Image.Image--fadeIn.lazyautosizes.Image--lazyLoaded").attr("src", "/Assets/images/" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].product1photo[0]);
    $(".ProductItem__Image.ProductItem__Image--alternate.Image--fadeIn.lazyautosizes.Image--lazyLoaded").attr("src", "/Assets/images/" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].product1photo[1]);
    $(".ProductItem__Title.Heading a").text(ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].product1nameprice[0]);
    $(".ProductItem__Price.Price.Text--subdued span").text(ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].product1nameprice[1]);
    $(".ShopTheLook__ViewButton.Button.Button--primary.Button--full").attr("href", ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].productsrc[0]);

}
});

$("#ShopTheLook__Dot2,#dottodot2").click(function () {
    if (Math.abs(i % 3) != 2) {
        $('#ShopTheLook__Dot1').removeClass('is--active');
        $('#ShopTheLook__Dot2').addClass('is--active');
        $('#dottodot1').removeClass('is-selected');
        $('#dottodot2').addClass('is-selected');


        $(".ProductItem__Image.Image--fadeIn.lazyautosizes.Image--lazyLoaded").attr("src", "/Assets/images/" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].product2photo[0]);
        $(".ProductItem__Image.ProductItem__Image--alternate.Image--fadeIn.lazyautosizes.Image--lazyLoaded").attr("src", "/Assets/images/" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].product2photo[1]);
        $(".ProductItem__Title.Heading a").text(ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].product2nameprice[0]);
        $(".ProductItem__Price.Price.Text--subdued span").text(ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].product2nameprice[1]);
        $(".ShopTheLook__ViewButton.Button.Button--primary.Button--full").attr("href", ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].productsrc[1]);

    }
});


$(document).ready(function () {
    console.log(i);

    $(".ShopTheLook__ImageWrapper").css("background-image", "url('/Assets/images/otherphoto/" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].view + "')");
    $(".ProductItem__Image.Image--fadeIn.lazyautosizes.Image--lazyLoaded").attr("src", "/Assets/images/" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].product1photo[0]);
    $(".ProductItem__Image.ProductItem__Image--alternate.Image--fadeIn.lazyautosizes.Image--lazyLoaded").attr("src", "/Assets/images/" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].product1photo[1]);
    $(".ProductItem__Title.Heading a").text(ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].product1nameprice[0]);
    $(".ProductItem__Price.Price.Text--subdued span").text(ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].product1nameprice[1]);
    $(".ShopTheLook__ViewButton.Button.Button--primary.Button--full").attr("href", ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].productsrc[0]);
    
    $(".ShopTheLook__Dot.ShopTheLook__Dot--light").attr("style", "left:" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].pickset2[0] + ";" + "top:" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].pickset2[1] + ";");

    $(".ShopTheLook__Dot.ShopTheLook__Dot--light.is--active").attr("style", "left:" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].pickset1[0] + ";" + "top:" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].pickset1[1] + ";");

   
    $(".flickity-prev-next-button.previous").click(function () {
         i = i + 1;
        console.log(i);

        if (Math.abs(i % 3) == 2) {
            $(".ShopTheLook__Dot.ShopTheLook__Dot--light").css("display", "none");
            $(".ShopTheLook__Dot.ShopTheLook__Dot--light.is--active").css("display", "inline-block");
            $(".dottodot").css("display", "none");
            $(".dottodot.is-selected").css("display", "inline-block");


        } else {
            $(".ShopTheLook__Dot.ShopTheLook__Dot--light").css("display", "inline-block");

            $(".dottodot").css("display", "inline-block");
        }


        $(".ShopTheLook__ImageWrapper").fadeOut( function () {


            $(".ShopTheLook__ImageWrapper").css("background-image", "url('/Assets/images/otherphoto/" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].view + "')");
            $(".ProductItem__Image.Image--fadeIn.lazyautosizes.Image--lazyLoaded").attr("src", "/Assets/images/" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].product1photo[0]);
            $(".ProductItem__Image.ProductItem__Image--alternate.Image--fadeIn.lazyautosizes.Image--lazyLoaded").attr("src", "/Assets/images/" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].product1photo[1]);
            $(".ProductItem__Title.Heading a").text(ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].product1nameprice[0]);
            $(".ProductItem__Price.Price.Text--subdued span").text(ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].product1nameprice[1]);
            $(".ShopTheLook__ViewButton.Button.Button--primary.Button--full").attr("href", ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].productsrc[0]);

            if (Math.abs(i % 3) != 2) {
                $(".ShopTheLook__Dot.ShopTheLook__Dot--light").attr("style", "left:" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].pickset2[0] + ";" + "top:" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].pickset2[1] + ";");
            }
            $(".ShopTheLook__Dot.ShopTheLook__Dot--light.is--active").attr("style", "left:" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].pickset1[0] + ";" + "top:" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].pickset1[1] + ";");



        });

        $(".ShopTheLook__ImageWrapper").fadeIn("slow", function () {


            $(".ShopTheLook__ImageWrapper").css("background-image", "url('/Assets/images/otherphoto/" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].view + "')");
            $(".ProductItem__Image.Image--fadeIn.lazyautosizes.Image--lazyLoaded").attr("src", "/Assets/images/" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].product1photo[0]);
            $(".ProductItem__Image.ProductItem__Image--alternate.Image--fadeIn.lazyautosizes.Image--lazyLoaded").attr("src", "/Assets/images/" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].product1photo[1]);
            $(".ProductItem__Title.Heading a").text(ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].product1nameprice[0]);
            $(".ProductItem__Price.Price.Text--subdued span").text(ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].product1nameprice[1]);
            $(".ShopTheLook__ViewButton.Button.Button--primary.Button--full").attr("href", ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].productsrc[0]);

            if (Math.abs(i % 3) != 2) {
                $(".ShopTheLook__Dot.ShopTheLook__Dot--light").attr("style", "left:" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].pickset2[0] + ";" + "top:" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].pickset2[1] + ";");
            }
            $(".ShopTheLook__Dot.ShopTheLook__Dot--light.is--active").attr("style", "left:" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].pickset1[0] + ";" + "top:" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].pickset1[1] + ";");



        });
      
     });
     $(".flickity-prev-next-button.next").click(function () {
         i = i - 1;
         console.log(i);

         if (Math.abs(i % 3)== 2) {
             $(".ShopTheLook__Dot.ShopTheLook__Dot--light").css("display", "none");
             $(".ShopTheLook__Dot.ShopTheLook__Dot--light.is--active").css("display", "inline-block");
             $(".dottodot").css("display", "none");
             $(".dottodot.is-selected").css("display", "inline-block");


         } else {
             $(".ShopTheLook__Dot.ShopTheLook__Dot--light").css("display", "inline-block");

             $(".dottodot").css("display", "inline-block");
         }


         $(".ShopTheLook__ImageWrapper").fadeOut(function () {


             $(".ShopTheLook__ImageWrapper").css("background-image", "url('/Assets/images/otherphoto/" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].view + "')");
             $(".ProductItem__Image.Image--fadeIn.lazyautosizes.Image--lazyLoaded").attr("src", "/Assets/images/" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].product1photo[0]);
             $(".ProductItem__Image.ProductItem__Image--alternate.Image--fadeIn.lazyautosizes.Image--lazyLoaded").attr("src", "/Assets/images/" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].product1photo[1]);
             $(".ProductItem__Title.Heading a").text(ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].product1nameprice[0]);
             $(".ProductItem__Price.Price.Text--subdued span").text(ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].product1nameprice[1]);
             $(".ShopTheLook__ViewButton.Button.Button--primary.Button--full").attr("href", ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].productsrc[0]);

             if (Math.abs(i % 3) != 2) {
                 $(".ShopTheLook__Dot.ShopTheLook__Dot--light").attr("style", "left:" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].pickset2[0] + ";" + "top:" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].pickset2[1] + ";");
             }
             $(".ShopTheLook__Dot.ShopTheLook__Dot--light.is--active").attr("style", "left:" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].pickset1[0] + ";" + "top:" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].pickset1[1] + ";");



         });

         $(".ShopTheLook__ImageWrapper").fadeIn("slow", function () {


             $(".ShopTheLook__ImageWrapper").css("background-image", "url('/Assets/images/otherphoto/" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].view + "')");
             $(".ProductItem__Image.Image--fadeIn.lazyautosizes.Image--lazyLoaded").attr("src", "/Assets/images/" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].product1photo[0]);
             $(".ProductItem__Image.ProductItem__Image--alternate.Image--fadeIn.lazyautosizes.Image--lazyLoaded").attr("src", "/Assets/images/" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].product1photo[1]);
             $(".ProductItem__Title.Heading a").text(ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].product1nameprice[0]);
             $(".ProductItem__Price.Price.Text--subdued span").text(ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].product1nameprice[1]);
             $(".ShopTheLook__ViewButton.Button.Button--primary.Button--full").attr("href", ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].productsrc[0]);

             if (Math.abs(i % 3) != 2) {
                 $(".ShopTheLook__Dot.ShopTheLook__Dot--light").attr("style", "left:" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].pickset2[0] + ";" + "top:" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].pickset2[1] + ";");
             }
             $(".ShopTheLook__Dot.ShopTheLook__Dot--light.is--active").attr("style", "left:" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].pickset1[0] + ";" + "top:" + ShopTheLook__ProductList.ShopTheLook_P[Math.abs(i % 3)].pickset1[1] + ";");



         });
     });
 });


