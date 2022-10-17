CREATE DATABASE `cjms`;

USE `cjms`;

# 00. Table Design
CREATE TABLE `planets`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(30) NOT NULL
);

CREATE TABLE `spaceports`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
	`name` VARCHAR(50) NOT NULL,
	`planet_id` INT,
    CONSTRAINT fk_spaceports_planets
    FOREIGN KEY (`planet_id`) REFERENCES `planets`(`id`)
);

CREATE TABLE `spaceships`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(50) NOT NULL,
    `manufacturer` VARCHAR(30) NOT NULL,
    `light_speed_rate` INT DEFAULT 0
);

CREATE TABLE `journeys`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `journey_start` DATETIME NOT NULL,
    `journey_end` DATETIME NOT NULL,
    `purpose` ENUM('Medical', 'Technical', 'Educational', 'Military'),
    `destination_spaceport_id` INT,
    `spaceship_id` INT,
    CONSTRAINT fk_journeys_spaceports
    FOREIGN KEY (`destination_spaceport_id`) REFERENCES `spaceports`(`id`),
    CONSTRAINT fk_journeys_spaceships
    FOREIGN KEY (`spaceship_id`) REFERENCES `spaceships`(`id`)
);

CREATE TABLE `colonists`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `first_name` VARCHAR(20) NOT NULL,
    `last_name` VARCHAR(20) NOT NULL,
    `ucn` CHAR(10) NOT NULL UNIQUE,
    `birth_date` DATE NOT NULL
);

CREATE TABLE `travel_cards`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `card_number` CHAR(10) NOT NULL UNIQUE,
    `job_during_journey` ENUM('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook'),
    `colonist_id` INT,
    `journey_id` INT,
    CONSTRAINT fk_travel_cards_colonists
    FOREIGN KEY (`colonist_id`) REFERENCES `colonists`(`id`),
    CONSTRAINT fk_travel_cards_journey
    FOREIGN KEY (`journey_id`) REFERENCES `journeys`(`id`)
);

# 01. Data Insertion
INSERT INTO `travel_cards`(`card_number`, `job_during_journey`, `colonist_id`, `journey_id`)
SELECT 
	IF (`birth_date` > '1980-01-01',CONCAT(YEAR(`birth_date`), DAY(`birth_date`),LEFT(`ucn`, 4)), CONCAT(YEAR(`birth_date`), MONTH(`birth_date`), RIGHT(`ucn`, 4))),
    (CASE
		WHEN `id` % 2 = 0 THEN 'Pilot'
        WHEN `id` % 3 = 0 THEN 'Cook'
        ELSE 'Engineer'
 	END),
    `id`,
    LEFT(`ucn`, 1)
FROM `colonists`
WHERE `id` BETWEEN 96 AND 100;

# 02. Data Update
UPDATE `journeys`
SET `purpose` = (CASE
					WHEN `id` % 2 = 0 THEN 'Medical'
                    WHEN `id` % 3 = 0 THEN 'Technical'
                    WHEN `id` % 5 = 0 THEN 'Educational'
                    WHEN `id` % 7 = 0 THEN 'Military'
                    ELSE `purpose`
				END);
                
# 03. Data Deletion
DELETE FROM `colonists`
WHERE `id` NOT IN (SELECT `colonist_id` FROM `travel_cards`);

# 04. Extract all travel cards
SELECT `card_number`, `job_during_journey` FROM `travel_cards`
ORDER BY `card_number`;

# 05. Extract all colonists
SELECT `id`, CONCAT_WS(' ', `first_name`, `last_name`) AS 'full_name', `ucn` FROM `colonists`
ORDER BY `full_name`, `last_name`, `id`;

# 06. Extract all military journeys
SELECT `id`, `journey_start`, `journey_end` FROM `journeys`
WHERE `purpose` = 'Military'
ORDER BY `journey_start`;

# 07. Extract all pilots
SELECT 	`c`.`id`, CONCAT_WS(' ', `c`.`first_name`, `c`.`last_name`) AS 'full_name' FROM `colonists` AS `c`
JOIN `travel_cards`	AS `t` ON `c`.`id` = `t`.`colonist_id`
WHERE `t`.`job_during_journey` = 'Pilot'
ORDER BY `c`.`id`;

# 08. Count all colonists that are on technical journey
SELECT COUNT(*) AS 'count' FROM `colonists` AS `c`
JOIN `travel_cards` AS `tc` ON `c`.`id` = `tc`.`colonist_id`
JOIN `journeys` AS `j` ON `tc`.`journey_id` = `j`.`id`
GROUP BY `j`.`purpose`
HAVING `j`.`purpose` = 'Technical';

