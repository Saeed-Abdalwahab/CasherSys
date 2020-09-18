

    $(document).ready(function () {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "positionClass": "toast-top-right",
            "onclick": null,
            "showDuration": ".2",
            "hideDuration": "1000",
            "timeOut": "1000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }

        $(".LogoutBtn").click(function () {
            $("#LogoutForm").submit();
        });

        var pageURL = $(location).attr("href");
        $.each($(".page-sidebar-menu a"), function (Inded, Elm) {

            var Href = $(this).attr("href");
            if (pageURL.indexOf(Href) >= 0) {
                $(this).parents("li").addClass("active open");
                return false;
        }
        })
    })
