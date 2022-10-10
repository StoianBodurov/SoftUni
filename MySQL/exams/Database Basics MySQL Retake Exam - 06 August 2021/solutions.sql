CREATE DATABASE `sgd`;

USE `sgd`;

# 1. Table Design
CREATE TABLE `addresses`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(50) NOT NULL
);

CREATE TABLE `categories`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(10) NOT NULL
);

CREATE TABLE `employees`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `first_name` VARCHAR(30) NOT NULL,
    `last_name` VARCHAR(30) NOT NULL,
    `age` INT NOT NULL,
    `salary` DECIMAL(10, 2) NOT NULL,
    `job_title` VARCHAR(20) NOT NULL,
    `happiness_level` CHAR(1) NOT NULL CHECK('L' OR 'N' OR 'H')
);

CREATE TABLE `offices`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `workspace_capacity` INT NOT NULL,
    `website` VARCHAR(50),
    `address_id` INT NOT NULL,
    CONSTRAINT fk_offices_addresses
    FOREIGN KEY (`address_id`) REFERENCES `addresses`(`id`)
);

CREATE TABLE `teams`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(40) NOT NULL,
    `office_id` INT NOT NULL,
    `leader_id` INT UNIQUE NOT NULL,
    CONSTRAINT fk_teams_offices
    FOREIGN KEY (`office_id`) REFERENCES `offices`(`id`),
    CONSTRAINT fk_teams_employees
    FOREIGN KEY (`leader_id`) REFERENCES `employees`(`id`)
);

CREATE TABLE `games`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(50) NOT NULL UNIQUE,
    `description` TEXT ,
    `rating` FLOAT DEFAULT 5.5 NOT NULL,
    `budget` DECIMAL(10, 2) NOT NULL,
    `release_date` DATE,
    `team_id` INT NOT NULL,
    CONSTRAINT fk_games_teams
    FOREIGN KEY (`team_id`) REFERENCES `teams`(`id`)
);

CREATE TABLE `games_categories`(
	`game_id` INT NOT NULL,
    `category_id` INT NOT NULL,
    CONSTRAINT primary_key
    PRIMARY KEY(`game_id`, `category_id` ),
    CONSTRAINT fk_game_categories_game
    FOREIGN KEY (`game_id`) REFERENCES `games`(`id`),
    CONSTRAINT fk_game_categories_categories
    FOREIGN KEY (`category_id`) REFERENCES `categories`(`id`)
);

# 2. Insert
INSERT INTO `games`(`name`, `rating`, `budget`, `team_id`)
	SELECT REVERSE(LOWER(SUBSTRING(`name`, 2))) AS 'name', `id` AS 'rating', `leader_id` * 1000 AS 'budget', `id` AS 'team_id' FROM `teams`
    WHERE `id` BETWEEN 1 AND 9;
    
# 3. Update
UPDATE `employees`
SET `salary` = `salary` + 1000
WHERE `id` IN (SELECT `leader_id` FROM `teams`) AND `age` < 40 AND `salary` < 5000;

# 4. Delete
DELETE FROM `games`
WHERE `release_date` IS NULL AND `id` NOT IN (SELECT `game_id` FROM `games_categories`);

# 5. Employees
SELECT `first_name`, `last_name`, `age`, `salary`, `happiness_level` FROM `employees`
ORDER BY `salary`, `id`;

# 6. Addresses of the teams
SELECT 
	`t`.`name` AS 'team_name',
	`a`.`name` AS 'address_name',
    CHAR_LENGTH(`a`.`name`) AS 'count_of_characters' FROM `teams` AS `t`
JOIN `offices` AS `o` ON `t`.`office_id` = `o`.`id`
JOIN `addresses` AS `a` ON `o`.`address_id` = `a`.`id`
WHERE `o`.`website` IS NOT NULL
ORDER BY `team_name`, `address_name`;
    
