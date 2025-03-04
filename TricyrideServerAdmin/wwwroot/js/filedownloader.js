window.downloadFile = function (fileUrl, fileName) {
    var link = document.createElement('a');
    link.href = fileUrl; // The URL of the file
    link.download = fileName; // The name you want the file to have when downloaded
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
};