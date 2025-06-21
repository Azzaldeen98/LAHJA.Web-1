//////function toggleTheme() {
//////    var body = document.body;
//////    var icon = document.getElementById('theme-icon'); // الحصول على الأيقونة

//////    if (body.classList.contains('dark-mode')) {
//////        body.classList.remove('dark-mode');
//////        body.classList.add('light-mode');
//////        localStorage.setItem('theme', 'light');
//////        icon.classList.remove('fa-moon');
//////        icon.classList.add('fa-sun');
//////    } else {
//////        body.classList.remove('light-mode');
//////        body.classList.add('dark-mode');
//////        localStorage.setItem('theme', 'dark');
//////        icon.classList.remove('fa-sun');
//////        icon.classList.add('fa-moon');
//////    }
//////}

//////// تحميل الوضع المخزن عند تحميل الصفحة
//////window.onload = function () {
//////    var theme = localStorage.getItem('theme');
//////    var icon = document.getElementById('theme-icon');

//////    if (theme === 'dark') {
//////        document.body.classList.add('dark-mode');
//////        icon.classList.add('fa-moon');
//////    } else {
//////        document.body.classList.add('light-mode');
//////        icon.classList.add('fa-sun');
//////    }
//////};
////////@inject IJSRuntime JS
////////@using MudBlazor
////////@inject IJSRuntime JSRuntime


////////    < h3 > تبديل الوضع الليلي والنهاري باستخدام MudBlazor</h3 >

////////        <button @onclick="ToggleTheme" class="btn" >
////////    <i id="theme-icon" class="fas"></i>  <!--الأيقونة -->
////////</button >
////////  private async Task ToggleTheme()
////////{
////////    await JSRuntime.InvokeVoidAsync("toggleTheme");
////////}

////const swiper = new Swiper('.swiper', {
////    slidesPerView: 2,
////    spaceBetween: 50,
////    breakpoints: {
////        576: { slidesPerView: 3 },
////        768: { slidesPerView: 4 },
////        1200: { slidesPerView: 6 },
////        1400: { slidesPerView: 7 },
////    },
////});
document.addEventListener('DOMContentLoaded', () => {
    const swiper = new Swiper('.swiper-container', {
        slidesPerView: 1,
        spaceBetween: 10,
        loop: true,
        navigation: {
            nextEl: '.swiper-button-next',
            prevEl: '.swiper-button-prev',
        },
        pagination: {
            el: '.swiper-pagination',
            clickable: true,
        },
        autoplay: {
            delay: 3000,
            disableOnInteraction: false,
        },
        effect: 'slide',
    });
});

