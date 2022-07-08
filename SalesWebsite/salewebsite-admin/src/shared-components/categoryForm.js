import { useNavigate } from "react-router-dom";
import { createCategoriesRequest, updateCategoriesRequest } from "~/services/categoriesService";
import { Formik, Form  } from 'formik';
import TextField from "./FormInputs/textField";
import { CATEGORIES } from "~/constants/pages";
import { NotificationManager } from 'react-notifications';
const initialFormValues = {
    name: '',
    description: ''
};

function CategoryForm({initalCategoryForm = {...initialFormValues}}) {

    const navigate = useNavigate();

    const isUpdate = initalCategoryForm.id ? true : false;

    const handleResult = (result, message) => {
        if(result) {
            NotificationManager.success(
                `${isUpdate ? 'Update' : 'Create'} successful `,
                `${isUpdate ? 'Update' : 'Create'} successful`,
                2000
            );

            setTimeout(() => {navigate(CATEGORIES)}, 1000)
        } else {
            NotificationManager.error(message, `${isUpdate ? 'Update' : 'Create'} Failed`, 2000);
        }
    }

    const createCategoryAsync = async (form) => {
        console.log('create');
        let data = await createCategoriesRequest(form.formValues)
        if (data)
        {
            handleResult(true, data.name);
        }
    }

    const updateCategoryAsync = async (form) => {
        let data = await updateCategoriesRequest(form.formValues)
        if (data)
        {
            handleResult(true, data.name);
        }
    }

    return (
        <Formik
            initialValues={initalCategoryForm}
            enableReinitialize
            onSubmit={(values) => {
                if(isUpdate) {
                    updateCategoryAsync({ formValues: values });
                } else {
                    createCategoryAsync({ formValues: values });
                }
            }}
        >
            <Form className="intro-y col-lg-6 col-12">
                <TextField 
                    placeholder='Name'
                    name='name'  
                />
                <TextField 
                    placeholder='description'
                    name='description' 
                />
                <button type="submit">Save</button>
            </Form>
            
        </Formik>
    )
}

export default CategoryForm;