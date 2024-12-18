function toggleCollapse(row) {
    const allContentRows = document.querySelectorAll(".collapsible-content");
    const allHeaderRows = document.querySelectorAll(".collapsible-header");

    // Hide all collapsible rows
    allContentRows.forEach(contentRow => {
        contentRow.style.maxHeight = null;
        contentRow.style.opacity = 0;
        contentRow.style.display = "none";
    });

    allHeaderRows.forEach(headerRow => {
        headerRow.classList.remove("expanded");
    });

    // Find the next sibling row (collapsible content)
    const nextRow = row.nextElementSibling;

    if (nextRow && nextRow.classList.contains("collapsible-content")) {
        const isCurrentlyVisible = nextRow.style.display === "table-row";

        if (!isCurrentlyVisible) {
            nextRow.style.display = "table-row";
            setTimeout(() => {
                nextRow.style.maxHeight = nextRow.scrollHeight + "px";
                nextRow.style.opacity = 1;
            }, 0);
            row.classList.add("expanded");
        } else {
            nextRow.style.maxHeight = null;
            nextRow.style.opacity = 0;
            setTimeout(() => {
                nextRow.style.display = "none";
            }, 600); // Match the transition duration
        }
    }

    // Remove highlight class from all rows
    const rows = document.querySelectorAll("tbody tr");
    rows.forEach(r => r.classList.remove("highlight"));

    // Add highlight class to the clicked row
    row.classList.add("highlight");
}

function unShowDetail() {
    const allContentRows = document.querySelectorAll(".collapsible-content");
    const allHeaderRows = document.querySelectorAll(".collapsible-header");

    // Hide all collapsible rows
    allContentRows.forEach(contentRow => {
        contentRow.style.maxHeight = null;
        contentRow.style.opacity = 0;
        contentRow.style.display = "none";
    });

    allHeaderRows.forEach(headerRow => {
        headerRow.classList.remove("expanded");
    });

}



/*
 *   This content is licensed according to the W3C Software License at
 *   https://www.w3.org/Consortium/Legal/2015/copyright-software-and-document
 *
 *   File:   tabs-automatic.js
 *
 *   Desc:   Tablist widget that implements ARIA Authoring Practices
 */

'use strict';

class TabsAutomatic {
    constructor(groupNode) {
        this.tablistNode = groupNode;

        this.tabs = [];

        this.firstTab = null;
        this.lastTab = null;

        this.tabs = Array.from(this.tablistNode.querySelectorAll('[role=tab]'));
        this.tabpanels = [];

        for (var i = 0; i < this.tabs.length; i += 1) {
            var tab = this.tabs[i];
            var tabpanel = document.getElementById(tab.getAttribute('aria-controls'));

            tab.tabIndex = -1;
            tab.setAttribute('aria-selected', 'false');
            this.tabpanels.push(tabpanel);

            tab.addEventListener('keydown', this.onKeydown.bind(this));
            tab.addEventListener('click', this.onClick.bind(this));

            if (!this.firstTab) {
                this.firstTab = tab;
            }
            this.lastTab = tab;
        }

        this.setSelectedTab(this.firstTab, false);
    }

    setSelectedTab(currentTab, setFocus) {
        if (typeof setFocus !== 'boolean') {
            setFocus = true;
        }
        for (var i = 0; i < this.tabs.length; i += 1) {
            var tab = this.tabs[i];
            if (currentTab === tab) {
                tab.setAttribute('aria-selected', 'true');
                tab.removeAttribute('tabindex');
                this.tabpanels[i].classList.remove('is-hidden');
                if (setFocus) {
                    tab.focus();
                }
            } else {
                tab.setAttribute('aria-selected', 'false');
                tab.tabIndex = -1;
                this.tabpanels[i].classList.add('is-hidden');
            }
        }
    }

    setSelectedToPreviousTab(currentTab) {
        var index;

        if (currentTab === this.firstTab) {
            this.setSelectedTab(this.lastTab);
        } else {
            index = this.tabs.indexOf(currentTab);
            this.setSelectedTab(this.tabs[index - 1]);
        }
    }

    setSelectedToNextTab(currentTab) {
        var index;

        if (currentTab === this.lastTab) {
            this.setSelectedTab(this.firstTab);
        } else {
            index = this.tabs.indexOf(currentTab);
            this.setSelectedTab(this.tabs[index + 1]);
        }
    }

    /* EVENT HANDLERS */

    onKeydown(event) {
        var tgt = event.currentTarget,
            flag = false;

        switch (event.key) {
            case 'ArrowLeft':
                this.setSelectedToPreviousTab(tgt);
                flag = true;
                break;

            case 'ArrowRight':
                this.setSelectedToNextTab(tgt);
                flag = true;
                break;

            case 'Home':
                this.setSelectedTab(this.firstTab);
                flag = true;
                break;

            case 'End':
                this.setSelectedTab(this.lastTab);
                flag = true;
                break;

            default:
                break;
        }

        if (flag) {
            event.stopPropagation();
            event.preventDefault();
        }
    }

