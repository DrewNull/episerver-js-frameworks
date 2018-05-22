import $ from 'jquery';

export class CartService {

    constructor() {
        this.onCartUpdated = [];
    }

    addingToCart(code, quantity) {

        var deferred = $.Deferred();

        $.ajax({
            data: {
                code: code,
                quantity: quantity
            },
            error: () => {
                deferred.reject();
            },
            method: 'POST',
            success: (data) => {
                this.cartUpdated(data);
                deferred.resolve(data);
            },
            url: '/api/cart/add-to-cart'
        });

        return deferred;
    }

    cartUpdated(data) {
        for (const handler of this.onCartUpdated) {
            handler(data);
        }
    }

    gettingPreview() {

        var deferred = $.Deferred();

        $.ajax({
            error: () => {
                deferred.reject();
            },
            method: 'GET',
            success: (data) => {
                this.cartUpdated(data);
                deferred.resolve(data);
            },
            url: '/api/cart/get-preview'
        });

        return deferred;
    }

};