# 7. Categories Info
SELECT 
	(SELECT `name` FROM `categories` WHERE `id` = `g_c`.`category_id`) AS 'name'  ,
    COUNT(*) AS 'games_count',  
    ROUND(AVG(`g`.`budget`), 2) AS 'avg_budget',
    ROUND(MAX(`rating`), 1) AS 'max_rating'
FROM `games_categories` AS `g_c`
JOIN `games` AS `g` ON `g_c`.`game_id` = `g`.`id`
GROUP BY `category_id`
HAVING `max_rating` >= 9.5
ORDER BY `games_count` DESC, `name`;

# 8. Games of 2022
SELECT 
	`name`, `release_date`,
    CONCAT(LEFT(`description`, 10), '...') AS 'summary',
    (CASE 
		WHEN  MONTH(`release_date`) IN (10, 11, 12) THEN 'Q4'
        WHEN  MONTH(`release_date`) IN (7, 8, 9 ) THEN 'Q3'
        WHEN MONTH(`release_date`) IN (4, 5, 6) THEN 'Q2'
        ELSE 'Q1'
	END) AS 'quarter',
    (SELECT `name` FROM `teams` WHERE `id` = `team_id`) AS 'team_name'
FROM `games`
WHERE YEAR(`release_date`) = 2022 AND MONTH(`release_date`) % 2 = 0 AND  `name` LIKE '%2'
ORDER BY `quarter`;

# 9. Full info for games
SELECT 
	DISTINCT(`g`.`name`),
    IF(`g`.`budget` < 50000, 'Normal budget', 'Insufficient budget') AS 'budget_level',
    (SELECT `name` FROM `teams` WHERE `id` = `g`.`team_id`) AS 'team_name',
    (
		SELECT `a`.`name` FROM `games` AS `g1`
		JOIN `teams` AS `t` ON `g1`.`team_id` = `t`.`id`
		JOIN `offices` AS `o` ON `t`.`office_id` = `o`.`id`
		JOIN `addresses` AS `a` ON `o`.`address_id` = `a`.`id`
        WHERE `g`.`id` = `g1`.`id`
        ) AS 'addresse_name'
FROM `games` AS `g`
LEFT JOIN `games_categories` AS `g_c` ON `g`.`id` = `g_c`.`game_id`
WHERE `g`.`release_date` IS NULL AND `g`.`id` NOT IN (SELECT `game_id` FROM `games_categories`)
ORDER BY `g`.`name`;

# 10. Find all basic information for a game
DELIMITER $$

CREATE FUNCTION udf_game_info_by_name (game_name VARCHAR (20))
RETURNS TEXT
DETERMINISTIC
BEGIN
	DECLARE g_id INT;
    DECLARE team_name VARCHAR(40);
    DECLARE addresse_text VARCHAR(50);
    SET g_id = (SELECT `id` FROM `games` WHERE `name` = game_name);
    SET team_name = (SELECT `name` FROM `teams` WHERE `id` = (SELECT `team_id` FROM `games` WHERE `id` = `g_id`));
    SET addresse_text = (SELECT `name` FROM `addresses` WHERE `id` = (SELECT `address_id` FROM `offices` WHERE `id` = (SELECT `office_id` FROM `teams` WHERE `name` = team_name)));
    RETURN CONCAT('The ', game_name, ' is developed by a ', team_name, ' in an office with an address ',  addresse_text);
END$$

SELECT udf_game_info_by_name('Bitwolf') AS 'result'$$
DROP FUNCTION udf_game_info_by_name$$

# 11. Update budget of the games 
CREATE PROCEDURE udp_update_budget (min_game_rating FLOAT)
BEGIN
	UPDATE `games`
    SET `budget` = `budget` + 100000, `release_date` = DATE_ADD(`release_date`, INTERVAL 1 YEAR )
	WHERE min_game_rating < `rating` 
    AND `release_date` IS NOT NULL 
    AND `id` NOT IN (SELECT `game_id` FROM `games_categories`);
END$$

CALL udp_update_budget(8)$$
DROP PROCEDURE udp_update_budget$$

DELIMITER ;



