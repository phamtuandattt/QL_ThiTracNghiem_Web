
async function exportExcelWithExcelJS() {
    // Step 1: Create a new workbook and worksheet
    const workbook = new ExcelJS.Workbook();
    const worksheet = workbook.addWorksheet("Exam Details");

    // Step 2: Add Title
    worksheet.mergeCells('A1:G1'); // Merge cells for the title
    const titleCell = worksheet.getCell('A1');
    titleCell.value = "Exam Title";
    titleCell.alignment = { vertical: 'middle', horizontal: 'center' };
    titleCell.font = { size: 25, bold: true };

    // Step 3: Add Exam Information
    worksheet.mergeCells('A3:G3'); // Merge cells for the exam information
    const infoCell = worksheet.getCell('A3');
    infoCell.value = "Exam Information";
    infoCell.alignment = { vertical: 'middle', horizontal: 'center' };
    infoCell.font = { size: 20, bold: true };

    // Step 4: Add Headers
    const headers = ["Column 1", "Column 2", "Column 3", "Column 4", "Column 5", "Column 6", "Column 7"];
    worksheet.addRow();
    worksheet.addRow(headers);
    const headerRow = worksheet.getRow(5); // The 5th row contains headers
    headerRow.font = { bold: true };
    headerRow.alignment = { horizontal: 'center', vertical: 'middle' };
    headerRow.eachCell((cell) => {
        cell.fill = {
            type: 'pattern',
            pattern: 'solid',
            fgColor: { argb: 'D9EAD3' }, // Light green background
        };
    });

    // Step 5: Add Table Data
    const rows = [
        ["Row 1 - Col 1", "Row 1 - Col 2", "Row 1 - Col 3", "Row 1 - Col 4", "Row 1 - Col 5", "Row 1 - Col 6", "Row 1 - Col 7"],
        ["Row 2 - Col 1", "Row 2 - Col 2", "Row 2 - Col 3", "Row 2 - Col 4", "Row 2 - Col 5", "Row 2 - Col 6", "Row 2 - Col 7"],
        ["Row 3 - Col 1", "Row 3 - Col 2", "Row 3 - Col 3", "Row 3 - Col 4", "Row 3 - Col 5", "Row 3 - Col 6", "Row 3 - Col 7"],
    ];
    rows.forEach((row) => worksheet.addRow(row));

    // Step 6: Style Table Rows
    worksheet.getColumn(1).width = 50; // Set column width for better readability
    worksheet.columns.forEach((column) => {
        column.width = 15; // Set default column width
        column.alignment = { horizontal: 'center', vertical: 'middle' }; // Align all cells
    });

    // Step 7: Save Workbook
    const buffer = await workbook.xlsx.writeBuffer();
    const blob = new Blob([buffer], { type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" });
    const link = document.createElement("a");
    link.href = URL.createObjectURL(blob);
    link.download = "ExamDetails.xlsx";
    link.click();
}