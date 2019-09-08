
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


document.addEventListener('DOMContentLoaded', function () {
    var dateFormat = 'DD-MM-YYYY hh:mm a';
    
    $('.datetimepicker1').datetimepicker({
        format: dateFormat,
    });

    // need this due an issue with validation checking
    $.validator.methods.date = function (value, element) {
        return this.optional(element) || moment(value, dateFormat, true).isValid();           
    }
    
});