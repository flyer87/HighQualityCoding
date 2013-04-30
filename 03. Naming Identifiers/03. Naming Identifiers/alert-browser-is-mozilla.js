function alertBrowserIsMozilla(event, args) {
    var currentWindow = window;
    var currentBrowser = currentWindow.navigator.appCodeName;

    var isMozilla = currentBrowser === "Mozilla";
    if (isMozilla) {
        window.alert("Yes");
    }
    else {
        window.alert("No");
    }
}
