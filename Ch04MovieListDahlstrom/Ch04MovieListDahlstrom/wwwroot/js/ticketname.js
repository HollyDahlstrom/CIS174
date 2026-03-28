$.validator.addMethod("ticketname", function (value, element, param) {
    if (!value) return false;
    return value !== param; 
});

$.validator.unobtrusive.adapters.add("ticketname", ["client"], function (options) {
    options.rules["ticketname"] = options.params.client;
    options.messages["ticketname"] = options.message || "Invalid ticket name.";
});