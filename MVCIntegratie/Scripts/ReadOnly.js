function invoer(obj) {
    $('.invoerveld').attr("readonly", false);
    $('.invoerdropdown').removeAttr("disabled");
    obj.style.display = "none";
    document.getElementById("opslaan").style.display = "block";
};
