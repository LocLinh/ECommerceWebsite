import ApiClient from '../ApiClient'

const CategoryApi = {
    GetAll: () => {
        const url = '/Categories/GetCategories';
        return ApiClient.get(url);
    },

    GetById: (categoryId) => {
        const url = `/Categories/${categoryId}`
        return ApiClient.get(url);
    },

    GetByPage: (pageNumber, pageSize) => {
        const url = `/Categories/GetCategoriesByPage?PageNumber=${pageNumber}&PageSize=${pageSize}`
        return ApiClient.get(url);
    }
}

export default CategoryApi;