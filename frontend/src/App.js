import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'; 
import Layout from './components/Layout/Layout';
import Home from './components/Home/Home';
import User from './components/User/User';

function App() {
  return (
    <Router>
      <Routes>
        <Route path='/' element={
            <Layout>
              <Home />
            </Layout>
          } 
        />
        <Route path='/users' element={
            <Layout category="Users">
              <User />
            </Layout>
          } 
        />
      </Routes>
    </Router>    
  );
}

export default App;
