function wijzigline(selectie, pol, thema, evo, polper, themaper) {
    if (selectie.value == "Politieker") {
        var all = document.getElementsByClassName(pol);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'block';
        }
        all = document.getElementsByClassName(thema);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
        all = document.getElementsByClassName(evo);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
        document.getElementById('linepolweken').style.display = 'none';
    }
    if (selectie.value == "Thema") {
        var all = document.getElementsByClassName(pol);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
        all = document.getElementsByClassName(thema);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'block';
        }
        all = document.getElementsByClassName(evo);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
        document.getElementById('linethemaweken').style.display = 'none';
    }
    if (selectie.value == "Evolutie") {
        var all = document.getElementsByClassName(pol);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
        all = document.getElementsByClassName(thema);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
        all = document.getElementsByClassName(evo);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'block';
        }
    }
}

function linewijzigaantalpol(selectie, classname) {
    if (selectie.value == "1") {
        var all = document.getElementsByClassName(classname);
        for (var i = 0; i < 1; i++) {
            all[i].style.display = 'block';
        }
        for (var i = 4; i >= 1; i--) {
            all[i].style.display = 'none';
        }
    }
    if (selectie.value == "2") {
        var all = document.getElementsByClassName(classname);
        for (var i = 0; i < 2; i++) {
            all[i].style.display = 'block';
        }
        for (var i = 4; i >= 2; i--) {
            all[i].style.display = 'none';
        }
    }
    if (selectie.value == "3") {
        var all = document.getElementsByClassName(classname);
        for (var i = 0; i < 3; i++) {
            all[i].style.display = 'block';
        }
        for (var i = 4; i >= 3; i--) {
            all[i].style.display = 'none';
        }
    }
    if (selectie.value == "4") {
        var all = document.getElementsByClassName(classname);
        for (var i = 0; i < 4; i++) {
            all[i].style.display = 'block';
        }
        for (var i = 4; i >= 4; i--) {
            all[i].style.display = 'none';
        }
    }
    if (selectie.value == "5") {
        var all = document.getElementsByClassName(classname);
        for (var i = 0; i < 5; i++) {
            all[i].style.display = 'block';
        }
        for (var i = 4; i >= 5; i--) {
            all[i].style.display = 'none';
        }
    }
}
function linewijzigaantalthema(selectie, classname) {
    if (selectie.value == "1") {
        var all = document.getElementsByClassName(classname);
        for (var i = 0; i < 1; i++) {
            all[i].style.display = 'block';
        }
        for (var i = 4; i >= 1; i--) {
            all[i].style.display = 'none';
        }
    }
    if (selectie.value == "2") {
        var all = document.getElementsByClassName(classname);
        for (var i = 0; i < 2; i++) {
            all[i].style.display = 'block';
        }
        for (var i = 4; i >= 2; i--) {
            all[i].style.display = 'none';
        }
    }
    if (selectie.value == "3") {
        var all = document.getElementsByClassName(classname);
        for (var i = 0; i < 3; i++) {
            all[i].style.display = 'block';
        }
        for (var i = 4; i >= 3; i--) {
            all[i].style.display = 'none';
        }
    }
    if (selectie.value == "4") {
        var all = document.getElementsByClassName(classname);
        for (var i = 0; i < 4; i++) {
            all[i].style.display = 'block';
        }
        for (var i = 4; i >= 4; i--) {
            all[i].style.display = 'none';
        }
    }
    if (selectie.value == "5") {
        var all = document.getElementsByClassName(classname);
        for (var i = 0; i < 5; i++) {
            all[i].style.display = 'block';
        }
        for (var i = 4; i >= 5; i--) {
            all[i].style.display = 'none';
        }
    }
}

function linewijzigtijdpol(selectie, dagen, weken) {
    if (selectie.value == "per dag") {
        document.getElementById(dagen).style.display = 'block';
        document.getElementById(weken).style.display = 'none';
    }
    if (selectie.value == "per week") {
        document.getElementById(dagen).style.display = 'none';
        document.getElementById(weken).style.display = 'block';
    }
}

function linewijzigtijdthema(selectie, dagen, weken) {
    if (selectie.value == "per dag") {
        document.getElementById(dagen).style.display = 'block';
        document.getElementById(weken).style.display = 'none';
    }
    if (selectie.value == "per week") {
        document.getElementById(dagen).style.display = 'none';
        document.getElementById(weken).style.display = 'block';
    }
}

function wijzigbar(selectie, pol, thema) {
    if (selectie.value == "Politieker") {
        var all = document.getElementsByClassName(pol);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'block';
        }
        all = document.getElementsByClassName(thema);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
    }
    if (selectie.value == "Thema") {
        var all = document.getElementsByClassName(pol);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
        all = document.getElementsByClassName(thema);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'block';
        }
    }
}

