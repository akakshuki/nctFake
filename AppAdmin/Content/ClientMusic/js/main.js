(function ($) {
	"use strict";
	//Search	
	$('#valueSearch').keyup(function () {
		if ($('#valueSearch').val() == "") {
			$('#viewSearch').hide();
		} else {
			var value = $(this).val();
			//search music
			$.ajax({
				url: "/Client/Home/SearchMusicByKey",
				type: 'GET',
				dataType: 'json',
				data: {
					name: value
				}, success: function (response) {

					var ls = response.data;
                    $('#viewSong').html("");
                    ls.forEach(function (i) {
						var row = '<div class="itemSongRandom">\n' +
                            '<div>\n' +
							'<a href="/Client/PlayMusic?id=' + i.ID + '"><img src="' + i.LinkImage + '">' + i.MusicName + '</a><br>' +
                            '<span>\n';
						i.SingerMusicDtOs.forEach(function (s) {
							if (s.index + 1 === i.SingerMusicDtOs.length ) {
                                row += '<a href=""> ' + s.UserDto.UserName + '</a>';
                            } else {
								row += '<a href=""> ' + s.UserDto.UserName + ',</a>';
                            }
                        });

                        row += '\n</span>' +
                            '</div>\n' +
                            '</div>';
                        $('#viewSong').append(row);
                    });

     //               var data = response.data;
					//var html = '';
                  
					//var template = $('#data-music-template').html();
					//$.each(data,
					//	function (i, item) {
					//		html += Mustache.render(template,
					//			{
					//				id: item.ID,
     //                               musicName: item.MusicName,
					//				linkFile: item.LinkImage
     //                           });
					//	});
     //              $('#viewSong').html(html);
				}
			});
			//search music
            $.ajax({
                url: "/Client/Home/SearchVideoByKey",
                type: 'GET',
                dataType: 'json',
                data: {
                    name: value
                },
                success: function(response) {
                    var data = response.data;
                    var html = '';

                    var template = $('#data-video-template').html();
                    $.each(data,
                        function(i, item) {
                            html += Mustache.render(template,
                                {
                                    id: item.ID,
                                    musicName: item.MusicName,
                                    linkFile: item.LinkImage,
                                    userName:item.UserDto.UserName
								});
                         

                        });
                    $('#viewMV').html(html);
                }
            });
			//search singer
            $.ajax({
				url: "/Client/Home/SearchSingerByKey",
                type: 'GET',
                dataType: 'json',
                data: {
                    name: value
                }, success: function (response) {
                    var data = response.data;
                    var html = '';
                    console.log(data);
                    var template = $('#data-singer-template').html();
                    $.each(data,
                        function (i, item) {
                            html += Mustache.render(template,
                                {
                                    id: item.ID,
                                    userName: item.UserName,
									linkFile: item.UserImage
                                });
                        });
                    $('#singerTemplate').html(html);
                }
            });

			$('#viewSearch').show();
		}

	});


  
  //Search	
	$(".chosen")[0] && $(".chosen").chosen({
		width: "100%",
		allow_single_deselect: !0
	});
	/*--------------------------
	 auto-size Active Class
	---------------------------- */
	$(".auto-size")[0] && autosize($(".auto-size"));
	/*--------------------------
	 Collapse Accordion Active Class
	---------------------------- */
	$(".collapse")[0] && ($(".collapse").on("show.bs.collapse", function (e) {
		$(this).closest(".panel").find(".panel-heading").addClass("active")
	}), $(".collapse").on("hide.bs.collapse", function (e) {
		$(this).closest(".panel").find(".panel-heading").removeClass("active")
	}), $(".collapse.in").each(function () {
		$(this).closest(".panel").find(".panel-heading").addClass("active")
	}));
	/*----------------------------
	 jQuery tooltip
	------------------------------ */
	$('[data-toggle="tooltip"]').tooltip();
	/*--------------------------
	 popover
	---------------------------- */
	$('[data-toggle="popover"]')[0] && $('[data-toggle="popover"]').popover();
	/*--------------------------
	 File Download
	---------------------------- */
	$('.btn.dw-al-ft').on('click', function (e) {
		e.preventDefault();
	});
	/*--------------------------
	 Sidebar Left
	---------------------------- */
	$('#sidebarCollapse').on('click', function () {
		$('#sidebar').toggleClass('active');

	});
	$('#sidebarCollapse').on('click', function () {
		$("body").toggleClass("mini-navbar");
		SmoothlyMenu();
	});
	$('.menu-switcher-pro').on('click', function () {
		var button = $(this).find('i.nk-indicator');
		button.toggleClass('notika-menu-befores').toggleClass('notika-menu-after');

	});
	$('.menu-switcher-pro.fullscreenbtn').on('click', function () {
		var button = $(this).find('i.nk-indicator');
		button.toggleClass('notika-back').toggleClass('notika-next-pro');
	});

	$('ul.nav li.dropdown').hover(function () {
		$(this).find('.dropdown-menu').stop(true, true).delay(200).fadeIn(500);
	}, function () {
		$(this).find('.dropdown-menu').stop(true, true).delay(200).fadeOut(500);
	});


	/*--------------------------
	 Button BTN Left
	---------------------------- */

	$(".nk-int-st")[0] && ($("body").on("focus", ".nk-int-st .form-control", function () {
		$(this).closest(".nk-int-st").addClass("nk-toggled")
	}), $("body").on("blur", ".form-control", function () {
		var p = $(this).closest(".form-group, .input-group"),
			i = p.find(".form-control").val();
		p.hasClass("fg-float") ? 0 == i.length && $(this).closest(".nk-int-st").removeClass("nk-toggled") : $(this).closest(".nk-int-st").removeClass("nk-toggled")
	})), $(".fg-float")[0] && $(".fg-float .form-control").each(function () {
		var i = $(this).val();
		0 == !i.length && $(this).closest(".nk-int-st").addClass("nk-toggled")
	});
	/*--------------------------
	 mCustomScrollbar
	---------------------------- */
	$(window).on("load", function () {
		$(".widgets-chat-scrollbar").mCustomScrollbar({
			setHeight: 460,
			autoHideScrollbar: true,
			scrollbarPosition: "outside",
			theme: "light-1"
		});
		$(".notika-todo-scrollbar").mCustomScrollbar({
			setHeight: 445,
			autoHideScrollbar: true,
			scrollbarPosition: "outside",
			theme: "light-1"
		});
		$(".comment-scrollbar").mCustomScrollbar({
			autoHideScrollbar: true,
			scrollbarPosition: "outside",
			theme: "light-1"
		});
	});
	/*----------------------------
	 jQuery MeanMenu
	------------------------------ */
	jQuery('nav#dropdown').meanmenu();

	/*----------------------------
	 wow js active
	------------------------------ */
	new WOW().init();

	/*----------------------------
	 owl active
	------------------------------ */
	$("#owl-demo").owlCarousel({
		autoPlay: false,
		slideSpeed: 2000,
		pagination: false,
		navigation: true,
		items: 4,
		/* transitionStyle : "fade", */    /* [This code for animation ] */
		navigationText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
		itemsDesktop: [1199, 4],
		itemsDesktopSmall: [980, 3],
		itemsTablet: [768, 2],
		itemsMobile: [479, 1],
	});

	/*----------------------------
	 price-slider active
	------------------------------ */
	$("#slider-range").slider({
		range: true,
		min: 40,
		max: 600,
		values: [60, 570],
		slide: function (event, ui) {
			$("#amount").val("£" + ui.values[0] + " - £" + ui.values[1]);
		}
	});
	$("#amount").val("£" + $("#slider-range").slider("values", 0) +
		" - £" + $("#slider-range").slider("values", 1));

	/*--------------------------
	 scrollUp
	---------------------------- */
	$.scrollUp({
		scrollText: '<i class="fa fa-angle-up"></i>',
		easingType: 'linear',
		scrollSpeed: 900,
		animation: 'fade'
	});



})(jQuery);

