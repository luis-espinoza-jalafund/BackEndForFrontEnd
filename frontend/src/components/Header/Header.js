import React from 'react';
import './Header.css';
import { Link } from 'react-router-dom';

function Header() {
  return (
    <header className='app-header'>
      <nav className='nav-links'>
        <label className='redirect'>
          Climate Change
        </label>
        <label className='redirect'>
          Politics
        </label>
        <Link to='/' className='redirect'>
          Home
        </Link>
        <label className='redirect'>
          Technology
        </label>
        <label className='redirect'>
          Health
        </label>
      </nav>
    </header>
  );
}

export default Header;
