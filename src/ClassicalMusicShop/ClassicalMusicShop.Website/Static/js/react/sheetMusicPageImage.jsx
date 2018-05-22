import $ from 'jquery';
import React from 'react';
import ReactDOM from 'react-dom';

export default class SheetMusicPageImage extends React.Component {
    constructor(props) {
        super(props);

        this.el = document.createElement('div');
        this.root = props.root;
        this.state = {
            selectedImage: props.selectedImage
        };
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
        let state = this.state;
        return ReactDOM.createPortal(
            <img className="thumbnail" src={state.selectedImage.src} alt={state.selectedImage.alt} />,
            this.el
        );
    }
}