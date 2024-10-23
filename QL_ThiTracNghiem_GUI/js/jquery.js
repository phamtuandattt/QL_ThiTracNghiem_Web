
function toggleSidebar() {
    var sidebar = document.querySelector('.sidebar');
    sidebar.classList.toggle('expanded');

    var btntogle = document.querySelector('.toggle-btn');
    btntogle.classList.toggle('expanded');
    
    var toggleBtn = document.querySelector('.toggle-btn span');
    if (sidebar.classList.contains('expanded')) {
        toggleBtn.innerHTML = '&#10094;'; // Collapse icon
    } else {
        toggleBtn.innerHTML = '&#10095;'; // Expand icon
    }
}
