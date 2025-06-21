window.copyToClipboard = (text) => {
    navigator.clipboard.writeText(text).then(() => {
        console.log(" „ «·‰”Œ »‰Ã«Õ: " + text);
    }).catch(err => {
        console.error("Œÿ√ ›Ì «·‰”Œ: ", err);
    });
};


window.deleteCookie = function (cookieName) {
 
    document.cookie = cookieName + "=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
}


window.reloadPage = function () {
    location.reload();
};

window.createObjectURL = (file) => {
    return URL.createObjectURL(new Blob([file]));
};


window.preventRefreshLoss = (message) => {
    window.onbeforeunload = function () {
        return message;
    };
};

function toggleDarkMode(isDark) {
  
    const iframe = document.querySelector("iframe");
    if (iframe.contentWindow) {
        iframe.contentWindow.postMessage({ darkMode: isDark }, "*");
    }
}


//document.getElementById("darkModeToggle").addEventListener("click", function () {
   
//    const isDark = document.body.classList.toggle("dark-mode");
//    alert("-A")
//    toggleDarkMode(isDark);
//});

window.downloadAudioFromElement = (audioElementId, fileName) => {
    const audioElement = document.getElementById(audioElementId);

    if (audioElement && audioElement.currentSrc) {
        const linkElement = document.createElement('a');
        linkElement.href = audioElement.currentSrc;
        linkElement.download = fileName || 'audio-file.mp3';
        document.body.appendChild(linkElement);
        linkElement.click();
        document.body.removeChild(linkElement);
    } else {
        console.error("Audio source not found or invalid audio element.");
    }
};









function typeText(elementId, text, typingSpeed) {
    const container = document.getElementById(elementId);
    let i = 0;

    function type() {
        if (i < text.length) {
            container.innerHTML += text.charAt(i);
            i++;
            setTimeout(type, typingSpeed);
        }
    }

    container.innerHTML = ""; //  ›—Ì€ «·‰’ «·”«»ﬁ
    type();
}


function controlSoundAnimation(isStart = false) {

    var animate = document.getElementById("logo-icon-animate-id");

    if (animate != null) {
        animate.style.display = (isStart) ? "flex !important" : "none !important";
    }

    var static = document.getElementById("logo-icon-static-id");

    if (static != null) {
        static.style.display = (!isStart) ? "block !important" : "none !important";
    }
}



async function queryT2S(data) {
        const response = await fetch(
            data.Url, 
            {
                headers: data.Headers,
                method: data.Method,
                body: JSON.stringify(data.Data),
            }
        );
        const result = await response.blob(); // Returns a blob containing the audio data
        return result;
    }

async function queryModelTextToSpeech(data) {


  
             data = JSON.parse(data);

            if (!data) {
                alert("Please enter some text");
                return "333";
            }

            const audioData = await queryT2S(data);

            // Create a URL for the audio Blob
            const audioUrl = URL.createObjectURL(audioData);

            // Get the audio player element and set the source
    const audioPlayer = document.getElementById(data.TagId);
            audioPlayer.src = audioUrl;

            // Play the audio
        audioPlayer.play();

        return "222";
   
}


//async function queryModelTextToSpeech2(data) {

//    alert(777)
//             data = JSON.parse(data);

//            if (!data) {
//                alert("Please enter some text");
//                return "333";
//            }

//            const audioData = await queryT2S(data);

//            // Create a URL for the audio Blob
//            const audioUrl = URL.createObjectURL(audioData);

//            // Get the audio player element and set the source
//    const audioPlayer = document.getElementById(data.TagId);
//            audioPlayer.src = audioUrl;

//            // Play the audio
//        audioPlayer.play();

//        return "222";
   
//    }

async function queryT2S1(inputText) {

    const response = await fetch(
        "https://api-inference.huggingface.co/models/wasmdashai/vits-ar-sa-huba-v2",
        {
            headers: {
                Authorization: "", // Replace with your actual API token
                "Content-Type": "application/json",
            },
            method: "POST",
            body: JSON.stringify(inputText),
        }
    );
    const result = await response.blob(); // Returns a blob containing the audio data
    return result;
}



//async function queryModelTextToSpeech1(inputText) {

