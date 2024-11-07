document.addEventListener("DOMContentLoaded", function() {
    const tableBody = document.querySelector("#tbl-danhsachdethidatao tbody");
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

    const selectElement = document.getElementById("option-ds-hocphan");

    // Add an event listener for the `change` event
    selectElement.addEventListener("change", function() {
        const selectedValue = selectElement.value;
        
        if (selectedValue == "option2") {
            const tableBody = document.querySelector("#tbl-danhsachdethidatao tbody");
            tableBody.innerHTML = "";
            checkTableRows();
        } else {
            const tableBody = document.querySelector("#tbl-danhsachdethidatao tbody");
            tableBody.innerHTML += "<tr onclick=\"showPopup('ABC','abcc')\"> <td>1</td> <td><p class=\"an\">Nhà Nam có 4 anh chị em, 3 người lớn tên là Xuân, Hạ, Thu. Đố bạn người emút tên gì?</p></td><td>Người em út tên Nam</td><td>30/12/2022</td><td>30/12/2022</td></tr><tr><td>2</td><td><p class=\"an\">Đố bạn khi Beckham thực hiện quả đá phạt đền, anh ta sẽ sút vào đâu?</p></td><td>Anh ta sẽ sút vào bóng</td><td>30/12/2022</td><td>30/12/2022</td></tr><tr><td>3</td><td><p class=\"an\">Một ly thuỷ tinh đựng đầy nước, làm thế nào để lấy nước dưới đáy ly mà không đổ nước ra ngoài ?</p></td><td>Ống hút</td><td>30/12/2022</td><td>30/12/2022</td></tr><tr><td>4</td><td><p class=\"an\">Cầm trên tay một cây thước và một cây bút , làm thế nào để bạn vẽ được mộtvòng tròn thật chính xác?</p></td><td>Bỏ cây thước đi và cầm compa lên để vẽ.</td><td>30/12/2022</td><td>30/12/2022</td></tr><tr><td>5</td><td><p class=\"an\">Bạn đang ở trong một cuộc đua và bạn vừa vượt qua người thứ nhì . Vậy bâygiờ bạn đang ở vị trí nào trong đoàn đua ấy?Bạn đang ở trong một cuộc đua và bạn vừavượt qua người thứ nhì . Vậy bây giờ bạn đang ở vị trí nào trong đoàn đua ấy?Bạnđang ở trong một cuộc đua và bạn vừa vượt qua người thứ nhì . Vậy bây giờ bạn đang ởvị trí nào trong đoàn đua ấy?Bạn đang ở trong một cuộc đua và bạn vừa vượt qua ngườithứ nhì . Vậy bây giờ bạn đang ở vị trí nào trong đoàn đua ấy?</p></td><td>Thứ nhì.</td><td>30/12/2022</td><td>30/12/2022</td></tr><tr><td>6</td><td><p class=\"an\">Bạn đang ở trong một cuộc đua và bạn vừa vượt qua người thứ nhì . Vậy bâygiờ bạn đang ở vị trí nào trong đoàn đua ấy?Bạn đang ở trong một cuộc đua và bạn vừavượt qua người thứ nhì . Vậy bây giờ bạn đang ở vị trí nào trong đoàn đua ấy?Bạnđang ở trong một cuộc đua và bạn vừa vượt qua người thứ nhì . Vậy bây giờ bạn đang ởvị trí nào trong đoàn đua ấy?Bạn đang ở trong một cuộc đua và bạn vừa vượt qua ngườithứ nhì . Vậy bây giờ bạn đang ở vị trí nào trong đoàn đua ấy?</p></td><td>Thứ nhì.</td><td>30/12/2022</td>                            <td>30/12/2022</td>                        </tr>";
            checkTableRows();
        }
    });
});

function showDetails(questionId) {
    const questionDetail = document.getElementById("questionDetail");
    const row = document.getElementById(questionId);

    let rowContent = [];
    if (row) {
        for (let cell of row.cells) {
            rowContent.push(cell.textContent.trim());
        }
    }
    questionDetail.innerHTML = '<p>' + rowContent[1] + '</p>';
    document.getElementById("answerOptions").innerHTML =
        '<label><input type=\"radio\" name=\"answer\" value=\"1\" disabled ' + ((rowContent[6].trim() === "A") ? "checked" : "") + '>' + rowContent[2] + '</label><br>' +
        '<label><input type=\"radio\" name=\"answer\" value=\"2\" disabled ' + ((rowContent[6].trim() === "B") ? "checked" : "") + '>' + rowContent[3] + '</label><br>' +
        '<label><input type=\"radio\" name=\"answer\" value=\"3\" disabled ' + ((rowContent[6].trim() === "C") ? "checked" : "") + '>' + rowContent[4] + '</label><br>' +
        '<label><input type=\"radio\" name=\"answer\" value=\"4\" disabled ' + ((rowContent[6].trim() === "D") ? "checked" : "") + '>' + rowContent[5] + '</label><br>';

    // Remove highlight class from all rows
    const rows = document.querySelectorAll("tbody tr");
    rows.forEach(r => r.classList.remove("highlight"));

    // Add highlight class to the clicked row
    row.classList.add("highlight");
}


function exportToDocx() {
    // Get content from HTML
    const content = document.getElementById("table-danhsachcauhoidethi").innerHTML;
    
    const wordContent =  content;

    // Create a Blob with MIME type for .docx
    const blob = new Blob([wordContent], {
        type: "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
    });

    // Create a download link
    const link = document.createElement("a");
    link.href = URL.createObjectURL(blob);
    link.download = "example.doc";
    link.click();
}