import ApiClient from '../ApiClient'

const ProductApi = {
    GetAll: () => {
        const url = "/Products/GetProducts";
        return ApiClient.get(url);
    },
    GetByPage: (pageNumber, pageSize) => {
        const url = `/Products/GetProductsByPage?PageNumber=${pageNumber}&PageSize=${pageSize}`
        return ApiClient.get(url);
    },
    GetById: (ProductId) => {
        const url = `/Products/${ProductId}`
        return ApiClient.get(url);
    }
}

export default ProductApi;