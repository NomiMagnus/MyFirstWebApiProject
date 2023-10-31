const register = async () => {
    try {
        const user = {
            fName: document.getElementById("txtFName").value,
            lName: document.getElementById("txtLName").value,
            email: document.getElementById("txtEmailReg").value,
            password: document.getElementById("txtPasswordReg").value
        }
        if (!user.fName || !user.password)
            throw new Error("Error: No user to add");

        const strong = await checkPassword(user.password);
        if (strong == 0)
            alert("Your password is weak, Enter password again!");
        else {
            const res = await fetch("/api/user", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        })
        if (!res.ok)
            throw new Error("Error: Adding user to server");
        const created = await res.json();
        
        document.getElementById("Register").style.visibility = "hidden";
        alert(`${created.fName} created`);
        }
    }
    catch (ex) {
        alert(ex.message)
    }
}

const registerVisible = () => document.getElementById("Register").style.visibility="visible";


const login = async () => {
    try {
        const user = {
            email: document.getElementById("txtEmailLog").value,
            password: document.getElementById("txtPasswordLog").value
        }
        const res = await fetch(`/api/user?email=${user.email}&password=${user.password}`)
        if (!res.ok)
            throw new Error("Error: login user to server");
        const myUser = await res.json();
        sessionStorage.setItem("User", JSON.stringify(myUser))
        document.location.href = "https://localhost:44331/mySite.html"
        alert(`Welcome ${myUser.fName}!`);

        //const u = JSON.parse(sessionStorage.getItem('User'))
        //document.getElementById("txtFName").value = u.fName
        //document.getElementById("txtLName").value = u.lName
        //document.getElementById("txtEmail").value = u.email
        //document.getElementById("txtPassword").value = u.password

    }
    catch (ex) {
        alert(ex.message)
    }
}

const update = async () => {
    try {
        const user = {
            fName: document.getElementById("txtFName").value,
            lName: document.getElementById("txtLName").value,
            email: document.getElementById("txtEmail").value,
            password: document.getElementById("txtPassword").value,
            userId: JSON.parse(sessionStorage.getItem("User")).userId
        }
        const strong = await checkPassword(user.password);
        if (strong == 0)
            alert("Your password is weak, Enter password again!");
        else {
            const res = await fetch(`/api/user/${user.userId}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(user)
            })

            if (!res.ok)
                throw new Error("Error: Update user to server");
            sessionStorage.setItem("User", JSON.stringify(user))
            document.location = "mySite.html"
            alert(`${user.fName} updtaed!`);
        }
    }
    catch (ex) {
        alert(ex.message)
    }
}

const checkPassword = async (pass) => {
    //const pass = document.getElementById("txtPasswordReg").value
    try {
        const check = await fetch("/api/user/checkPassword", {
            method: 'POST',
            headers: {
                'Content-Type': "application/json"
            },
            body: JSON.stringify(pass)
        })
        if (!check.ok)
            throw new Error("Error: Check password strength failed")

        const score = await check.json()
        document.getElementById("progress").value=score

        if (score > 2)
            return 1;
        else
            return 0;
    }
    catch (ex) {
        alert(ex.message)
    }
    
}