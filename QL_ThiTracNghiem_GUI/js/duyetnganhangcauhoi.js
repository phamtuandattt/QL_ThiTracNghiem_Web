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

function showPopupDuyetNHCH(popup_id) {
    const popup = document.getElementById(popup_id);
    document.getElementById('popup-title').innerText = 'Nội dung câu hỏi';

    popup.classList.add('show'); // Add the 'show' class to display the popup
}

function showDetails(questionId) {
    const questionDetail = document.getElementById("questionDetail");
    const row = document.getElementById(questionId);

    let rowContent = [];
    if (row) {
        for (let cell of row.cells) {
            rowContent.push(cell.textContent.trim());
        }
    }
    questionDetail.innerHTML = '<p>' + rowContent[0] + '</p>';
    document.getElementById("answerOptions").innerHTML =
        '<label><input type=\"radio\" name=\"answer\" value=\"1\" disabled ' + ((rowContent[5].trim() === "A") ? "checked" : "") + '>' + rowContent[1] + '</label><br>' +
        '<label><input type=\"radio\" name=\"answer\" value=\"2\" disabled ' + ((rowContent[5].trim() === "B") ? "checked" : "") + '>' + rowContent[2] + '</label><br>' +
        '<label><input type=\"radio\" name=\"answer\" value=\"3\" disabled ' + ((rowContent[5].trim() === "C") ? "checked" : "") + '>' + rowContent[3] + '</label><br>' +
        '<label><input type=\"radio\" name=\"answer\" value=\"4\" disabled ' + ((rowContent[5].trim() === "D") ? "checked" : "") + '>' + rowContent[4] + '</label><br>';

    // Remove highlight class from all rows
    const rows = document.querySelectorAll("tbody tr");
    rows.forEach(r => r.classList.remove("highlight"));

    // Add highlight class to the clicked row
    row.classList.add("highlight");
}

function countChecked() {
    // Get all checkboxes in the table
    const checkboxes = document.querySelectorAll('#table-duyetNHCH tbody input[type="checkbox"]');

    // Count how many checkboxes are checked
    let checkedCount = 0;
    checkboxes.forEach((checkbox) => {
        const row = checkbox.closest("tr");
        if (checkbox.checked) {
            if (!listChecked.some(item => item.id === row.id)) {
                listChecked.push(row);
            }
            checkedCount++;
        } else {
            listChecked = listChecked.filter(item => item.id !== row.id);
        }
    });

    // Update the count display
    document.getElementById("quantity-selected").textContent = 'Đã chọn (' + checkedCount + ') câu hỏi.';
}

function selectedAll() {
    // Get all checkboxes in the table
    const checkboxes = document.querySelectorAll('#table-duyetNHCH tbody input[type="checkbox"]');
    checkboxes.forEach(checkbox => checkbox.checked = true);

    // Update the count display
    countChecked();

    // Update button text based on action
    // document.getElementById("selected-all").textContent = allChecked ? "Chọn tất cả" : "Bỏ chọn tất cả";
}

function unselectedAll() {
    // Get all checkboxes in the table
    const checkboxes = document.querySelectorAll('#table-duyetNHCH tbody input[type="checkbox"]');
    checkboxes.forEach(checkbox => checkbox.checked = false);

    // Update the count display
    countChecked();

    // Update button text based on action
    // document.getElementById("selected-all").textContent = allChecked ? "Chọn tất cả" : "Bỏ chọn tất cả";
}

function saveAll(popup_id_path) {
    var path = '#' + popup_id_path + ' input[type=\"radio\"]';
    console.log(listChecked);
    listChecked = [];
}