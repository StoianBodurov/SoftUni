class Trainer:
    def __init__(self, name):
        self.name = name
        self.pokemon = []

    def add_pokemon(self, pokemon):
        if pokemon in self.pokemon:
            return 'This pokemon is already caught'

        self.pokemon.append(pokemon)
        return f"Caught {pokemon.pokemon_details()}"

    def release_pokemon(self, pokemon_name):
        for pokemon in self.pokemon:
            if pokemon.name == pokemon_name:
                self.pokemon.remove(pokemon)
                return f'You have released {pokemon_name}'

        return 'Pokemon is not caught'

    def trainer_data(self):
        info_pokemons = '\n- '.join([pokemon.pokemon_details() for pokemon in self.pokemon])
        return f"Pokemon Trainer {self.name}\nPokemon count {len(self.pokemon)}\n- {info_pokemons}"


