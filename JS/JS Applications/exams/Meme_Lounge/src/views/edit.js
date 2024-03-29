import { html } from "../../node_modules/lit-html/lit-html.js";
import {editMeme, getMemeById } from "../api/data.js";   
import {notify} from '../../src/notify.js';


const editTemplat = (meme, onSubmit) => html`
  <section id="edit-meme">
    <form id="edit-form" @submit=${onSubmit}>
      <h1>Edit Meme</h1>
      <div class="container">
        <label for="title">Title</label>
        <input id="title" type="text" placeholder="Enter Title" name="title" .value=${meme.title} />
        <label for="description">Description</label>
        <textarea
          id="description"
          placeholder="Enter Description"
          name="description" .value=${meme.description}
        >
                        
                        </textarea
        >
        <label for="imageUrl">Image Url</label>
        <input
          id="imageUrl"
          type="text"
          placeholder="Enter Meme ImageUrl"
          name="imageUrl" .value=${meme.imageUrl}
        />
        <input type="submit" class="registerbtn button" value="Edit Meme" />
      </div>
    </form>
  </section>
`;

 
export async function editPage(ctx) {
    const meme = await getMemeById(ctx.params.id);
    ctx.render(editTemplat(meme, onSubmit));

    async function onSubmit(event) {
        event.preventDefault()

        const form = new FormData(event.target)

        const title = form.get('title').trim();
        const description = form.get('description').trim();
        const imageUrl = form.get('imageUrl').trim();

        if (title == '' || description == '' || imageUrl == '') {
            return notify('All field are required')
        }

        await editMeme(ctx.params.id, {
            title,
            description,
            imageUrl
        })

        ctx.page.redirect('/memes')

    }
}