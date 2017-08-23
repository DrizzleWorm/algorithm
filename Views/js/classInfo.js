$(function () {
        $.ajax({
            type: 'get',
            url: "../Handler/classInfo.ashx?",
            success: function (data) {
                if (data == "1") {
                    $('#cs').attr('disabled',false);
                }
                else {
                    $('#cs').attr('disabled',true);
                    $('#cs').css('background-color', 'rgb(212,212,212');
                }
            }
       })
});