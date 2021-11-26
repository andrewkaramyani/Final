function AddNewCourse(url) {
    $.ajax({
        type: "GET",
        url: url,
        dataType: 'html',
        success: function (data) {
            $('#EmployeePage #EmployeeModalBody').html(data);
            $('#EmployeePage #btnEmployeeModal').click();
            $("#EmployeePage form").removeData("validator");
            $("#EmployeePage form").removeData("unobtrusiveValidation");
            $.validator.unobtrusive.parse("form");
        }
    });
}
function EditCourse(courseId, url) {
    $.ajax({
        type: "GET",
        url: url,
        dataType: "html",
        data: { courseID: courseId },
        success: function (data) {
            //$('#CourseModalLabel').html("Edit course");
            $('#EmployeePage #CourseModalBody').html(data);
            $('#EmployeePage #btnCourseModal').click();
            $("#EmployeePage form").removeData("validator");
            $("#EmployeePage form").removeData("unobtrusiveValidation");
            $.validator.unobtrusive.parse("#coursesPage form");
        }
    });
}
function DeleteCourse(courseId, url) {
    $.ajax({
        type: "Delete",
        url: url,
        data: {  CourseId: courseId},
        dataType: 'html',
        success: function (data) {
            $('#EmployeePage #Employees').html(data); 
        }
    });
}


//function AddNewCourse(url,PageId,ModalId,BtnId) {
//    $.ajax({
//        type: "GET",
//        url: url,
//        dataType: 'html',
//        success: function (data) {
//            debugger;
//            $(PageId + " " +ModalId).html(data);
//            $(PageId+" "+ BtnId).click();
//            $(PageId+" form").removeData("validator");
//            $(PageId + " form").removeData("unobtrusiveValidation");
//            $.validator.unobtrusive.parse(PageId+" form");
//        }
//    });
//}
//function EditCourse(courseId, PageId, ModalId, BtnId) {
//    $.ajax({
//        type: "GET",
//        url: url,
//        dataType: "html",
//        data: { courseID: courseId },
//        success: function (data) {
//            //$('#CourseModalLabel').html("Edit course");
//            $(PageId + " " + ModalId).html(data);
//            $(PageId + " " + BtnId).click();
//            $(PageId + " form").removeData("validator");
//            $(PageId + " form").removeData("unobtrusiveValidation");
//            $.validator.unobtrusive.parse(PageId + " form");
//        }
//    });
//}

//function DeleteCourse(courseId, url,PageId,DataId) {
//    $.ajax({
//        type: "Delete",
//        url: url,
//        data: {  CourseId: courseId},
//        dataType: 'html',
//        success: function (data) {
//            $(PageId+" "+DataId).html(data); 
//        }
//    });
//}







