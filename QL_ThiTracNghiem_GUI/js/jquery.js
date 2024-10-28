
function toggleSidebar() {
    var sidebar = document.querySelector('.sidebar');
    sidebar.classList.toggle('expanded');

    var btntogle = document.querySelector('.toggle-btn');
    btntogle.classList.toggle('expanded');

    const element = document.querySelector("body > div > div.content")
    var toggleBtn = document.querySelector('.toggle-btn span');
    if (sidebar.classList.contains('expanded')) {
        // toggleBtn.innerHTML = '&#10094;'; // Collapse icon
        element.style.margin = '0 0 0 270px';
        element.style.transition = 'margin 0.3s ease'
    } else {
        // toggleBtn.innerHTML = '&#10095;'; // Expand icon
        element.style.margin = '0 0 0 80px';
        element.style.transition = 'margin 0.3s ease'
    }
}

function showPopup(name, age) {
    const popup = document.getElementById('popup');
    document.getElementById('popup-title').innerText = 'Nội dung câu hỏi';

    popup.classList.add('show'); // Add the 'show' class to display the popup
}

// Function to close the popup with a fade-out effect
function closePopup() {
    const popup = document.getElementById('popup');

    const radioButtons = document.querySelectorAll('#popup-answer input[type="radio"]');
    radioButtons.forEach(radio => {
        radio.disabled = true;
    });
    
    popup.classList.remove('show'); // Start the fade-out transition  
}

function enableEditing() {
    // Get all radio buttons in the form
    const radioButtons = document.querySelectorAll('#popup-answer input[type="radio"]');
    // Enable each radio button
    radioButtons.forEach(radio => {
        radio.disabled = false;
    });
}

function disableEditing() {
    const radioButtons = document.querySelectorAll('#popup-answer input[type="radio"]');
    radioButtons.forEach(radio => {
        radio.disabled = true;
    });
}

document.addEventListener("DOMContentLoaded", function() {
    const image = document.getElementById("img-question");
    const container_img_question = document.getElementById("image-section");
    // Check if `src` attribute has a value
    if (image.src == "" || image.src.endsWith("/")) {
        // If `src` is empty or invalid, hide the image
        container_img_question.style.display = "none";
    } else {
        // Show the image if `src` has a valid value
        container_img_question.style.display = "block";
    }
});

document.addEventListener("DOMContentLoaded", function() {
    const tableBody = document.querySelector("#recordsTable tbody");
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

    // Example of dynamically adding rows for testing
    // Uncomment to see how rows affect the message display
    // tableBody.innerHTML += "<tr><td>1</td><td>1001</td><td>Example Name</td><td>501</td><td>201</td><td>Yes</td><td>No</td></tr>";
    // checkTableRows();

    const selectElement = document.getElementById("options");

    // Add an event listener for the `change` event
    selectElement.addEventListener("change", function() {
        const selectedValue = selectElement.value;
        
        if (selectedValue == "option2") {
            const tableBody = document.querySelector("#recordsTable tbody");
            tableBody.innerHTML = "";
            checkTableRows();
        } else {
            const tableBody = document.querySelector("#recordsTable tbody");
            tableBody.innerHTML += "<tr onclick=\"showPopup('ABC','abcc')\"> <td>1</td> <td><p class=\"an\">Nhà Nam có 4 anh chị em, 3 người lớn tên là Xuân, Hạ, Thu. Đố bạn người emút tên gì?</p></td><td>Người em út tên Nam</td><td>30/12/2022</td><td>30/12/2022</td></tr><tr><td>2</td><td><p class=\"an\">Đố bạn khi Beckham thực hiện quả đá phạt đền, anh ta sẽ sút vào đâu?</p></td><td>Anh ta sẽ sút vào bóng</td><td>30/12/2022</td><td>30/12/2022</td></tr><tr><td>3</td><td><p class=\"an\">Một ly thuỷ tinh đựng đầy nước, làm thế nào để lấy nước dưới đáy ly mà không đổ nước ra ngoài ?</p></td><td>Ống hút</td><td>30/12/2022</td><td>30/12/2022</td></tr><tr><td>4</td><td><p class=\"an\">Cầm trên tay một cây thước và một cây bút , làm thế nào để bạn vẽ được mộtvòng tròn thật chính xác?</p></td><td>Bỏ cây thước đi và cầm compa lên để vẽ.</td><td>30/12/2022</td><td>30/12/2022</td></tr><tr><td>5</td><td><p class=\"an\">Bạn đang ở trong một cuộc đua và bạn vừa vượt qua người thứ nhì . Vậy bâygiờ bạn đang ở vị trí nào trong đoàn đua ấy?Bạn đang ở trong một cuộc đua và bạn vừavượt qua người thứ nhì . Vậy bây giờ bạn đang ở vị trí nào trong đoàn đua ấy?Bạnđang ở trong một cuộc đua và bạn vừa vượt qua người thứ nhì . Vậy bây giờ bạn đang ởvị trí nào trong đoàn đua ấy?Bạn đang ở trong một cuộc đua và bạn vừa vượt qua ngườithứ nhì . Vậy bây giờ bạn đang ở vị trí nào trong đoàn đua ấy?</p></td><td>Thứ nhì.</td><td>30/12/2022</td><td>30/12/2022</td></tr><tr><td>6</td><td><p class=\"an\">Bạn đang ở trong một cuộc đua và bạn vừa vượt qua người thứ nhì . Vậy bâygiờ bạn đang ở vị trí nào trong đoàn đua ấy?Bạn đang ở trong một cuộc đua và bạn vừavượt qua người thứ nhì . Vậy bây giờ bạn đang ở vị trí nào trong đoàn đua ấy?Bạnđang ở trong một cuộc đua và bạn vừa vượt qua người thứ nhì . Vậy bây giờ bạn đang ởvị trí nào trong đoàn đua ấy?Bạn đang ở trong một cuộc đua và bạn vừa vượt qua ngườithứ nhì . Vậy bây giờ bạn đang ở vị trí nào trong đoàn đua ấy?</p></td><td>Thứ nhì.</td><td>30/12/2022</td>                            <td>30/12/2022</td>                        </tr>";
            checkTableRows();
        }
    });
});
