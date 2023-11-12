const links = document.getElementsByClassName('link');

for (const link of links) {
  if (link.getAttribute('href') === window.location.pathname) {
    link.classList.add('active');
  }
}
