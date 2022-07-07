import Table from 'react-bootstrap/Table';
import Button from "react-bootstrap/esm/Button";
import { useNavigate } from 'react-router-dom';
function CategoryTable( {categories}) {

    const navigate = useNavigate()

    return (
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Description</th>
            <th>Action</th>
          </tr>
        </thead>

        <tbody>
          {categories.map((category) => (
            <tr key={category.id}>
              <th>{category.id}</th>
              <th>{category.name}</th>
              <th>{category.description}</th>
              <th>
                <Button variant="outline-warning" onClick={() => navigate('/')} >Update</Button>
                <Button variant="outline-danger">Delete</Button>
              </th>
            </tr>
          ))}
        </tbody>
      </Table>
    );
}

export default CategoryTable; 
