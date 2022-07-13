import { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import ProductForm from "../productForm";

function UpdateProduct() {

    const [products, setProducts] = useState({});

    const {state} = useLocation();
    const {existProduct} =state;
    useEffect(() => {
        if(existProduct) {
            setProducts({
                id: existProduct.id,
                name: existProduct.name,
                price: existProduct.price,
                image: existProduct.image,
                quantity: existProduct.quantity,
                sold: existProduct.sold,
                category : existProduct.category.id
            })
        }
    }, [existProduct])

    return (
        <div className='ml-5'>
            <div className='primaryColor text-title intro-x'>
                Update Product
            </div>

            <div className='row'>
                <ProductForm
                    initalProductForm={products}
                />
            </div>
  
        </div>
    );
}

export default UpdateProduct;