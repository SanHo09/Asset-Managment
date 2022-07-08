import qs from 'qs'
import requestService from './request'
import Endpoints from '~/constants/endpoints'

export function getCategoriesRequest(query) {
    return requestService.axios.get(Endpoints.categories, {
        params: query,
        paramsSerializer: params => qs.stringify(params)
    })
}

export function createCategoriesRequest(categoryForm) {
    const formData = new FormData();

    Object.keys(categoryForm).forEach(key => {
        console.log(`${key}, ${categoryForm[key]}`);
        formData.append(key, categoryForm[key])
    });

    return requestService.axios.post(Endpoints.categories, formData);
}

export function updateCategoriesRequest(categoryForm) {
    const formData = new FormData();

    Object.keys(categoryForm).forEach(key => {
        formData.append(key, categoryForm[key])
    });

    return requestService.axios.put(Endpoints.categoryId(categoryForm.id ?? - 1), formData);
}

export function deleteCategoriesRequest(categoryId) {
    return requestService.axios.delete(Endpoints.categoryId(categoryId));
}