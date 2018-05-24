function verwijder(id) {
   $.ajax('/api/IngelogdeGebruiker/VerwijderGrafiek/' + id,
      {
         type: 'GET',
         dataType: 'json'
      }).done(function (data) {
         var element = document.getElementById(id).parentNode;
         element.outerHTML = "";
         delete element;
      }).fail(function () {
         alert('fail');
      });
}