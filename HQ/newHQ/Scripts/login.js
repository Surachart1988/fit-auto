
(function ($) {
    "use strict";


    /*==================================================================
    [ Focus input ]*/
    $('.input100').each(function(){
        $(this).on('blur', function(){
            if($(this).val().trim() != "") {
                $(this).addClass('has-val');
            }
            else {
                $(this).removeClass('has-val');
            }
        })    
    })
  
  
    /*==================================================================
    [ Validate ]*/
    var input = $('.validate-input .input100');

    $('.validate-form').on('submit',function(){
        var check = true;

        for(var i=0; i<input.length; i++) {
            if(validate(input[i]) == false){
                showValidate(input[i]);
                check=false;
            }
        }

        return check;
    });


    $('.validate-form .input100').each(function(){
        $(this).focus(function(){
           hideValidate(this);
        });
    });

    function validate (input) {
            if($(input).val().trim() == ''){
                return false;
            }
    }

    function showValidate(input) {
        $('.validate.' + input.id).show()
    }

    function hideValidate(input) {
        $('.validate.' + input.id).hide()
    }
    
    /*==================================================================
    [ Show pass ]*/
    var showPass = 0;
    $('.btn-show-pass').on('click', function(){
        if(showPass == 0) {
            $(this).next('input').attr('type','text');
            $(this).find('i').removeClass('zmdi-eye');
            $(this).find('i').addClass('zmdi-eye-off');
            showPass = 1;
        }
        else {
            $(this).next('input').attr('type','password');
            $(this).find('i').addClass('zmdi-eye');
            $(this).find('i').removeClass('zmdi-eye-off');
            showPass = 0;
        }
        
    });

    $('.input-group-addon.beautiful').each(function () {

        var $widget = $(this),
            $input = $widget.find('input'),
            type = $input.attr('type'),
        settings = {
            checkbox: {
                on: { icon: 'fa fa-check-circle-o' },
                off: { icon: 'fa fa-circle-o' }
            },
            radio: {
                on: { icon: 'fa fa-dot-circle-o' },
                off: { icon: 'fa fa-circle-o' }
            }
        };

        $widget.prepend('<span class="' + settings[type].off.icon + '"></span>');

        $widget.on('click', function () {
            $input.prop('checked', !$input.is(':checked'));
            updateDisplay();
        });

        function updateDisplay() {
            var isChecked = $input.is(':checked') ? 'on' : 'off';

            $widget.find('.fa').attr('class', settings[type][isChecked].icon);

            //Just for desplay
            isChecked = $input.is(':checked') ? 'checked' : 'not Checked';
            $widget.closest('.input-group').find('input[type="text"]').val('Input is currently ' + isChecked)
        }

        updateDisplay();
    });

})(jQuery);