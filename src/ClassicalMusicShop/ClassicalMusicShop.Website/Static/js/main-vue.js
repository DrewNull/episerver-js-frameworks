console.log('Hello Vue!');

import { CartService } from './cartService';
import { CartPreview } from './vue/cartPreview';
import { SheetMusicPage } from './vue/sheetMusicPage';
import { VueInitialization } from './vue/vueInitialization';

const cartService = new CartService();

const cartPreviews    = VueInitialization.init('[cms-cart-preview]'    , (el) => new CartPreview(el, cartService)   );
const sheetMusicPages = VueInitialization.init('[cms-sheet-music-page]', (el) => new SheetMusicPage(el, cartService));

cartService.gettingPreview();