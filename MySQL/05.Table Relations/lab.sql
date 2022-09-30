# 1. Mountains and Peaks
USE `camp`;

CREATE TABLE `mountains`
(
	`id` INT NOT NULL AUTO_INCREMENT,
    `name` VARCHAR(30),
    PRIMARY KEY (`id`)
);

CREATE TABLE `peaks`
(
	`id` INT NOT NULL AUTO_INCREMENT,
    `name` VARCHAR(30),
    `mountain_id` INT,
    PRIMARY KEY (`id`),
    CONSTRAINT `pk_mountains_peak`
    FOREIGN KEY (`mountain_id`) REFERENCES `mountains`(`id`)
);

# 2. Trip Organization
SELECT `driver_id`, `vehicle_type`, CONCAT(`first_name`, ' ', `last_name`) AS 'driver_name' FROM `vehicles` AS `v`
JOIN `campers` AS `c`
ON `v`.`driver_id` = `c`.`id`;

# 3. SoftUni Hiking
SELECT `starting_point`, `end_point`, `leader_id`, CONCAT(`first_name`, ' ', `last_name` )  AS 'leader_name' FROM `routes` AS `r`
JOIN `campers` AS `c`
ON `r`.`leader_id` = `c`.`id`;

# 4. Delete Mountains
DROP TABLE `peaks`;
DROP TABLE `mountains`;

CREATE TABLE `mountains`
(
	`id` INT NOT NULL AUTO_INCREMENT,
    `name` VARCHAR(30),
    PRIMARY KEY (`id`)
);

CREATE TABLE `peaks`
(
	`id` INT NOT NULL AUTO_INCREMENT,
    `name` VARCHAR(30),
    `mountain_id` INT,
    PRIMARY KEY (`id`),
    CONSTRAINT `pk_mountains_peak`
    FOREIGN KEY (`mountain_id`) REFERENCES `mountains`(`id`)
    ON DELETE CASCADE
);



