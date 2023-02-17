import ApiClient from '../ApiClient'

const AuthApi = {
    GetToken: (params) => {
        const url = '/Auth';
        return ApiClient.post(url, params);
    }
}

export default AuthApi;