document.querySelectorAll('.sidebar-item').forEach(item => {
    item.addEventListener('click', function() {
        document.querySelector('.sidebar-item.active').classList.remove('active');
        this.classList.add('active');
    });
});
