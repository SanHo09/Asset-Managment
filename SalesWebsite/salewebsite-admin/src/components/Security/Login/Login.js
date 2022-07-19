import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import { Button } from 'react-bootstrap';
import { loginRequest, setToken } from '~/services/loginService';
import TextField from '~/shared-components/FormInputs/textField';
import { useNavigate } from 'react-router-dom';
import { NotificationManager } from 'react-notifications';
import { PRODUCT } from '~/constants/pages';
import '~/styles/login.css'
const initialFormValues = {
    UserName: '',
    Password: ''
};

const validationSchema = Yup.object().shape({
    UserName: Yup.string().required('*UserName is required'),
    Password: Yup.string().required('*password is required')
});

function Login() {

    let navigate = useNavigate();

    const handleLogin = async (form) => {
        var result = await loginRequest(form.formValues).catch(err =>
            handleResult(false, 'Login Failed'));
        var token = result.data.token;
        var isAdmin = result.data.isAdmin;
        if (token && isAdmin) {
            setToken(token);
            handleResult(true, 'Login sucessfully')
        }
        else {
            handleResult(false, 'Login Failed')
        }
    }

    const handleResult = (result, message) => {
        if (result) {
            NotificationManager.success(
                `Login successfully `,
                `Login successfully`,
                2000
            );

            setTimeout(() => { navigate(PRODUCT) }, 1000)
        } else {
            NotificationManager.error(message, `Login Failed Failed`, 2000);
        }
    }

    return (
        <div className='loginForm'>
            <Formik
                enableReinitialize
                initialValues={initialFormValues}
                validationSchema={validationSchema}
                onSubmit={values => handleLogin({ formValues: values })}
            >

                <div className="Auth-form-container">
                    <Form className="Auth-form">
                        <div className="Auth-form-content">
                            <h3 className="Auth-form-title">Sign In</h3>
                            <div className="form-group mt-3">
                                <label>UserName</label>
                                <TextField
                                    
                                    name='UserName'
                                />
                            </div>
                            <div className="form-group mt-3">
                                <label>Password</label>
                                <TextField
                                   
                                    type='password'
                                    name='Password'
                                />
                            </div>
                            <div className="d-grid gap-2 mt-3">
                                <button type="submit" className="btn btn-primary">
                                    Submit
                                </button>
                            </div>
                            <p className="forgot-password text-right mt-2">
                                Forgot <a href="#">password?</a>
                            </p>
                        </div>
                    </Form>
                </div>


                {/* <Form>
                    <TextField
                        placeholder='UserName'
                        name='UserName'
                    />
                    <br />
                    <TextField
                        placeholder='Password'
                        type='password'
                        name='Password'
                    />
                    <br />
                    <Button variant="outline-primary" type='submit'>Add</Button>
                </Form> */}
            </Formik>
        </div>

        
    )
}

export default Login;