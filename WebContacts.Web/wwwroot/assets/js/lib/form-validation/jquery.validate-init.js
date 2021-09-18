
var form_validation = function() {
    var e = function() {
            jQuery(".form-valide").validate({
                ignore: [],
                errorClass: "invalid-feedback animated fadeInDown",
                errorElement: "div",
                errorPlacement: function(e, a) {
                    jQuery(a).parents(".form-group > div").append(e)
                },
                highlight: function(e) {
                    jQuery(e).closest(".form-group").removeClass("is-invalid").addClass("is-invalid")
                },
                success: function(e) {
                    jQuery(e).closest(".form-group").removeClass("is-invalid"), jQuery(e).remove()
                },
                rules: {
                    "Name": {
                        required: !0,
                        minlength: 4
                    },
                    
                    "EmployeeTypeId": {
                        required: !0
                    },
                   
                    "Address": {
                        required: !0,
                        minlength: 5
                    },
                   
                    "MobileNumber": {
                        required: !0,
                        
                    },
                    "PhoneNumber": {
                       
                      
                    },
                    "NationalId": {
                        required: !0,
                        phoneUS: !0
                    },
                    "NationalId": {
                        required: !0,
                        minlength: 5
                        
                    },
                    "StartDate":{
                        required: !0
                    },
                    "EndDate": {

                    }
                },
                messages: {
                    "Name": {
                        required: "Please enter a Name",
                        minlength: "Your Name must consist of at least 3 characters"
                    },
                  
                    "EmployeeTypeId": "Please select a value!",
                    "val-select2-multiple": "Please select at least 2 values!",
                    "Address": "fill address please",
                    "NationalId": "Please select a skill!",
                    "MobileNumber": "Please enter a mobile Number!",
                    "StartDate": "please enter start date"
                }
            })
        }
    return {
        init: function() {
            e(), a(), jQuery(".js-select2").on("change", function() {
                jQuery(this).valid()
            })
        }
    }
}();
jQuery(function() {
    form_validation.init()
});