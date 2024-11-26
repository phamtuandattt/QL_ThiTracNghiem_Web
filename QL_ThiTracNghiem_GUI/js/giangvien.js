function showAccountPanel() {
    document.getElementById('content-account-gv').style.display = 'block';
    document.getElementById('content-information-gv').style.display = 'none';
}

function showInformationPanel() {
    document.getElementById('content-information-gv').style.display = 'block';
    document.getElementById('content-account-gv').style.display = 'none';
}

function changeAvata() {
    const profilePicture = document.getElementById('profilePicture');
    const fileInput = document.getElementById('fileInput');
    fileInput.click();

    fileInput.addEventListener('change', (event) => {
        const file = event.target.files[0];
        if (file) {
          const reader = new FileReader();
  
          // Read the file and set it as the profile picture
          reader.onload = (e) => {
            profilePicture.src = e.target.result;
          };
  
          reader.readAsDataURL(file);
        }
    });
}