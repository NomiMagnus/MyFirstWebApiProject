const register = async () => {
    try {
        const user = {
            FirstName: document.getElementById("txtFName").value,
            LastName: document.getElementById("txtLName").value,
            Email: document.getElementById("txtEmailReg").value,
            Password: document.getElementById("txtPasswordReg").value
        }
        if (!user.FirstName || !user.Password)
            throw new Error("Error: No user to add");

        const strong = await checkPassword(user.Password);
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
            alert(`${created.firstName} created`);
        }
    }
    catch (ex) {
        alert(ex.message)
    }
}

const registerVisible = () => document.getElementById("Register").style.visibility = "visible";


const login = async () => {
    try {
        const user = {
            Email: document.getElementById("txtEmailLog").value,
            Password: document.getElementById("txtPasswordLog").value
        }
        const res = await fetch(`/api/user?email=${user.Email}&password=${user.Password}`)
        if (!res.ok)
            throw new Error("Error: login user to server");
        const myUser = await res.json();
        sessionStorage.setItem("User", JSON.stringify(myUser))
        document.location.href = await "https://localhost:44331/mySite.html"
        let message = `Welcome ${myUser.firstName}!`
        alert(message.trim());
    }
    catch (ex) {
        alert(ex.message)
    }
}

const update = async () => {
    try {
        const user = {
            FirstName: document.getElementById("txtFName").value,
            LastName: document.getElementById("txtLName").value,
            Email: document.getElementById("txtEmail").value,
            Password: document.getElementById("txtPassword").value,
            UserId: JSON.parse(sessionStorage.getItem("User")).userId
        }
        const strong = await checkPassword(user.Password);
        if (strong == 0)
            alert("Your password is weak, Enter password again!");
        else {
            const res = await fetch(`/api/user/${user.UserId}`, {
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
            alert(`${user.firstName} updtaed!`);
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
        document.getElementById("progress").value = score

        if (score > 2)
            return 1;
        else
            return 0;
    }
    catch (ex) {
        alert(ex.message)
    }

}

const fillFields = () => {
    const u = JSON.parse(sessionStorage.getItem('User'))
    console.log(u)
    document.getElementById("txtFName").value = u.firstName || ''
    document.getElementById("txtLName").value = u.lastName || ''
}
