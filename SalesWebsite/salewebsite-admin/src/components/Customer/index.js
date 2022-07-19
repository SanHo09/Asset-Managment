import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom"
import { LOGIN } from "~/constants/pages";
import { getCustomerRequest } from "~/services/customerService";
import { checkLogin } from "~/services/loginService";
import CustomerTable from "./List/customerTable";

function ListCustomer() {

    let navigate = useNavigate();

    const [customers, setCustomers] = useState(undefined)

    useEffect(() => {
        if(localStorage.getItem("admin")==null) {
            navigate(LOGIN)
        }
        console.log(checkLogin());
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