import { html } from '../../node_modules/lit-html/lit-html.js'
import { deleteById, getAlbumById } from '../api/data.js'
import { getUserData } from '../utils.js'

const deatilsTemplate = (album, isOwner, onDelete) => html `
        <section id="detailsPage">
            <div class="wrapper">
                <div class="albumCover">
                    <img src=${album.imgUrl}>
                </div>
                <div class="albumInfo">
                    <div class="albumText">

                        <h1>Name: ${album.name}</h1>
                        <h3>Artist: ${album.artist}</h3>
                        <h4>Genre: ${album.genre}</h4>
                        <h4>Price: $${album.price}</h4>
                        <h4>Date: ${album.releaseDate}</h4>
                        <p>${album.description}</p>
                    </div>

                    ${isOwner 
                        ? html `<div class="actionBtn">
                                            <a href="/edit/${album._id}" class="edit">Edit</a>
                                            <a href="javascript:void(0)" class="remove" @click=${onDelete}>Delete</a>
                                        </div>` 
                        : null}
                    
                </div>
            </div>
        </section>
`


export async function detailsPage(ctx) {
    const album = await getAlbumById(ctx.params.id)

    const userData = getUserData()
    const isOwner = userData && album._ownerId == userData.id
    ctx.render(deatilsTemplate(album, isOwner,onDelete))

    async function onDelete() {
        const choce = confirm('Are you shor you want to delete this Album')

        if (choce) {
            await deleteById(ctx.params.id)
            ctx.page.redirect('/catalog')
        }
    }
}