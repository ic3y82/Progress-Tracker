// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const list = document.getElementById("barsList");

function updateOrCreateBar(bar) {
    let li = document.getElementById(`bar-${bar.id}`);

    if (!li) {
        li = document.createElement("li");
        li.id = `bar-${bar.id}`;
        list.appendChild(li);
    }

    li.innerHTML = `
        ${bar.name} - ${bar.progress}% ${bar.isRunning ? '' : '(Done!)'}
        <div class="progress-container">
            <div class="progress-bar" style="width:${bar.progress}%;"></div>
        </div>
    `;
}