$('#btn-comment').click(function() {
    var d = {
        id : $('#movie-id').val(),
        txt : $('#comment-text').val()
    }
    $.ajax({
        type: "POST",
        url: "https://localhost:5001/api/v1/Comments/SendComment",
        data: {text: d.txt, id: d.id},
        success: function(result){
            $('#comments').append('<li>'+$('#comment-text').val());
        },
        failure: function(result) {
            alert ('Cannot send that comment. Try again later');
        }
    });
})
