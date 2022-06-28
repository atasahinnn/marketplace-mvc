// Dropdown ani kapanma çözümü
$('.nav-link').hover(function() {
  $(this).closest('.nav-item.dropdown').siblings('.nav-item.dropdown').removeClass('show').find('.dropdown-menu').removeClass('show');
})


// MEGA MENÜ TRIGGER
var navigation = new Navigation(document.getElementById("navigation"));

// SATICI SAYFALARI NAVIGASYON
var navigation = new Navigation(document.getElementById("satici-navigation"));

// ANA SAYFA SLIDER TRIGGERLAR
$('.slider-1').slick({
    slidesToShow: 1,
    slidesToScroll: 1,
    arrows: false,
    fade: true,
    asNavFor: '.slider-nav-1',
    autoplay: true,
    infinite: true
});
$('.slider-nav-1').slick({
    slidesToScroll: 1,
    infinite:true,
    //slidesToShow:4,
    focusOnSelect: true,
    variableWidth: true,
    autoplay: true,
    //autoplaySpeed: 1000,
    asNavFor: '.slider-1',
});

$('.slider-2').slick({
    slidesToShow: 1,
    slidesToScroll: 1,
    arrows: false,
    fade: true,
    asNavFor: '.slider-nav-2',
    autoplay: true,
    infinite: true
});
$('.slider-nav-2').slick({
    arrows: true,
    asNavFor: '.slider-2',
    centerMode: false,
    centerPadding: '20px',
    dots: false,
    focusOnSelect: true,
    slidesToShow: 5,
    infinite: true
});

$('.slider-3').slick({
    slidesToShow: 1,
    slidesToScroll: 1,
    arrows: false,
    fade: true,
    asNavFor: '.slider-nav-3',
    autoplay: true,
    infinite: true
});
$('.slider-nav-3').slick({
    arrows: true,
    asNavFor: '.slider-3',
    centerMode: false,
    centerPadding: '20px',
    dots: false,
    focusOnSelect: true,
    slidesToShow: 5,
    infinite: true
});

$('.slider-4').slick({
    slidesToShow: 1,
    slidesToScroll: 1,
    arrows: false,
    fade: true,
    asNavFor: '.slider-nav-4',
    autoplay: true,
    infinite: true
});
$('.slider-nav-4').slick({
    arrows: true,
    asNavFor: '.slider-4',
    centerMode: false,
    centerPadding: '20px',
    dots: false,
    focusOnSelect: true,
    slidesToShow: 5,
    infinite: true
});

$('.slider-5').slick({
    slidesToShow: 1,
    slidesToScroll: 1,
    arrows: false,
    fade: true,
    asNavFor: '.slider-nav-5',
    autoplay: true,
    infinite: true
});
$('.slider-nav-5').slick({
    arrows: true,
    asNavFor: '.slider-5',
    centerMode: false,
    centerPadding: '20px',
    dots: false,
    focusOnSelect: true,
    slidesToShow: 5,
    infinite: true
});

// INFLUENCER SLIDER
$('.influencer-card-slider').slick({
    slidesToShow: 2,
    slidesToScroll: 1,
    arrows: true,
    fade: false,
    autoplay: false,
    infinite: true,
    dots: false,
    prevArrow:"<ion-icon name='arrow-back-circle' class='slider-arrow sol'></ion-icon>",
    nextArrow:"<ion-icon name='arrow-forward-circle' class='slider-arrow sag'></ion-icon>",

    responsive: [
    {
      breakpoint: 1024,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1,
        infinite: true,
        dots: false
      }
    },
    {
      breakpoint: 768,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: false,
        dots: false,
      }
    },
    {
      breakpoint: 575,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: false,
        dots: false,
      }
    }
  ]
});
$('.influencer2-card-slider').slick({
    slidesToShow: 4,
    slidesToScroll: 1,
    arrows: true,
    fade: false,
    autoplay: false,
    infinite: true,
    dots: false,
    prevArrow:"<ion-icon name='arrow-back-circle' class='slider-arrow sol'></ion-icon>",
    nextArrow:"<ion-icon name='arrow-forward-circle' class='slider-arrow sag'></ion-icon>",

    responsive: [
    {
      breakpoint: 1024,
      settings: {
        slidesToShow: 2,
        slidesToScroll: 1,
        infinite: true,
        dots: false
      }
    },
    {
      breakpoint: 768,
      settings: {
        slidesToShow: 2,
        slidesToScroll: 1,
        arrows: false,
        dots: false,
      }
    },
    {
      breakpoint: 575,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: false,
        dots: false,
      }
    }
  ]
});

$('.urun-thumbnail-slider').slick({
    slidesToShow: 5,
    slidesToScroll: 1,
    arrows: true,
    fade: false,
    autoplay: false,
    infinite: true,
    dots: false,
    prevArrow:"<ion-icon name='arrow-back-circle' class='slider-arrow sol'></ion-icon>",
    nextArrow:"<ion-icon name='arrow-forward-circle' class='slider-arrow sag'></ion-icon>",

    responsive: [
    {
      breakpoint: 1024,
      settings: {
        slidesToShow: 3,
        slidesToScroll: 3,
        infinite: true,
        dots: false
      }
    },
    {
      breakpoint: 768,
      settings: {
        slidesToShow: 2,
        slidesToScroll: 2,
        arrows: false,
        dots: false,
      }
    },
    {
      breakpoint: 575,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: false,
        dots: false,
      }
    }
  ]
});

