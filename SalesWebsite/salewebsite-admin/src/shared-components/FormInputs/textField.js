import {useField} from 'formik'
import { useState } from 'react';

function TextField(props) {
    const [field, meta, helpers] = useField(props.name)
    
    return (
        <>
            <input {...field} {...props} />
            {meta.error && meta.touched && <div>{meta.error}</div>}
        </>
    );
}

export default TextField;