    onClick(event) {
        this.setSelectedTab(event.currentTarget);
    }
}

// Initialize tablist
window.addEventListener('load', function () {
    var tablists = document.querySelectorAll('[role=tablist].automatic');
    for (var i = 0; i < tablists.length; i++) {
        new TabsAutomatic(tablists[i]);
    }
});


// function saveData() {
//     const dataFields = document.querySelectorAll(".info-data");
//     const updatedData = {};

//     dataFields.forEach(field => {
//         const title = field.previousElementSibling.innerText.replace(":", "");
//         updatedData[title] = field.value;
//     });

//     console.log("Updated Data:", updatedData);
//     alert("Data saved! Check the console for updated values.");
// }

function addData() {
    const inputs = document.querySelectorAll('.info-data');
    inputs.forEach(input => {
        input.value = ''; // Clear the value of each input field
    });

    // Enable all input fields and dropdowns
    inputs.forEach(input => {
        if (input.tagName === "INPUT") {
            input.removeAttribute("readonly");
        } else if (input.tagName === "SELECT") {
            input.removeAttribute("disabled");
        }
    });

    document.getElementById("importDSSV").style.display = "inline-block";
    document.getElementById("addData").style.display = "none";
    document.getElementById("editData").style.display = "none";
    document.getElementById("saveData").style.display = "inline-block";
}

function enableEdit() {
    // Enable all input fields and dropdowns
    const inputs = document.querySelectorAll(".info-data");
    inputs.forEach(input => {
        if (input.tagName === "INPUT") {
            input.removeAttribute("readonly");
        } else if (input.tagName === "SELECT") {
            input.removeAttribute("disabled");
        }
    });
    document.getElementById("importDSSV").style.display = "inline-block";
    document.getElementById("addData").style.display = "none";
    document.getElementById("editData").style.display = "none";
    document.getElementById("saveData").style.display = "inline-block";
}

function saveData() {
    // Collect updated data
    const inputs = document.querySelectorAll(".info-data");
    const updatedData = {};
    inputs.forEach(input => {
        const title = input.previousElementSibling.innerText.replace(":", "");

        if (input.tagName === "INPUT") {
            updatedData[title] = input.value;
            input.setAttribute("readonly", true); // Disable editing
        } else if (input.tagName === "SELECT") {
            updatedData[title] = input.options[input.selectedIndex].text;
            input.setAttribute("disabled", true); // Disable editing
        }
    });

    console.log("Updated Data:", updatedData);

    // Show Edit button and hide Save button
    document.getElementById("importDSSV").style.display = "none";
    document.getElementById("addData").style.display = "inline-block";
    document.getElementById("editData").style.display = "inline-block";
    document.getElementById("saveData").style.display = "none";

    alert("Data saved! Check the console for updated values.");
}

function ImportDSSinhVienIntoLopHocPhan() {
    const excel_file = document.getElementById('excel_file');
    excel_file.click();

    excel_file.addEventListener('change', (event) => {

        if (!['application/vnd.openxmlformats-officedocument.spreadsheetml.sheet', 'application/vnd.ms-excel'].includes(event.target.files[0].type)) {
            document.getElementById('ds-sinhvien-thamgialop-container').innerHTML = '<div class="alert alert-danger">Only .xlsx or .xls file format are allowed</div>';

            excel_file.value = '';

            return false;
        }

        var reader = new FileReader();

        reader.readAsArrayBuffer(event.target.files[0]);

        reader.onload = function (event) {

            var data = new Uint8Array(reader.result);

            var work_book = XLSX.read(data, { type: 'array' });

            var sheet_name = work_book.SheetNames;

            var sheet_data = XLSX.utils.sheet_to_json(work_book.Sheets[sheet_name[0]], { header: 1 });

            if (sheet_data.length > 0) {
                var table_output = '<table id="tblDSSinhvienThamGia" class="tblDSSinhvienThamGia">';

                for (var row = 0; row < sheet_data.length; row++) {

                    if (row == 0) {
                        table_output += '<thead>'
                    }
                    table_output += '<tr>';

                    for (var cell = 0; cell < sheet_data[row].length; cell++) {

                        if (row == 0) {

                            table_output += '<th onclick="sortTable(' + cell + ')">' + sheet_data[row][cell] + '</th>';

                        }
                        else {

                            table_output += '<td>' + sheet_data[row][cell] + '</td>';

                        }

                    }

                    table_output += '</tr>';
                    if (row == 0) {
                        table_output += '</thead>'
                    }

                }

                table_output += '</table>';

                document.getElementById('ds-sinhvien-thamgialop-container').innerHTML = table_output;
            }

            excel_file.value = '';

        }

    });

}
