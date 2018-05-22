import $ from 'jquery';
import React from 'react';
import ReactDOM from 'react-dom';

export default class SheetMusicPageVariant extends React.Component {
    constructor(props) {
        super(props);

        this.el = document.createElement('div');
        this.root = props.root;
        this.state = {
            variants: props.variants, 
            selectedQuantity: props.selectedQuantity
        };

        this.addToCart = props.addToCart.bind(this);
        this.selectQuantity = props.selectQuantity.bind(this);
        this.toggleVariant = props.toggleVariant.bind(this);
    }

    componentDidMount() {
        this.root.appendChild(this.el);
    }

    componentWillUnmount() {
        this.root.removeChild(this.el);
    }

    static getDerivedStateFromProps(nextProps, prevState) {
        return nextProps;
    }

    render() {
        const state = this.state;

        const variantButtons = state.variants.map((variant) =>
            <VariantButton key={variant.code} variant={variant} toggleVariant={this.toggleVariant} />
        );

        return ReactDOM.createPortal(
            <div>
                <p>Instrument:</p>
                <p className="expanded button-group">
                    {variantButtons}
                </p>
                <VariantDetails
                    selectedVariant={state.selectedVariant}
                    quantities={state.quantities}
                    selectedQuantity={state.selectedQuantity}
                    selectQuantity={this.selectQuantity}
                    addToCart={this.addToCart} />
            </div>,
            this.el
        );
    }
}

function VariantButton(props) {
    const code = props.variant.code;
    const instrument = props.variant.instrument;
    const isSelected = props.variant.isSelected;
    const toggleVariant = props.toggleVariant;

    return (
        <a className={isSelected ? "button" : "button secondary"} onClick={(e) => toggleVariant(code, e)}>
            {instrument}
        </a>
    );
}

function VariantDetails(props) {
    const addToCart = props.addToCart;
    const quantities = props.quantities;
    const selectedQuantity = props.selectedQuantity;
    const selectedVariant = props.selectedVariant;
    const selectQuantity = props.selectQuantity;

    if (!selectedVariant.code) {
        return <div></div>;
    }

    const quantityOptions = quantities.map((quantity) =>
        <QuantityOption key={quantity} quantity={quantity} />
    );

    return (
        <div>
            <h4>${selectedVariant.price}</h4>
            <p>{selectedVariant.code}</p>
            <p>Quantity:</p>
            <select value={selectedQuantity} onChange={(e) => selectQuantity(e.target.value)}>
                {quantityOptions}
            </select>
            <p>
                <a className="button large" onClick={addToCart}>Add to Cart</a>
            </p>
        </div>
    );
}

function QuantityOption(props) {
    const quantity = props.quantity;

    return <option value={quantity}>{quantity}</option>;
}