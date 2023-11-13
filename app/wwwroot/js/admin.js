const links = document.getElementsByClassName('link');

for (const link of links) {
  if (window.location.pathname.includes(link.getAttribute('href'))) {
    link.classList.add('active');
  }
}
