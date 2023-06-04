import {useFormik} from 'formik'
import * as Yup from 'yup'
import userService from '../../services/UserService'
//import Table from "../Table/Table";
//import DynamicTable from "../DynamicTable/DynamicTable";
import Dictionary from "../Dictionary/Dictionary";
import React, { useState } from "react";
import "./Register.css";
//import { useNavigate } from 'react-router-dom';

export default function Register2(){
    
    const [status, setStatus] = useState(false);
    const [data, setData] = useState(null);
    //const _navigate=useNavigate();
    const sendData = (data) => {
		setData(data);
	}
	const changeStatus = () => {
		setStatus(true);
	}
    const _mySubmit=()=>{
        debugger
        userService._insertUser(_myForm.values).then((userDeatails)=>{
            if(userDeatails)
            { 
                console.log(userDeatails);
                // _dispatch(setUser(userDeatails))
              //  _navigate('/Dictionary')
              sendData(userDeatails);
              changeStatus();
            }
       else
            alert('the user is undefind')
        });
     }

    // const _mySubmit=(_formDetails)=>{
    //    let Ans= userService._insertUser(_formDetails);
    //    sendData(Ans.data);
    //    changeStatus();
    // }

    const _myForm=useFormik({
        initialValues:{
         //   lastName:'',
         //   firstName:'',
            email:'',
        //    numberId:'',
            password:''
        },
        onSubmit:_mySubmit,
        validationSchema:Yup.object().shape({
            email:Yup.string().required('email is must'),
            numberId:Yup.string().test('my_validation','error the number id is not valid',
            (_value)=>{
               return _value && _value.length!=9?false:true
            })
        })
    })


    return (
        <> {!status && <><div class="sidenav">
            <div class="login-main-text">
                <img src="./logo.png" class="logo"/>
            </div>
        </div><div class="main">
                <div class="col-md-6 col-sm-12">
                    <div class="login-form"><form onSubmit={_myForm.handleSubmit}>
                        {/* <div className="form-group">
<label>lastName</label>
<input className="form-control" name="lastName" onChange={_myForm.handleChange}></input>
</div>

<div className="form-group">
<label>firstName</label>
<input className="form-control" name="firstName" onChange={_myForm.handleChange}></input>
</div> */}

                        <div className="form-group">
                            <label>email</label>
                            <input type="email" className="form-control" name="email" placeholder="email" onChange={_myForm.handleChange}></input>
                            {_myForm.errors.email ? <div>{_myForm.errors.email}</div> : ''}
                        </div>

                        {/* <div className="form-group">
<label>numberId</label>
<input className="form-control" name="numberId" onChange={_myForm.handleChange}></input>
{_myForm.errors.numberId?<div>{_myForm.errors.numberId}</div>:''}
</div> */}

                        <div class="form-group">
                            <label>password</label>
                            <input type="password" class="form-control" name="password" placeholder="password" onChange={_myForm.handleChange}></input>
                        </div>
                        <br></br>
                        <button type="submit" class="btn btn-black">Login</button>

                    </form>
                    </div>
                </div>
            </div></>}
        <div>
        {status && <><Dictionary DynamicData={data}></Dictionary></>}
        </div></>
    )
}