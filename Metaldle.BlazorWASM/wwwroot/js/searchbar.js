window.registerEnterKey = (dotNetHelper) => {
    document.addEventListener('keydown', (e) => {
        if (e.code === 'Enter' || e.code === 'NumpadEnter') {
            dotNetHelper.invokeMethodAsync('SubmitOnEnter');
        }
    });
};