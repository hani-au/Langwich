import { useState } from "react";

export default function useForm(initialState) {

    const [detailsForm, setDetails] = useState(initialState)

    const handlerSubmit = (event) => {
        event.preventDefault();
        console.log(detailsForm);
    }

    const handlerChange = (event) => {
        let a = event.currentTarget.type == "checkbox" ? event.currentTarget.checked : event.currentTarget.value
        setDetails({
            ...detailsForm,
            [event.currentTarget.name]: a
        })
    }
    return [
        handlerSubmit,
        handlerChange,
        detailsForm
    ]


}

// import { useState } from "react";

// /**
//  * 
//  * @param {*} initialState 
//  * @returns handlerSubmit
//  * @returns handlerChange an function that call on change input
//  */
// export default function useForm(initialState) {
//     debugger
//     const [detailsForm,setDetails]=useState(initialState)

//     const handlerSubmit = (event) => {
//         debugger
//         event.preventDefault();
//         console.log(detailsForm);
//     }



//     const handlerChange = (event) => {
//         debugger
//         let valueField = event.currentTarget.type == "checkbox" ? event.currentTarget.checked : event.currentTarget.value;
//         setDetails({
//             ...detailsForm,
//             [event.currentTarget.name]: valueField
//         })
//     }

//     return [
//         handlerSubmit,
//         handlerChange,
//         detailsForm
//     ]
// }