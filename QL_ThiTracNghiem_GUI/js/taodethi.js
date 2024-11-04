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
    document.getElementById('overlay').style.display = 'block';
    document.getElementById('quantityDialog').style.display = 'block';
}

function closeQuantityDialog() {
    // Hide the overlay and dialog
    document.getElementById('overlay').style.display = 'none';
    document.getElementById('quantityDialog').style.display = 'none';
}