import { Button, Table } from "react-bootstrap";
import { NotificationManager } from "react-notifications";
import { useNavigate } from "react-router-dom";
import { DEFAULT_IMAGE } from "~/constants/default";
import { CREATE_PRODUCT, PRODUCT, UPDATE_CATEGORY, UPDATE_PRODUCT, UPDATE_PRODUCT_ID } from "~/constants/pages";
import { deleteProductRequest } from "~/services/productService";

function ProductTable( {products, fetchData} ) {

    const navigate = useNavigate();

    const formatDate = (date) => {
        var date_new = new Date(date);
        return (new Intl.DateTimeFormat('en-US').format(date_new));
    }

    const handleDelete = async (id) => {
        if(window.confirm("Are you sure you want to delete?")) {
  
          deleteProductRequest(id);
          await fetchData();
          NotificationManager.success(
            `Delete successful `,
            `Delete successful`,
            2000
          );
          
          setTimeout(() => {navigate(PRODUCT)}, 1000)
        }
      }

    const handleUpdate = async(id) => {
        const existProduct = products?.items.find(item => item.id === Number(id));
        navigate(UPDATE_PRODUCT_ID(id), {
            state : {
                existProduct : existProduct
            }
        });
    }

    return (
        <Table striped bordered hover>
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Name</th>
                    <th>Price</th>
                    <th>Stock</th>
                    <th>Sold</th>
                    <th>Created Date</th>
                    <th>Image</th>
                    <th>Action</th>
                </tr>
            </thead>

            <tbody>
                {products && products.items.map(product => (
                    <tr key={product.id}>
                        <th>{product.id}</th>
                        <th>{product.name}</th>
                        <th>{product.price}</th>
                        <th>{product.quantity}</th>
                        <th>{product.sold}</th>
                        <th>{formatDate(product.createdDate)}</th>
                        <th>
                            <img src={product.image || DEFAULT_IMAGE} width={100} height={100} />
                        </th>
                        <th>
                            <Button variant="outline-warning" onClick={() => handleUpdate(product.id)} >Update</Button>
                            <Button variant="outline-danger" onClick={() => handleDelete(product.id)}>Delete</Button>
                        </th>
                    </tr>
                ))}
            </tbody>
        </Table>
    )
}

export default ProductTable; 
