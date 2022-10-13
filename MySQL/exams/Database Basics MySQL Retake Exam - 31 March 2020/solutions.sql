CREATE DATABASE `insta_influencers`;

USE `insta_influencers`;

# 01. able Design
CREATE TABLE `photos`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `description` TEXT NOT NULL,
    `date` DATETIME NOT NULL,
    `views` INT NOT NULL DEFAULT 0
);

CREATE TABLE `comments`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `comment` VARCHAR(255) NOT NULL,
    `date` DATETIME NOT NULL,
    `photo_id` INT NOT NULL,
    CONSTRAINT fk_comments_photos
    FOREIGN KEY (`photo_id`) REFERENCES `photos`(`id`)
);

CREATE TABLE `users`(
	`id` INT PRIMARY KEY,
    `username` VARCHAR(30) NOT NULL UNIQUE,
    `password` VARCHAR(30) NOT NULL,
    `email` VARCHAR(50) NOT NULL,
    `gender` CHAR(1) NOT NULL,
    `age` INT NOT NULL,
    `job_title` VARCHAR(40) NOT NULL,
    `ip` VARCHAR(30) NOT NULL
);

CREATE TABLE `addresses`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `address` VARCHAR(30) NOT NULL,
    `town` VARCHAR(30) NOT NULL,
    `country` VARCHAR(30) NOT NULL,
    `user_id` INT NOT NULL,
    CONSTRAINT fk_addresses_users
    FOREIGN KEY (`user_id`) REFERENCES `users`(`id`)
);

CREATE TABLE `likes`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `photo_id` INT,
    `user_id` INT,
    CONSTRAINT fk_likes_photos
    FOREIGN KEY (`photo_id`) REFERENCES `photos`(`id`),
    CONSTRAINT fk_likes_users 
    FOREIGN KEY (`user_id`) REFERENCES `users`(`id`)
);

CREATE TABLE `users_photos`(
	`user_id` INT NOT NULL,
    `photo_id` INT NOT NULL,
    CONSTRAINT fk_users_photos_users
    FOREIGN KEY (`user_id`) REFERENCES `users`(`id`),
    CONSTRAINT fk_users_photos_photos
    FOREIGN KEY (`photo_id`) REFERENCES `photos`(id)
);

# 02. Insert 
INSERT INTO `addresses` (`address`, `town`, `country`, `user_id`)
	SELECT `username`, `password`, `ip`, `age` 
	FROM `users` 
    WHERE `gender` = 'M';
    
# 03. Update
UPDATE `addresses`
SET `country` = (CASE 
					WHEN LEFT(`country`, 1) = 'B' THEN 'Blocked'
                    WHEN LEFT(`country`, 1) = 'T' THEN 'Test'
                    WHEN LEFT(`country`, 1) = 'P' THEN 'In Progress'
                    ELSE `country`
				END);
                
# 04. Delete
DELETE FROM `addresses`
WHERE `id` % 3 = 0;

# 05. Users
SELECT `username`, `gender`, `age` FROM `users`
ORDER BY `age` DESC, `username` ASC;

# 06. Extract 5 Most Commented Photos
SELECT `ph`.`id`, `ph`.`date`, `ph`.`description`, COUNT(`c`.`comment`) AS 'commentsCount' FROM `photos` AS `ph`
JOIN `comments` AS `c` ON `ph`.`id` = `c`.`photo_id`
GROUP BY `ph`.`id`
ORDER BY `commentsCount` DESC, `ph`.`id`
LIMIT 5;

# 07. Lucky Users
SELECT CONCAT(`u`.`id`, ' ', `u`.`username`) AS 'id_username', `u`.`email` FROM `users` AS `u`
JOIN `users_photos` AS `u_ph` ON  `u`.`id` = `u_ph`.`user_id`
JOIN `photos` AS `ph` ON `u_ph`.`photo_id` = `ph`.`id`
WHERE `u`.`id` = `ph`.`id`
ORDER BY `u`.`id`;

# 08. Count Likes and Comments
SELECT 
	`ph`.`id` AS 'photo_id' ,
	(SELECT COUNT(*) FROM `likes` WHERE `photo_id` = `ph`.`id`) AS 'likes_count',
    (SELECT COUNT(*) FROM `comments` WHERE `photo_id` = `ph`.`id` ) AS 'comments_count'
FROM `photos` AS `ph`
ORDER BY `likes_count` DESC, `comments_count` DESC, `photo_id` ASC;

# 09. The Photo on the Tenth Day of the Month
SELECT 
	CONCAT(LEFT(`description`, 30), '...') AS 'summary',
    `date` FROM `photos`
WHERE DAY(`date`) = 10
ORDER BY `date` DESC;

# 10. Get User’s Photos Count
DELIMITER $$

CREATE FUNCTION udf_users_photos_count(user_name VARCHAR(30)) 
RETURNS INT
DETERMINISTIC
BEGIN
	DECLARE u_id INT;
    SET u_id = (SELECT `id` FROM `users` WHERE `username` = user_name);
    
    RETURN (SELECT COUNT(*) FROM `users_photos` WHERE `user_id` = u_id);
END$$

SELECT udf_users_photos_count('ssantryd')$$

# 11. Increase User Age
CREATE PROCEDURE udp_modify_user (address VARCHAR(30), town VARCHAR(30)) 
BEGIN
	UPDATE `users`
    SET `age` = `age` + 10
    WHERE `id` IN(SELECT `a`.`user_id` FROM `addresses` AS `a`
                    WHERE `a`.`address` = address AND `a`.`town` = town);
END$$

CALL udp_modify_user('97 Valley Edge Parkway', 'Divinópolis')$$
