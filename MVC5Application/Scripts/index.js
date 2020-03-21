$(document).ready(function(){
   
    $('#generate_button').click(function () {
        $.get('Home/GeneratePDF', function (data) {
            alert('document genéré dans: ' + $('#generate_button').attr('href'));
            //window.open($('#generate_button').attr('href'), '_blank');


        })
    })
})