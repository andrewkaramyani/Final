function AddNewDepartment(url) {
    $.ajax({
        type: "GET",
        url: url,
        dataType: 'html',
        success: function (data) {
            $('#DepartmentPage #DepartmentModalBody').html(data);
            $('#DepartmentPage #btnDepartmentModal').click();
            $("#DepartmentPage form").removeData("validator");
            $("#DepartmentPage form").removeData("unobtrusiveValidation");
            $.validator.unobtrusive.parse("form");
        }
    });
}
function EditDepartment(DepartmentId, url) {
    $.ajax({
        type: "GET",
        url: url,
        dataType: "html",
        data: { id: DepartmentId },
        success: function (data) {
            //$('#DepartmentModalLabel').html("Edit Department");
            $('#DepartmentPage #DepartmentUpdateModalBody').html(data);
            $('#DepartmentPage #btnUpdateDepartmentModal').click();
            $("#DepartmentPage form").removeData("validator");
            $("#DepartmentPage form").removeData("unobtrusiveValidation");
            $.validator.unobtrusive.parse("form");
        }
    });
}
function DeleteDepartment(DepartmentId, url) {
    $.ajax({
        type: "Get",
        url: url,
        data: { id: DepartmentId },
        dataType: 'html',
        success: function (data) {
            $('#DepartmentPage #Departments').html(data);
        }
    });
}
function AddNewEmployee(url) {
    $.ajax({
        type: "GET",
        url: url,
        dataType: 'html',
        success: function (data) {
            $('#EmployeePage #EmployeeModalBody').html(data);
            $('#EmployeePage #btnEmployeeModal').click();
            $("form").removeData("validator");
            $("form").removeData("unobtrusiveValidation");
            $.validator.unobtrusive.parse($('form'));
        }
    });
}
function EditEmployee(EmployeeId, url) {
    $.ajax({
        type: "GET",
        url: url,
        dataType: "html",
        data: { id: EmployeeId },
        success: function (data) {
            //$('#EmployeeModalLabel').html("Edit Employee");
            $('#EmployeePage #EmployeeModalBody').html(data);
            $('#EmployeePage #btnEmployeeModal').click();
            $("#EmployeePage form").removeData("validator");
            $("#EmployeePage form").removeData("unobtrusiveValidation");
            $.validator.unobtrusive.parse("#EmployeesPage form");
        }
    });
}
function DeleteEmployee(EmployeeId, url) {
    $.ajax({
        type: "Delete",
        url: url,
        data: { id: EmployeeId },
        dataType: 'html',
        success: function (data) {
            $('#EmployeePage #Employees').html(data);
        }
    });
}

function AddNewSection(url) {
    $.ajax({
        type: "GET",
        url: url,
        dataType: 'html',
        success: function (data) {
            $('#SectionPage #SectionModalBody').html(data);
            $('#SectionPage #btnSectionModal').click();
            $("#SectionPage form").removeData("validator");
            $("#SectionPage form").removeData("unobtrusiveValidation");
            $.validator.unobtrusive.parse("form");
        }
    });
}
function EditSection(SectionId, url) {
    $.ajax({
        type: "GET",
        url: url,
        dataType: "html",
        data: { id: SectionId },
        success: function (data) {
            //$('#SectionModalLabel').html("Edit Section");
            $('#SectionPage #SectionUpdateModalBody').html(data);
            $('#SectionPage #btnUpdateSectionModal').click();
            $("#SectionPage form").removeData("validator");
            $("#SectionPage form").removeData("unobtrusiveValidation");
            $.validator.unobtrusive.parse("form");
        }
    });
}
function DeleteSection(SectionId, url) {
    $.ajax({
        type: "Get",
        url: url,
        data: { id: SectionId },
        dataType: 'html',
        success: function (data) {
            $('#SectionPage #Sections').html(data);
        }
    });
}

function AddNewSubSection(url) {
    $.ajax({
        type: "GET",
        url: url,
        dataType: 'html',
        success: function (data) {
            $('#SubSectionPage #SubSectionModalBody').html(data);
            $('#SubSectionPage #btnSubSectionModal').click();
            $("#SubSectionPage form").removeData("validator");
            $("#SubSectionPage form").removeData("unobtrusiveValidation");
            $.validator.unobtrusive.parse("form");
        }
    });
}
function EditSubSection(SubSectionId, url) {
    $.ajax({
        type: "GET",
        url: url,
        dataType: "html",
        data: { id: SubSectionId },
        success: function (data) {
            //$('#SubSectionModalLabel').html("Edit SubSection");
            $('#SubSectionPage #SubSectionUpdateModalBody').html(data);
            $('#SubSectionPage #btnUpdateSubSectionModal').click();
            $("#SubSectionPage form").removeData("validator");
            $("#SubSectionPage form").removeData("unobtrusiveValidation");
            $.validator.unobtrusive.parse("form");
        }
    });
}
function DeleteSubSection(SubSectionId, url) {
    $.ajax({
        type: "Get",
        url: url,
        data: { id: SubSectionId },
        dataType: 'html',
        success: function (data) {
            $('#SubSectionPage #SubSections').html(data);
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







