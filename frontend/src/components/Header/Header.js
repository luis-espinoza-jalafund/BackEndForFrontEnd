import React from 'react';
import './Header.css';

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
        <label className='redirect'>
          Technology
        </label>
        <label className='redirect'>
          Soccer
        </label>
        <label className='redirect'>
          Health
        </label>
      </nav>
    </header>
  );
}

export default Header;
