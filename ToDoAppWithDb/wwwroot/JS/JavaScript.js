function toggleComplete(id) {
	const td = document.getElementById("td-" + id);
	const checkbox = document.getElementById("cb-" + id);

	if (checkbox.checked) {
		td.classList.add("completed");
	} else {
		td.classList.remove("completed");
	}

	fetch('/Todo/ToggleComplete', {
		method: 'POST',
		headers: {
			'Content-Type': 'application/json'
		},
		body: JSON.stringify({ id: id, isComp: checkbox.checked })
	})
		.then(response => {
			if (!response.ok) {
				console.error("Güncelleme başarısız.");
			}
		})
		.catch(error => {
			console.error("Hata:", error);
		});
}
