function downloadFile(base64Data, filename) {
    const link = document.createElement('a');
    link.href = base64Data;
    link.download = filename; // Set the desired filename
    document.body.appendChild(link);
    link.click(); // Simulate a click to download
    document.body.removeChild(link); // Clean up
}