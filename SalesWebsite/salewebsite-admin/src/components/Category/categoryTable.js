import Table from 'react-bootstrap/Table';
import Button from "react-bootstrap/esm/Button";
import { useNavigate } from 'react-router-dom';
import {CATEGORIES, CREATE_CATEGORY, UPDATE_CATEGORY_ID} from '~/constants/pages'
import { deleteCategoriesRequest } from '~/services/categoriesService';
import { NotificationManager } from 'react-notifications';
import { useState } from 'react';

function CategoryTable( {categories, fetchData}) {

    const navigate = useNavigate();

    const [isDelete, setIsDelete] = useState(true)

    console.log();

    const handleUpdate = (id) => {
      const existCategory = categories?.items.find(item => item.id === Number(id));
      navigate(
        UPDATE_CATEGORY_ID(id), {
        state : {
          existCategory: existCategory
        }
      })
    }

    const handleDelete = async (id) => {
      if(window.confirm("Are you sure you want to delete?")) {

        deleteCategoriesRequest(id);
        await fetchData();
        NotificationManager.success(
          `Delete successful `,
          `Delete successful`,
          2000
        );
        
        setTimeout(() => {navigate(CATEGORIES)}, 1000)
      }
      setIsDelete(false)
    }

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
          {categories && categories.items.map((category) => (
            <tr key={category.id}>
              <th>{category.id}</th>
              <th>{category.name}</th>
              <th>{category.description}</th>
              <th>
                <Button variant="outline-warning" onClick={() => handleUpdate(category.id)} >Update</Button>
                <Button variant="outline-danger" onClick={() => handleDelete(category.id)}>Delete</Button>
              </th>
            </tr>
          ))}
        </tbody>
      </Table>
    );
}

export default CategoryTable; 
