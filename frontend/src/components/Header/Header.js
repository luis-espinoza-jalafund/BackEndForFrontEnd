import React from 'react';
import './Header.css';
import { Link } from 'react-router-dom';

function Header() {
  return (
    <header className='app-header'>
      <nav className='nav-links'>
        <Link to='/news/climate-change' className='redirect'>
          Climate Change
        </Link>
        <Link to='/news/politics' className='redirect'>
          Politics
        </Link>
        <Link to='/' className='redirect'>
          Home
        </Link>
        <Link to='/news/technology' className='redirect'>
          Technology
        </Link>
        <Link to='/news/health' className='redirect'>
          Health
        </Link>
      </nav>
    </header>
  );
}

export default Header;
