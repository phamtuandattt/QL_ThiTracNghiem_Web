document.querySelectorAll('.sidebar-item').forEach(item => {
    item.addEventListener('click', function() {
        document.querySelector('.sidebar-item.active').classList.remove('active');
        this.classList.add('active');
    });
});

// JavaScript to toggle the dropdown visibility
document.querySelector('.profile-button').addEventListener('click', function() {
    const dropdown = document.querySelector('.profile-dropdown');
    dropdown.classList.toggle('open');
});

//Close the dropdown if you click outside of it
document.addEventListener('click', function(e) {
    const profileDropdown = document.querySelector('.profile-dropdown');
    if (!profileDropdown.contains(e.target)) {
        profileDropdown.classList.remove('open');
    }
});
