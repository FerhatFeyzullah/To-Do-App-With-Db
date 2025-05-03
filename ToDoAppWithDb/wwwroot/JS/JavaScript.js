function toggleComplete(id) {
	const td = document.getElementById("td-" + id);
	const checkbox = document.getElementById("cb-" + id);

	if (checkbox.checked) {
		td.classList.add("completed");
	} else {
		td.classList.remove("completed");
	}


}
