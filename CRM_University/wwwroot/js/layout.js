var isOpenMenu = true;
var links = document.getElementsByClassName('linkText');
var items = document.getElementsByClassName('item');
var brandName = document.querySelector('.brandName');
var isOpenLogout = false;
var logoutBtn = document.querySelector('.logOut');



function toggle() {
    const nav = document.querySelector('.navigation');
    if (isOpenMenu) {
        nav.style.width = '3%';
        closeAllLinks();
    } else {
        nav.style.width = '20%';
        openAllLinks();

    }
    isOpenMenu = !isOpenMenu;
}

function closeAllLinks() {
    brandName.style.display = 'none';
    for (let i = 0; i < links.length; i++) {
        links[i].style.display = 'none';
    }
    for (let i = 0; i < items.length; i++) {
        items[i].classList.add('closed');
        console.log(items[i].classList)
    }
}
function openAllLinks() {
    brandName.style.display = 'inline-block';

    for (let i = 0; i < links.length; i++) {
        links[i].style.display = 'inline-block';
    }
    for (let i = 0; i < items.length; i++) {
        items[i].classList.remove('closed');
    }
}
function toogleLogOut(event) {
    if (isOpenLogout) {
        logoutBtn.style.display = "none";
    } else {
        logoutBtn.style.display = "inline-block";
    }
    isOpenLogout = !isOpenLogout;
}

document.querySelector('body').addEventListener('click', () => {
    if (isOpenLogout) {
        logoutBtn.style.display = "none";
    }
    isOpenLogout = false;
})
document.querySelector('#toogleLogOut').addEventListener('click', (event) => {
    toogleLogOut(event);
    event.stopPropagation();
})