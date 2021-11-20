async function attachEvents() {
    const loadButton = document.getElementById('btnLoadPosts').addEventListener('click', loadPosts);
    const viewButton = document.getElementById('btnViewPost').addEventListener('click', loadComments);


}

attachEvents();

async function getRequest(url){
    const respons = await fetch(url);
    const data = await respons.json();

    return data;
}

async function loadPosts() {
    const selectNode = document.getElementById('posts');
    const url = 'http://localhost:3030/jsonstore/blog/posts';
    const posts = await getRequest(url);

    for (let [key, post] of Object.entries(posts)) {
        const optionElement = createElement('option', {'value': post.id}, post.title);
        selectNode.appendChild(optionElement)
    }

}

async function loadComments() {
    const options = document.querySelectorAll('option')
    let postId = getId(options)

    if (postId != undefined){
        
        const commentList = document.querySelector('#post-comments')
        const url = 'http://localhost:3030/jsonstore/blog/comments';
        const comments = await getRequest(url);
        commentList.replaceChildren()
    
        for (let [key, comment] of Object.entries(comments)) {
            if (postId == comment.postId){
                const optionElement = createElement('li', {value: [comment.id]}, comment.text);
                commentList.appendChild(optionElement);
    
            }
        }
    }
    
}

function getId(elements) {
    for (let e of Array.from(elements)) {
        if (e.selected) {
            postId = e.value
            return postId
        }
    }

}

function createElement(type, atributes, ...values) {
  const element = document.createElement(type);

  for (let [a, v] of Object.entries(atributes)) {
    if (a == "className") {
      for (let c of v) {
        element.classList.add(`${c}`);
      }
    } else {
      element.setAttribute(a, `${v}`);
    }
  }

  for (let value of values) {
    if (typeof value == "string" || typeof value == "number") {
      const textNode = document.createTextNode(value);
      element.appendChild(textNode);
    } else {
      element.appendChild(value);
    }
  }

  return element;
}

