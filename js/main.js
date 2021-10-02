$(function (){

    $(window).scroll(function (){
        $('#know-title').each(function (){
            const imagePos = $(this).offset().top;
            const topOfWindow = $(window).scrollTop()
            if (imagePos < topOfWindow + 1500){
                $(this).addClass('animate__fadeInLeft visible_vis animate__fast')
            }
        })
    })

    $(window).scroll(function (){
        $('.skill-img').each(function (){
            const imagePos = $(this).offset().top;
            const topOfWindow = $(window).scrollTop()
            if (imagePos < topOfWindow + 800){
                $(this).addClass('animate__fadeInDown visible_vis animate__slow')
            }
        })
    })

    $(window).scroll(function (){
        $('.title-3').each(function (){
            const imagePos = $(this).offset().top;
            const topOfWindow = $(window).scrollTop()
            if (imagePos < topOfWindow + 800){
                $(this).addClass('animate__fadeIn visible_vis animate__slow')
            }
        })
    })

    $(window).scroll(function (){
        $('.skill-inf').each(function (){
            const imagePos = $(this).offset().top;
            const topOfWindow = $(window).scrollTop()
            if (imagePos < topOfWindow + 800){
                $(this).addClass('animate__fadeInUp visible_vis animate__slow')
            }
        })
    })

    $(window).scroll(function (){
        $('#order-title').each(function (){
            const imagePos = $(this).offset().top;
            const topOfWindow = $(window).scrollTop()
            if (imagePos < topOfWindow + 1500){
                $(this).addClass('animate__fadeInDown visible_vis animate__fast')
            }
        })
    })

    $(window).scroll(function (){
        $('.in_r').each(function (){
            const imagePos = $(this).offset().top;
            const topOfWindow = $(window).scrollTop()
            if (imagePos < topOfWindow + 800){
                $(this).addClass('animate__fadeInRight visible_vis animate__fast')
            }
        })
    })

    $(window).scroll(function (){
        $('.in_l').each(function (){
            const imagePos = $(this).offset().top;
            const topOfWindow = $(window).scrollTop()
            if (imagePos < topOfWindow + 800){
                $(this).addClass('animate__fadeInLeft visible_vis animate__fast')
            }
        })
    })
    $(window).scroll(function (){
        $('.btn-order').each(function (){
            const imagePos = $(this).offset().top;
            const topOfWindow = $(window).scrollTop()
            if (imagePos < topOfWindow + 800){
                $(this).addClass('animate__fadeInUp visible_vis animate__slow')
            }
        })
    })
    $.fn.serializeObject = function()
    {
        var o = {};
        var a = this.serializeArray();
        $.each(a, function() {
            if (o[this.name] !== undefined) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return o;
    };

    $(function() {
        $('form').submit(function() {
            $('#result').text(JSON.stringify($('form').serializeObject()));
            let result = JSON.stringify($('form').serializeObject());
            console.log(result);

            $.ajax
            ({
                type: "POST",
                //the url where you want to sent the userName and password to
                url: 'https://kdhackapi20211002024226.azurewebsites.net/api/dogs/',
                dataType: 'json',
                async: true,
                //json object to sent to the authentication url
                data: result,
                success: function () {

                    alert("Thanks!");
                }
            })

            return false;
        });
    });
})