//    if (!inputText) {
//        alert("Please enter some text");
//        return "333";
//    }

//    const audioData = await queryT2S1(inputText);

//    // Create a URL for the audio Blob
//    const audioUrl = URL.createObjectURL(audioData);

//    // Get the audio player element and set the source
//    const audioPlayer = document.getElementById("OutputPlayerId");
//    audioPlayer.src = audioUrl;

//    // Play the audio
//    audioPlayer.play();

//}



//async function getEventIdAndData() {
//    // Make the first POST request to get the EVENT_ID
//    const response = await fetch('https://wasmdashai-lahja-ai.hf.space/call/predict', {
//        method: 'POST',
//        headers: {
//            'Content-Type': 'application/json',
//        },
//        body: JSON.stringify({
//            data: [
//                "Hello!!",
//                "wasmdashai/vits-ar-sa-huba-v1",
//                0
//            ]
//        })
//    });

//    // Parse the response and extract the EVENT_ID
//    const data = await response.json();
//    const eventId = data?.event_id || '';  // Extract the event ID if available

//    if (!eventId) {
//        console.error('EVENT_ID not found');
//        return;
//    }

//    // Make the second request to get the result using the EVENT_ID
//    const finalResponse = await fetch(`https://wasmdashai-lahja-ai.hf.space/call/predict/${eventId}`, {
//        method: 'GET'
//    });

//    // Parse and log the result
//    const result = await finalResponse.json();
//    console.log(result);
//}



   

//import { Client } from "https://cdn.jsdelivr.net/npm/@gradio/client/dist/index.min.js"; //  Õ„Ì· „ﬂ »… Gradio „‰ CDN

//async function Text2Text(data) {

//    try {

//        data = JSON.parse(data);

//        const client1 = await Client.connect(data.Space);
//        const result = await client1.predict(data.Function, {
//            text: data.Input,
//            key: data.Key,
//        });

//        const textres = result.data;

//        return textres;
//    } catch {
//        return null;
//    }

//}

//async function Text2Speech(data) {

//    try {
//        // «·« ’«· »‹ Gradio API
//        data = JSON.parse(data);

//        const client = await Client.connect(data.Space);
//        const result = await client.predict(data.Function, {
//            text: data.Input,
//            name_model: data.Model,
//            speaking_rate: data.SR,
//        });




//        const audioPlayer = document.getElementById(data.AudioPlayerID);
//        if (result.data) {
//            audioPlayer.src = result.data[0].url; //  ⁄ÌÌ‰ —«»ÿ «·’Ê 
//            audioPlayer.style.display = 'block'; // ≈ŸÂ«— „‘€· «·’Ê 
//            audioPlayer.play(); //  ‘€Ì· «·’Ê   ·ﬁ«∆Ì«
//        }
//        return "222"
//    } catch (error) {

//        return "333.3"
//    }
//}
//async function VoiceBot(data) {

//    alert(data)
//    data = JSON.parse(data);
//    alert(data)
//    var text = Text2Text(data.Text2Text)
//    if (text != null) {
//        data.Speech.Input = text;

//        var res = Text2Speech(data.Speech)
//        return res
//    }

//    return "333.3"

//}
async function t2t(data) {
    //const url = 'https://wasmdashai-t2t.hf.space/gradio_api/call/predict';

    data = JSON.parse(data);

    try {
        // Step 1: POST request to get EVENT_ID
        const postResponse = await fetch(data.URL, {
            method: data.Method,
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                data: [data.Text, data.Key],
            }),
        });

        const postData = await postResponse.json();
        const eventId = postData?.event_id;





        const getResponse = await fetch(`${data.URL}/${eventId}`, {
            method: 'GET',
        });

        const reader = getResponse.body.getReader();
        const decoder = new TextDecoder('utf-8');
        let result = '';

        while (true) {
            const { done, value } = await reader.read();
            if (done) break;
            result += decoder.decode(value);
        }

        const dataLine = result.split('\n').find(line => line.startsWith('data:'));
        const jsonString = dataLine.replace('data: ', '');

        return jsonString;
    } catch (error) {

        return null;
    }
}
//async function t2t(data) {

//    alert("Alert")
//    const url = 'https://wasmdashai-t2t.hf.space/gradio_api/call/predict';



