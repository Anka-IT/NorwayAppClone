$(document).ready(function () {

    //For å endre fra stasjon. Denne gjemmer de kommende delene i formen
    $(".from-station-card > div > a").click(function () {
        $('.to-station-input').hide();
        $('.to-station-card').hide();
        $('.from-station-card').hide();
        $('.from-station-input').show();
        $(".bytt").hide();
        $(".retning").hide();
        $("#datepickerTur").hide();
        $("#datepickerRetur").hide();
        $(".seAvganger").hide();
    });

    //Velger en gyldig stasjon fra listen hentet fra DB 
    $('body').on('click', '#fraStasjonListe ul li', function () {
        $(".from-station-card .station-subtitle").html($(this).html());
        $("#fraStasjon").val($(this).html());
        $('.to-station-input').show();
        $('.from-station-card').show();
        $('.from-station-input').hide();
        $("#fraStasjonListe").html("");
    });

    //For å endre til stasjon. Denne gjemmer de kommende delene i formen
    $(".to-station-card > div > a").click(function () {
        $('.to-station-card').hide();
        $('.to-station-input').show();
        $(".bytt").hide();
        $(".retning").hide();
        $("#datepickerTur").hide();
        $("#datepickerRetur").hide();
        $(".seAvganger").hide();
    });
    //Velger en gyldig stasjon fra listen hentet fra DB 
    $('body').on('click', '#tilStasjonListe ul li', function () {
        $(".to-station-card .station-subtitle").html($(this).html());
        $("#tilStasjon").val($(this).html());
        $('.to-station-card').show();
        $('.to-station-input').hide();
        $("#tilStasjonListe").html("");
        $(".bytt").show();
        $(".retning").show();
        $("#datepickerTur").show();
    });

    //Bytter om fra og til stasjon
    $(".bytt").click(function () {
        var husk = $(".from-station-card .station-subtitle").html();
        $(".from-station-card .station-subtitle").html($(".to-station-card .station-subtitle").html());
        $(".to-station-card .station-subtitle").html(husk);
        $("#tilStasjon").val(husk);
        $("#fraStasjon").val($(".from-station-card .station-subtitle").html());
    });

    //henter liste over stasjoner når man skriver minst to tegn på fra-stasjon feltet
    $("#fraStasjon").on('keyup', function () {
        let sok = $(this).val();
        if (sok.length > 1) hentStasjoner(sok,"#fraStasjonListe");
        else $("#fraStasjonListe").html("");
    });
    //henter liste over stasjoner når man skriver minst to tegn på til-stasjon feltet
    $("#tilStasjon").on('keyup', function () {
        let sok= $(this).val();
        if (sok.length > 1) hentStasjoner(sok,"#tilStasjonListe");
        $("#tilStasjonListe").html("");
    });

    //Henter lister over stasjoner basert på søkeord
    function hentStasjoner(sok,id) {
        const url = "Reise/FinnStasjoner?sok=" + sok;
        $.get(url, function (stasjoner) {
            formaterStasjoner(stasjoner,id);
        });
    }

    //Formaterer stasjonlisten fra DB
    function formaterStasjoner(stasjoner,id) {
        let liste = "<ul>";
        for (let stasjon of stasjoner) {
            liste += "<li>" + stasjon.stasjonsNavn+"</li>";
        }
        liste += "</ul>";

        $(id).html(liste);
    }

    //Javascript for datepicker på forsiden basert på kode fra https://www.w3schools.com/code/tryit.asp?filename=FTUTR9BYRNI0
    $("#datepickerTur").datepicker({ dateFormat: 'yy-mm-dd', minDate: 0, maxDate: "+1M +15D" });
    $("#datepickerRetur").datepicker({ dateFormat: 'yy-mm-dd', minDate: 0, maxDate: "+1M +15D" });

    //Gjør to datovelgere synlig ved valg av tur retur
    $("[name='retning']").on("change", function () {
        if ($("#turRetur").is(":checked")) {
            $("#datepickerRetur").show();
            if ($("#datepickerRetur").val() == "") {
                $(".velgReisende").hide();
                $(".seAvganger").hide();
            }
        } else {
            $("#datepickerRetur").hide();
            if ($("#datepickerTur").val() != "") $(".velgReisende").show();
        }
    })

    //Setter minstedato for returreisen til å bli samme som utreisen
    $("#datepickerTur").on("change", function () {//Kode for endring av mindate etter initisering https://api.jqueryui.com/datepicker/#option-minDate
        $("#datepickerRetur").datepicker("option", "minDate", $(this).val());
        if (!$("#turRetur").is(":checked")) {
            $(".velgReisende").show();
        }
    })
    $("#datepickerRetur").on("change", function () {//Kode for endring av mindate etter initisering https://api.jqueryui.com/datepicker/#option-minDate
        $(".velgReisende").show();
    })

    //Hentet fra https://bootsnipp.com/snippets/4no2R og justert
    // Den øker og minter antall reisende ved trykk på knappene
    $(document).on('click', '.number-spinner a', function () {
        var btn = $(this),
            input = btn.closest('.number-spinner').find('input'),
            total = $('#passengers').val(),
            oldValue = input.val().trim();

        if (btn.attr('data-dir') == 'up') {
            if (oldValue < input.attr('max')) {
                oldValue++;
                total++;
            }
        } else {
            if (oldValue > input.attr('min')) {
                oldValue--;
                total--;
            }
        }
        input.val(oldValue);
        total = "";
        sep = "";
        if ($("#voksen").val() > 0) {
            total += sep+ "Voksen: " + $("#voksen").val(); sep = ", ";
        }
        if ($("#barn").val() > 0) {
            total += sep + "Barn: " + $("#barn").val(); sep = ", ";
        }
        if ($("#smaabarn").val() > 0) {
            total += sep + "Småbarn: " + $("#smaabarn").val(); sep = ", ";
        }
        if ($("#student").val() > 0) {
            total += sep + "Student: " + $("#student").val(); sep = ", ";
        }
        if ($("#honnor").val() > 0) {
            total += sep + "Honnør: " + $("#honnor").val(); sep = ", ";
        }
        if ($("#vernepliktig").val() > 0) {
            total += sep + "Vernepliktig: " + $("#vernepliktig").val(); sep = ", ";
        }
        if ($("#ledsager").val() > 0) {
            total += sep + "Ledsager: " + $("#ledsager").val(); sep = ", ";
        }
        $('#totalReisende').val(total);
        if (total == "") $(".seAvganger").hide(); else $(".seAvganger").show(); 
    });
});


