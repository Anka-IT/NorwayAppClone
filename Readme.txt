# Kommentarer rundt leveringen

Jeg har satt opp bestillingsprosessen til å gå trinnvis.
Data settes inn en etter en i bestemt rekkefølge.
Slik foregår bestilling av en reise:
Kunde begynner å skrive inn navn på en stasjon som man ønsker å reisefra.
Etter at kunden har skrevet minst to tegn sendes inputdata til databasen som sender tilbake liste over stasjoner.
Når man klikker på en stasjon på den listen blir den valgt og man går videre til neste steg som er valg av til-stasjon.
Dette foregår også på samme måte.
Om man ønsker å gå tilbake er det lagt inn endre knapper.
Deretter velger man om det skal være en-veisreise eller tur-retur reise.
Velger man tur-retur dukker det opp to datovelgere.
Etter at datoer er valgt velger man antall reisende og type reisende.
Når dette også er valgt kan man klikke seg videre til å liste opp avganger.
Der får man opp linjenummer, hvor lang tid reisen tar, distansen for reisen og hva den koster for alle reisende.
Deretter klikker man på "Bestill reisen" for å bestille.  
Da kommer den kvittering opp med oppsummering og systemet ønsker en god reise.


Jeg gjorde så godt jeg kunne men der fortsatt mye rom for forbedringer. 
Her er liste over ting jeg ikke fikk helt på plass slik jeg ønsket og vil forbedre til neste innlevering.

1. Autofullfør når en søker etter stasjon er ikke case-insensitive. Det vil si om vi søker etter "oslo" vil den ikke komme opp siden den er skrevet med liten "O".
Her er liste over noen stasjoner: Kongsberg, Drammen, Asker, Sandvika, Oslo S, Lillestrøm, Oslo Lufthavn, Eidsvoll
2. Systemet håndterer ikke returreisen foreløpig, selv om det er mulig å velge ved søk etter avganger.
3. Avgangene viser ikke tidspunktet for reisen da jeg må jobbe videre med henting av data med EntityFramework
4. Når det gjelder validering av data har jeg satt det opp for backend med jeg fikk stadig feilmelding "BadRequest" da jeg sende inn data. For frontend er input av data ganske restriktivt allerede, men her kan det settes opp grundig validering av inndata.
5. Designet kan også gjøres mer responsiv. Den fungerer helt fint på desktop, men på mobil kan den være enda mer ryddig i neste steg. 


## Kilder 
Jeg har brukt Jquery og JqueryUi samt bootstrap i oppgaven.
Eventuelle open source koder som jeg har hentet fra eksterne steder er merket i selve koden. 
https://www.nor-way.no/
https://bootsnipp.com/snippets/4no2R
https://www.w3schools.com/code/tryit.asp?filename=FTUTR9BYRNI0

Generelt har jeg brukt dokumentasjonen og eksemplene på https://www.w3schools.com og https://getbootstrap.com/docs for inspirasjon til å bygge opp løsningen.
Hovedsaklig er alt av kode bygget opp etter videoer, slider, forelesningesnotater og eksempler tilgjengelig på canvas lagt ut av fagansvarlig. 