$('.neden-biz-slider').slick({
    slidesToShow: 8,
    slidesToScroll: 1,
    arrows: true,
    fade: false,
    autoplay: false,
    infinite: true,
    dots: false,
    prevArrow:"<ion-icon name='arrow-back-circle' class='slider-arrow sol'></ion-icon>",
    nextArrow:"<ion-icon name='arrow-forward-circle' class='slider-arrow sag'></ion-icon>",

    responsive: [
    {
      breakpoint: 1024,
      settings: {
        slidesToShow: 5,
        slidesToScroll: 1,
        infinite: true,
        dots: false
      }
    },
    {
      breakpoint: 768,
      settings: {
        slidesToShow: 4,
        slidesToScroll: 1,
        arrows: false,
        dots: false,
      }
    },
    {
      breakpoint: 575,
      settings: {
        slidesToShow: 3,
        slidesToScroll: 1,
        arrows: false,
        dots: false,
      }
    }
  ]
});

// MOBIL SLIDER

$('.mobil-hero-slider').slick({
    slidesToShow: 1,
    slidesToScroll: 1,
    arrows: false,
    fade: false,
    autoplay: true,
    infinite: true,
    dots: true

});

// Ürün Listeleme Hero Slider
$('.urun-listeleme-hero-slider').slick({
    slidesToShow: 1,
    slidesToScroll: 1,
    arrows: true,
    fade: false,
    autoplay: true,
    infinite: true,
    dots: false,
    prevArrow:"<ion-icon name='arrow-back-circle' class='slider-arrow sol'></ion-icon>",
    nextArrow:"<ion-icon name='arrow-forward-circle' class='slider-arrow sag'></ion-icon>",

    responsive: [
    {
      breakpoint: 1024,
      settings: {
        arrows: false
      }
    }
  ]

});
$('.gunun-firsatlari-slider').slick({
    slidesToShow: 1,
    slidesToScroll: 1,
    arrows: true,
    fade: false,
    autoplay: false,
    infinite: true,
    dots: false,
    prevArrow:"<i class='fas fa-chevron-left slider-arrow sol'></i>",
    nextArrow:"<i class='fas fa-chevron-right slider-arrow sag'></i>",

    responsive: [
    {
      breakpoint: 1024,
      settings: {
        arrows: false
      }
    }
  ]

});
$('.logo-slider').slick({
    slidesToShow: 5,
    slidesToScroll: 1,
    arrows: true,
    fade: false,
    centerMode: true,
    autoplay: false,
    infinite: true,
    dots: false,
    prevArrow:"<i class='fas fa-chevron-left logo-slider-arrow sol'></i>",
    nextArrow:"<i class='fas fa-chevron-right logo-slider-arrow sag'></i>",
    responsive: [
    {
      breakpoint: 1024,
      settings: {
        slidesToShow: 3,
        slidesToScroll: 1,
        infinite: true,
        arrows: false,
        dots: false
      }
    },
    {
      breakpoint: 768,
      settings: {
        slidesToShow: 2,
        slidesToScroll: 1,
        arrows: false,
        dots: false,
      }
    }
  ]
});

$('.urun-detay-slider').slick({
    slidesToShow: 1,
    slidesToScroll: 1,
    arrows: true,
    dots: false,
    fade: true,
    asNavFor: '.urun-detay-slider-nav',
    autoplay: false,
    infinite: false,
    prevArrow:"<i class='fas fa-arrow-left slider-arrows arrow-inside arrow-type-1'></i>",
    nextArrow:"<i class='fas fa-arrow-right slider-arrows arrow-inside arrow-type-1'></i>",
});
$('.urun-detay-slider-nav').slick({
    // centerMode: true,
    // centerPadding: '60px',
    slidesToShow: 5,
    //autoplaySpeed: 1000,
    asNavFor: '.urun-detay-slider',
    arrows: true,
    dots: false,
    infinite: false,
    focusOnSelect: true,
    prevArrow:"<i class='fas fa-chevron-left slider-arrows arrow-outside'></i>",
    nextArrow:"<i class='fas fa-chevron-right slider-arrows arrow-outside'></i>",
});


	// Mobil Kategori Navigation
	var navigation = new Navigation(document.getElementById("navigation"),{
		autoSubmenuIndicator: false
	});	
	
	var navigation_hidden = new Navigation(document.getElementById("navigation-hidden"),{
		autoSubmenuIndicator: false,
		breakpoint: 999999
	});
	if($("#btn-show").length > 0){
		document.getElementById("btn-show").addEventListener("click", navigation_hidden.toggleOffcanvas);
	}
	
	
	var navigation_animated = new Navigation(document.getElementById("navigation-animated"),{
		autoSubmenuIndicator: false
	});
	if(document.getElementById("navigation-animated")){
		window.onscroll = function setScrollAnimation(){
			var scrollPosY = window.pageYOffset | document.body.scrollTop;
			if(scrollPosY > 50){
				navigation_animated.classList.add("navigation-animated");
			}
			else{
				navigation_animated.classList.remove("navigation-animated");
			}
		}
	}


// Mobil Footer Akordiyon Menü

var acc = document.getElementsByClassName("accordion");
var i;

for (i = 0; i < acc.length; i++) {
  acc[i].addEventListener("click", function () {
    this.classList.toggle("active");
    var panel = this.nextElementSibling;
    if (panel.style.maxHeight) {
      panel.style.maxHeight = null;
    } else {
      panel.style.maxHeight = panel.scrollHeight + "px";
    }
  });
}

// Sidebar Custom Scrollbar
Scrollbar.initAll();



