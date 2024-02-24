function workingSearch() {
	$(() => {
		getCars();

		$('#txtSearch').on('keyup', () => {
			getCars();
		});
	});

	function getCars() {
		$.ajax({
			url.'@Url.Action("SearchCars", "Car_Rentals")',
			dataType: 'html',
			method: 'GET',
			data: { searchText: $('#txtSearch').val() },
			success: function (res) {
				$('#grdCars').html('').html(res);
			},
			error: function (err) {
				console.log(err);
			}
		})
	}
}