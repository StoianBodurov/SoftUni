import { html } from "../../node_modules/lit-html/lit-html.js";
import { getBookByUserId } from "../api/data.js";
import { getUserData } from "../utils.js";


const myBookTemplate = (books, cardBook) => html `
    <section id="my-books-page" class="my-books">
            <h1>My Books</h1>
            ${books.length == 0 
            ? html `<p class="no-books">No books in database!</p>`
            : html `<ul class="my-books-list">${books.map(b => cardBook(b))}
                     
            </ul>`}

        
            
        </section>

`


const cardBook = (book) => html `
    <li class="otherBooks">
        <h3>${book.title}</h3>
        <p>Type: ${book.type}</p>
        <p class="img"><img src=${book.imageUrl}></p>
        <a class="button" href="/details/${book._id}">Details</a>
    </li>
`


export async function myBookPage(ctx) {
    const userData = getUserData()
    const myBooks  = await getBookByUserId(userData.id)

    ctx.render(myBookTemplate(myBooks, cardBook))
}