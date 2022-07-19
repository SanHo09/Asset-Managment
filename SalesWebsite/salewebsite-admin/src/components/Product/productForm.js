import { Formik, Form  } from 'formik';
import { useEffect, useState } from 'react';
import { NotificationManager } from 'react-notifications';
import  * as Yup from 'yup';
import { useNavigate } from 'react-router-dom';
import { DEFAULT_IMAGE } from '~/constants/default';
import { PRODUCT } from '~/constants/pages';
import { getCategoriesRequest } from '~/services/categoriesService';
import { createProductRequest, updateProductRequest } from '~/services/productService';
import ChooseFile from '~/shared-components/FormInputs/fileChoosen';
import SelectField from '~/shared-components/FormInputs/selectBox';
import TextField from '~/shared-components/FormInputs/textField';

const initialFormValues = {
    name: '',
    price: '',
    stock: '',
    image: '',
    sold: '',
    categoryId: '',
    image: DEFAULT_IMAGE
};
const validationSchema = Yup.object().shape({
    name : Yup.string().required('*Name is required'),
    price : Yup.string().required('*price is required'),
    quantity : Yup.string().required('*Stock is required'),
    sold : Yup.string().required('*sold is required'),
    categoryId: Yup.number().integer().min(1).required('Category is required')
});
function ProductForm({initalProductForm = {...initialFormValues}}) {

    let navigate = useNavigate();

    const [categories, setCategories] = useState(undefined);
    
    const isUpdate = initalProductForm.id ? true : false;
    
    initalProductForm.categoryId = initalProductForm.category
    useEffect(() => {
        const fetchData = async() => {
            let result = await getCategoriesRequest({});
            setCategories(result.data.items)
        }
        fetchData();

    }, [])
    
    const handleResult = (result, message) => {
        if(result) {
            NotificationManager.success(
                `${isUpdate ? 'Update' : 'Create'} successful `,
                `${isUpdate ? 'Update' : 'Create'} successful`,
                2000
            );

            setTimeout(() => {navigate(PRODUCT)}, 1000)
        } else {
            NotificationManager.error(message, `${isUpdate ? 'Update' : 'Create'} Failed`, 2000);
        }
    }

    const createProductAsync = async (form) => {
        console.log(form.formValues);
        let data = await createProductRequest(form.formValues)
        if (data)
        {
            handleResult(true, data.name);
        }
    }

    const updateProductAsync = async (form) => {
        let data = await updateProductRequest(form.formValues)
        if (data)
        {
            handleResult(true, data.name);
        }
    }

    return (
        <Formik
            initialValues={initalProductForm}
            enableReinitialize 
            validationSchema={validationSchema}
            onSubmit = {(values) => {
                if(isUpdate) {
                    updateProductAsync({ formValues: values });
                } else {
                    createProductAsync({ formValues: values });
                }
            }}
        >
            <Form className='intro-y col-lg-6 col-12' enctype="multipart/form-data">
                <TextField 
                    placeholder='Name'
                    name='name'  
                />
                <br />
                <TextField 
                    placeholder='Price'
                    name='price'  
                    type='Number'
                /><br />
                <TextField 
                    placeholder='Stock'
                    name='quantity'  
                    type='Number'
                />
                <br />
                {/* image */}
                <TextField 
                    placeholder='Sold'
                    name='sold'  
                    type='Number'
                />
                <br />
                {/* <input type='file' name='image' accept="image/jpeg,image/jpg,image/png"/> */}
                <ChooseFile name='image' defaultImage = {initalProductForm.image}/> 
                {categories && <SelectField  name='categoryId' 
                    options = {categories.map(category => ({
                        optionValue : category.id,
                        optionLabel : category.name
                    }))}
                />}
                <br /><br />
                <button className='btn btn-secondary' type="submit">Save</button>
            </Form>
        </Formik>
    )
}

export default ProductForm