//const TrackLinkID = () => {

//}

const filterProducts = async () => {
    let Categories = [];
    const allCategoriesOptions = document.querySelectorAll(".opt");
    for (let i = 0; i < allCategoriesOptions.length; i++) {
        if (allCategoriesOptions[i].checked) Categories.push(allCategoriesOptions[i].id)
    }
    
    const minPrice = document.getElementById("minPrice").value
    const maxPrice = document.getElementById("maxPrice").value
    const pName = document.getElementById("nameSearch").innerText

    try {
        const url = `api/Product?desc=${pName}&minPrice=${minPrice}&maxPrice=${maxPrice}`;
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

        products.forEach(p => drawProducts(p))
    }
    catch (ex) {
        alert(ex.message)
    }
}

const drawProducts = (product) => {

    temp = document.getElementById("temp-card")
    var cloneProducts = temp.content.cloneNode(true)

    cloneProducts.querySelector("img").source = "./NoPic.jpg" /*+ product.imageUrl*/;
        cloneProducts.querySelector("h1").innerText = product.productName;
    cloneProducts.querySelector(".price").innerText = product.price + ' ₪';
    cloneProducts.querySelector(".description").innerText = product.description;
    cloneProducts.querySelector("button").addEventListener("click", () => addToCart(product));
    document.getElementById("ProductList").appendChild(cloneProducts);
}


const drawCategories = async () => {
    try {
        const res = await fetch("/api/Category")
        if (!res.ok)
            throw new Error("Error: Failed to fetch categories")
        const categories = await res.json()

        for (let i = 0; i < categories.length; i++) {
            var tmpCatg = document.getElementById("temp-category");
            var cln = tmpCatg.content.cloneNode(true);
            cln.querySelector("span.OptionName").innerText = categories[i].categoryName;
            cln.querySelector("span.OptionName").id = categories[i].categoryId;
            cln.querySelector(".opt").addEventListener("change", () => filterProducts());

            document.getElementById("categoryList").appendChild(cln);
        }
    }
    catch (ex) {
        alert(ex.message)
    }
}

const addToCart = (product) => {

}