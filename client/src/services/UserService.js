import axios from 'axios'
class UserService{
    _insertUser=(userDetails)=>{
        debugger
       return(axios.post('http://localhost:8246/api/Search/searchUser',userDetails)
       .then((response)=>{
           debugger
        console.log(response.data)
        return response.data
       }).catch(()=>alert('opsss the server is faild'),))
    // const Ans={
    //     "data": [{ firstname: "Anom", lastname:"Cohen", age: 19, gender: "Male" },
    //              { firstname: "Megha", lastname:"Levy", age: 19, gender: "Female" },
    //              { firstname: "Subham",lastname:"Gold", age: 25, gender: "Male"},]
    // }
    // return Ans;
      }
    }
    export default new UserService

   
// import axios from 'axios'
// class UserService {
//     BASE_URL = "http://localhost:8246/api/Search/searchUser"
//     // _addUser = (userDetails) => {
//     //     axios.post('https://academeez-login-ex.herokuapp.com/api/users/register', userDetails)
//     //         .then((response) => {
//     //             debugger
//     //             alert(response.data)
//     //         })
//     // }
//     sendUser(userObj) {
//         try {
//             axios.post((this.BASE_URL + "?userName=" + userObj.userName + "&password=" + userObj.password)
//                 .then(response => {
//                     alert(response.data)
//                     return response.data
//                 }))
//         } catch (ex) {
//             console.log(ex);
//         }
//     }
// }

// export default new UserService


      // }
      //     "data": response.data
      //   }
      //   return Ans;
      //  } ,(error) => {
      //   console.log(error);
      //   });
       
