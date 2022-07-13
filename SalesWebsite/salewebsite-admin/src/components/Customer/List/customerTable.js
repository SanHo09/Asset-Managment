import { Table } from "react-bootstrap";
import { useNavigate } from "react-router-dom";

function CustomerTable( {customers, fetchData}) {

    const navigate = useNavigate();

    const handleUpdate = (id) => {
        
    }

    const handleDelete = async (id) => {
      
    }

    return (
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>ID</th>
            <th>User Name</th>
            <th>Full Name</th>
            <th>Password</th>
          </tr>
        </thead>

        <tbody>
          {customers && customers.map((customer) => (
            <tr key={customer.id}>
                <th>{customer.id}</th>
                <th>{customer.userName}</th>
                <th>{customer.fullName}</th>
                <th>{customer.password}</th>
            </tr>
          ))}
        </tbody>
      </Table>
    );
}

export default CustomerTable; 
