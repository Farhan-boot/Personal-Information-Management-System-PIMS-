/**
 *
 * You can write your JS code here, DO NOT touch the default style file
 * because it will make it harder for you to update.
 * 
 */

"use strict";


/**
 * Get UI date string
 * @param {Date} date - date to convert
 */
function getUIDateString(date) {
    date = new Date(date);

    if (typeof date.getMonth === 'function') {
        var month = (date.getMonth() + 1).toString().padStart(2, '0');
        var day = date.getDate().toString().padStart(2, '0');
        var year = date.getFullYear();

        return `${year}-${month}-${day}`;
    }

    return "";
}

// Custom Validators
const _isInteger = num => /^-?[0-9]+$/.test(num + '');
const _isEmail = (email) => {
    return /^\w+@@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$/.test(email);
}
const _isEnglish = (str) => {
    return /^[\x20-\x7E]*$/.test(str);
}

$.validator.addMethod(
    '_mustBeInteger',
    function (value, element, requiredValue) {
        return _isInteger(value);
    },
    'Must be a valid number.'
);
$.validator.addMethod(
    '_mustBeIntegerOptional',
    function (value, element, requiredValue) {
        if (value) {
            return _isInteger(value);
        }
        return true;
    },
    'Must be a valid number.'
);
$.validator.addMethod(
    '_isEmail',
    function (value) {
        return isEmail(value);
    },
    'Invalid Email'
);
$.validator.addMethod(
    '_isEmailOptional',
    function (value) {
        if (value) {
            return _isInteger(value);
        }
        return true;
    },
    'Invalid Email'
);
$.validator.addMethod(
    '_isEnglish',
    function (value) {
        return _isEnglish(value);
    },
    'Please enter English characters'
);
