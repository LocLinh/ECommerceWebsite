var productFetch = fetch("https://localhost:44351/api/Products");
function handleCalculatePrice(index) {
    var quantity = document.getElementById(`quantity${index}`).value;
    var price = document
        .getElementById(`price${index}`)
        .getAttribute("data-value");
    document.getElementById(`price${index}`).innerHTML = `${
        quantity * price
    } VNĐ`;
}

function handleRemoveItem(id) {
    var cartItems = JSON.parse(sessionStorage.itemCount);
    delete cartItems[id];
    sessionStorage.itemCount = JSON.stringify(cartItems);
    document.getElementById(`product-no${id}`).remove();
    setItemCount();
}

function handleCalculateTotalPrice() {
    var cartItems = JSON.parse(sessionStorage.itemCount);
    var totalPrice = cartItems.map;
}

function handleCountItems() {
    var cartItems = JSON.parse(sessionStorage.itemCount);
    return Object.keys(cartItems).length;
}

function setItemCount() {
    Array.from(document.getElementsByClassName("item-count")).map(
        (i) => (i.innerHTML = handleCountItems())
    );
    document.getElementById("cart-items-counter").innerHTML =
        handleCountItems();
}

function handleCalculateTotalPrice() {
    productFetch
        .then((res) => res.json())
        .then((products) => {
            var cartItems = JSON.parse(sessionStorage.itemCount);
            var cartProducts = products.filter((item) => {
                return item.id in cartItems;
            });
            var a = cartProducts.reduce(
                (prevProduct, currProduct) =>
                    prevProduct.price * cartItems[prevProduct.id] +
                    currProduct.price * cartItems[currProduct.id],
                0
            );
            console.log(a);
        });
}

const getCartItems = async () => {
    try {
        setItemCount();
        var response = await fetch("https://localhost:44351/api/Products");
        var products = await response.json();
        var cartItems = JSON.parse(sessionStorage.itemCount);
        var container = document.getElementById("item-container");
        var cartProducts = products.filter((item) => {
            return item.id in cartItems;
        });
        var item = cartProducts.map((product, index) => {
            return `<div id="product-no${product.id}">
                <hr class="my-4">
                <div class="row mb-4 d-flex justify-content-between align-items-center">
                    <div class="col-md-2 col-lg-2 col-xl-2">
                        <img src="${
                            product.imagePath != ""
                                ? product.imagePath
                                : "https://www.citizenwatch.com/dw/image/v2/BBQB_PRD/on/demandware.static/-/Sites-citizen_US-Library/default/dw474767b5/homepage-images/hero-images/home-half-hero-mickey-baseball.jpg"
                        }"
                            class="img-fluid rounded-3" alt="Cotton T-shirt">
                    </div>
                    <div class="col-md-3 col-lg-3 col-xl-3">
                        <h6 class="text-muted">Shirt</h6>
                        <h6 class="text-black mb-0 fs-0">${product.name}</h6>
                    </div>
                    <div class="col-md-3 col-lg-3 col-xl-3 d-flex">
                        <button class="btn btn-link px-1 mx-1"
                            onclick="this.parentNode.querySelector('input[type=number]').stepDown();handleCalculatePrice(${index});">
                            <i class="fas fa-minus"></i>
                        </button>

                        <input id="quantity${index}" min="0" name="quantity" value="${
                cartItems[product.id]
            }" type="number"
                            class="form-control form-control-md pe-1" 
                            onchange="handleCalculatePrice(${index})"
                            />

                        <button class="btn btn-link px-1 mx-1"
                            onclick="this.parentNode.querySelector('input[type=number]').stepUp();handleCalculatePrice(${index});">
                            <i class="fas fa-plus"></i>
                        </button>
                    </div>
                    <div class="col-md-3 col-lg-2 col-xl-2 offset-lg-1">
                        <h6 class="mb-0" id="price${index}" data-value="${
                product.price
            }">${product.price * cartItems[product.id]} VNĐ</h6>
                    </div>
                    <div class="col-md-1 col-lg-1 col-xl-1 text-end" >
                        <a onclick="handleRemoveItem(${
                            product.id
                        })" class="text-muted"><i class="fas fa-times"></i></a>
                    </div>
                </div>
            </div>`;
        });

        container.innerHTML = "";
        item.map((i) => (container.innerHTML += i));
        return products;
    } catch (error) {
        console.log(error);
        return null;
    }
};
handleCalculateTotalPrice();
getCartItems();
