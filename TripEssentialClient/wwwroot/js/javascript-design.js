let shouldHidePopupBackground = true

window.onresize = (e) => {

    e.preventDefault()

    reCenterPopupFormSmall()
    reCenterPopupFormProgressBar()
}

const formatNumber = (number) => {
    return isNaN(number) ? "" : number.toString().replace(/\B(?=(\d{3})+(?!\d))/g, '$&,')
}

const formatFloat = (number) => {
    return isNaN(number) ? "" : number.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,')
}

const removeLineBreaks = (string) => {
    return string.replace(/\s{2,}/g, "")
}

const removeWhiteSpaceAndComma = (string) => {
    let _result = string.replace(/\,/g, '')
    _result = _result.replace(",","")
    return _result
}

const handleError = (response) => {
    if (!response.ok) {
        return response.text().
            then((error) => {
                throw Error(error)
            })
    }
    return response
}

const handleErrors = (responses) => {

    for (let i = 0; i < responses.length; i++) {
        if (!responses[i].ok) {
            return responses[i].text().
                then((error) => {
                    throw Error(error)
                })
            break
        }
    }
    return responses
}

const htmlDataType = (response) => {
    return response.text()
}

const jsonDataType = (response) => {
    return response.json()
}

const postOptions = (body) => {
    return {
        method: "POST",
        headers: {
            "Content-Type": "application/x-www-form-urlencoded; charset=UTF-8"
        },
        body: body
    }
}

const isVisible = (element) => {

    if (!!element) {

        const _style = window.getComputedStyle(element)

        return (
            _style.opacity !== "0" &&
            _style.display !== "none" &&
            _style.visibility !== "hidden")
    }
    else {
        return false
    }
}

const show = (element) => {
    element.style.display = "block"
}

const hide = (element) => {
    element.style.display = "none"
}

const toggle = (element) => {

    if (window.getComputedStyle(element).display === "block") {
        hide(element)
    }
    else {
        show(element)
    }
}

const showPopupFormProgressBar = () => {

    const _backgroundPopup = document.querySelector(".background-popup"),
        _popupFormProgressBar = document.querySelector(".popup-form-progress-bar")

    _popupFormProgressBar.classList.remove("hide-popup-form-progress-bar")
    _popupFormProgressBar.classList.add("show-popup-form-progress-bar")

    centerPopupFormProgressBar(_popupFormProgressBar)

    if (isVisible(_backgroundPopup)) {
        shouldHidePopupBackground = false
        _backgroundPopup.style.cssText = "z-index:6"
    }
    else {
        shouldHidePopupBackground = true;
        showPopupBackground()
    }
}

const hidePopupFormProgressBar = () => {

    const _popupFormProgressBar = document.querySelector(".popup-form-progress-bar")

    _popupFormProgressBar.classList.remove("show-popup-form-progress-bar")
    _popupFormProgressBar.classList.add("hide-popup-form-progress-bar")

    if (shouldHidePopupBackground) {
        hidePopupBackground()
    }
    else {
        document.querySelector(".background-popup").style.cssText = "z-index:3"
    }
}

const showPopupForm = () => {

    hidePopupFormProgressBar()

    let _popupForm

    if (!!document.querySelector(".popup-form-small")) {
        _popupForm = document.querySelector(".popup-form-small")

        centerPopupFormSmall(_popupForm)
    }
    
    if (!!_popupForm) {

        showPopupBackground()

        _popupForm.classList.remove("hide-popup-form")
        _popupForm.classList.add("show-popup-form")
    }
}

const showPopupFormHtml = (data) => {
    document.querySelector("#popupFormToShow").innerHTML = data

    let _popupForm

    if (!!document.querySelector(".popup-form-small")) {
        _popupForm = document.querySelector(".popup-form-small")

        centerPopupFormSmall(_popupForm)
    }

    if (!!_popupForm) {

        showPopupBackground()

        _popupForm.classList.remove("hide-popup-form")
        _popupForm.classList.add("show-popup-form")
    }
}

const hidePopupForm = () => {

    let _popupForm

    if (!!document.querySelector(".popup-form-small")) {
        _popupForm = document.querySelector(".popup-form-small")
    }

    if (!!_popupForm) {

        _popupForm.classList.remove("show-popup-form")
        _popupForm.classList.add("hide-popup-form")

        hidePopupBackground()
    }
}

const showErrorPopupForm = (error) => {
    fetch(`/Shared/Ok?okMessage=${error}&messageSymbol=x`).
        then(handleError).
        then(htmlDataType).
        then((data) => {
            showPopupFormHtml(data)
        }).
        catch((error) => {
            console.log(error)
        })
}

const reCenterPopupFormProgressBar = () => {

    const _popupForm = document.querySelector(".popup-form-progress-bar")
    if (isVisible(_popupForm)) {
        centerPopupFormProgressBar(_popupForm)
    }
}

const reCenterPopupFormSmall = () => {

    const _popupForm = document.querySelector(".popup-form-small")

    if (isVisible(_popupForm)) {
        centerPopupFormSmall(_popupForm)
    }
}

function hidePopupBackground() {

    const _backgroundPopup = document.querySelector(".background-popup")

    _backgroundPopup.classList.remove("show-popup-background")
    _backgroundPopup.classList.add("hide-popup-background")
}

function showPopupBackground() {

    const _backgroundPopup = document.querySelector(".background-popup")

    _backgroundPopup.classList.remove("hide-popup-background")
    _backgroundPopup.classList.add("show-popup-background")
}

function centerPopupFormProgressBar(popupForm) {

    const _windowWidth = document.documentElement.clientWidth,
        _popupWidth = popupForm.clientWidth

    popupForm.style.cssText =
        `top:${window.pageYOffset + 6}px;left:${_windowWidth / 2 - _popupWidth / 2}px`
}

function centerPopupFormSmall(popupForm) {

    const _windowWidth = document.documentElement.clientWidth,
        _popupWidth = popupForm.clientWidth

    popupForm.style.cssText =
        `top:${window.pageYOffset + 10}px;left:${_windowWidth / 2 - _popupWidth / 2}px`
}

