

$(document).ready(function () {

       


    $("#typeOfsections").on('change', function () {

            $('#BelongToBarnch').removeAttr("disabled");
        //   $('#BelongToBarnch').removeAttr("disabled");
        // BelongToBarnch


        if ($("#typeOfsections").val() ==1) {



            $('#BelongToBarnch').select2({
                placeholder: 'Select an option',
                ajax: {
                    url: 'http://localhost:60011/Main/GetDataBaranchAll',
                    dataType: 'json',
                    data: function (params) {
                        var query = {
                            search: params.term,
                            type:"1"
                        }

                        // Query parameters will be ?search=[term]&type=public
                        return query;
                    }
                }

            });



        }



        else {



            $('#BelongToBarnch').select2({
                placeholder: 'Select an option',
                ajax: {
                    url: 'http://localhost:60011/Main/GetDataDepartmentAll',
                    dataType: 'json',
                    data: function (params) {
                        var query = {
                            search: params.term,
                            type: "1"
                        }

                        // Query parameters will be ?search=[term]&type=public
                        return query;
                    }
                }

            });




        }

       
    });




    $('#BranchLevel').select2({
        placeholder: 'Select an option'

    });

    //  alert("ss");   BranchLevel
    $('body').on('click', '.EditForm', function () {




        $('#SectionID').val($(this).attr('id'));


    

     

        $("#typeOfsections2").on('change', function () {

            $('#BelongToBarnch').removeAttr("disabled");
            //   $('#BelongToBarnch').removeAttr("disabled");
            // BelongToBarnch

            $("#BelongToBarnch2").attr("disabled", false);
            if ($("#typeOfsections2").val() == 1) {



                $('#BelongToBarnch2').select2({
                    placeholder: 'Select an option',
                    ajax: {
                        url: 'http://localhost:60011/Main/GetDataBaranchAll',
                        dataType: 'json',
                        data: function (params) {
                            var query = {
                                search: params.term,
                                type: "1"
                            }

                            // Query parameters will be ?search=[term]&type=public
                            return query;
                        }
                    }

                });



            }



            else {



                $('#BelongToBarnch2').select2({
                    placeholder: 'Select an option',
                    ajax: {
                        url: 'http://localhost:60011/Main/GetDataDepartmentAll',
                        dataType: 'json',
                        data: function (params) {
                            var query = {
                                search: params.term,
                                type: "1"
                            }

                            // Query parameters will be ?search=[term]&type=public
                            return query;
                        }
                    }

                });




            }


        });




        $('#exampleModal').modal();
    });







    $('body').on('click', '.StoperForm', function () {
        $('#BranchID2').val($(this).attr('id'));
        $('#exampleModal2').modal();
    });

});