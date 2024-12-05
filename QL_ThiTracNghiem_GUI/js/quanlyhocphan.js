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
