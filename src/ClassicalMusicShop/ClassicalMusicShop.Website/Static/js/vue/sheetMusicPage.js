import Vue from 'vue';
import $ from 'jquery';

export class SheetMusicPage extends Vue {
    constructor(el, cartService) {
        super({
            el: el, 
            data: {
                variants: [], 
                quantities: [], 
                productImage: {}, 
                selectedVariant: {},
                selectedQuantity: 1, 
                selectedImage: {}
            }, 
            methods: {
                addToCart: addToCart,
                hasSelectedVariant: hasSelectedVariant, 
                isSelectedVariant: isSelectedVariant, 
                toggleVariant: toggleVariant
            }
        });

        function addToCart(event) {
            cartService.addingToCart(this.selectedVariant.code, this.selectedQuantity);
            this.selectedQuantity = 1;
        }

        function hasSelectedVariant() {
            return !!this.selectedVariant && !!this.selectedVariant.code;
        }

        function isSelectedVariant(code) {

            if (this.hasSelectedVariant()) {
                return this.selectedVariant.code === code;
            }

            return false;
        }

        function toggleVariant(code) {

            if (!this.hasSelectedVariant() || !this.isSelectedVariant(code)) {

                for (let variant of this.variants) {

                    if (variant.code === code) {

                        this.selectedVariant = variant;
                        this.selectedImage = variant.mainImage;
                        return;
                    }
                }
            }

            this.selectedImage = this.productImage;
            this.selectedVariant = {};
        }

        function update() {
            this.selectedQuantity = 1;
        }

        this.quantities = JSON.parse($(el).attr('data-cms-quantities'));
        this.variants = JSON.parse($(el).attr('data-cms-variants'));
        this.productImage = JSON.parse($(el).attr('data-cms-product-image'));
        this.selectedImage = this.productImage;

        cartService.onCartUpdated.push(update.bind(this));
    }
}