# 09. Extract the fastest spaceship
SELECT `ships`.`name` AS 'spaceship_name', `ports`.`name` AS 'spaceport_name' FROM `spaceships` AS `ships`
JOIN `journeys` AS `j` ON `ships`.`id` = `j`.`spaceship_id`
JOIN `spaceports` AS `ports` ON `j`.`destination_spaceport_id` = `ports`.`id`
WHERE `ships`.`light_speed_rate` = (SELECT MAX(`light_speed_rate`) FROM `spaceships`);

# 10. Extract spaceships with pilots younger than 30 years
SELECT `s`.`name`, `s`.`manufacturer` FROM `colonists` AS `c`
JOIN `travel_cards` AS `tc` ON `c`.`id` = `tc`.`colonist_id`
JOIN `journeys` AS `j` ON `tc`.`journey_id` = `j`.`id`
JOIN `spaceships` AS `s` ON `j`.`spaceship_id` = `s`.`id`
WHERE `c`.`birth_date` > DATE_SUB('2019-01-01', INTERVAL 30 YEAR) AND `tc`.`job_during_journey` = 'Pilot'
ORDER BY `s`.`name`;

# 11. Extract all educational mission planets and spaceports
SELECT 	`p`.`name` AS 'planet_name', `s`.`name` AS 'spaceport_name' FROM `planets` AS `p`
JOIN `spaceports` AS `s` ON `p`.`id` = `s`.`planet_id`
JOIN `journeys` AS `j` ON `s`.`id` = `j`.`destination_spaceport_id`
WHERE `j`.`purpose` = 'Educational'
ORDER BY `spaceport_name` DESC;

# 12. Extract all planets and their journey count
SELECT 	`p`.`name` AS 'planet_name', COUNT(`j`.`id`) AS 'journeys_name' FROM `planets` AS `p`
JOIN `spaceports` AS `s` ON `p`.`id` = `s`.`planet_id`
JOIN `journeys` AS `j` ON `s`.`id` = `j`.`destination_spaceport_id`
GROUP BY `p`.`name`
ORDER BY `journeys_name` DESC, `planet_name`;

# 13. Extract the shortest journey
SELECT `j`.`id`, `p`.`name` AS 'planet_name', `s`.`name` AS 'spaceport_name', `purpose` AS 'journey_purpose' FROM `journeys` AS `j`
JOIN `spaceports` AS `s` ON `j`.`destination_spaceport_id` = `s`.`id`
JOIN `planets` AS `p` ON `s`.`planet_id` = `p`.`id`
WHERE DATEDIFF(`j`.`journey_end`, `j`.`journey_start`) = (SELECT MIN(DATEDIFF(`journey_end`, `journey_start`)) FROM `journeys`);

# 14. Extract the less popular job
SELECT `job_during_journey` FROM `travel_cards` AS `t_c`
JOIN `journeys` AS `j` ON `t_c`.`journey_id` = `j`.`id`
WHERE DATEDIFF(`j`.`journey_end`, `j`.`journey_start`) = (SELECT MAX(DATEDIFF(`journey_end`, `journey_start`)) FROM `journeys`)
GROUP BY `job_during_journey`
ORDER BY COUNT(`job_during_journey`) 
LIMIT 1;

# 15. Get colonists count
DELIMITER $$

CREATE FUNCTION udf_count_colonists_by_destination_planet (planet_name VARCHAR (30))
RETURNS INT
DETERMINISTIC
BEGIN
	DECLARE result INT;
    SET result = (SELECT COUNT(`c`.`id`) FROM `colonists` AS `c`
					JOIN `travel_cards` AS `t_c` ON `c`.`id` = `t_c`.`colonist_id` 
					JOIN `journeys` AS `j` ON `t_c`.`journey_id` = `j`.`id`
					JOIN `spaceports` AS `s` ON `j`.`destination_spaceport_id` = `s`.`id`
					JOIN `planets` AS `p` ON `s`.`planet_id` = `p`.`id`
					WHERE `p`.`name` = planet_name
					GROUP BY `p`.`id`);
				
    RETURN result;
END$$

SELECT udf_count_colonists_by_destination_planet('Otroyphus')$$

# 16. Modify spaceship
CREATE PROCEDURE udp_modify_spaceship_light_speed_rate(spaceship_name VARCHAR(50), light_speed_rate_increse INT(11)) 
BEGIN
	START TRANSACTION;
		IF (spaceship_name NOT IN (SELECT `name` FROM `spaceships`)) THEN
			SELECT 'Spaceship you are trying to modify does not exists.'
			ROLLBACK;
		ELSE 
			UPDATE `spaceships`
            SET `light_speed_rate` = `light_speed_rate` + light_speed_rate_increse
            WHERE `name` = spaceship_name;
        END IF;
END;


