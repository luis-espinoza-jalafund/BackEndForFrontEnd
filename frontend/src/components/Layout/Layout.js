import React from 'react';
import Header from '../Header/Header';
import './Layout.css';

const Layout = ({ children }) => {
  return (
    <div className="layout">
      <Header />
      <div className="content-container">
        <div className="content-box">
          {children}
        </div>
      </div>
    </div>
  );
};

export default Layout;
