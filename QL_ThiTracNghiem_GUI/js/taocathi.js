flatpickr("#datetimePicker", {
    enableTime: false,
    dateFormat: "d-m-Y",
    minDate: "today",
    defaultDate: new Date(new Date().setDate(new Date().getDate() + 1)),
    onDayCreate: function(dObj, dStr, fp, dayElem) {
        const today = new Date();
        const dayDate = new Date(dayElem.dateObj);

        // If the date is in the past, add the `past-date` class
        if (dayDate < today.setHours(0, 0, 0, 0)) {
            dayElem.classList.add("past-date");
        }
    }
});

function selectAllRows() {
    // Get all checkboxes in the table
    const checkboxes = document.querySelectorAll('#tblDSSinhVienTaoCaThi tbody input[type="checkbox"]');
    // checkboxes.forEach(checkbox => checkbox.checked = true);
    checkboxes.forEach(checkbox => {
        checkbox.checked = !allChecked;
    });

    // Count how many checkboxes are checked
    let checkedCount = 0;
    checkboxes.forEach((checkbox) => {
        const row = checkbox.closest("tr");
        if (checkbox.checked) {
            checkedCount++;
        }
    });

    document.getElementById("header-checked").textContent = allChecked ? "Check (" + checkedCount + ")" : "Uncheck (" + checkedCount + ")";

    // Toggle the allChecked state
    allChecked = !allChecked;
}

function sortTable(columnIndex) {
    const table = document.getElementById("tblDSSinhVienTaoCaThi");
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

function taoCaThi() {
    showLoading();
    var hocPhan = document.querySelector("#options-monhoc").value;
    var gioThi = document.querySelector("#options-giothi").value;
    var phongThi = document.querySelector("#options-phongthi").value;
    var toHopDe = document.querySelector("#options-tohopde").value;
    var ngayThi = document.querySelector("#datetimePicker").value;

    const table = document.getElementById("tblDSSinhVienTaoCaThi");
    const rows = table.querySelectorAll("tbody tr");
    const checkedRows = [];

    // Loop through each row
    rows.forEach(row => {
        const checkbox = row.querySelector('input[type="checkbox"]');
        // Check if the checkbox is checked
        if (checkbox && checkbox.checked) {
            checkedRows.push(row); // Add the row to checkedRows array
        }
    });

    if (checkedRows.length > 0) {
        // Display checked rows (for demonstration)
        checkedRows.forEach((row, index) => {
            const cells = Array.from(row.cells).map(cell => cell.innerText);
            console.log(`Row ${index + 1}:`, cells[5]);
        });
        showSuccessBox("successBox", "message-success", "Thành công, quá trình tạo ca thi hoàn tất.");
    } else {
        showErrorBox("errorrBox", "message-errorr", "Hãy chọn sinh viên !");
    }
}