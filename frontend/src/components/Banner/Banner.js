import React from 'react';
import './Banner.css';

function Banner({ category = 'Welcome' }) {
    return(
        <>
        <div className='container-images'>
            <a href='https://x.com' target='_blank' rel='noopener noreferrer'>
                <img src='https://res.cloudinary.com/dkappxhfr/image/upload/v1727884113/web/wylmct78pnbpt3r39bbs.png' alt='error'/>
            </a>
            <a href='https://facebook.com' target='_blank' rel='noopener noreferrer'>
                <img src='https://res.cloudinary.com/dkappxhfr/image/upload/v1727884112/web/emviec449fwmnkwzgy8c.png' alt='error'/>
            </a>
            <a href='https://instagram.com' target='_blank' rel='noopener noreferrer'>
                <img src='https://res.cloudinary.com/dkappxhfr/image/upload/v1727884113/web/cdhzqknlop1xfb1xija2.png' alt='error'/>
            </a>
        </div>
        <div className='container-titles'>
            <div className='title'>
                BFF News
            </div>

            <div className='category'>
                {category}
            </div>
        </div></>

    );
}
export default Banner;
