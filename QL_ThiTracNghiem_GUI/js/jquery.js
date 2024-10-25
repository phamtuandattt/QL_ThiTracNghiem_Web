
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
    document.getElementById('popup-title').innerText = name;
    document.getElementById('popup-info').innerText = 'Age: ' + age;
    
    popup.classList.add('show'); // Add the 'show' class to display the popup
}
// Function to close the popup with a fade-out effect
function closePopup() {
    const popup = document.getElementById('popup');
    popup.classList.remove('show'); // Start the fade-out transition
}
