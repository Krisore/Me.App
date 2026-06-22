
window.meUI = {
    initScrollHeader: function (containerId, headerId) {
        const scrollContainer = document.getElementById(containerId);
        const header = document.getElementById(headerId);

        let lastScrollY = 0;
        let hideTimer; // This variable will hold our countdown clock

        if (!scrollContainer || !header) {
            return;
        }

        scrollContainer.addEventListener('scroll', () => {
            const currentScrollY = scrollContainer.scrollTop;
            clearTimeout(hideTimer);

            if (currentScrollY > lastScrollY && currentScrollY > 50) {

                hideTimer = setTimeout(() => {
                    header.classList.add('header-hidden');
                }, 2000);
            } else {
                header.classList.remove('header-hidden');
            }

            lastScrollY = currentScrollY <= 0 ? 0 : currentScrollY;
        }, { passive: true });
    }
};