export const toUrl = function (page) {
    if (page.charAt(0) === '/') {
        page = page.substring(1);
    }
    return `/${page}`;
}