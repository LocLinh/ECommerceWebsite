import ApiClient from "../ApiClient";
import { getToken } from "../ApiClient";

const CategoryApi = {
    GetAll: () => {
        const url = "/Users/GetAllUsers";
        return ApiClient.get(url, {
            headers: { Authorization: "Bearer " + getToken() },
        });
    },
    GetCurrentUser: () => {
        const url = "/Users/GetCurrentUser";
        return ApiClient.get(url);
    },
};

export default CategoryApi;
