import $ from 'jquery';
import React from 'react';
import ReactDOM from 'react-dom';
import { CartService } from '../cartService.js';
import CartPreview from './cartPreview.jsx';
import SheetMusicPage from './sheetMusicPage.jsx';

const cartService = new CartService();

ReactDOM.render(
    <CartPreview cartService={cartService} />,
    $('[cms-cart-preview]')[0]);

ReactDOM.render(
    <SheetMusicPage cartService={cartService} imageSelector="[cms-sheet-music-page-image]" variantSelector="[cms-sheet-music-page-variant]" />,
    $('[cms-sheet-music-page]')[0]);

cartService.gettingPreview();