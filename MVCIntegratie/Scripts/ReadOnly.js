function invoer(obj) {
    $('.invoerveld').attr("readonly", false);
    $('.invoerdropdown').removeAttr("disabled");
    obj.style.display = "none";
    document.getElementById("opslaan").style.display = "block";
};

function opslaan(obj) {
   obj.style.display = "none";
   document.getElementById("wijzig").style.display = "block";

   class Gebruiker {
      constructor(voornaam, achternaam, email, geboortedatum, postcode, vraag, antwoord) {
         this.voornaam = voornaam;
         this.achternaam = achternaam;
         this.email = email;
         this.geboortedatum = geboortedatum;
         this.postcode = postcode;
         this.vraag = vraag;
         this.antwoord = antwoord;
      }
   }

   var gebruiker = new Gebruiker(
      document.getElementById("voornaam").value,
      document.getElementById("achternaam").value,
      document.getElementById("email").value,
      document.getElementById("geboortedatum").value,
      document.getElementById("postcode").value,
      document.getElementById("veiligheidsvraag").value,
      document.getElementById("antwoord").value
   );

   var jsonG = JSON.stringify(gebruiker);

   var json = '"';

   for (var i = 0; i < jsonG.length; i++) {
      var ch = jsonG.charAt(i);
      if (ch == '"') {
         json += "'";
      } else {
         json += ch;
      }
   }

   json += '"';

   $.ajax("/api/IngelogdeGebruiker/WijzigGebruiker", {
      type: 'POST',
      contentType: "application/json",
      accepts: 'application/json',
      data: json
   }).done(function (data) {
      window.location.reload();
   }).fail(function () {
      alert('Er is iets misgelopen, probeer opnieuw');
   });
}