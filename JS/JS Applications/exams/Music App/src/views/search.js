import { html } from '../../node_modules/lit-html/lit-html.js'
import { searchAlbums } from '../api/data.js'
import { getUserData } from '../utils.js'


const searchTemplate = (albums ) => html `
        <section id="searchPage">
            <h1>Search by Name</h1>

            <div class="search">
                <input id="search-input" type="text" name="search" placeholder="Enter desired albums's name">
                <button  class="button-list">Search</button>
            </div>

            <h2>Results:</h2>

            <!--Show after click Search button-->
            <div class="search-result">
                <!--If have matches-->
                ${albums.length == 0 
                ? html `<p class="no-result">No result.</p>`
                : html `${albums.map(resultCard)}`}
            
            </div>
        </section>
`

const resultCard = (album) => html `
        <div class="card-box">
            <img src=${album.imgUrl}>
            <div>
                <div class="text-center">
                    <p class="name">Name: ${album.name}</p>
                    <p class="artist">Artist: ${album.artist}</p>
                    <p class="genre">Genre: ${album.genre}</p>
                    <p class="price">Price: $${album.price}</p>
                    <p class="date">Release Date: ${album.releaseDate}</p>
                </div>

                ${userData ? html `
                            <div class="btn-group">
                                <a href="/details/${album._id}" id="details">Details</a>
                            </div>`
                            : null}
                
            </div>
        </div>

`

const userData = getUserData()

export async function searchPage(ctx) {
    const userData = getUserData()
    const value = ctx.querystring.split('=')[1]
    let albums = ''
    if (value) {
        albums = await searchAlbums(value)
    }
    ctx.render(searchTemplate(albums, userData))

    document.querySelector('button').addEventListener('click', onSearch)
        
    async function onSearch() {
        
        const value = document.querySelector('input').value.trim()
        ctx.page.redirect('/search?title=' + value)
      
        

    }
}

