 window.addEventListener('load', () => {
      const splash = document.getElementById('splash');
      const site = document.getElementById('site-content');
      const logo = document.getElementById('logo');

      // Fade-in splash and logo after a short delay
      setTimeout(() => {
        splash.classList.add('opacity-100');
        logo.classList.add('opacity-100');
      }, 50);

      // Fade-out with smooth scaling
      setTimeout(() => {
        logo.classList.remove('animate-scaleUpSlow');
        logo.classList.add('animate-fadeOutSmooth');
      }, 2000);

      // Hide splash after animation
      setTimeout(() => {
        splash.classList.remove('opacity-100');
        splash.classList.add('opacity-0');
      }, 2500);

      // Remove splash and show main site
      setTimeout(() => {
        splash.style.display = 'none';
        site.classList.remove('hidden');
        document.body.classList.remove('overflow-hidden');
      }, 2900);
    });