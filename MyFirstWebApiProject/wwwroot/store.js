//const TrackLinkID = () => {

//}

const filterProducts = async () => {
   
    try {
        //const minPrice = document.getElementById("minPrice").value
        //const maxPrice = document.getElementById("maxPrice").value
        //const pName = document.getElementById("nameSearch").value

//איך מוסיפים לURL???????????????
        const p = await fetch("/api/Product/", {
            method: 'GET',
            headers: {
                'Content-Type': "application/json"
            },
            body: JSON.stringify()
        })
        if (!p.ok)
            throw new Error("Error: Failed to fetch products")

        const products = await p.json()
        products.forEach(p => drawProducts(p))
    }
    catch (ex) {
        alert(ex.message)
    }
}

const drawProducts = (product) => {
    temp = document.getElementById("temp-card")
    var cloneProducts = temp.content.cloneNode(true)

    cloneProducts.querySelector("img").source = "./NoPic.jpg" /*+ product.imageUrl ||*/;
        cloneProducts.querySelector("h1").innerText = product.productName;
    cloneProducts.querySelector(".price").innerText = product.price + ' ₪';
    cloneProducts.querySelector(".description").innerText = product.description;
    cloneProducts.querySelector("button").addEventListener("click", () => addToCart(product));
    document.getElementById("ProductList").appendChild(cloneProducts);
}

const drawCategories = async(c) => {
    try {
        const p = await fetch("/api/Category/", {
            method: 'GET',
            headers: {
                'Content-Type': "application/json"
            },
            body: JSON.stringify()
        })
        if (!p.ok)
            throw new Error("Error: Failed to fetch categories")

        const category = await c.json()
        category.forEach(c => drawProducts(c))

        temp = document.getElementById("temp-category")
        var cloneCategory = temp.content.cloneNode(true)
        cloneCategory.querySelector(".OptionName").value = c.categoryName
    }
    catch (ex) {
        alert(ex.message)
    }

    
}

const addToCart = (product) => {

}