import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Home from './components/Home/Home'
import User from './components/User/User';

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
