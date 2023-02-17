function HandleShowPassword() {
    const inputPassword = event.target.parentNode.querySelector("input");
    const type = inputPassword.getAttribute("type") === "password" ? "text" : "password";
    inputPassword.setAttribute("type", type);

    event.target.classList.toggle("fa-eye-slash");
    event.target.classList.toggle("fa-eye");
}