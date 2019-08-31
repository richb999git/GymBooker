
function buttonClick() {
    // id="spinner1" class="show" or hidden
    var firstItem = document.getElementById("spinner1");
    firstItem.className = "show spinner-centre";
    console.log("make spinner visible");
    return false;
};

document.addEventListener('DOMContentLoaded', function () {
    var firstItem = document.getElementById("spinner1");
    //firstItem.className = "invisible text-center";
    firstItem.className = "invisible spinner-centre";
    console.log("make spinner invisible");
}, false);

window.addEventListener('beforeunload', function () {
    var firstItem = document.getElementById("spinner1");
    firstItem.className = "show spinner-centre";
    console.log("make spinner visible onbeforeunload");
    return false;
}, false);
