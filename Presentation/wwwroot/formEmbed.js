(function() {
    const scriptTag = document.currentScript;
    const uuid = scriptTag.getAttribute('data-uuid');
    const targetDivId = scriptTag.getAttribute('data-target');

    if (!uuid || !targetDivId) {
        console.error("UUID or container ID not specified.");
        return;
    }

    const apiUrl = `http://localhost:8080/Form/generate/${uuid}`;

    fetch(apiUrl)
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP request error: ${response.status}`);
            }
            return response.text();
        })
        .then(html => {
            const targetDiv = document.getElementById(targetDivId);
            if (!targetDiv) {
                throw new Error(`The div with ID ${targetDivId} does not exist.`);
            }
            targetDiv.innerHTML = html;
        })
        .catch(err => {
            console.error('Error loading form:', err);
        });
})();