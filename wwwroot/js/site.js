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

// Close dropdowns when clicking outside
document.addEventListener('click', function(event) {
    const dropdowns = document.querySelectorAll('.dropdown-menu');
    dropdowns.forEach(dropdown => {
        // If the click is outside the dropdown and its parent button
        if (!dropdown.parentElement.contains(event.target)) {
            dropdown.classList.add('hidden');
        }
    });
});

// Add event listeners to close other dropdowns when one is opened
document.addEventListener('DOMContentLoaded', function() {
    const dropdownButtons = document.querySelectorAll('.dropdown button');

    dropdownButtons.forEach(button => {
        button.addEventListener('click', function(event) {
            // Close all other dropdowns
            const allDropdownMenus = document.querySelectorAll('.dropdown-menu');
            const thisDropdownMenu = this.parentElement.querySelector('.dropdown-menu');

            allDropdownMenus.forEach(menu => {
                if (menu !== thisDropdownMenu) {
                    menu.classList.add('hidden');
                }
            });

            // Prevent the click from propagating to the document
            event.stopPropagation();
        });
    });

    // Handle logout forms
    const logoutForms = document.querySelectorAll('form[action="/Account/Logout"]');
    logoutForms.forEach(form => {
        form.addEventListener('submit', function(event) {
            event.preventDefault();

            // Submit the form using fetch API
            fetch(this.action, {
                method: 'POST',
                body: new FormData(this),
                headers: {
                    'X-Requested-With': 'XMLHttpRequest'
                }
            })
            .then(response => {
                if (response.ok || response.redirected) {
                    // Redirect to login page
                    window.location.href = '/Account/Login';
                }
            })
            .catch(error => {
                console.error('Logout error:', error);
                // Fallback redirect
                window.location.href = '/Account/Login';
            });
        });
    });
});