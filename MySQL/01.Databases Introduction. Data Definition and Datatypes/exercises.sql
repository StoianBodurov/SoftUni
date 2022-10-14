-- CREATE DATABASE `minions`;-- 

USE `minions`;

/* 1. Craete Table */
CREATE TABLE `minions`(
	`id` INT NOT NULL,
    `name` VARCHAR(50),
    `age` INT,
    PRIMARY KEY (`id`)
);

CREATE TABLE `towns`(
	`town_id` INT NOT NULL,
    `name` VARCHAR(50),
    PRIMARY KEY(`town_id`)
);

/* 2. Alter Minions Table */

ALTER TABLE `minions`
ADD `town_id` INT;

ALTER TABLE `minions`
ADD CONSTRAINT `fk_towns_id`
FOREIGN KEY (`town_id`) REFERENCES `towns`(`id`);

/* 3. Insert Records in Both Tables */

INSERT INTO `towns`(`id`,`name`)
VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna');

INSERT INTO `minions`(`id`, `name`, `age`, `town_id`)
VALUES 
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL ,2);

/* 4. Truncate Table Minions */

DELETE FROM `minions`;

/* 5 Drop All Tables */

DROP TABLE `minions`;
DROP TABLE `towns`; 

/* 6. Create Table People */

CREATE TABLE `people`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(200) NOT NULL,
    `picture` BLOB,
    `height` DOUBLE(10, 2),
    `weight` DOUBLE(10, 2),
    `gender` CHAR(1) NOT NULL,
    `birthdate` DATE NOT NULL,
    `biography` TEXT
);

INSERT INTO `people`(`name`, `gender`, `birthdate`)
VALUES
('ivan', 'm', DATE(NOW())),
('Mima', 'f', DATE(NOW())),
('Pesh', 'm', DATE(NOW())),
('Stoian', 'm', DATE(NOW())),
('Katerina', 'f', DATE(NOW()));

/* 7. Create table users */

CREATE TABLE `users`(
	`id` INT AUTO_INCREMENT,
    `username` VARCHAR(30) NOT NULL,
    `password` VARCHAR(26) NOT NULL,
    `profil_picture` BLOB,
    `last_login_time` DATE,
    `is_deleted` BOOLEAN,
    CONSTRAINT pk_users
    PRIMARY KEY `users`(`id`)
    
);

INSERT INTO `users`(`username`, `password`, `last_login_time`, `is_deleted`)
VALUES
('stoian', 's123', DATE(NOW()), 0),
('stoian1', 's123', DATE(NOW()), 1),
('stoian2', 's123', DATE(NOW()), 0),
('stoian3', 's123', DATE(NOW()), 0),
('stoian4', 's123', DATE(NOW()), 1);

/* 8. Change Primary key */

ALTER TABLE `users`
DROP PRIMARY KEY,
ADD CONSTRAINT pk_users PRIMARY KEY `users`(`id`, `username`);

/* 9. Set Default Value of a Field */

ALTER TABLE `users`
CHANGE COLUMN `last_login_time`
`last_login_time` DATETIME DEFAULT NOW();

/* 10. Set Unique Field*/

ALTER TABLE `users`
DROP PRIMARY KEY,
ADD CONSTRAINT pk_users PRIMARY KEY `users`(`id`),
CHANGE COLUMN `username`
`username` VARCHAR(50) UNIQUE; 

/* 11. Movies Database */

CREATE DATABASE `movies`;

USE `movies`;

CREATE TABLE `directors`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `director_name` VARCHAR(50) NOT NULL,
    `notes` TEXT
);

INSERT INTO `directors`(`director_name`)
VALUES ('PESO1'),
 ('PESO2'),
 ('PESO3'),
 ('PESO3'),
 ('PESO5'),
 ('PESO6');

CREATE TABLE `genres`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `genre_name` VARCHAR(50) NOT NULL,
    `notes` TEXT
);

INSERT INTO `genres`(`genre_name`)
VALUES ('test1'),
('test2'),
('test3'),
('test4'),
('test5');



CREATE TABLE `categories`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `category_name` VARCHAR(50) NOT NULL,
    `notes` TEXT
);

INSERT INTO `categories`(`category_name`)
VALUES ('Test categories1'),
('Test categories2'),
('Test categories3'),
('Test categories4'),
('Test categories5');


CREATE TABLE `movies`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
	`title` VARCHAR(50) NOT NULL,
    `director_id` INT,
    `copyright_year` YEAR,
    `genre_id` INT,
    `category_id` int,
    `rating` INT,
    `notes` TEXT
);

INSERT INTO `movies` (`title`)
VALUES ('Movies test 1'),
('Movies test 2'),
('Movies test 3'),
('Movies test 4'),
('Movies test 5');

# 12. Car Rental Database
CREATE DATABASE `car_rental`;

USE `car_rental`;

