/*

TemplateMo 559 Zay Shop

https://templatemo.com/tm-559-zay-shop

*/

'use strict';
$(document).ready(function() {

    // Accordion
    var all_panels = $('.templatemo-accordion > li > ul').hide();

    $('.templatemo-accordion > li > a').click(function() {
        console.log('Hello world!');
        var target =  $(this).next();
        if(!target.hasClass('active')){
            all_panels.removeClass('active').slideUp();
            target.addClass('active').slideDown();
        }
      return false;
    });
    // End accordion

    // Product detail
    $('.product-links-wap a').click(function(){
      var this_src = $(this).children('img').attr('src');
      $('#product-detail').attr('src',this_src);
      return false;
    });
    $('#btn-minus').click(function(){
      var val = $("#var-value").html();
      val = (val=='1')?val:val-1;
      $("#var-value").html(val);
      $("#product-quanity").val(val);
      return false;
    });
    $('#btn-plus').click(function(){
      var val = $("#var-value").html();
      val++;
      $("#var-value").html(val);
      $("#product-quanity").val(val);
      return false;
    });
    $('.btn-size').click(function(){
      var this_val = $(this).html();
      $("#product-size").val(this_val);
      $(".btn-size").removeClass('btn-secondary');
      $(".btn-size").addClass('btn-success');
      $(this).removeClass('btn-success');
      $(this).addClass('btn-secondary');
      return false;
    });
    // End roduct detail
    getCartCounter();

    if ($(".siparis").text() !== "") {
        Swal.fire(
            'Tebrikler!',
            $(".siparis").text(),
            'success'
        );
    }

});




    var isRequesting = false;

    function showProductsByCategory(categoryID) {
        if (!isRequesting) {
        isRequesting = true;
    $.ajax({
        url: '/Shop/GetProductsByCategory', 
    type: 'GET',
    data: {categoryID: categoryID },
    success: function (data) {
        $("#products-by-category").html(data);
                },
    error: function () {
        alert('Ürünler yüklenirken bir hata oluştu.');
                },
    complete: function () {
        isRequesting = false;
                }
            });
        }
    }




function addCart(productid, stock) {
    var istenenmiktar = parseInt($(".inputQuantity").val());
    if (istenenmiktar <= stock) {
        $.ajax({
            url: "/sepetim/ekle",
            type: "POST",
            data: { productid: productid, quantity: istenenmiktar },
            success: function (data) {
                if (data != "") {
                    Swal.fire({
                        icon: 'success',
                        title: 'Başarılı!',
                        text: 'Ürün sepete eklendi.'
                    });

                    getCartCounter();
                }
            },
           
        });
    }
    else {
        $(".inputQuantity").val(stock);
        Swal.fire({
            icon: 'error',
            title: 'Hata!',
            text: 'İstenen miktar stoktan fazla...',
           
        });
        return false; 
    }

    return false; 
}




function getCartCounter() {

    $.ajax({
        url: "/sepetim/sayiver",
        type: "GET",       
        success: function (data) {
            $(".cartCounter").text(data);
        }
    }); 
}




function removeCart(productid) {
    $.ajax({
        url: "/sepetim/sil",
        type: "POST",
        data: { productid: productid },
        success: function (data) {
            if (data === "OK") {
                location.reload(); 
            } else {
                location.href = "/sepetim";
            }
        }
    });
}
 