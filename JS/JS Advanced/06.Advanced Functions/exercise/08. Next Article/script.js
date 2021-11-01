function getArticleGenerator(articles) {
    const inputArray = articles

    function showNext() {
        if (inputArray.length > 0) {
            const divElement = document.getElementById('content')

            const article = document.createElement('article')
            article.textContent = inputArray.shift()
            divElement.appendChild(article)
        }   

    }   
    return showNext
}
