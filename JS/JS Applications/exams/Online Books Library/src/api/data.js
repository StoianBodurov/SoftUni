import * as api from '../api/api.js'



export async function getAllBook() {
    return api.get('/data/books?sortBy=_createdOn%20desc')
}

export async function createBook(data) {
    return api.post('/data/books', data)
}

export async function getBookById(id) {
    return api.get('/data/books/' + id)
}

export async function deleteById(id) {
    return api.del('/data/books/' + id)
}

export async function editBook(id, data) {
    return api.put('/data/books/' + id, data)
}

export async function getBookByUserId(id) {
    return api.get(`/data/books?where=_ownerId%3D%22${id}%22&sortBy=_createdOn%20desc`)
}