//Viser kommende avganger basert på utfylt skjema
function visAvganger() {
    const visAvgang = {
        fraStasjon: $("#fraStasjon").val(),
        tilStasjon: $("#tilStasjon").val(),
        datepickerTur: $("#datepickerTur").val(),
        datepickerRetur: $("#datepickerRetur").val(),
        voksen: $("#voksen").val(),
        barn: $("#barn").val(),
        smaabarn: $("#smaabarn").val(),
        student: $("#student").val(),
        honnor: $("#honnor").val(),
        vernepliktig: $("#vernepliktig").val(),
        ledsager: $("#ledsager").val()
    }
    const url = "Reise/visAvganger";
    $.get(url, visAvgang, function (avganger) { 
        if (avganger) {
            formaterAvganger(avganger);
        }
        else {
            $("#feil").html("Feil i db - prøv igjen senere");
        }
    })
    .fail(function () {
        $("#feil").html("Fant ingen avganger");
    });
};

//Lister opp kommende avganger i en tabell
function formaterAvganger(avganger) {

    let cnt = 0;
    let liste = "";
    for (let avgang of avganger) {
        if (cnt == 0) {
            let total = "";
            let sep = "";
            if (avgang.voksen > 0) {
                total += sep + "Voksen: " + avgang.voksen; sep = ", ";
            }
            if (avgang.barn > 0) {
                total += sep + "Barn: " + avgang.barn; sep = ", ";
            }
            if (avgang.smaabarn > 0) {
                total += sep + "Småbarn: " + avgang.smaabarn; sep = ", ";
            }
            if (avgang.student > 0) {
                total += sep + "Student: " + avgang.student; sep = ", ";
            }
            if (avgang.honnor > 0) {
                total += sep + "Honnør: " + avgang.honnor; sep = ", ";
            }
            if (avgang.vernepliktig > 0) {
                total += sep + "Vernepliktig: " + avgang.vernepliktig; sep = ", ";
            }
            if (avgang.ledsager > 0) {
                total += sep + "Ledsager: " + avgang.ledsager; sep = ", ";
            }

            //liste += "<span>" + total + "</span>";
            liste += "<h2>Kommende reiser fra " + avgang.fraStasjon + " til " + avgang.tilStasjon + "</h2><h3> " + avgang.datepickerTur + " Reisende: "+ total+"</h3>";
            liste += "<table class=\"table\">";
            liste += "<tr>";
            liste += "<th>Rute</th>";
            liste += "<th>Reisetid</th>";
            liste += "<th>Distanse</th>";
            liste += "<th>Totalpris</th>";
            liste += "<th>Bestill</th>";
            liste += "</tr>";
        }
        cnt++;
        let totalPris = avgang.prisVoksen + avgang.prisBarn + avgang.prisSmaabarn + avgang.prisStudent + avgang.prisHonnor + avgang.prisVernepliktig + avgang.prisLedsager;
        liste += "<tr>";
        liste += "<td>" + avgang.ruteNavn + "</td>";
        liste += "<td>" + avgang.tid + " min</td>";
        liste += "<td>" + avgang.distanse + " km</td>";
        liste += "<td>" + totalPris + " kr</td>";
        liste += "<td><a href=\"#\" class=\"btn btn-primary btn-lg\" onclick=\"bestill('" + avgang.fraStasjon + "','" + avgang.tilStasjon + "','" + totalPris +"') \">Bestill reisen</a></td>";
        liste += "</tr>";
    }
    liste += "</table>";
    $(".travel-card").hide();
    $(".kommendeAvganger").show();
    $(".listeAvganger").html(liste);
}

//Går tilbake til å endre søk etter avganger
function endreSok() {
    $(".travel-card").show();
    $(".kommendeAvganger").hide();
    $(".listeAvganger").html("");
}

//Bestiller reise og viser kvittering
function bestill(fra,til,total) {
    $(".kommendeAvganger").hide();
    $(".kvittering").show();
  
    let kvittering = "<h2>Takk for din bestilling</h2>";
    kvittering += "<p>Din reise fra " + fra + " til " + til + " er nå bestilt. </p>";
    kvittering += "<p>Reisen koster totalt "+ total +" kr.</p>";
    kvittering += "<p>Vi ønsker deg en god reise</p>";
    $(".bestiltReise").html(kvittering);
}