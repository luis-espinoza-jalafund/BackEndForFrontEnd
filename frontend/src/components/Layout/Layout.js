import React from 'react';
import Header from '../Header/Header';
import Banner from '../Banner/Banner';
import './Layout.css';

const Layout = ({ children, category}) => {
  return (
    
    <div className="layout">
      <Header />
      <Banner category={category}/>
      <div className="content-container">
        <div className="content-box">
          {children}
        </div>
      </div>
    </div>
    
  );
};

export default Layout;
