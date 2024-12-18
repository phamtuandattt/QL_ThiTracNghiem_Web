function ImportDSSinhVien() {
    const excel_file = document.getElementById('excel_file');
    excel_file.click();

    excel_file.addEventListener('change', (event) => {
    
        if (!['application/vnd.openxmlformats-officedocument.spreadsheetml.sheet', 'application/vnd.ms-excel'].includes(event.target.files[0].type)) {
            document.getElementById('excel_data').innerHTML = '<div class="alert alert-danger">Only .xlsx or .xls file format are allowed</div>';
    
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
                var table_output = '<table id="tblDSSinhVienLopHoc" class="tblDSSinhVienLopHoc">';
    
                for (var row = 0; row < sheet_data.length; row++) {
    
                    if (row == 0) {
                        table_output += '<thead>'
                    }
                    table_output += '<tr>';
    
                    for (var cell = 0; cell < sheet_data[row].length; cell++) {
    
                        if (row == 0) {
    
                            table_output += '<th onclick="sortTable('+ cell +')">' + sheet_data[row][cell] + '</th>';
    
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
    
                document.getElementById('excel_data').innerHTML = table_output;
            }
    
            excel_file.value = '';
    
        }
    
    });
    
}


function sortTable(columnIndex) {
    const table = document.getElementById("tblDSSinhVienLopHoc");
    const rows = Array.from(table.rows).slice(1); // Get all rows except the header
    const isAscending = table.querySelectorAll("th")[columnIndex].classList.toggle("sorted-asc");

    // Clear other sorted column classes
    table.querySelectorAll("th").forEach((th, index) => {
        if (index !== columnIndex) {
            th.classList.remove("sorted-asc", "sorted-desc");
        }
    });
    if (!isAscending) {
        table.querySelectorAll("th")[columnIndex].classList.replace("sorted-asc", "sorted-desc");
    }

    // Determine sort direction
    const direction = isAscending ? 1 : -1;

    rows.sort((a, b) => {
        const cellA = a.cells[columnIndex].innerText;
        const cellB = b.cells[columnIndex].innerText;

        const valA = isNaN(cellA) ? cellA : parseFloat(cellA);
        const valB = isNaN(cellB) ? cellB : parseFloat(cellB);

        return valA > valB ? direction : valA < valB ? -direction : 0;
    });

    // Append sorted rows back to the table
    rows.forEach(row => table.tBodies[0].appendChild(row));
}