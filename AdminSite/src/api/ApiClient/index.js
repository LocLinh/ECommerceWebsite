import axios from "axios";
import Cookies from "universal-cookie";
// const PORT = "44351"
const PORT = "7154"
const SERVER_URL = `https://localhost:${PORT}/api/`
const instance = axios.create({
    baseURL: SERVER_URL,
    timeout: 30000,
    headers: {Authorization: 'Bearer ' + getToken()}
});

instance.interceptors.response.use(
    (response) => {
        return response.data;
    },
    (error) => {
        console.log(error);
    }
);

export function getToken() {
    const cookies = new Cookies();
    const token = cookies.get("Token");
    return token;
}

export default instance;
