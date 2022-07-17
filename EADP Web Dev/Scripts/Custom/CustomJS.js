$(document).ready(function() {
    function RefreshField(input_selector1) {
        var input_selector = inputselector1;
        $(input_selector).each(function(index, element) {
            var $this = $(this);
            if ($(element).val().length > 0 ||
                $(element).is(':focus') ||
                element.autofocus ||
                $this.attr('placeholder') !== undefined) {
                $this.siblings('label').addClass('active');
            } else if ($(element)[0].validity) {
                $this.siblings('label').toggleClass('active', $(element)[0].validity.badInput === true);
            } else {
                $this.siblings('label').removeClass('active');
            }
        });
    };

});