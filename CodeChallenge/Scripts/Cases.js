const $fileInput = document.getElementById('uploadFile')
$fileInput.addEventListener('change', function (e) {

    $("#loading").show();

    var formData = new FormData();
    var file = e.target.files[0];

    formData.append("file", file);

    $.ajax({
        type: 'POST',
        url: "/Case/UploadCases",
        data: formData,
        contentType: false,
        dataType: "html",
        processData: false,
        success: function (viewHTML) {
            $("#loading").hide();
            $("#cases_grid").html(viewHTML);
        },
        error: function (errorData) {
            $("#loading").hide();
            $("#ErrorMsg").show();
            $("#ErrorMsg").fadeOut(4000);
        }
    });

    $fileInput.value = ''
}, false);

function openModal(caseNumber)
{

    $.ajax({
        url: '/Case/GetDetails',
        type: "GET",
        dataType: 'html',
        data: { 'caseNumber': caseNumber },
        cache: false,
        contentType: "application/jsonrequest; charset=utf-8",
        success: function (data) {
            $("#case_detail").html(data);
            $('#exampleModalCenter').modal('show'); 
         }
});
}

