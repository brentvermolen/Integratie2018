function verwijder(id) {
    var element = document.getElementById(id);
    element.outerHTML = "";
    delete element;
}