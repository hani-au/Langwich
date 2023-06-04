
import './App.css';
import React, { useState } from 'react'
import {
  BrowserRouter as Router,
  Routes,
  Route,
  useRoutes,
} from "react-router-dom";
import Header from './components/Header/Header.jsx'
import Table from './components/Table/Table'
import DynamicTable from './components/DynamicTable/DynamicTable'
import Dictionary from './components/Dictionary/Dictionary'

import Home from './components/Home/Home.jsx'
import Login from './components/Login/Login.jsx'
import NotFound from './components/NotFound/NotFound.jsx'
import Register from './components/Register/Register.jsx'
import login from './components/Login/Login.jsx';
import { Provider } from 'react-redux';
function App() {
  return (
    <div className="container">
      {/* <Provider store={store}> */}
      {/* <Routes>
        <Route path='/' element={<Register></Register>}></Route>
        <Route path='/Dictionary' element={<Dictionary></Dictionary>}></Route>
      </Routes> */}
      {/* </Provider> */}
      <Router>
      <Routes>
        <Route path="/my-website" element={<Header></Header>}>
          <Route  path="" element={<Home></Home>} />
        </Route> 
        <Route path="/" element={<Register></Register>} />
        {/* <Route path="*" element={<NotFound></NotFound>} /> */}
        {/* <Route path="/table" element={<Table></Table>} /> */}
        <Route />
      </Routes>
      </Router>
    </div>


  );
}

export default App;
