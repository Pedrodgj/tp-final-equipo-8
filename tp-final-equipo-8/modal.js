
    const openModalBtns = document.querySelectorAll('.openModalBtn');
    const closeModalBtns = document.querySelectorAll('.closeModalBtn');
    const modals = document.querySelectorAll('.myModal');

    openModalBtns.forEach((openModalBtn, index) => {
        openModalBtn.addEventListener('click', (e) => {
            e.preventDefault();
            modals[index].classList.remove('hidden');
        });

        closeModalBtns[index].addEventListener('click', () => {
            modals[index].classList.add('hidden');
        });
    });
