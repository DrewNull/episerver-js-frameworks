import $ from 'jquery';

export class VueInitialization {

    static init(selector, createVue) {

        let elements = $(selector);

        let result = [];

        for (let index = 0; index < elements.length; index++) {

            let element = elements[index];

            var vue = createVue(element);

            result.push(vue);
        }

        return result;
    }

}