function barwijzigaantalpol(selectie, classname) {
    if (selectie.value == "1") {
        var all = document.getElementsByClassName(classname);
        for (var i = 0; i < 1; i++) {
            all[i].style.display = 'block';
        }
        for (var i = 4; i >= 1; i--) {
            all[i].style.display = 'none';
        }
    }
    if (selectie.value == "2") {
        var all = document.getElementsByClassName(classname);
        for (var i = 0; i < 2; i++) {
            all[i].style.display = 'block';
        }
        for (var i = 4; i >= 2; i--) {
            all[i].style.display = 'none';
        }
    }
    if (selectie.value == "3") {
        var all = document.getElementsByClassName(classname);
        for (var i = 0; i < 3; i++) {
            all[i].style.display = 'block';
        }
        for (var i = 4; i >= 3; i--) {
            all[i].style.display = 'none';
        }
    }
    if (selectie.value == "4") {
        var all = document.getElementsByClassName(classname);
        for (var i = 0; i < 4; i++) {
            all[i].style.display = 'block';
        }
        for (var i = 4; i >= 4; i--) {
            all[i].style.display = 'none';
        }
    }
    if (selectie.value == "5") {
        var all = document.getElementsByClassName(classname);
        for (var i = 0; i < 5; i++) {
            all[i].style.display = 'block';
        }
        for (var i = 4; i >= 5; i--) {
            all[i].style.display = 'none';
        }
    }
}

function barwijzigaantalthema(selectie, classname) {
    if (selectie.value == "1") {
        var all = document.getElementsByClassName(classname);
        for (var i = 0; i < 1; i++) {
            all[i].style.display = 'block';
        }
        for (var i = 4; i >= 1; i--) {
            all[i].style.display = 'none';
        }
    }
    if (selectie.value == "2") {
        var all = document.getElementsByClassName(classname);
        for (var i = 0; i < 2; i++) {
            all[i].style.display = 'block';
        }
        for (var i = 4; i >= 2; i--) {
            all[i].style.display = 'none';
        }
    }
    if (selectie.value == "3") {
        var all = document.getElementsByClassName(classname);
        for (var i = 0; i < 3; i++) {
            all[i].style.display = 'block';
        }
        for (var i = 4; i >= 3; i--) {
            all[i].style.display = 'none';
        }
    }
    if (selectie.value == "4") {
        var all = document.getElementsByClassName(classname);
        for (var i = 0; i < 4; i++) {
            all[i].style.display = 'block';
        }
        for (var i = 4; i >= 4; i--) {
            all[i].style.display = 'none';
        }
    }
    if (selectie.value == "5") {
        var all = document.getElementsByClassName(classname);
        for (var i = 0; i < 5; i++) {
            all[i].style.display = 'block';
        }
        for (var i = 4; i >= 5; i--) {
            all[i].style.display = 'none';
        }
    }
}

function wijzigpie(selectie, type, kruisingpol, kruisingthema, piepol, piethema) {
    if (selectie.value == "Kruising" && document.getElementById(type).value == "Politieker") {
        var all = document.getElementsByClassName(kruisingpol);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'block';
        }
        all = document.getElementsByClassName(kruisingthema);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
        all = document.getElementsByClassName(piepol);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
        all = document.getElementsByClassName(piethema);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
    }
    if (selectie.value == "Kruising" && document.getElementById(type).value == "Thema") {
        var all = document.getElementsByClassName(kruisingpol);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
        all = document.getElementsByClassName(kruisingthema);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'block';
        }
        all = document.getElementsByClassName(piepol);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
        all = document.getElementsByClassName(piethema);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
    }
    if (selectie.value == "Overzicht" && document.getElementById(type).value == "Politieker") {
        var all = document.getElementsByClassName(kruisingpol);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
        all = document.getElementsByClassName(kruisingthema);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
        all = document.getElementsByClassName(piepol);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'block';
        }
        all = document.getElementsByClassName(piethema);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
    }
    if (selectie.value == "Overzicht" && document.getElementById(type).value == "Thema") {
        var all = document.getElementsByClassName(kruisingpol);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
        all = document.getElementsByClassName(kruisingthema);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
        all = document.getElementsByClassName(piepol);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
        all = document.getElementsByClassName(piethema);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'block';
        }
    }
}

function wijzigtypepie(selectie, type, kruisingpol, kruisingthema, piepol, piethema) {
    if (selectie.value == "Politieker" && document.getElementById(type).value == "Kruising") {
        var all = document.getElementsByClassName(kruisingpol);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'block';
        }
        all = document.getElementsByClassName(kruisingthema);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
        all = document.getElementsByClassName(piepol);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
        all = document.getElementsByClassName(piethema);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
    }
    if (selectie.value == "Politieker" && document.getElementById(type).value == "Overzicht") {
        var all = document.getElementsByClassName(kruisingpol);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
        all = document.getElementsByClassName(kruisingthema);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
        all = document.getElementsByClassName(piepol);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'block';
        }
        all = document.getElementsByClassName(piethema);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
    }
    if (selectie.value == "Thema" && document.getElementById(type).value == "Kruising") {
        var all = document.getElementsByClassName(kruisingpol);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
        all = document.getElementsByClassName(kruisingthema);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'block';
        }
        all = document.getElementsByClassName(piepol);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
        all = document.getElementsByClassName(piethema);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
    }
    if (selectie.value == "Thema" && document.getElementById(type).value == "Overzicht") {
        var all = document.getElementsByClassName(kruisingpol);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
        all = document.getElementsByClassName(kruisingthema);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
        all = document.getElementsByClassName(piepol);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
        all = document.getElementsByClassName(piethema);
        for (var i = 0; i < all.length; i++) {
            all[i].style.display = 'block';
        }
    }

}
