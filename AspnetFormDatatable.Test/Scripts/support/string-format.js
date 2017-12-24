(function () {
    /**
    * This helper requiest following library
    * - Numeral-js
    * - moment js
    */
    window.stringFormat = {
        number: function (value) {
            return {
                toString: function (format) {
                    // Format could be: '0,0'
                    return numeral(value).format(format);
                }
            }
        },
        dateTime: function (value) {
            return {
                toString: function (format) {
                    return moment(value).format(format);
                }
            }
        }
    };
})();