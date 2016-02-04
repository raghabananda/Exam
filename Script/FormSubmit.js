window.onload = function () {
    window.setTimeout(function () { redirect(); }, 60000);
};
function redirect() {
    document.getElementById('FormPost').submit();
}