//    try {

//        data = JSON.parse(data);
//        // Step 1: POST request to get EVENT_ID
//        const postResponse = await fetch(data.URL, {
//            method: data.Method,
//            headers: {
//                'Content-Type': 'application/json',
//            },
//            body: JSON.stringify({
//                data: [data.Text, data.Key],
//            }),
//        });

//        const postData = await postResponse.json();
//        const eventId = postData?.event_id;
        




//        const getResponse = await fetch(`${ data.URL } / ${ eventId }`, {
//            method: 'GET',
//        });
        
        
//        const reader = getResponse.body.getReader();
//        const decoder = new TextDecoder('utf-8');
//        let result = '';
        
//        while (true) {
//            const { done, value } = await reader.read();
//            if (done) break;
//            result += decoder.decode(value);
//        }
//        alert('jsonString')
//        const dataLine = result.split('\n').find(line => line.startsWith('data:'));
//        const jsonString = dataLine.replace('data: ', '');
        
//        return jsonString[0];
//    } catch (error) {

//        return null;
//    }
//}
window.playerAudioSource = (audioUrl, audioElementId = "audioPlayer") => {
    //alert(audioUrl)
    const audioElement = document.getElementById(audioElementId);
    audioElement.src = audioUrl;
    audioElement.play();
}
//function playerAudioSource(audioUrl) {

//    //const audioPlayer = document.getElementById("audioPlayer");
//    //audioPlayer.src = audioUrl;

//    //// Play the audio
//    //audioPlayer.play();

//    //fetch(audioUrl)
//    //    .then(response => {
//    //        if (!response.ok) throw new Error("Failed to fetch audio data");
//    //        return response.blob();
//    //    })
//    //    .then(blob => {
//            //const audioUrl = URL.createObjectURL(blob);
//            const audioElement = document.getElementById("audioPlayer");
//            audioElement.src = audioUrl;
//            audioElement.play();
//        //})
//        //.catch(error => {
//        //    console.error("Error:", error);
//        //});
//}
 function extractData(data) {
    // Split the data based on the keyword "data:"
    const parts = data.split('data: ');
    
    if (parts.length > 1) {
       
        const jsonData = JSON.parse(parts[1].trim());


                            const audioUrl = jsonData[0].url;

                            const audioPath = jsonData[0].path;
                            const originalName = jsonData[0].orig_name;


                            return {
                                audioUrl,
                                audioPath,
                                originalName
                            };
    } else {
        throw new Error("Data format incorrect.");
    }
}

//function convertTextToSpeech(text2) {

    ////data = JSON.parse(data);
    //var text = "«·”·«„ ⁄·Ìﬂ„";
    //if (!data) {
    //    alert("Please enter some text");
    //    return "333";
    //}
      

    //                        // Define the payload and headers
    //const payload = {
    //    data:
    //        [    text, // The text to convert to speech
    //            "wasmdashai/vits-ar-sa-huba-v2", // Model identifier
    //             0.6 // Speaker ID or variation
    //        ]
    //};

    //const headers = {
    //     "Content-Type": "application/json"
    //};

    //                        // Step 1: Send the POST request
    //      fetch("https://wasmdashai-runtasking.hf.space/call/predict", {
    //                         method: "POST",
    //                        headers: headers,
    //                        body: JSON.stringify(payload)
    //        }) .then(response => response.json())
    //            .then(data => {
    //                // Extract the EVENT_ID from the response
    //                const eventId = data.event_id; // Assuming the response format contains event ID here
    //                        console.log("Event ID:", eventId);

    //                        // Step 2: Use the EVENT_ID in the next request to fetch the audio file
    //                        return fetch(https://wasmdashai-runtasking.hf.space/call/predict/${eventId}, {
    //                            method: "GET"
    //                });
    //            })
    //            .then(response => {
    //                if (!response.ok) {
    //                    throw new Error("Failed to fetch audio data");
    //                }
    //                        // Parse the audio data as a Blob
    //                        return response.text();
    //            })
    //            .then(blob => {
    //                // Convert Blob to Object URL
    //                const extractedData = extractData(blob);
    //                        console.log(extractedData)

    //                        console.log("Event ID:",extractedData.audioUrl );

    //                        // Set the audio source to the Blob URL and play
    //                const audioElement = document.getElementById("audioPlayer");
    //                        audioElement.src ='https://wasmdashai-runtasking.hf.space/file='+extractedData.audioPath;
    //                        audioElement.play();
    //            })
    //            .catch(error => {
    //                            console.error("Error:", error);
    //            });

    //            return "222"
    //    }



