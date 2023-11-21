//const TrackLinkID = () => {

//}

const filterProducts = async () => {
    let Categories = [];
    let allCategoriesOptions = document.getElementsByClassName("opt");
    for (let i = 0; i < allCategoriesOptions.length; i++) {
        if (allCategoriesOptions[i].checked) {
            Categories.push(allCategoriesOptions[i].id)
        }
    }

    const minPrice = document.getElementById("minPrice").value
    const maxPrice = document.getElementById("maxPrice").value
    const pName = document.getElementById("nameSearch").value

    try {
        let url = `api/Product?desc=${pName}&minPrice=${minPrice}&maxPrice=${maxPrice}`;
        if (Categories) {
            for (let i = 0; i < Categories.length; i++) {
                url += `&categoryIds=${Categories[i]}`
            }
        }
        const p = await fetch(url
            ,
            {
                method: 'GET',
                headers: {
                    'Content-Type': "application/json"
                },
                body: JSON.stringify()
            })
        if (!p.ok)
            throw new Error("Error: Failed to fetch products")
        const products = await p.json()
        document.getElementById("ProductList").replaceChildren([])
        document.getElementById("counter").innerText = products.length

        products.forEach(p => drawProducts(p))
    }
    catch (ex) {
        alert(ex.message)
    }
}

const drawProducts = (product) => {

    temp = document.getElementById("temp-card")
    var cloneProducts = temp.content.cloneNode(true)
    cloneProducts.querySelector("img").src = `./pic/${product.image.trim()}`
    cloneProducts.querySelector("h1").innerText = product.productName;
    cloneProducts.querySelector(".price").innerText = product.price + ' ₪';
    cloneProducts.querySelector(".description").innerText = product.description;
    cloneProducts.querySelector("button").addEventListener("click", () => addToCart(product));
    document.getElementById("ProductList").appendChild(cloneProducts);

    let itemCount = document.getElementById("ItemsCountText")
    itemCount.innerText = myCart.length
}


const drawCategories = async () => {
    try {
        const res = await fetch("/api/Category")
        if (!res.ok)
            throw new Error("Error: Failed to fetch categories")
        const categories = await res.json()

        var tmpCatg = document.getElementById("temp-category").content;

        categories.forEach(category => {
            let clone = tmpCatg.cloneNode(true);
            clone.querySelector(".opt").id = category.categoryId;
            clone.querySelector("label").setAttribute("for", category.categoryId);
            clone.querySelector(".OptionName").textContent = category.categoryName;
            document.getElementById("categoryList").appendChild(clone);
        });
    }
    catch (ex) {
        alert(ex.message)
    }
}

let myCart = JSON.parse(sessionStorage.getItem("myCart")) || []

const addToCart = (product) => {
    myCart.push(product)
    sessionStorage.setItem("myCart", JSON.stringify(myCart))
    let itemCount = document.getElementById("ItemsCountText")
    itemCount.innerText = myCart.length
}