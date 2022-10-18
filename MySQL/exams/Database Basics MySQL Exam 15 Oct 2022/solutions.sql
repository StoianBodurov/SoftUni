CREATE DATABASE `restaurant`;

USE `restaurant`;

# 01. Table Design
CREATE TABLE `tables`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `floor` INT NOT NULL,
    `reserved` TINYINT(1),
    `capacity` INT NOT NULL
);

CREATE TABLE `waiters`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `first_name` VARCHAR(50) NOT NULL,
    `last_name` VARCHAR(50) NOT	NULL,
    `email` VARCHAR(50) NOT NULL,
    `phone` VARCHAR(50),
    `salary` DECIMAL(10, 2)
);

CREATE TABLE `orders`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `table_id` INT NOT NULL, 
    `waiter_id` INT NOT NULL,
    `order_time` TIME NOT NULL,
    `payed_status` TINYINT(1),
    CONSTRAINT fk_orders_tables
    FOREIGN KEY (`table_id`) REFERENCES `tables`(`id`),
    CONSTRAINT fk_orders_waiters
    FOREIGN KEY (`waiter_id`) REFERENCES `waiters`(`id`)
);

CREATE TABLE `products`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(30) NOT NULL UNIQUE,
    `type` VARCHAR(30) NOT NULL,
    `price` DECIMAL(10, 2) NOT NULL
);

CREATE TABLE `orders_products`(
	`order_id` INT,
    `product_id` INT,
    CONSTRAINT fk_orders_products_orders
    FOREIGN KEY (`order_id`) REFERENCES `orders`(`id`),
    CONSTRAINT fk_orders_products_products
    FOREIGN KEY (`product_id`) REFERENCES `products`(`id`)
);

CREATE TABLE `clients`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `first_name` VARCHAR(50) NOT NULL,
    `last_name` VARCHAR(50) NOT NULL,
    `birthdate` DATE NOT NULL	,
    `card` VARCHAR(50),
    `review` TEXT
);

CREATE TABLE `orders_clients`(
	`order_id` INT,
    `client_id` INT,
    CONSTRAINT fk_orders_clients_orders
    FOREIGN KEY (`order_id`) REFERENCES `orders`(`id`),
    CONSTRAINT fk_orders_clients_clients
    FOREIGN KEY (`client_id`) REFERENCES `clients`(`id`)
    
); 

# 02. Insert
INSERT INTO `products`(`name`,`type`, `price`)
SELECT CONCAT_WS(' ', `last_name`, 'specialty') AS 'name', 'Cocktail', CEIL(`salary` * 0.01) FROM `waiters`
WHERE `id` > 6;

# 03. Update
UPDATE `orders`
SET `table_id` = `table_id` - 1
WHERE `id` BETWEEN 12 AND 23;

# 04. Delete
DELETE FROM `waiters`
WHERE `id` NOT IN (SELECT `waiter_id` FROM `orders`);

# 05. Clients
SELECT `id`, `first_name`, `last_name`, `birthdate`, `card`, `review` FROM `clients`
ORDER BY `birthdate` DESC, `id` DESC;

# 06. Birthdate
SELECT `first_name`, `last_name`, `birthdate`, `review` FROM `clients`
WHERE `card` IS NULL AND YEAR(`birthdate`) BETWEEN 1978 AND 1993
ORDER BY `last_name` DESC, `id`
LIMIT 5;

# 07. Accounts
SELECT 
	CONCAT(`last_name`, `first_name`, CHAR_LENGTH(`first_name`), 'Restaurant') AS 'usernam',
    REVERSE(SUBSTRING(`email`, 2, 12)) AS 'password'
FROM `waiters`
WHERE `salary` IS NOT NULL
ORDER BY `password` DESC;    

# 08. Top from menu
SELECT `p`.`id`, `p`.`name`, COUNT(`a_p`.`product_id`) AS 'count' FROM `products` AS `p`
RIGHT JOIN `orders_products` AS `a_p` ON `p`.`id` = `a_p`.`product_id`
RIGHT JOIN `orders` AS `o` ON `a_p`.`order_id` = `o`.`id`
GROUP BY `p`.`name`
HAVING `count` >= 5
ORDER BY `count` DESC, `p`.`name`;

# 09. Availability
SELECT 
	`t`.`id`, `t`.`capacity`, 
	COUNT(`o_c`.`client_id`) AS 'count_clients',
    (CASE 
		WHEN COUNT(`o_c`.`client_id`)  = `t`.`capacity` THEN 'Full'
        WHEN COUNT(`o_c`.`client_id`)  < `t`.`capacity` THEN 'Free seats'
        ELSE 'Extra seats'
	END) AS 'availability'
FROM `tables` AS `t`
JOIN `orders` AS `o` ON `t`.`id` = `o`.`table_id`
JOIN `orders_clients` AS `o_c` ON `o`.`id` = `o_c`.`order_id`
WHERE `t`.`floor` = 1
GROUP BY `t`.`id`
ORDER BY `t`.`id` DESC;


# 10. Extract bill
DELIMITER $$

CREATE FUNCTION udf_client_bill(full_name VARCHAR(50)) 
RETURNS DECIMAL(19, 2)
DETERMINISTIC
BEGIN
	DECLARE c_id INT;
    DECLARE result DECIMAL(19, 2);
    SET c_id = (SELECT `id` FROM `clients` WHERE CONCAT_WS(' ', `first_name`, `last_name`) = full_name);
    SET result = (SELECT  SUM(`p`.`price`) FROM `orders_clients` AS `o_c`
					JOIN `orders` AS `o` ON `o_c`.`order_id` = `o`.`id`
                    JOIN `orders_products`  AS `o_p` ON `o`.`id` = `o_p`.`order_id`
                    JOIN `products` AS `p` ON `o_p`.`product_id` = `p`.`id`
                    GROUP BY `o_c`.`client_id`
                    HAVING `o_c`.`client_id` = c_id);
                    
		RETURN result;
 	
END$$

SELECT udf_client_bill('Silvio Blyth')$$

# 11. Happy hour


CREATE PROCEDURE udp_happy_hour(t VARCHAR(50))
BEGIN
	UPDATE `products`
    SET `price` = `price` * 0.8
    WHERE `type` = t AND `price` >= 10;
END$$