function convertTextToSpeech() {


    alert("convertTextToSpeech")

 
    const text = "«·”·«„ ⁄·Ìﬂ„"; // «·‰’ «·«› —«÷Ì
    if (!text) {
        alert("Please enter some text");
        return "Input is required.";
    }

    // ≈⁄œ«œ «·»Ì«‰«  «··«“„…
    const payload = {
        data: [
            text, // «·‰’ «·„œŒ·
            "wasmdashai/vits-ar-sa-huba-v2", // „⁄—› «·‰„Ê–Ã
            0.6 // ID «·„ ÕœÀ √Ê «· ‰ÊÌ⁄
        ]
    };

    const headers = {
        "Content-Type": "application/json"
    };

    // «·ŒÿÊ… 1: ≈—”«· «·ÿ·» «·√Ê·
    fetch("https://wasmdashai-runtasking.hf.space/call/predict", {
        method: "POST",
        headers: headers,
        body: JSON.stringify(payload)
    })
        .then(response => {
            if (!response.ok) {
                throw new Error("Failed to send POST request");
            }
            return response.json();
        })
        .then(data => {
            const eventId = data.event_id; // «” Œ—«Ã event_id „‰ «·«” Ã«»…
            console.log("Event ID:", eventId);

            // «·ŒÿÊ… 2: ≈—”«· «·ÿ·» «·À«‰Ì ··Õ’Ê· ⁄·Ï «·„·› «·’Ê Ì
            return fetch(`https://wasmdashai-runtasking.hf.space/call/predict/${eventId}`, {
                method: "GET"
            });
        })
        .then(response => {
            if (!response.ok) {
                throw new Error("Failed to fetch audio data");
            }
            return response.json(); //  ÕÊÌ· «·«” Ã«»… ≈·Ï JSON
        })
        .then(data => {

            console.log("dataL:", data);
            // «· √ﬂœ „‰ «·»Ì«‰«  «·„” ·„…
            const audioUrl = data.audioPath; //  √ﬂœ „‰  ‰”Ìﬁ «·»Ì«‰«  ›Ì «·«” Ã«»…
            if (!audioUrl) {
                throw new Error("Audio URL not found in response");
            }

        
            console.log("Audio URL:", audioUrl);

            //  ‘€Ì· «·„·› «·’Ê Ì
            const audioElement = document.getElementById("audioPlayer");
            if (audioElement) {
                audioElement.src = `https://wasmdashai-runtasking.hf.space/file=${audioUrl}`;
                audioElement.play();
            } else {
                console.error("Audio element not found in the DOM");
            }
        })
        .catch(error => {
            console.error("Error:", error);
        });

    return "222";
}



window.speechRecognition = {
    recognition: null,
    lang: "ar-AR", 
    
    isSupported: function () {
        return ('webkitSpeechRecognition' in window || 'SpeechRecognition' in window);
    },

    setLanguage: function (language) {
        this.lang = language;
    },

    startSpeechRecognition: function () {

        //this.tagId = tagId;
        if (!this.isSupported()) {
            alert('Your browser does not support Speech Recognition. Please use Chrome or another modern browser.');
            return;
        }

        const SpeechRecognition = window.SpeechRecognition || window.webkitSpeechRecognition;
        if (!this.recognition) {
            this.recognition = new SpeechRecognition();
            this.recognition.lang = this.lang; 
            this.recognition.interimResults = true;
            this.recognition.continuous = true;

            this.recognition.onresult =async (event) => {
                const transcript = Array.from(event.results)
                    .map(result => result[0].transcript)
                    .join('');
                //DotNet.invokeMethodAsync('UpdateTranscription', transcript);
                //console.log(transcript.length()+"\n");

                document.getElementById("displayTranscript").value = transcript;
                
                if (event.results[0].isFinal) {
                   
                    const btn = document.getElementById("btnTranscript");
                    if (btn) {
                        btn.click();
                    } else {
                        console.error("Element with id 'btnTranscript' not found.");
                    }
                }
                //await DotNet.invokeMethodAsync('LAHJA', 'TriggerOnSubmit');

                //await dotNetObjectReference.invokeMethodAsync('LAHJA', 'UpdateTranscription', transcript);
            };

            this.recognition.onerror = (event) => {
                console.error(`Speech Recognition Error: ${event.error}`);
            };

            this.recognition.onend = () => {
                
               
                //console.log("Speech recognition stopped.");
            };
        }
        this.recognition.lang = this.lang;
        this.recognition.start();
    },

    stopSpeechRecognition: function () {
        if (this.recognition) {
            this.recognition.stop();
        }
    }
};


