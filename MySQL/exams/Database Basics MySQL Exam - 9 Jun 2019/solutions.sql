CREATE DATABASE `bank`;

USE `bank`;

CREATE TABLE `branches`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(30) NOt NULL UNIQUE
); 

CREATE TABLE `clients`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `full_name` VARCHAR(50) NOT NULL,
    `age` INT NOT NULL
);

CREATE TABLE `bank_accounts`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `account_number` VARCHAR(10) NOT NULL,
    `balance` DECIMAL(10, 2) NOT NULL,
    `client_id` INT NOT NULL UNIQUE,
    CONSTRAINT fk_bank_accounts_clients
    FOREIGN KEY (`client_id`) REFERENCES `clients`(`id`)
);

CREATE TABLE `cards`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `card_number` VARCHAR(19) NOT NULL,
    `card_status` VARCHAR(7) NOT NULL,
    `bank_account_id` INT NOT NULL,
    CONSTRAINT fk_cards_bank_accounts
    FOREIGN KEY (`bank_account_id`) REFERENCES `bank_accounts`(`id`)
);

CREATE TABLE `employees`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `first_name` VARCHAR(20) NOT NULL,
    `last_name` VARCHAR(20) NOT NULL,
    `salary` DECIMAL(10, 2) NOT NULL,
    `started_on` DATE NOT NULL,
    `branch_id` INT NOT NULL,
    CONSTRAINT fk_employees_branches
	FOREIGN KEY (`branch_id`) REFERENCES `branches`(`id`)
); 

CREATE TABLE `employees_clients`(
	`employee_id` INT,
    `client_id` INT,
    CONSTRAINT fk_employees_clients_emplpyees
    FOREIGN KEY (`employee_id`) REFERENCES `employees`(`id`),
    CONSTRAINT fk_employees_clients_clients
    FOREIGN KEY (`client_id`) REFERENCES `clients`(`id`)
);

# 02. Insert
INSERT INTO `cards`(`card_number`, `card_status`, `bank_account_id`)
SELECT REVERSE(`full_name`), 'Active', `id` FROM `clients`
WHERE `id` BETWEEN 191 AND 200;

# 03. Update
UPDATE `employees_clients` AS `e_c`
SET `e_c`.`employee_id` = (SELECT * FROM (SELECT `employee_id` 
							FROM `employees_clients`
							GROUP BY `employee_id`
							ORDER BY count(`client_id`), `employee_id`
							LIMIT 1) AS `c` )
                   
WHERE `employee_id` = `client_id`;

#0 4. Delete
DELETE FROM `employees`
WHERE `id` NOT IN (SELECT `employee_id` FROM `employees_clients`);

# 05. Clients
SELECT `id`, `full_name` FROM `clients`
ORDER BY `id`;

# 06. Newbies
SELECT `id`, CONCAT_WS(' ', `first_name`, `last_name`) AS 'full_name', CONCAT('$',`salary`) AS 'salary', `started_on` FROM `employees`
WHERE `salary` >= 100000 AND `started_on` >= DATE('2018-01-01')
ORDER BY `employees`.`salary` DESC, `id`;

# 07. Cards against Humanity
SELECT `c`.`id`, CONCAT_WS(' : ', `c`.`card_number`, `cl`.`full_name`) AS 'card_token' FROM `cards` AS `c`
JOIN `bank_accounts` AS `b_a` ON `c`.`bank_account_id` = `b_a`.`id`
JOIN `clients` AS `cl` ON `b_a`.`client_id` = `cl`.`id`
ORDER BY `c`.`id` DESC; 

# 08. Top 5 Employees
SELECT 
	CONCAT_WS(' ', `first_name`, `last_name`) AS 'name',
    `started_on`, 
    COUNT(`client_id`) 'count_of_clients' 
FROM `employees` AS `e`
JOIN `employees_clients` AS `e_c` ON `e`.`id` = `e_c`.`employee_id`
GROUP BY `id`
ORDER BY `count_of_clients` DESC, `id`
LIMIT 5;

# 09. Branch cards
SELECT `b`.`name`, COUNT(`ca`.`id`) AS 'count_of_cards' FROM `branches` AS `b`
LEFT JOIN `employees` AS `e` ON `b`.`id` = `e`.`branch_id`
LEFT JOIN `employees_clients` AS `e_c` ON `e`.`id` = `e_c`.`employee_id`
LEFT JOIN `clients` AS `c` ON `e_c`.`client_id` = `c`.`id`
LEFT JOIN `bank_accounts` AS `b_a` ON `c`.`id` = `b_a`.`client_id`
LEFT JOIN `cards` AS `ca` ON `b_a`.`id` = `ca`.`bank_account_id`
GROUP BY `b`.`name`
ORDER BY `count_of_cards` DESC, `b`.`name`;

# 10. Extract client cards count
DELIMITER $$

CREATE FUNCTION udf_client_cards_count(f_name VARCHAR(30))
RETURNS INT
DETERMINISTIC
BEGIN

		DECLARE c_id INT;
        SET c_id = (SELECT `id` FROM `clients` WHERE `full_name` = f_name);
        
        RETURN (SELECT COUNT(*) FROM `cards` WHERE `bank_account_id` = (SELECT `id` FROM `bank_accounts` WHERE `client_id` = c_id));
END$$

SELECT udf_client_cards_count('Baxy David')$$

# 11. Extract Client Info
CREATE PROCEDURE udp_clientinfo(f_name VARCHAR(50))
BEGIN
	SELECT `c`.`full_name`, `c`.`age`, `b_a`.`account_number`, CONCAT('$',`b_a`.`balance`) AS 'balance' FROM `bank_accounts` AS `b_a`
    JOIN `clients` AS `c` ON `b_a`.`client_id` = `c`.`id`
    WHERE `c`.`id` = (SELECT `id` FROM `clients` WHERE `full_name` = f_name); 
END$$

DELIMITER ;