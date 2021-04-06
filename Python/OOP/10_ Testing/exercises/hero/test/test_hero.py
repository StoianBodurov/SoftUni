from unittest import TestCase, main

from project.hero import Hero


class HeroTest(TestCase):
    username = 'username'
    level = 5
    health = 10
    damage = 2

    def setUp(self):
        self.hero = Hero(self.username, self.level, self.health, self.damage)

    def test_init(self):
        self.assertEqual(self.username, self.hero.username)
        self.assertEqual(self.health, self.hero.health)
        self.assertEqual(self.level, self.hero.level)
        self.assertEqual(self.damage, self.hero.damage)

    def test_battle_when_enemy_name_is_same_like_hero_expect_exception(self):
        enemy = Hero(self.username, 3, 10, 3)
        with self.assertRaises(Exception) as ex:
            self.hero.battle(enemy)
        self.assertEqual('You cannot fight yourself', str(ex.exception))

    def test_battle_when_hero_health_is_0_expect_exception(self):
        self.hero.health = 0
        with self.assertRaises(ValueError) as ex:
            self.hero.battle(Hero('a', 5, 6, 2))

        self.assertEqual('Your health is lower than or equal to 0. You need to rest', str(ex.exception))

    def test_battle_when_hero_health_is_negative_expect_exception(self):
        self.hero.health = -1
        with self.assertRaises(ValueError) as ex:
            self.hero.battle(Hero('a', 5, 6, 2))

        self.assertEqual('Your health is lower than or equal to 0. You need to rest', str(ex.exception))

    def test_battle_when_enemy_health_is_0_expect_exception(self):
        enemy = Hero('Enemy', 2, 0, 3)
        with self.assertRaises(ValueError) as ex:
            self.hero.battle(enemy)

        self.assertEqual(f'You cannot fight {enemy.username}. He needs to rest', str(ex.exception))

    def test_battle_when_enemy_health_is_negative_expect_exception(self):
        enemy = Hero('Enemy', 2, -1, 3)
        with self.assertRaises(ValueError) as ex:
            self.hero.battle(enemy)

        self.assertEqual(f'You cannot fight {enemy.username}. He needs to rest', str(ex.exception))

    def test_battle_when_draw_expect_return_string(self):
        enemy = Hero('Enemy', 5, 10, 2)
        self.assertEqual('Draw', self.hero.battle(enemy))

    def test_battle_when_hero_win_expect_return_string(self):
        enemy = Hero('Enemy', 1, 10, 1)
        self.assertEqual('You win', self.hero.battle(enemy))
        self.assertEqual(self.level + 1, self.hero.level)
        self.assertEqual(self.health + 4, self.hero.health)
        self.assertEqual(self.damage + 5, self.hero.damage)

    def test_battle_when_enemy_win_expect_return_string(self):
        enemy = Hero('Enemy', 5, 11, 2)
        self.assertEqual('You lose', self.hero.battle(enemy))
        self.assertEqual(6, enemy.level)
        self.assertEqual(6, enemy.health)
        self.assertEqual(7, enemy.damage)

    def test_battle_when_not_winner_win_expect_return_string(self):
        enemy = Hero('Enemy', 4, 11, 2)
        self.hero.battle(enemy)
        self.assertEqual(2, self.hero.health)
        self.assertEqual(6, enemy.health)

    def test_class_str(self):
        self.assertEqual(f"Hero {self.username}: {self.level} lvl\nHealth: {self.health}\nDamage: {self.damage}\n", str(self.hero))


if __name__ == '__main__':
    main()