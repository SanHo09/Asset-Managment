import qs from 'qs'
import requestService from './request'
import Endpoints from '~/constants/endpoints'

export async function getProductRequest(query) {
    return requestService.axios.get(Endpoints.products,  {
        params: query,
        paramsSerializer: params => qs.stringify(params)
    })
}

export function createProductRequest(productForm) {
    const formData = new FormData();
    formData.append('IsDeleted','false')
    formData.append('Rate' ,0)
    
    Object.keys(productForm).forEach(key => {
        console.log(`${key}, ${productForm[key]}`);
        formData.append(key, productForm[key])
    });
    return requestService.axios.post(Endpoints.products, formData);
}

export function updateProductRequest(productForm) {
    const formData = new  FormData();
    formData.append('IsDeleted','false')
    formData.append('Rate' ,0)
    Object.keys(productForm).forEach(key => {
        formData.append(key, productForm[key])
    });

    return requestService.axios.put(Endpoints.productId(productForm.id ?? - 1), formData);
}

export function deleteProductRequest(productId) {
    return requestService.axios.delete(Endpoints.productId(productId));
}