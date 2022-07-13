import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom"
import { getCustomerRequest } from "~/services/customerService";
import CustomerTable from "./List/customerTable";

function ListCustomer() {

    let navigate = useNavigate();

    const [customers, setCustomers] = useState(undefined)

    useEffect(() => {
        const fetchData = async() => {
            let result = await getCustomerRequest();
            setCustomers(result.data)
        }
        fetchData()
    }, [])

    return (
        <div>
            <CustomerTable 
                customers={customers}
            />
        </div>
    )
}

export default ListCustomer