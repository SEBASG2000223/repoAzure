$(document).ready(function () {
  
   
    var mensaje = $('#mensajeAlerta').val();
    if (mensaje) {
        Swal.fire({
            title: "Se registro con éxito",
            text: mensaje,
            icon: "success",
            timer: 5000, 
            timerProgressBar: true,
            allowOutsideClick: false,
            showConfirmButton: true,
            confirmButtonText: "Entendido"
        });
    }
});
    
