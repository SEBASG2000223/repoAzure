$(document).ready(function () {
    $('#myTable').DataTable({
        "columnDefs": [
            { "targets": 7, "orderable": false }  
        ]
    });

    $("#llamarAMiAlerta").on("click", function () {
        Swal.fire("SweetAlert2 is working!", "Hola mundo!", "success");
    });
});