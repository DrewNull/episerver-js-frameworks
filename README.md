# javascript-episerver-ope
Angular, Vue.js, and React with Episerver on-page-editing.

This is an example of an online store that sells copies of sheet music. The sheet music product detail page and add-to-cart functionality is highlighted in this example.

Interesting Vue bits:
- [IndexVue.cshtml](https://github.com/DrewNull/javascript-episerver-ope/blob/master/src/ClassicalMusicShop/ClassicalMusicShop.Website/Features/SheetMusic/Views/IndexVue.cshtml) - Sheet music product detail page view
- [main-vue.js](https://github.com/DrewNull/javascript-episerver-ope/blob/master/src/ClassicalMusicShop/ClassicalMusicShop.Website/Static/js/main-vue.js) - Main entry point for custom code
- [Vue components](https://github.com/DrewNull/javascript-episerver-ope/tree/master/src/ClassicalMusicShop/ClassicalMusicShop.Website/Static/js/vue) - Sheet music page and cart preview Vue components
- [MainLayoutVue.cshtml](https://github.com/DrewNull/javascript-episerver-ope/blob/master/src/ClassicalMusicShop/ClassicalMusicShop.Website/Features/Layout/Views/MainLayoutVue.cshtml) - Razor layout where <script> files are embedded
