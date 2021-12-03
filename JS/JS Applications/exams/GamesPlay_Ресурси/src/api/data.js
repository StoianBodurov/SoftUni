import * as api from '../api/api.js'

export async function getRecentGames() {
    return api.get('/data/games?sortBy=_createdOn%20desc&distinct=category')
}

export async function getAllGames() {
    return api.get('/data/games?sortBy=_createdOn%20desc')
}

export async function createGame(data) {
    return api.post('/data/games', data)
}

export async function getGameById(id) {
    return api.get('/data/games/' + id)
}

export async function deleteById(id) {
    return api.del('/data/games/' + id)
}

export async function editGame(id, data) {
    return api.put('/data/games/' + id, data)
}