console.log('Hello Vue!');

import $ from 'jquery';
import { CartService } from './cartService';
import { CartPreview } from './vue/cartPreview';
import { SheetMusicPage } from './vue/sheetMusicPage';

const cartService = new CartService();

const cartPreviews =    initVue('[cms-cart-preview]'    , (el) => new CartPreview(el, cartService)   );
const sheetMusicPages = initVue('[cms-sheet-music-page]', (el) => new SheetMusicPage(el, cartService));

cartService.gettingPreview();

function initVue(selector, createVue) {

    let elements = $(selector);

    let result = [];

    for (let index = 0; index < elements.length; index++) {

        let element = elements[index];

        var vue = createVue(element);

        result.push(vue);
    }

    return result;
}