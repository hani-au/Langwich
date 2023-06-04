// import { useState } from "react"
// import useForm from '../../hooks/costomHooks'
// import {useFormik} from 'formik';
// import * as Yup from 'yup'

// export default function Login(){
//     const _mySubmit=(stateForm)=>{
//         console.log(myForm.values)
//         alert('submited')
//     }
// //מותר להשתמש בשתי סוגי אשרויות בדיקת תקינות?
// //  ? בדיקת תקינות של מספר תווים validationSchema איך עושים ב
//     const my_validation=(myFormDetails)=>{
//         let error={};
//         if(myFormDetails.email=='' || !myFormDetails.email){
//             error.email="Email field is required"
//         }
//         // if(myFormDetails.password=='' || !myFormDetails.password){
//         //     error.password="The password field is required"
//         }
//         if(myFormDetails.password.length<5){
//             error.password="עליך להזין לפחות 5 תווים"
//         }
//         return error;
       
   

//      const myForm=useFormik({
//         initialValues:{
//             email:'',
//             password:''
//         },

//          onSubmit:_mySubmit,
//          validate:my_validation,
//          validationSchema:Yup.object().shape({
//             email: Yup.string().email('אנא הכנס מייל תקין'),
//             password:Yup.string().required('שדה זה חובה')

//          })
        
//           })
//       return(
//         <form onSubmit={myForm.handleSubmit}>
//             <div className="form-group">
//                 <label>Email:</label>
//                 <input autoComplete="off" name="email" onChange={myForm.handleChange} className="form-control"></input>
//                 {myForm.errors.email?
//                 <div class="alert alert-danger" role="alert">
//                  {myForm.errors.email}
//               </div>:''}
//             </div>

//             <div className="form-group">
//                 <label>Password:</label>
//                 <input autoComplete="off" type="password" name="password" onChange={myForm.handleChange} className="form-control"></input>
//                 {myForm.errors.password?
//                 <div className="alert alert-danger" role="alert">
//                 {myForm.errors.password}
//                 </div>
//                :''}
//             </div>
//             <button onChange={myForm.handleChange} className="btn btn-primary" type="submit">הרשם</button>
//         </form>

//     )
// }

   