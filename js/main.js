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
})
