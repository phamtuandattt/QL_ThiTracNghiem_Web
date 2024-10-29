document.addEventListener("DOMContentLoaded", function() {
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

    if (questionId === 1) {
        questionDetail.innerHTML = `
            <p>Khi kiểm định cầu đường sắt, công tác tổ chức đoàn hoạt tải dành riêng để thử tải mô
               phỏng sơ đồ hoạt tải đứng yên ở trên cầu được thực hiện ít nhất bao nhiêu lần?
               Khi kiểm định cầu đường sắt, công tác tổ chức đoàn hoạt tải dành riêng để thử tải mô
               phỏng sơ đồ hoạt tải đứng yên ở trên cầu được thực hiện ít nhất bao nhiêu lần?</p>`;
        document.getElementById("answerOptions").innerHTML = `
            <label><input type="radio" name="answer" value="1"> 2 lần</label><br>
            <label><input type="radio" name="answer" value="2"> 3 lần</label><br>
            <label><input type="radio" name="answer" value="3"> 4 lần</label><br>
            <label><input type="radio" name="answer" value="4"> 5 lần</label><br>`;
    } else if (questionId === 2) {
        questionDetail.innerHTML = `
            <p>Công tác kiểm định cầu đường bộ, kiểm tra tải trọng phải được thực hiện tối thiểu bao nhiêu lần?</p>`;
        document.getElementById("answerOptions").innerHTML = `
            <label><input type="radio" name="answer" value="1"> 1 lần</label><br>
            <label><input type="radio" name="answer" value="2"> 2 lần</label><br>
            <label><input type="radio" name="answer" value="3"> 3 lần</label><br>
            <label><input type="radio" name="answer" value="4"> 4 lần</label><br>`;
    }
}
