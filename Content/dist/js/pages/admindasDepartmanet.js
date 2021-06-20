



$(document).ready(function () {




    $("#BranchLevel").on('change', function () {


     //   $('#BelongToBarnch').removeAttr("disabled");


        $('#BelongToBarnch').select2({
            placeholder: 'Select an option',
            ajax: {
                url: 'http://localhost:60011/Main/GetDataBaranchByUperLevel',
                dataType: 'json',
                data: function (params) {
                    var query = {
                        search: params.term,
                        type: $("#BranchLevel").val()
                    }

                    // Query parameters will be ?search=[term]&type=public
                    return query;
                }
            }

        });
    });




    $('#BranchLevel').select2({
        placeholder: 'Select an option'

    });

    //  alert("ss");   BranchLevel
    $('body').on('click', '.EditForm', function () {




        $('#DepartmenteorID').val($(this).attr('id'));

      
        if ($(this).attr('value') === "False") {

            $("#BelongToBarnch2").attr("disabled", true);

          //  alert("");

        }



        else {

            $("#BelongToBarnch2").attr("disabled", false);
          //  alert("");
        }
        $('#exampleModal').modal();
    });







    $('body').on('click', '.StoperForm', function () {
        $('#BranchID2').val($(this).attr('id'));
        $('#exampleModal2').modal();
    });

});