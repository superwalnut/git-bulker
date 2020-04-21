import '../public/styles/lib/bootstrap.min.css';
import '../public/styles/site.scss';
import React from 'react';

function MyApp({ Component, pageProps }) {
    return <Component {...pageProps} />
}

export default MyApp;