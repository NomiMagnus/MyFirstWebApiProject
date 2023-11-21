const showProducts = () => {
    const products = JSON.parse(sessionStorage.getItem("myCart"))

    temp = document.getElementById("temp-row")

    products.forEach(p => {
        var cloneProducts = temp.content.cloneNode(true)
        cloneProducts.querySelector(".itemName").innerText = p.productName
    })

    //< td class="imageColumn" > <a rel="lightbox" href="#"><div class="image"></div></a></td >
    //    <td class="descriptionColumn"><div><h3 class="itemName"></h3><h6><p class="itemNumber"></p><a class="viewLink" href="https://www.next.co.il/he/g59522s11#407223">לפרטים נוספים</a></h6></div></td>
    //    <td class="availabilityColumn"><div>במלאי</div></td>
    //    <td class="totalColumn delete"><div class="expandoHeight" style="height: 99px;"><p class="price"></p><a href="#" title="לחצו כאן כדי להסיר את פריט זה" class="Hide DeleteButton showText">הסרת פריט</a></div></td>


}