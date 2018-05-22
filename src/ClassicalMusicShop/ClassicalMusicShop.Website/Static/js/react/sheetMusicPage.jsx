import $ from 'jquery';
import React from 'react';
import ReactDOM from 'react-dom';
import SheetMusicPageImage from './sheetMusicPageImage.jsx';
import SheetMusicPageVariant from './sheetMusicPageVariant.jsx';

export default class SheetMusicPage extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            variants: [],
            quantities: [],
            productImage: {},
            selectedVariant: {},
            selectedQuantity: 1,
            selectedImage: {}
        };

        this.cartService = props.cartService;
        this.imageSelector = props.imageSelector;
        this.variantSelector = props.variantSelector;

        this.addToCart = this.addToCart.bind(this);
        this.selectQuantity = this.selectQuantity.bind(this);
        this.toggleVariant = this.toggleVariant.bind(this);
    }

    componentDidMount() {

        const parentNode = ReactDOM.findDOMNode(this).parentNode;
        const quantities = JSON.parse(parentNode.getAttribute('data-cms-quantities'));
        const variants = JSON.parse(parentNode.getAttribute('data-cms-variants'));
        const productImage = JSON.parse(parentNode.getAttribute('data-cms-product-image'));

        this.setState({
            productImage: productImage, 
            quantities: quantities,
            selectedImage: productImage, 
            variants: variants,
        });
    }

    selectQuantity(quantity) {
        this.setState({
            selectedQuantity: quantity
        });
    }

    addToCart() {
        const state = this.state;

        this.cartService.addingToCart(
            state.selectedVariant.code,
            state.selectedQuantity);

        this.setState({
            selectedQuantity: 1
        });
    }

    hasSelectedVariant() {
        const state = this.state;

        return !!state.selectedVariant && !!state.selectedVariant.code;
    }

    isSelectedVariant(code) {
        const state = this.state;

        if (this.hasSelectedVariant()) {
            return state.selectedVariant.code === code;
        }

        return false;
    }

    toggleVariant(code) {
        const state = this.state;

        if (!this.hasSelectedVariant() || !this.isSelectedVariant(code)) {

            for (let variant of state.variants) {

                if (variant.code === code) {

                    this.setState({
                        selectedVariant: variant,
                        selectedImage: variant.mainImage
                    });

                    return;
                }
            }
        }

        this.setState({
            selectedImage: state.productImage,
            selectedVariant: {}
        });
    }

    render() {
        const state = this.state;

        const variants = state.variants.map((variant) => {
            return {
                code: variant.code, 
                instrument: variant.instrument,
                isSelected: this.isSelectedVariant(variant.code)
            }
        });

        return (
            <div>
                <SheetMusicPageImage
                    root={$(this.imageSelector)[0]}
                    selectedImage={state.selectedImage} />
                <SheetMusicPageVariant
                    addToCart={this.addToCart}
                    quantities={state.quantities}
                    root={$(this.variantSelector)[0]}
                    selectedQuantity={state.selectedQuantity} 
                    selectedVariant={state.selectedVariant}
                    selectQuantity={this.selectQuantity}
                    toggleVariant={this.toggleVariant}
                    variants={variants} />
            </div>
        );
    }
}