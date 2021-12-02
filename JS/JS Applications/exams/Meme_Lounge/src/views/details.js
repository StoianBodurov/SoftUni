import { html } from "../../node_modules/lit-html/lit-html.js";
import { deleteMeme, getMemeById } from "../api/data.js";
import { getUserData } from "../utils.js";


const detailsTemplat = (meme, onDelete, isOwner) => html `
 <section id="meme-details">
            <h1>Meme Title: ${meme.title}

            </h1>
            <div class="meme-details">
                <div class="meme-img">
                    <img alt="meme-alt" src=${meme.imageUrl}>
                </div>
                <div class="meme-description">
                    <h2>Meme Description</h2>
                    <p>
                        ${meme.description}
                    </p>

                   ${isOwner ? html `<a class="button warning" href="/edit/${meme._id}">Edit</a>
                    <button class="button danger" @click=${onDelete}>Delete</button>` : null}
                    
                    
                </div>
            </div>
        </section>

`

export async function detailsPage(ctx) {
    const meme = await getMemeById(ctx.params.id);

    const userData = getUserData();
    const isOwner = userData && meme._ownerId == userData.id;

    ctx.render(detailsTemplat(meme, onDelete, isOwner));

    async function onDelete() {
        const choice = confirm('Are you sure you want to delete this meme');

        if(choice) {
            await deleteMeme(ctx.params.id);
            ctx.page.redirect('/memes');

        }
    }
}