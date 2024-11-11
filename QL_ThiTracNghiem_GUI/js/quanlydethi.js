document.addEventListener("DOMContentLoaded", function () {
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
    selectElement.addEventListener("change", function () {
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


function exportToPDFs() {
    // Get content from HTML
    const element = document.getElementById('container-export-pdf');
    element.style.display = 'block';

    document.querySelector("#container-export-pdf > div.pdf-header > div.pdf-header-left").innerHTML = 'BỘ CÔNG THƯƠNG <br>TRƯỜNG ĐẠI HỌC CÔNG THƯƠNG';
    document.querySelector("#container-export-pdf > div.pdf-header > div.pdf-header-right").innerHTML = 'CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM <br>Độc lập - Tự do - Hạnh phúc <br> <br>HCM, Ngày ... tháng ... năm ...';
    document.querySelector("#ten-mon-hoc").innerHTML = '<b>Môn:</b> ' + document.querySelector('#lbl-hocphan').textContent.toUpperCase();
    document.querySelector("#thoi-gian-lam-bai").innerHTML = 'Thời gian làm bài: ' + document.querySelector("#lbl-thoigianlambai").textContent + 'phút';
    document.querySelector("#made").innerHTML = '<b>Mã đề: ' + document.getElementById("option-madethi").value + '</b>';

    const rows = document.querySelectorAll("#table-danhsachcauhoidethi tbody tr");
    rows.forEach((r) => {
        const row = r.closest("tr");
        const r_content = [];
        for (let cell of row.cells) {
            r_content.push(cell.textContent.trim());
        }

        $("#pdf-content").append(
            '<div class=\"question-box\">' +
                '<div id=\"question-box__question\" class=\"question-box__question\"><b>Câu ' + r_content[0].trim() + ':</b> ' + r_content[1].trim() + ' </div>' +
                '<div class=\"question-box__answers\"><div class=\"question-box__answer\"><b>A. </b>' + r_content[2].trim() + '</div>' +
                '<div class=\"question-box__answers\"><div class=\"question-box__answer\"><b>B. </b>' + r_content[3].trim() + '</div>' +
                '<div class=\"question-box__answers\"><div class=\"question-box__answer\"><b>C. </b>' + r_content[4].trim() + '</div>' +
                '<div class=\"question-box__answers\"><div class=\"question-box__answer\"><b>D. </b>' + r_content[5].trim() + '</div>' +
            '</div>'
        );
    });
    
    const filename = document.querySelector("#lbl-hocphan").textContent + '_' + 
                        document.getElementById("option-madethi").value + '_' + 
                        document.querySelector("#lbl-ngaytaodethi").textContent;

    const options = {
        margin: 1,
        filename: filename + '.pdf',
        image: { type: 'jpeg', quality: 0.98 },
        html2canvas: { scale: 2 },
        jsPDF: { unit: 'in', format: 'letter', orientation: 'portrait' }
    };
    // Promise-based usage:
    html2pdf().set(options).from(element).save();

    setTimeout(() => {
        element.style.display = 'none';
    }, 5000); 
}