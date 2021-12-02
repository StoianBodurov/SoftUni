import * as api from '../api/api.js'


export async function getAllmemes() {
    return  api.get('/data/memes?sortBy=_createdOn%20desc')
}

export async function createMeme(data) {
    return api.post('/data/memes', data)

}

export async function getMemeById(id) {
    return api.get('/data/memes/' + id)
}


export async function deleteMeme(id) {
    return api.del('/data/memes/' + id)
}


export async function editMeme(id, data) {
    return api.put('/data/memes/' + id, data)
}

export async function getUserMemes(id) {
    return api.get(`/data/memes?where=_ownerId%3D%22${id}%22&sortBy=_createdOn%20desc`)
}