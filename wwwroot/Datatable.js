


    $('#tbl3').DataTable({
        buttons: [
    {
        extend: 'pdf',
    text: 'Save current page',
    exportOptions: {
        modifier: {
        page: 'current'
                }
            }
        }
    ]
});




//$('#tbl3').DataTable({
//    buttons: [
//        {
//            extend: 'pdf',
//            text: 'Save current page',
//            exportOptions: {
//                modifier: {
//                    page: 'current'
//                }
//            }
//        }
//    ]
//});