// variable urlSales generated in _Layout.cshtml

//Dropzone configuration
Dropzone.options.homeDropzone = {
  dictDefaultMessage: 'Drop transaction file here or click to upload',
  maxFiles: 1,
  addRemoveLinks: true,
  init: function () {
    //allow only one file before post
    this.on('addedfile',
      function(file) {
        if (this.files[1] != null) {
          this.removeFile(this.files[0]);
        }
      });
    //clear file from server session 
    this.on('removedfile',
      function (file) {
        var form = $('#home-dropzone');
        var url = form.attr('action');
        $.ajax({ type: 'POST', url: url });
      });
    //redirects to sales summary after file upload
    this.on('success',
      function (file, response) {
        window.location.href = urlSales;
      });
    // wrong file uploaded
    this.on('error',
      function (file, response) {
        $(file.previewElement).find('.dz-error-message').text('File not processed.');
      });
  }
};

$(function () {
  //Configures dropzone to show if file exists in session
  if (typeof fileName != 'undefined' && fileName !== null && fileName !== '') {
    var mockFile = { name: fileName, size: fileSize };

    var homeDropzone = Dropzone.forElement('#home-dropzone');
    homeDropzone.emit('addedfile', mockFile);
    homeDropzone.emit('complete', mockFile);
    homeDropzone.options.maxFiles = 1;
    homeDropzone.files.push(mockFile);
  }
})

