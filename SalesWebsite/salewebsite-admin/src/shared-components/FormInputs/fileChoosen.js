import { useField } from "formik"
import { useEffect, useState } from "react"

function ChooseFile(props) {
    const [field, { error, touched, value }, { setValue }] = useField(props);
    const [image, setImage] = useState(props.defaultImage)


    useEffect(() => {
        return () => {
            image && URL.revokeObjectURL(image.preview)
        }
    }, [image])

    
    const handlePreviewImage = (e) => {
        const file = e.target.files[0]
        setValue(e.target.files[0]) 
        var preview = URL.createObjectURL(file)
        setImage(preview)
    }

    return (
        <>
            <input type={'file'}  onChange={handlePreviewImage} />
            <img src={image || props.defaultImage} width={100} height={100} />         
        </>
    )
}

export default ChooseFile