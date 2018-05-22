import React from 'react';

export default class CartPreview extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            count: 0,
            amount: ''
        };

        props.cartService.onCartUpdated.push((data) => {
            this.setState({
                count: data.count, 
                amount: data.amount
            });
        });
    }

    render() {
        const state = this.state;
        return (
            <a href="#" className="cart-preview__link">
                <i className="fi-shopping-cart cart-preview__icon"></i>
                <CartPreviewDetail count={state.count} amount={state.amount} />
            </a>
        );
    }
};

function CartPreviewDetail(props) {

    if (props.count < 1) {
        return <span></span>;
    }

    return (
        <span>
            {' '}
            <span className="cart-preview__count">
                ({props.count})
            </span>
            {' '}
            <span className="cart-preview__amount">
                {props.amount}
            </span>
            {' '}
        </span>
    );
};