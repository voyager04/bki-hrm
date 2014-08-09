/*
JavaScript Document
*/


//popup window
function popupwindow(url) {

    var left = ((screen.width / 2) - (600 / 2));
    var top = ((screen.height / 2) - (350 / 2));

    newwindow = window.open(url, 'name', 'height=350,width=600, top='+top+', left='+left);
    if (window.focus) { newwindow.focus() }
    return false;
}


//refresh the default.aspx when close
function RefreshDefault() {
    window.opener.location.reload();
    window.close();
}


//confirm delete block
function confirmDelete() {
    var r = confirm("Are you sure?");
}