// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Enable tooltips
$(function () {
  $('[data-toggle="tooltip"]').tooltip();
});

// Enable popovers
$(function () {
  $('[data-toggle="popover"]').popover();
});

// Confirm delete actions
$('.confirm-delete').on('click', function (e) {
  if (!confirm('Are you sure you want to delete this item?')) {
    e.preventDefault();
  }
});

// Auto-hide alerts after 5 seconds
setTimeout(function() {
  $('.alert-dismissible').fadeOut('slow');
}, 5000);