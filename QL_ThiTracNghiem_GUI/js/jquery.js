
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