CREATE TABLE `categories`(
    `id` INT NOT NULL AUTO_INCREMENT,
    `category` VARCHAR(50),
    `daily_rate` DOUBLE,
    `weekly_rate` DOUBLE,
    `monthly_rate` DOUBLE,
    `weekend_rate` DOUBLE,
    PRIMARY KEY (`id`) 
);

INSERT INTO `categories` (`category`)
VALUE('Test1'),
('Test2'),
('Test3');

CREATE TABLE `employees`(
    `id` INT NOT NULL AUTO_INCREMENT,
    `first_name` VARCHAR(50),
    `last_name` VARCHAR(50),
    `title` VARCHAR(50),
    `notes` TEXT,
    PRIMARY KEY(`id`)
);

INSERT INTO `employees`(`first_name`)
VALUE('Test1'),
('Test2'),
('Test3');

CREATE TABLE `cars`(
    `id` INT NOT NULL AUTO_INCREMENT,
    `plate_number` VARCHAR(20),
    `make` VARCHAR(50),
    `car_year` INT,
    `category_id` INT,
    `doors` INT,
    `picture` BLOB,
    `car_condition` VARCHAR(20),
    `available` BOOLEAN,
    PRIMARY KEY(`id`)
);

INSERT INTO `cars`(`plate_number`)
VALUE('3432'),
('3433'),
('3434');

CREATE TABLE `customers`(
    `id` INT NOT NULL AUTO_INCREMENT,
    `driver_licence_number` VARCHAR(50),
    `full_name` VARCHAR(20),
    `address` VARCHAR(50),
    `city` VARCHAR(20),
    `zip_code` INT,
    `notes` TEXT,
    PRIMARY KEY(`id`)
);

INSERT INTO `customers` (`full_name`)
VALUE('Test1'),
('Test2'),
('Test3');

CREATE TABLE `rental_orders`(
    `id` INT NOT NULL AUTO_INCREMENT,
    `employee_id` INT,
    `customer_id` INT,
    `car_id` INT,
    `car_condition` VARCHAR(20),
    `tank_level` DOUBLE,
    `kilometrage_start` INT,
    `kilometrage_end` INT,
    `total_kilometrage` INT,
    `start_date` TIMESTAMP,
    `end_date` TIMESTAMP,
    `total_days` INT,
    `rate_applied` DOUBLE,
    `tax_rate` DOUBLE,
    `order_status` VARCHAR(20),
    `notes` TEXT,
    PRIMARY KEY(`id`)
);

INSERT INTO `rental_orders`(`total_kilometrage`)
VALUE(123456),
(123457),
(123458);

# 13. Basic Insert
CREATE DATABASE `s_u`;

USE `s_u`;

CREATE TABLE `towns`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(50)
);

CREATE TABLE `addresses`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `address` VARCHAR(150),
    `town_id` INT,
    CONSTRAINT fk_addresses_towns
    FOREIGN KEY (`town_id`) REFERENCES `towns`(`id`)
);

CREATE TABLE `departments`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(30)
);

CREATE TABLE `employees`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `first_name` VARCHAR(30),
    `middle_name` VARCHAR(30),
    `last_name` VARCHAR(30),
    `job_title` VARCHAR(30),
    `department_id` INT,
    `hire_date` DATE,
    `salary` DECIMAL(19, 2),
    `address_id` INT,
    CONSTRAINT fk_employees_departments
    FOREIGN KEY (`department_id`) REFERENCES `departments`(`id`),
    CONSTRAINT fk_employees_adresses
    FOREIGN KEY (`address_id`) REFERENCES `addresses`(`id`)
);

INSERT INTO `towns`(`name`)
VALUES ('Sofia'),
		('Plovdiv'),
        ('Varna'),
        ('Burgas');
        
INSERT INTO `departments`(`name`)
VALUES ('Engineering'),
		('Sales'),
        ('Marketing'),
        ('Software Development'),
        ('Quality Assurance');
        
INSERT INTO `employees`(`first_name`, `middle_name`, `last_name`, `job_title`, `department_id`, `hire_date`, `salary`)
VAlUES ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500),
		('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000),
        ('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25),
        ('Georgi', 'Terziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000),
        ('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88);
        
# 14. Basic Select All Fields
SELECT * FROM `towns`;
SELECT * FROM `departments`;
SELECT * FROM `employees`;

# 15. Basic Select All Fields and Order Them
SELECT * FROM `towns` 
ORDER BY `name`;
SELECT * FROM `departments`
ORDER BY `name`;
SELECT * FROM `employees`
ORDER BY `salary` DESC;

# 16. Basic Select Some Fields
SELECT `name` FROM `towns` 
ORDER BY `name`;
SELECT `name` FROM `departments`
ORDER BY `name`;
SELECT `first_name`, `last_name`, `job_title`, `salary` FROM `employees`
ORDER BY `salary` DESC;

# 17. Increase Employees Salary
UPDATE `employees`
SET `salary` = `salary` * 1.1;
SELECT `salary` FROM `employees`;



