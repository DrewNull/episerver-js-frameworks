import Vue from 'vue';

export class CartPreview extends Vue {
    constructor(el, cartService) {
        super({
            el: el,
            data: {
                count: 0,
                amount: ''
            },
            methods: {
                hasItems: hasItems
            }
        });

        function hasItems() {
            return this.count > 0;
        }

        function update(cartPreview) {
            this.count = cartPreview.count;
            this.amount = cartPreview.amount;
        }

        cartService.onCartUpdated.push(update.bind(this));
    }
}