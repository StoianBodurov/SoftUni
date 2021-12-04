import {html} from '../../node_modules/lit-html/lit-html.js';
import { deleteById, getGameById } from '../api/data.js';
import { getUserData } from '../utils.js';


const detailsTemplate = (game, onDelete, isOwner) => html `
         <section id="game-details">
            <h1>${game.title}</h1>
            <div class="info-section">

                <div class="game-header">
                    <img class="game-img" src=${game.imageUrl} />
                    <h1>${game.title}</h1>
                    <span class="levels">MaxLevel: ${game.maxLevel}</span>
                    <p class="type">${game.category}</p>
                </div>

                <p class="text">
                    ${game.summary}
                </p>

                ${isOwner 
                    ? html `  
                            <div class="buttons">
                                <a href="/edit/${game._id}" class="button">Edit</a>
                                <a href="javascript:void(0)" class="button" @click=${onDelete}>Delete</a>
                            </div>`
                    : null}
            <div>
             

        </section>
`


export async function detailsPage(ctx) {

    const game = await getGameById(ctx.params.id)
    const userData = getUserData()

    const isOwner = userData && game._ownerId == userData.id
    ctx.render(detailsTemplate(game, onDelete, isOwner))

    async function onDelete() {
        const coice = confirm('Are you sure you want to delete this Game')

        if (coice) {
            await deleteById(ctx.params.id)
            ctx.page.redirect('/')

        }

        
    }
    
}