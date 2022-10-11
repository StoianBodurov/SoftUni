CREATE DATABASE `stc`;

USE `stc`;

# 1. Table Design
CREATE TABLE `addresses`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(100) NOT NULL
);

CREATE TABLE `categories`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(10) NOT NULL
);

CREATE TABLE `clients`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `full_name` VARCHAR(50) NOT NULL,
    `phone_number` VARCHAR(20) NOT NULL
);

CREATE TABLE `drivers`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `first_name` VARCHAR(30) NOT NULL,
    `last_name` VARCHAR(30) NOT NULL,
    `age` INT NOT NULL,
    `rating` FLOAT DEFAULT 5.5
);

CREATE TABLE `cars`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `make` VARCHAR(20) NOT NULL,
    `model` VARCHAR(20),
    `year` INT NOT NULL DEFAULT 0,
    `mileage` INT DEFAULT 0,
    `condition` CHAR(1),
    `category_id` INT NOT NULL,
    CONSTRAINT fk_cars_categories
    FOREIGN KEY (`category_id`) REFERENCES `categories`(`id`)
);

CREATE TABLE `courses`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `from_address_id` INT NOT NULL,
    `start` DATETIME NOT NULL,
    `bill` DECIMAL(10, 2) DEFAULT 10,
    `car_id` INT NOT NULL,
    `client_id` INT NOT NULL,
    CONSTRAINT fk_courses_addresses
    FOREIGN KEY (`from_address_id`) REFERENCES `addresses`(`id`),
    CONSTRAINT fk_courses_car
    FOREIGN KEY (`car_id`) REFERENCES `cars`(`id`),
    CONSTRAINT fk_courses_clients
    FOREIGN KEY (`client_id`) REFERENCES `clients`(`id`)
);

CREATE TABLE `cars_drivers`(
	`car_id` INT NOT NULL,
    `driver_id` INT NOT NULL,
    CONSTRAINT pk_cars_drivers
    PRIMARY KEY (`car_id`, `driver_id`),
    CONSTRAINT fk_cars_drivers_cars
    FOREIGN KEY (`car_id`) REFERENCES `cars`(`id`),
    CONSTRAINT fk_cars_drivers_drivers
    FOREIGN KEY (`driver_id`) REFERENCES `drivers`(`id`)
);

# 2. Insert
INSERT INTO `clients`(`full_name`, `phone_number`)
	SELECT 
		CONCAT_WS(' ', `first_name`, `last_name`) AS 'full_name',
		CONCAT('(088) 9999', `id` * 2) AS 'phone_number'
	FROM `drivers` WHERE `id` BETWEEN 10 AND 20;
    
# 3. Update
UPDATE `cars`
SET `condition` = 'C'
WHERE (`mileage` >= 800000 OR `mileage` IS NULL) AND `year` <= 2010;

# 4. Delete
DELETE FROM `clients`
WHERE `id` NOT IN (SELECT `client_id` FROM `courses`) AND CHAR_LENGTH(`full_name`) > 3;

# 5. Cars
SELECT `make`, `model`, `condition` FROM `cars`
ORDER BY `id`;

# 6. Drivers and Cars
SELECT `first_name`, `last_name`, `make`, `model`, `mileage` FROM `drivers` AS `d`
JOIN `cars_drivers` AS `c_d` ON `d`.`id` = `c_d`.`driver_id`
JOIN `cars` AS `c` ON `c_d`.`car_id` = `c`.`id`
WHERE `mileage` IS NOT NULL
ORDER BY `mileage` DESC, `first_name`;

# 7. Number of courses for each car
SELECT 
	`id` AS 'car_id', 
    `make`,
    `mileage`,
    (SELECT COUNT(*) FROM `courses` WHERE `c`.`id` = `car_id`) AS 'count_of_courses',
    (SELECT ROUND(AVG(`bill`), 2) FROM `courses` WHERE `c`.`id` = `car_id`) AS 'avg_bill'

FROM `cars` AS `c`
WHERE (SELECT COUNT(*) FROM `courses` WHERE `c`.`id` = `car_id`) NOT IN (2)
ORDER BY `count_of_courses` DESC, `car_id`;

# 8. Regular clients
SELECT 
	(SELECT `full_name` FROM `clients` WHERE `id` = `client_id`) AS 'full_name',
    COUNT(`car_id`) AS 'count_of_cars',
    SUM(`bill`) AS 'total_sum' 
FROM `courses`
GROUP BY `client_id`
HAVING (`full_name` LIKE '_a%' AND `count_of_cars` > 1)
ORDER BY `full_name`;

# 9. Full information of courses
SELECT 
	`a`.`name`,
	(CASE 
		WHEN HOUR(`co`.`start`) BETWEEN 6 AND 20 THEN 'Day'
		ELSE 'Night'
	END)  AS 'dey_time',
    `co`.`bill`, 
    `cl`.`full_name`, 
    `ca`.`make`, 
    `ca`.`model`, 
    `cat`.`name` AS `category_name`
FROM `addresses` AS `a`
JOIN `courses` AS `co` ON `a`.`id` = `co`.`from_address_id`
JOIN `clients` AS `cl` ON `co`.`client_id` = `cl`.`id`
JOIN `cars` AS `ca` ON `co`.`car_id` = `ca`.`id`
JOIN  `categories` AS `cat` ON `ca`.`category_id` = `cat`.`id`
ORDER BY `co`.`id`;

# 10. Find all courses by client’s phone number
DELIMITER $$

CREATE FUNCTION udf_courses_by_client (phone_num VARCHAR (20))
RETURNS INT
DETERMINISTIC
BEGIN
	DECLARE cl_id INT;
    SET cl_id = (SELECT `id` FROM `clients` WHERE `phone_number` = phone_num);
    
    RETURN (SELECT COUNT(*) FROM `courses` WHERE `client_id` = cl_id); 

END$$

SELECT udf_courses_by_client('(803) 6386812')$$

# 11. Full info for address

CREATE PROCEDURE udp_courses_by_address(adr_name VARCHAR(100))
BEGIN
	SELECT 
		`a`.`name`,
		`cl`.`full_name`,
		(CASE
			WHEN `co`.`bill` <= 20 THEN 'Low'
			WHEN `co`.`bill` <= 30 THEN 'Medium'
			ELSE 'High'
		END) AS 'levil_of_bill',
		`ca`.`make`,
		`ca`.`condition`, 
		`cat`.`name` AS `category_name`
	FROM `addresses` AS `a`
	JOIN `courses` AS `co` ON `a`.`id` = `co`.`from_address_id`
	JOIN `clients` AS `cl` ON `co`.`client_id` = `cl`.`id`
	JOIN `cars` AS `ca` ON `co`.`car_id` = `ca`.`id`
	JOIN  `categories` AS `cat` ON `ca`.`category_id` = `cat`.`id`
    WHERE `a`.`name` = adr_name
	ORDER BY `ca`.`make`, `cl`.`full_name`;
END$$

CALL udp_courses_by_address('700 Monterey Avenue')$$

DELIMITER ;
