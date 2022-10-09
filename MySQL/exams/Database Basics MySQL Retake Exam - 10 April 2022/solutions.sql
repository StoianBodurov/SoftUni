CREATE DATABASE `softuni_imdb`;

USE `softuni_imdb`;

# 01. Table Design
CREATE TABLE `movies_additional_info`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `rating` DECIMAL(10, 2) NOT NULL,
    `runtime` INT NOT NULL,
    `picture_url` VARCHAR(80) NOT NULL,
    `budget` DECIMAL(10, 2),
    `release_date` DATE NOT NULL,
    `has_subtitles` TINYINT(1),
    `description` TEXT
);

CREATE TABLE `countries`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(30) NOT NULL UNIQUE,
    `continent` VARCHAR(30) NOT NULL,
    `currency` VARCHAR(5) NOT NULL
);

CREATE TABLE `movies`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `title` VARCHAR(70) NOT NULL UNIQUE,
    `country_id` INT NOT NULL,
    `movie_info_id` INT NOT NULL UNIQUE,
	FOREIGN KEY (`country_id`) REFERENCES `countries`(`id`),
    FOREIGN KEY (`movie_info_id`) REFERENCES `movies_additional_info`(`id`)
);

CREATE TABLE `genres`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE `genres_movies`(
	`genre_id` INT,
    `movie_id` INT,
    FOREIGN KEY(`genre_id`) REFERENCES `genres`(`id`),
    FOREIGN KEY(`movie_id`) REFERENCES `movies`(`id`)
);

CREATE TABLE `actors`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `first_name` VARCHAR(50) NOT NULL,
    `last_name` VARCHAR(50) NOT NULL,
    `birthdate` DATE NOT NULL,
    `height` INT,
    `awards` INT,
    `country_id` INT NOT NULL,
    FOREIGN KEY (`country_id`) REFERENCES `countries`(`id`)
);

CREATE TABLE `movies_actors`(
	`movie_id` INT,
    `actor_id` INT,
    CONSTRAINT fk_movies_movie_movies_actors
    FOREIGN KEY (`movie_id`) REFERENCES `movies`(`id`),
    CONSTRAINT fk_actors_actors_movies_actors
    FOREIGN KEY (`actor_id`) REFERENCES `actors`(`id`)
);

# 02. Insert
INSERT INTO `actors`(`first_name`, `last_name`, `birthdate`, `height`, `awards`, `country_id`)
	SELECT REVERSE(`first_name`), 
        REVERSE(`last_name`), 
        DATE_SUB(`birthdate`, INTERVAL 2 DAY), 
        (`height` + 10),
        `country_id`,
        (SELECT `id` FROM `countries` WHERE `name` = 'Armenia')
	FROM `actors` WHERE `id` BETWEEN 1 AND 10;
        
# 03. Update
UPDATE `movies_additional_info`
SET `runtime` = `runtime` - 10 
WHERE `id` >= 15  AND `id` <= 25;

# 04.	Delete
DELETE FROM `countries` WHERE `id` NOT IN (SELECT `country_id` FROM `movies`);

# 05. Countries
SELECT `id`, `name`, `continent`, `currency` FROM `countries`
ORDER BY `currency` DESC, `id`;

# 06. Old movies
SELECT `mai`.`id`, `m`.`title`, `mai`.`runtime`, `mai`.`budget`, `mai`.`release_date` FROM `movies_additional_info` AS `mai`
JOIN `movies` AS `m` ON `mai`.`id` = `m`.`movie_info_id`
WHERE YEAR(`mai`.`release_date`) BETWEEN 1996 AND 1999
ORDER BY `mai`.`runtime`, `mai`.`id`
LIMIT 20;

# 07. Movie casting
SELECT CONCAT_WS(' ', `first_name`, `last_name`) AS 'full_name',
	CONCAT(REVERSE(`last_name`),CHAR_LENGTH(`last_name`),'@cast.com'),
    YEAR(NOW()) - YEAR(`birthdate`) AS 'age', `height` FROM `actors`
WHERE `id` NOT IN (SELECT `actor_id` FROM `movies_actors`)
ORDER BY `height`;

#  08. International festival
SELECT (SELECT `name` FROM `countries` WHERE `id` = `country_id`) AS 'name', COUNT(*) AS 'movies_count' FROM `movies`
GROUP BY `country_id`
HAVING `movies_count` >= 7
ORDER BY `name` DESC;	

# 09. Rating system
SELECT `m`.`title`, 
	(CASE
		WHEN `m_a_i`.`rating` <= 4 THEN 'poor'
        WHEN `m_a_i`.`rating` <= 7 THEN 'good'
        ELSE 'excellent'
	END) AS 'rating', 
	IF(`m_a_i`.`has_subtitles`=1, 'english', '-') AS 'subtitles',
	`m_a_i`.`budget` FROM `movies` AS `m`
JOIN `movies_additional_info` AS `m_a_i` ON `m`.`movie_info_id`	= `m_a_i`.`id`
ORDER BY `m_a_i`.`budget` DESC;

# 10. History movies
DELIMITER &&
CREATE FUNCTION udf_actor_history_movies_count(full_name VARCHAR(50))
RETURNS INT
DETERMINISTIC
BEGIN
	DECLARE result INT;
    SET result = (SELECT COUNT(*) FROM `movies_actors` AS `m_a`
		JOIN `genres_movies` AS `g_m` ON `m_a`.`movie_id` = `g_m`.`movie_id`
		WHERE (`m_a`.`actor_id` = (SELECT `id` FROM `actors` WHERE CONCAT_WS(' ', `first_name`, `last_name`) = full_name)) AND `g_m`.`genre_id` = 12);
    
	RETURN  result;
	
END&&

# 11. Movie awards
CREATE PROCEDURE udp_award_movie (movie_title VARCHAR(50))
BEGIN
	DECLARE m_id INT;
    SET m_id = (SELECT `id` FROM `movies` WHERE `title` = movie_title);
    UPDATE `actors`
    SET `awards` = `awards` + 1
    WHERE `id` IN (SELECT `actor_id` FROM `movies_actors` WHERE `movie_id` = m_id);
    
END&&
 

DELIMITER ;




