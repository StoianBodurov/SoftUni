function encodeAndDecodeMessages() {
    const buttons = document.querySelectorAll('#main button');
    
    for (let button of buttons) {
        button.addEventListener('click', encodeDecode)

        function encodeDecode(event) {

            const parent = event.target.parentElement
            const buttonText = event.target.textContent
            const textAreas = document.querySelectorAll('textarea')
            const inputTextArea = textAreas[0]
            const resultTextArea = textAreas[1]
        
            let result = ''

             
                        
                if (buttonText == 'Encode and send it') {
                    for (let char of inputTextArea.value) {

                        result += String.fromCharCode(char.charCodeAt() + 1)
                    }
                } else {
                    for (let char of resultTextArea.value)
                    result += String.fromCharCode(char.charCodeAt() - 1)

                }
                
                resultTextArea.value = result
                inputTextArea.value = ''

        }
    }
}