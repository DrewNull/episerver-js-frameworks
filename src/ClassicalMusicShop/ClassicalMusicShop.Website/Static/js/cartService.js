import $ from 'jquery';

export class CartService {
    constructor() {

        this.addingToCart = function(code, quantity) {

            var deferred = $.Deferred();

            $.ajax({
                data: {
                    code: code,
                    quantity: quantity
                },
                error: () => addingToCartError(deferred),
                method: 'POST', 
                success: (data) => addingToCartSuccess(data, deferred),
                url: '/api/cart/add-to-cart'
            });

            return deferred;
        };

        function addingToCartError(deferred) {
            deferred.reject();
        }

        function addingToCartSuccess(data, deferred) {
            deferred.resolve(data);
        }

    }
};