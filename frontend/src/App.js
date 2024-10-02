import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'; 
import Layout from './components/Layout/Layout';
import Banner from './components/Banner/Banner';

function App() {
  return (
    <Router>
      <Routes>
        <Route path='/' element={<Home />}></Route>
        <Route path='/users' element={<User />}></Route>
      </Routes>
    </Router>
    
  );
}

export default App;
