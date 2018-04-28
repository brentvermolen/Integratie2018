function verwijder() {
    var element = document.getElementById("test1");
    element.outerHTML = "";
    delete element;

}