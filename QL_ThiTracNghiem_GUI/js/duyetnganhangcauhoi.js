document.addEventListener("DOMContentLoaded", function () {
    const tableBody = document.querySelector("#recordsTable tbody");
    const noRecordsMessage = document.getElementById("noRecordsMessage");

    function checkTableRows() {
        if (tableBody.children.length === 0) {
            noRecordsMessage.style.display = "block";
        } else {
            noRecordsMessage.style.display = "none";
        }
    }

    checkTableRows();
});

function sortTable(columnIndex) {
    const table = document.getElementById("recordsTable");
    const rows = Array.from(table.rows).slice(1); // Get all rows except the header
    const isAscending = table.querySelectorAll("th")[columnIndex].classList.toggle("sorted-asc");

    // Clear other sorted column classes
    table.querySelectorAll("th").forEach((th, index) => {
        if (index !== columnIndex) {
            th.classList.remove("sorted-asc", "sorted-desc");
        }
    });
    if (!isAscending) {
        table.querySelectorAll("th")[columnIndex].classList.replace("sorted-asc", "sorted-desc");
    }

    // Determine sort direction
    const direction = isAscending ? 1 : -1;

    rows.sort((a, b) => {
        const cellA = a.cells[columnIndex].innerText;
        const cellB = b.cells[columnIndex].innerText;

        const valA = isNaN(cellA) ? cellA : parseFloat(cellA);
        const valB = isNaN(cellB) ? cellB : parseFloat(cellB);

        return valA > valB ? direction : valA < valB ? -direction : 0;
    });

    // Append sorted rows back to the table
    rows.forEach(row => table.tBodies[0].appendChild(row));
}


function showDetails(questionId) {
    const questionDetail = document.getElementById("questionDetail");
    const table = document.getElementById("table-duyetNHCH");
    const row = document.getElementById(questionId);

    let rowContent = [];
    if (row) {
        for (let cell of row.cells) {
            rowContent.push(cell.textContent.trim());
        }
    }
    questionDetail.innerHTML = '<p>' + rowContent[0] + '</p>';
    document.getElementById("answerOptions").innerHTML = 
        '<label><input type=\"radio\" name=\"answer\" value=\"1\">' + rowContent[1] + '</label><br>' +
        '<label><input type=\"radio\" name=\"answer\" value=\"2\">' + rowContent[2] + '</label><br>' +
        '<label><input type=\"radio\" name=\"answer\" value=\"3\">' + rowContent[3] + '</label><br>' +
        '<label><input type=\"radio\" name=\"answer\" value=\"4\">' + rowContent[4] + '</label><br>';
}