//window.speechRecognition = {
//    recognition: null,
//    lang: "ar-AR",
//    timeoutId: null, 
//    inactivityTimeout: 10000, 

//    isSupported: function () {
//        return ('webkitSpeechRecognition' in window || 'SpeechRecognition' in window);
//    },

//    setLanguage: function (language) {
//        this.lang = language;
//    },

//    resetTimeout: function () {
//        // ≈⁄«œ…  ⁄ÌÌ‰ «·„ƒﬁ 
//        if (this.timeoutId) {
//            clearTimeout(this.timeoutId);
//        }
//        this.timeoutId = setTimeout(() => {
//            this.stopSpeechRecognition(); // «· Êﬁ› »⁄œ «‰ Â«¡ «·„Â·…
//            console.log("Stopped listening due to inactivity.");
//        }, this.inactivityTimeout);
//    },

//    startSpeechRecognition: function () {
//        if (!this.isSupported()) {
//            alert('Your browser does not support Speech Recognition. Please use Chrome or another modern browser.');
//            return;
//        }

//        const SpeechRecognition = window.SpeechRecognition || window.webkitSpeechRecognition;
//        if (!this.recognition) {
//            this.recognition = new SpeechRecognition();
//            this.recognition.lang = this.lang;
//            this.recognition.interimResults = true;
//            this.recognition.continuous = true;

//            this.recognition.onresult = async (event) => {
//                const transcript = Array.from(event.results)
//                    .map(result => result[0].transcript)
//                    .join('');

//                document.getElementById("displayTranscript").value = transcript;
//                const btn = document.getElementById("btnTranscript");
//                if (btn) {
//                    btn.click();
//                } else {
//                    console.error("Element with id 'btnTranscript' not found.");
//                }

//                // ≈⁄«œ…  ⁄ÌÌ‰ «·„Â·… ⁄‰œ  ·ﬁÌ ‰ «∆Ã ÃœÌœ…
//                this.resetTimeout();
//            };

//            this.recognition.onerror = (event) => {
//                console.error(`Speech Recognition Error: ${event.error}`);
//            };

//            this.recognition.onend = () => {
//                console.log("Speech recognition stopped.");
//                clearTimeout(this.timeoutId); // „”Õ «·„Â·… ⁄‰œ «· Êﬁ›
//            };
//        }

//        this.recognition.lang = this.lang; //  ÕœÌÀ «··€… ⁄‰œ «· ‘€Ì·
//        this.recognition.start();
//        console.log("Speech recognition started.");

//        // ≈⁄œ«œ «·„Â·… ⁄‰œ »œ¡ «·«” „«⁄
//        this.resetTimeout();
//    },

//    stopSpeechRecognition: function () {
//        if (this.recognition) {
//            this.recognition.stop();
//            clearTimeout(this.timeoutId); // „”Õ «·„Â·… ⁄‰œ «·≈Ìﬁ«›
//        }
//    }
//};


function startSpeechRecognition(lang="ar-AR"){

    window.speechRecognition.setLanguage(lang); 
    window.speechRecognition.startSpeechRecognition(); // »œ¡ «·«” „«⁄

}

function getSpeechRecognitionResult() {
    var result = document.getElementById("displayTranscript").value;
    stopSpeechRecognition();
    return result;
}
function stopSpeechRecognition() {

    window.speechRecognition.stopSpeechRecognition(); // »œ¡ «·«” „«⁄

}

