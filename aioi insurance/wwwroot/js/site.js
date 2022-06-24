// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const searchBox = document.getElementById("searchBox");
 

searchBox.addEventListener('change', function () {
    sessionStorage.setItem(txt.value);
    searchBox.submit();
});

 