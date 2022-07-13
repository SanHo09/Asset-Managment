import {useField} from 'formik'
import { useState } from 'react';

function TextAreaField(props) {
    const [field, meta, helpers] = useField(props)
    return (
        <>
            <textarea
                className={`form-control`}
                {...field}
                {...props}>
            </textarea>
            {meta.error && meta.touched && <div>{meta.error}</div>}
        </>
    );
}

export default TextAreaField;