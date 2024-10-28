
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