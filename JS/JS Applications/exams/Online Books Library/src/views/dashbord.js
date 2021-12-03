import { html } from "../../node_modules/lit-html/lit-html.js";
import { getAllBook } from "../api/data.js";


const templateDashbord = (books, cardBook) => html `
        <section id="dashboard-page" class="dashboard">
            <h1>Dashboard</h1>
            ${books.length == 0 
            ? html `<p class="no-books">No books in database!</p>` 
            : html `<ul class="other-books-list">
              ${books.map(b => cardBook(b))}
            </ul>`
            
             
        }
        
        </section>

`
const cardBook = (book) => html `
    <li class="otherBooks">
        <h3>${book.title}</h3>
        <p>Type: ${book.tupe}</p>
        <p class="img"><img src=${book.imageUrl}></p>
        <a class="button" href="/details/${book._id}">Details</a>
    </li>
`

export async function dashbordPage(ctx) {
    const books = await getAllBook()

    ctx.render(templateDashbord(books, cardBook))
}