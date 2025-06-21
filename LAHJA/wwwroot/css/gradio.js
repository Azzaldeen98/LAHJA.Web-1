<

import {Client} from "https://cdn.jsdelivr.net/npm/@gradio/client/dist/index.min.js"; // تحميل مكتبة Gradio من CDN


        import {Client} from "@gradio/client";

        const client = await Client.connect("wasmdashai/smplate");
        const result = await client.predict("/predict", {
            text: "Hello!!",
        key: "Hello!!", 
});

        console.log(result.data);

document.getElementById('textForm').addEventListener('submit', async (event) => {
            event.preventDefault(); // منع إرسال النموذج بشكل افتراضي

        const outputElement = document.getElementById('output');
        const audioPlayer = document.getElementById('audioPlayer');
        const textInput = document.getElementById('textInput').value.trim();

        outputElement.textContent = 'Sending request...';
        audioPlayer.style.display = 'none'; // إخفاء مشغل الصوت حتى يتم استلام الملف

        if (!textInput) {
            outputElement.textContent = 'Error: Text input is required.';
        return;
}

        try {
// الاتصال بـ Gradio API
const client = await Client.connect("wasmdashai/wasm-ara");

        // إرسال النص إلى واجهة Gradio API
        const result = await client.predict("/predict", {
            text: textInput // النص الذي سيتم تحويله إلى صوت
});

        outputElement.textContent = Result: ${JSON.stringify(result.data)};


        if (result.data) {
            audioPlayer.src = result.data[0].url; // تعيين رابط الصوت
        audioPlayer.style.display = 'block'; // إظهار مشغل الصوت
        audioPlayer.play(); // تشغيل الصوت تلقائيًا
}

} catch (error) {
            outputElement.textContent = Error: ${error.message};
}
});


 