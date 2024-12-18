function countQuestionChecked() {
    // Get all checkboxes in the table
    const checkboxes = document.querySelectorAll('#table-taodethi tbody input[type="checkbox"]');

    // Count how many checkboxes are checked
    let checkedCount = 0;
    checkboxes.forEach((checkbox) => {
        const row = checkbox.closest("tr");
        if (checkbox.checked) {
            if (!listQuestionCreate_dethi.some(item => item.id === row.id)) {
                listQuestionCreate_dethi.push(row);
            }
            checkedCount++;
        } else {
            listQuestionCreate_dethi = listQuestionCreate_dethi.filter(item => item.id !== row.id);
        }
    });

    // Update the count display
    document.getElementById("input-soluongcauhoidachon").value = checkedCount;
}

function randomSelected() {
    const quantity = document.getElementById('quantityInput').value;

    const table = document.getElementById('table-taodethi');
    const checkboxes = table.querySelectorAll('tbody input[type="checkbox"]');
    const rowCount = checkboxes.length;

    // Array to keep track of selected indices to avoid duplicates
    const selectedIndices = new Set();

    // Select random checkboxes without duplicates
    while (selectedIndices.size < quantity) {
        const randomIndex = Math.floor(Math.random() * rowCount);
        selectedIndices.add(randomIndex);
    }

    // Uncheck all rows before selecting new random ones
    checkboxes.forEach(checkbox => checkbox.checked = false);

    // Check the randomly selected rows
    selectedIndices.forEach(index => checkboxes[index].checked = true);
    closeQuantityDialog();

    // Update the count display
    countQuestionChecked();
}

function randomUnselectedAll() {
    // Get all checkboxes in the table
    const checkboxes = document.querySelectorAll('#table-taodethi tbody input[type="checkbox"]');
    checkboxes.forEach(checkbox => checkbox.checked = false);

    // Update the count display
    countQuestionChecked();
}

function showQuantityDialog() {
    // Show the overlay and dialog
    document.getElementById('overlay-enter-quantity').style.display = 'block';
    document.getElementById('quantityDialog').style.display = 'block';
    document.getElementById("quantityInput").focus();
}

function closeQuantityDialog() {
    // Hide the overlay and dialog
    document.getElementById('overlay-enter-quantity').style.display = 'none';
    document.getElementById('quantityDialog').style.display = 'none';
}

document.addEventListener("DOMContentLoaded", function () {
    const tableBody = document.querySelector("#table-taodethi tbody");
    const noRecordsMessage = document.getElementById("noRecordsMessage");

    function checkTableRows() {
        if (tableBody.children.length === 0) {
            // Show the "No matching records found" message if no rows are in the table
            noRecordsMessage.style.display = "block";
        } else {
            // Hide the message if rows are present
            noRecordsMessage.style.display = "none";
        }
    }

    // Initially check the table on page load
    checkTableRows();

    const selectElement = document.getElementById("options-monhoc");

    // Add an event listener for the `change` event
    selectElement.addEventListener("change", function () {
        const selectedValue = selectElement.value;

        if (selectedValue == "option2") {
            const tableBody = document.querySelector("#table-taodethi tbody");
            tableBody.innerHTML = "";
            checkTableRows();
        } else {
            const tableBody = document.querySelector("#table-taodethi tbody");
            tableBody.innerHTML += "<tr onclick=\"showDetails(1)\" id=\"1\"><td><p class=\"an\">Khi kiểm định... Khi kiểm định... Khi kiểm định...Khi kiểm định...Khi kiểm định...Khi kiểm định...Khi kiểm định...Khi kiểm định...Khi kiểm định...</p></td><td style=\"display: none;\">1 lần</td><td style=\"display: none;\">2 lần</td><td style=\"display: none;\">3 lần</td><td style=\"display: none;\">4 lần</td><td>B</td><td><input type=\"checkbox\" onclick=\"countQuestionChecked()\"/></td></tr><tr onclick=\"showDetails(2)\" id=\"2\"><td><p class=\"an\">Công tác kiểm định...</p></td><td style=\"display: none;\">1 lần</td><td style=\"display: none;\">2 lần</td><td style=\"display: none;\">3 lần</td><td style=\"display: none;\">4 lần</td><td>A</td><td><input type=\"checkbox\" onclick=\"countQuestionChecked()\"/></td></tr>";
            checkTableRows();
        }
    });
})

function taoDeThi() {
    const thoigianlambai = document.querySelector("#input-thoigianlambai");
    const soluongcauhoi = document.querySelector("#input-soluongcauhoidachon");
    const mamonhoc = document.querySelector("#options-monhoc");

    if (!thoigianlambai.value) {
        showLoading();
        showErrorBox("errorrBox", "message-errorr", "Hãy nhập thời gian làm bài !");
        thoigianlambai.focus();
        return;
    }
    if (!soluongcauhoi.value) {
        showLoading();
        showErrorBox("errorrBox", "message-errorr", "Hãy chọn câu hỏi để tạo đề thi");
        thoigianlambai.focus();
        return;
    }


    showLoading();
    showSuccessBox("successBox", "message-success", "Thành công, quá trình tạo đề thi hoàn tất.");
    const table = document.getElementById("table-taodethi");
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

    // Display checked rows (for demonstration)
    checkedRows.forEach((row, index) => {
        const cells = Array.from(row.cells).map(cell => cell.innerText);
        console.log(`Row ${index + 1}:`, cells[0]);
    });
}

function checkPositiveNumber(input) {
    if (input.value < 0) {
        input.value = ""; // Clear the input if it's negative
    }
}