mergeInto(LibraryManager.library, {
    Download: function (base64str, fileName) {
        var link = document.createElement('a');
        link.href = 'data:application/octet-stream;base64,' + base64str;
        link.download = UTF8ToString(fileName);
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
    }
});
