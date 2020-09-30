$(document).ready(function () {
    $(".from-station-card > div > a").click(function () {
        $('.to-station-input').hide();
        $('.to-station-card').hide();
        $('.from-station-card').hide();
        $('.from-station-input').show();
        $(".bytt").hide();
        $(".retning").hide();
    });

    $('body').on('click', '#fraStasjonListe ul li', function () {
        $(".from-station-card .station-subtitle").html($(this).html());
        $("#fraStasjon").val($(this).html());
        $('.to-station-input').show();
        $('.from-station-card').show();
        $('.from-station-input').hide();
        $("#fraStasjonListe").html("");
    });
    $(".from-station-input > input").click(function () {
        var liste = "";
        liste += "<ul>";
        liste += "<li>Oslo Bussterminal</li>";
        liste += "<li>Nationalteateret</li>";
        liste += "<li>Lysaker</li>";
        liste += "<li>Asker</li>";
        liste += "</ul>";
        $("#fraStasjonListe").html(liste);
    });
    $(".to-station-card > div > a").click(function () {
        $('.to-station-card').hide();
        $('.to-station-input').show();
        $(".bytt").hide();
        $(".retning").hide();
    });
    $('body').on('click', '#tilStasjonListe ul li', function () {
        $(".to-station-card .station-subtitle").html($(this).html());
        $("#tilStasjon").val($(this).html());
        $('.to-station-card').show();
        $('.to-station-input').hide();
        $("#tilStasjonListe").html("");
        $(".bytt").show();
        $(".retning").show();
    });
    $(".to-station-input > input").click(function () {
        var liste = "";
        liste += "<ul>";
        liste += "<li>Oslo Bussterminal</li>";
        liste += "<li>Nationalteateret</li>";
        liste += "<li>Lysaker</li>";
        liste += "<li>Asker</li>";
        liste += "</ul>";
        $("#tilStasjonListe").html(liste);
    });
    $(".bytt").click(function () {
        //$(".bytt").hide();
        var husk = $(".from-station-card .station-subtitle").html();
        $(".from-station-card .station-subtitle").html($(".to-station-card .station-subtitle").html());
        $(".to-station-card .station-subtitle").html(husk);
        $("#tilStasjon").val(husk);
        $("#fraStasjon").val($(".from-station-card .station-subtitle").html());
    });

    //henter liste over stasjoner når man begynner å skrive på fra-stasjon feltet
    $("#fraStasjon").on('keyup', function () {
        var id = $(this).val();
        $("#frastasjonliste").html(id);
        $.ajax({
            url: '/Home/hentAlleStasjoner/?sok=' + id,
            type: 'GET',
            dataType: 'text',
            success: function (stasjoner) {
                $("#frastasjonliste").html(stasjoner);
                $("#tilstasjonliste").html("");
            },
            error: function (x, y, z) {
                alert(x + '\n' + y + '\n' + z);
            }
        });
    });
});