import * as api from '../api/api.js'


export async function getAllAlbums() {
    return api.get('/data/albums?sortBy=_createdOn%20desc&distinct=name')
}

export async function createAlbum(data) {
    return api.post('/data/albums', data)
}

export async function getAlbumById(id) {
    return api.get('/data/albums/' + id)
}

export async function deleteById(id) {
    return api.del('/data/albums/' + id)
}

export async function editAlbum(id, data) {
    return api.put('/data/albums/' + id, data)
}


export async function searchAlbums(query) {
    return api.get(`/data/albums?where=name%20LIKE%20%22${query}%22 `)
}