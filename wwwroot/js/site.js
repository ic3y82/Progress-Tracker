// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

li.innerHTML = `${bar.name} - ${bar.progress}% ` +
    (bar.isRunning ? '' : '(Done!)') +
    `<div class="progress-container">
        <div class="progress-bar" style="width:${bar.progress}%;"></div>
     </div>`;