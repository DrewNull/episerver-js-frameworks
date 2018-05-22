import React from 'react';
import ReactDOM from 'react-dom';
import CartPreview from './cartPreview.jsx';
import { CartService } from '../cartService.js';
import $ from 'jquery';

const cartService = new CartService();

ReactDOM.render(
    <CartPreview cartService={cartService} />,
    $('[cms-cart-preview]')[0]
);

cartService.gettingPreview();