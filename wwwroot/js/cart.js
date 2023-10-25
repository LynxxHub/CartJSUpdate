function addToCart(productId) {
    const apiUrl = `/api/cart/add/${productId}`;

    fetch(apiUrl, {
        method: 'POST'
    })
        .then(response => {
            // Ensure the response is "OK" before proceeding
            if (response.ok) {
                return response.json();
            }
            throw new Error('Network response was not ok.');
        })
        .then(data => {
            if (data.success) {
                updateCartUI(productId);
            } else {
                alert('There was a problem adding the product to the cart.');
            }
        })
        .catch(error => {
            console.error('Error:', error);
            alert('There was an error processing your request.');
        });
}

function updateCartUI(productId) {
    let product = window.productsData.find(p => p.id == productId);

    let cartTableBody = document.querySelector(".cart-table tbody");
    let newRow = cartTableBody.insertRow();

    let cell1 = newRow.insertCell(0);
    let cell2 = newRow.insertCell(1);
    let cell3 = newRow.insertCell(2);
    let cell4 = newRow.insertCell(3);

    cell1.innerText = product.id;
    cell2.innerText = product.name;
    cell3.innerText = product.description;
    cell4.innerText = product.price;
    alert('Product added to the cart successfully!');
}