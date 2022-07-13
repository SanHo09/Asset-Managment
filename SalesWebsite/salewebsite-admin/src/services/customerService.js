import qs from 'qs'
import requestService from './request'
import Endpoints from '~/constants/endpoints'

export async function getCustomerRequest() {
    return requestService.axios.get(Endpoints.customers)
}
