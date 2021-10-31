function notify(message) {
  const messageDiv = document.getElementById('notification')
  messageDiv.textContent = message;
 
  messageDiv.style.display = 'block';

  messageDiv.addEventListener('click', () =>{
    messageDiv.style.display = 'none';
  });
}