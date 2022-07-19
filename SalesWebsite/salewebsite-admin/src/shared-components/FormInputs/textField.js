import {useField} from 'formik'
import { useState } from 'react';
import '~/styles/error.css'
function TextField(props) {
    const [field, meta, helpers] = useField(props)
    
    return (
        <>
            <input className='form-control' {...field} {...props} />
            {meta.error && meta.touched && <div className='error'>{meta.error}</div>}
        </>
    );
}

export default TextField;