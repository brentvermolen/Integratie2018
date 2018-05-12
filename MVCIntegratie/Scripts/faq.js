$(function () {
   // Since there's no list-group/tab integration in Bootstrap
   $('.list-group-item').on('click', function (e) {
      var previous = $(this).closest(".list-group").children(".active");
      previous.removeClass('active'); // previous list-item
      $(e.target).addClass('active'); // activated list-item
   });
});

function verzendVraag() {
   var divError = document.getElementById("divError");
   var divVerzonden = document.getElementById("divVerzonden");
   var divVraag = document.getElementById("divVraag");
   var divLeeg = document.getElementById("divLeeg");

   var vraag = document.getElementById("vraag").value;
   var categorie = document.getElementById("categorie").value;

   if (vraag != "") {
      class FAQ {
         constructor(vraag, categorie) {
            this.vraag = vraag;
            this.categorie = categorie;
         }
      }

      var faq = new FAQ(vraag, categorie);

      var jsonG = JSON.stringify(faq);

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

      $.ajax('/api/FYI/VraagOpslaan', {
         type: 'POST',
         contentType: "application/json",
         accepts: 'application/json',
         data: json
      }).done(function () {
         divError.style.display = "none";
         divVraag.style.display = "none";
         divVerzonden.style.display = "block";
         divLeeg.style.display = "none";
      }).fail(function () {
         divError.style.display = "block";
         divVraag.style.display = "block";
         divVerzonden.style.display = "none";
         divLeeg.style.display = "none";
      });
   } else {
      divLeeg.style.display = "block";
      divVraag.style.display = "block";
      divError.style.display = "none";
      divVerzonden.style.display = "none";
   }
}
