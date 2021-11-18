﻿var dataTable;

$(document).ready(function () {
	loadDataTable();

});

function loadDataTable() {

	dataTable = $('#DT_load').DataTable({

		"ajax": {
			"url": "/Regionals/GetAll",
			"type": "GET",
			"datatype": "Json"

		},

		"columns": [
			{ "data": "firstname", "width": "20%" },
			{ "data": "lastname", "width": "20%" },
			{ "data": "email", "width": "20%" },
			{ "data": "password", "width": "20%" },
			{ "data": "id","render": function (data) {
					return `<div class="text-center">
						<a href="/Regionals/Insert?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>Edit</a>
						&nbsp;
						<a class='btn btn-danger text-white' style='cursor:pointer; width:70px;'onclick=Delete('/Regionals/Delete?id='+${data})>Delete</a>
						</div>`;
				}, "width": "40%"
			}
		],

		"language": {
			"emptyTable": "no data found"
		},
		"width": "100%"
	});
}

function Delete(url) {
	swal({
		title: "Are you sure?",
		text: "Once deleted, you will not be able to recover",
		icon: "warning",
		buttons: true,
		dangerMode: true
	}).then((willDelete) => {
		if (willDelete) {
			$.ajax({
				type: "DELETE",
				url: url,
				success: function (data) {
					if (data.success) {
						toastr.success(data.message);
						dataTable.ajax.reload();
					}
					else {
						toastr.error(data.message);
					}

				}

			});
		}
	});

}
