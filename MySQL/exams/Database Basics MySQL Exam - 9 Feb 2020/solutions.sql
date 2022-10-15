CREATE DATABASE `fsd`;

USE `fsd`;

# 1. Table Design
CREATE TABLE `coaches`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `first_name` VARCHAR(10) NOT NULL,
    `last_name` VARCHAR(20) NOT NULL,
    `salary` DECIMAL(10, 2) NOT NULL DEFAULT 0,
    `coach_level` INT NOT NULL DEFAULT 0
);

CREATE TABLE `countries`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(45) NOT NULL
);

CREATE TABLE `towns`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(45) NOT NULL,
    `country_id` INT NOT NULL,
    CONSTRAINT fk_towns_countries
    FOREIGN KEY (`country_id`) REFERENCES `countries`(`id`)
);

CREATE TABLE `stadiums`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(45) NOT NULL,
    `capacity` INT NOT NULL, 
    `town_id` INT NOT NULL,
    CONSTRAINT fk_stadiums_towns
    FOREIGN KEY (`town_id`) REFERENCES `towns`(`id`)
);

CREATE TABLE `teams`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(45) NOT NULL,
    `established` DATE NOT NULL,
    `fan_base` BIGINT(20) NOT NULL DEFAULT 0,
    `stadium_id` INT NOT NULL,
    CONSTRAINT fk_teams_stadiums
    FOREIGN KEY (`stadium_id`) REFERENCES `stadiums`(`id`)
);

CREATE TABLE `skills_data`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `dribbling` INT DEFAULT 0,
    `pace` INT DEFAULT 0,
    `passing` INT DEFAULT 0,
    `shooting` INT DEFAULT 0,
    `speed` INT DEFAULT 0,
    `strength` INT DEFAULT 0
);

CREATE TABLE `players`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `first_name` VARCHAR(10) NOT NULL,
    `last_name` VARCHAR(20) NOT NULL,
    `age` INT NOT NULL DEFAULT 0,
    `position` CHAR(1) NOT NULL,
    `salary` DECIMAL(10, 2) NOT NULL DEFAULT 0,
    `hire_date` DATETIME,
    `skills_data_id` INT NOT NULL,
    `team_id` INT,
    CONSTRAINT fk_players_skills_data
    FOREIGN KEY (`skills_data_id`) REFERENCES `skills_data`(`id`),
    CONSTRAINT fk_players_teams
    FOREIGN KEY (`team_id`) REFERENCES `teams`(`id`)
);

CREATE TABLE `players_coaches`(
	`player_id` INT,
    `coach_id` INT,
    CONSTRAINT fk_players_coaches_players
    FOREIGN KEY (`player_id`) REFERENCES `players`(`id`),
    CONSTRAINT fk_players_coaches_couches
    FOREIGN KEY (`coach_id`) REFERENCES `coaches`(`id`)
);

# 2. Insert
INSERT INTO `coaches`(`first_name`, `last_name`, `salary`, `coach_level`)
SELECT `first_name`, `last_name`, (`salary` * 2), CHAR_LENGTH(`first_name`) FROM `players`
WHERE `age` >= 45;

# 3. Update
UPDATE `coaches`
SET `coach_level` = `coach_level` + 1
WHERE `id` IN (SELECT `coach_id` FROM `players_coaches`) AND LEFT(`first_name`, 1) = 'A';

# 4. Delete
DELETE FROM `players`
WHERE `age` >= 45;

# 5. Players 
SELECT `first_name`, `age`, `salary` FROM `players`
ORDER BY `salary` DESC;

# 6. Young offense players without contract
SELECT 
	`p`.`id`,
    CONCAT_WS(' ', `p`.`first_name`, `p`.`last_name`) AS 'full_name',
	`p`.`age`, 
    `p`.`position`,
    `p`.`hire_date`
FROM `players` AS `p`
JOIN `skills_data` AS `sd` ON `p`.`skills_data_id` = `sd`.`id`
WHERE `age` < 23 AND `position` = 'A' AND `hire_date` IS NULL AND `sd`.`strength` > 50
ORDER BY `p`.`salary`, `p`.`age`;

# 7. Detail info for all teams
SELECT `t`.`name`, `t`.`established`, `t`.`fan_base`, COUNT(`p`.`id`) AS 'count_of_playerrs' FROM `teams` AS `t`
LEFT JOIN `players` AS `p` ON `t`.`id` = `p`.`team_id`
GROUP BY `t`.`id`
ORDER BY `count_of_playerrs` DESC, `fan_base` DESC;

# 8. The fastest player by towns
SELECT MAX(`sd`.`speed`) AS 'max_speed', `tw`.`name` FROM `players` AS `p`
RIGHT JOIN `teams` AS `t` ON `p`.`team_id` = `t`.`id`
LEFT JOIN `stadiums` AS `s` ON `t`.`stadium_id` = `s`.`id`
LEFT JOIN `towns` AS `tw` ON `s`.`town_id` = `tw`.`id`
LEFT JOIN `skills_data` AS `sd` ON `p`.`skills_data_id` = `sd`.`id`
WHERE `t`.`name` != 'Devify'
GROUP BY `tw`.`name`
ORDER BY `max_speed` DESC, `tw`.`name`;

# 9. Total salaries and players by country
SELECT `c`.`name`, COUNT(`p`.`id`) AS 'total_count_of_players',SUM(`p`.`salary`)  AS 'total_sum_of_salaries' FROM `countries`AS `c`
LEFT JOIN `towns` AS `t` ON `c`.`id` = `t`.`country_id` 
LEFT JOIN `stadiums` AS `s` ON `t`.`id` = `s`.`town_id`
LEFT JOIN `teams` AS `tm` ON `s`.`id` = `tm`.`stadium_id`
LEFT JOIN `players` AS `p` ON `tm`.`id` = `p`.`team_id`
GROUP BY `c`.`name`
ORDER BY `total_count_of_players` DESC, `c`.`name`;

# 10. Find all players that play on stadium
DELIMITER $$

CREATE FUNCTION udf_stadium_players_count (stadium_name VARCHAR(30)) 
RETURNS INT
DETERMINISTIC
BEGIN
	RETURN (SELECT COUNT(`p`.`id`)  FROM `players` AS `p`
			RIGHT JOIN `teams` AS `t` ON `p`.`team_id` = `t`.`id`
			RIGHT JOIN `stadiums` AS `s` ON `t`.`stadium_id` = `s`.`id`
			RIGHT JOIN `towns` AS `tw` ON `s`.`town_id` = `tw`.`id`
			WHERE `s`.`name` = stadium_name
			GROUP BY `s`.`name`);
END$$

# 11. Find good playmaker by teams
CREATE PROCEDURE udp_find_playmaker (min_dribble_points INT, team_name VARCHAR(45))
BEGIN
	SELECT CONCAT_WS(' ', `p`.`first_name`, `p`.`last_name`) AS 'full_name', `p`.`age`, `p`.`salary`, `sd`.`dribbling`, `sd`.`speed`, `t`.`name` AS 'team_name'FROM `players` AS `p`
JOIN `teams` AS `t` ON `p`.`team_id` = `t`.`id`
JOIN `skills_data` AS `sd` ON `p`.`skills_data_id` = `sd`.`id`
WHERE `t`.`name` = team_name AND `sd`.`dribbling` > min_dribble_points AND `sd`.`speed` > (SELECT AVG(`speed`) FROM `skills_data`)
ORDER BY `sd`.`speed` DESC
LIMIT 1;
END$$
DELIMITER ;



