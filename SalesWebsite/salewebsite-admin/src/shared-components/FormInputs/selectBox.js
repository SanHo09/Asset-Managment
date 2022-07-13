import {useField} from 'formik'

function SelectField(props) {
    const [ field, {error, touched, value}, {setValue} ] = useField(props)
    const {options, category} = props;
    const hanldeChange = (e) => {
        setValue(e.target.value)
    };


    return (
        <>
            <select onChange={hanldeChange}>
                <option selected hidden value={0}>Open this select menu</option>
                {options.map(option => (
                    <option key={option.id} value={option.optionValue} selected = {option.optionValue === value}>
                        {option.optionLabel}
                    </option>
                ))}
            </select>
            {error && touched && <div>{error}</div>}
        </>
    )
}

export default SelectField;