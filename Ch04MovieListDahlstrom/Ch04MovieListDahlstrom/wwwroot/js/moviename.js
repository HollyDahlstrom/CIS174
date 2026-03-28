$.validator.addMethod("moviename",
    function (value, element, param) {
        if (value == '') return false;
        if (value == 'HollyD') return false;
        return true;
    });

$.validator.unobtrusive.adapters.add("moviename", ["name"], function (options) {
    options.rules["moviename"] = options.params.name;
    options.messages["moviename"] = "Client Side Validation";
});