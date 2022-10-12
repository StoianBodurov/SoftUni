CREATE DATABASE `softuni_store`;

USE `softuni_store`;

# 1. Table Design
CREATE TABLE `towns`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(20) NOT NULL
);

CREATE TABLE `pictures`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `url` VARCHAR(100) NOT NULL,
    `added_on` DATETIME NOT NULL
);

CREATE TABLE `categories`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(40) NOT NULL UNIQUE
);

CREATE TABLE `addresses`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(50) NOT NULL UNIQUE,
    `town_id` INT,
    CONSTRAINT fk_addresses_towns
    FOREIGN KEY (`town_id`) REFERENCES `towns`(`id`) 
);

CREATE TABLE `stores`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(20) NOT NULL UNIQUE,
    `rating` FLOAT NOT NULL,
    `has_parking` TINYINT(1) DEFAULT 0,
    `address_id` INT,
    CONSTRAINT fk_stores_addresses
    FOREIGN KEY (`address_id`) REFERENCES `addresses`(`id`)
);

CREATE TABLE `employees`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `first_name` VARCHAR(15) NOT NULL,
    `middle_name` CHAR(1),
    `last_name` VARCHAR(20) NOT NULL,
    `salary` DECIMAL(19, 2) DEFAULT 0,
    `hire_date` DATE NOT NULL,
    `manager_id` INT,
    `store_id` INT NOT NULL,
    CONSTRAINT fk_employees_employees
    FOREIGN KEY (`manager_id`) REFERENCES `employees`(`id`),
    CONSTRAINT fk_employees_stores
    FOREIGN KEY (`store_id`) REFERENCES `stores`(`id`)
);

CREATE TABLE `products`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(40) NOT NULL UNIQUE,
    `best_before` DATE,
    `price` DECIMAL(10, 2) NOT NULL,
    `description` TEXT,
    `category_id` INT NOT NULL,
    `picture_id` INT NOT NULL,
    CONSTRAINT fk_products_categories
    FOREIGN KEY (`category_id`) REFERENCES `categories`(`id`),
    CONSTRAINT fk_products_pictures
    FOREIGN KEY (`picture_id`) REFERENCES `pictures`(`id`)
);

CREATE TABLE `products_stores`(
	`product_id` INT NOT NULL,
    `store_id` INT NOT NULL,
    CONSTRAINT pk
    PRIMARY KEY (`product_id`, `store_id`),
    CONSTRAINT fk_products_stores_products
    FOREIGN KEY (`product_id`) REFERENCES `products`(`id`),
    CONSTRAINT fk_products_stores_stores
    FOREIGN KEY (`store_id`) REFERENCES `stores`(`id`)
);

# 2. Insert
INSERT INTO `products_stores`(`product_id`, `store_id`)
	SELECT `id`, 1 FROM `products` WHERE `id` NOT IN (SELECT `product_id` FROM `products_stores`);
    
# 3. Update
UPDATE `employees`
SET `salary` = `salary` - 500, `manager_id` = 3
WHERE YEAR(`hire_date`) > 2003 AND `store_id` NOT IN (5, 14);

# 4. Delete
DELETE FROM `employees`
WHERE `salary` >= 6000 AND `manager_id` IS NOT NULL;

# 5. Employees 
SELECT `first_name`, `middle_name`, `last_name`, `salary`, `hire_date` FROM `employees`
ORDER BY `hire_date` DESC;

# 6. Products with old pictures
SELECT 
	`pro`.`name`, 
	`pro`.`price`, 
	`pro`.`best_before`,
    CONCAT(LEFT(`pro`.`description`, 10), '...') AS 'short_description ',
    `pic`.`url` FROM `products` AS `pro`
JOIN `pictures` AS `pic` ON `pro`.`picture_id` = `pic`.`id`
WHERE CHAR_LENGTH(`pro`.`description`) > 100 AND `pro`.`price` > 20 AND YEAR(`pic`.`added_on`) < 2019
ORDER BY `pro`.`price` DESC;

# 7. Counts of products in stores and their average 
SELECT `s`.`name`, COUNT(`p_s`.`product_id`) AS 'product_count', ROUND(AVG(`price`), 2) AS 'avg' FROM `stores` AS `s`
LEFT JOIN `products_stores` AS `p_s` ON `s`.`id` = `p_s`.`store_id`
LEFT JOIN `products` AS `p` ON `p_s`.`product_id` = `p`.`id`
GROUP BY `s`.`name`
ORDER BY `product_count` DESC, `avg` DESC, `s`.`id`; 

# 8. Specific employee
SELECT 
	CONCAT_WS(' ', `first_name`, `last_name`) AS 'Full_name',
    `s`.`name` AS 'Store_name',
    `a`.`name`, 
    `e`.`salary`
FROM `employees` AS `e`
JOIN `stores` AS `s` ON `e`.`store_id` = `s`.`id`
JOIN `addresses` AS `a` ON `s`.`address_id` = `a`.`id`
WHERE `e`.`salary` < 4000 
AND `a`.`name` LIKE '%5%' 
AND CHAR_LENGTH(`s`.`name`) > 8
AND RIGHT(`e`.`last_name`, 1) = 'n';

# 9. Find all information of stores
SELECT 
	reverse(`s`.`name`) AS 'reversed_name',
    CONCAT_WS('-',UPPER(`t`.`name`), `a`.`name`) AS 'full_address',
    COUNT(`e`.`id`) AS 'employees_count'
FROM `stores` AS `s`
JOIN `addresses` AS `a` ON `s`.`address_id` = `a`.`id`
JOIN `towns` AS `t` ON `a`.`town_id` = `t`.`id`
JOIN `employees` AS `e` ON `s`.`id` = `e`.`store_id`
GROUP BY `s`.`name`
HAVING `employees_count` >= 1
ORDER BY `full_address`;

# 10. Find full name of top paid employee by store name
DELIMITER $$

CREATE FUNCTION udf_top_paid_employee_by_store(store_name VARCHAR(50))
RETURNS TEXT
DETERMINISTIC
BEGIN
	DECLARE s_id INT;
    SET s_id = (SELECT `id` FROM `stores` WHERE `name` = store_name);
    RETURN (SELECT 
				CONCAT(`first_name`, ' ', `middle_name`, '. ', `last_name`, ' works in store for ', YEAR('2020-10-18') - YEAR(`hire_date`), ' years')
			FROM `employees`
            WHERE `store_id` = s_id
            ORDER BY `salary` DESC LIMIT 1);
END$$

SELECT udf_top_paid_employee_by_store('Keylex')$$

DROP FUNCTION udf_top_paid_employee_by_store$$

# 11. Update product price by address
CREATE PROCEDURE udp_update_product_price (address_name VARCHAR (50))
BEGIN
	UPDATE `products`
    SET `price` = `price` + IF(LEFT(address_name, 1) = 0, 100, 200)
    WHERE `id` IN (SELECT `product_id` FROM `products_stores` AS `p_s`
					JOIN `stores` AS `s` ON `p_s`.`store_id` = `s`.`id`
                    JOIN `addresses` AS `a` ON `s`.`address_id` = `a`.`id`
                    WHERE `a`.`name` = address_name);
END$$
CALL udp_update_product_price('07 Armistice Parkway')$$
SELECT name, price FROM products WHERE id = 15$$
