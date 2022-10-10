CREATE DATABASE `online_store`;

USE `online_store`;

#01. Table Design
CREATE TABLE `customers`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `first_name` VARCHAR(20) NOT NULL,
    `last_name` VARCHAR(20) NOT NULL,
	`phone` VARCHAR(30) NOT NULL UNIQUE,
    `address` VARCHAR(60) NOT NULL,
    `discount_card` BIT(1) NOT NULL
);
CREATE TABLE `reviews`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
	`content` TEXT,
	`rating` DECIMAL(10, 2),
    `picture_url` VARCHAR(80),
    `published_at` DATETIME
);
CREATE TABLE `brands`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(40) NOT NULL UNIQUE
);
CREATE TABLE `categories`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(40) NOT NULL UNIQUE
);
CREATE TABLE `products`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(40) NOT NULL,
    `price` DECIMAL(19, 2) NOT NULL,
    `quantity_in_stock` INT,
    `description` TEXT,
    `brand_id` INT NOT NULL,
    `category_id` INT NOT NULL,
    `review_id` INT,
    CONSTRAINT fk_products_brand
    FOREIGN KEY (`brand_id`) REFERENCES `brands`(`id`),
    CONSTRAINT fk_product_category
    FOREIGN KEY (`category_id`) REFERENCES `categories`(`id`),
    CONSTRAINT fk_products_reviews
    FOREIGN KEY (`review_id`) REFERENCES `reviews`(`id`)
);
CREATE TABLE `orders`(
	`id` INT PRIMARY KEY AUTO_INCREMENT,
    `order_datetime` DATETIME NOT NULL,
    `customer_id` INT NOT NULL,
    CONSTRAINT fk_orders_customers 
    FOREIGN KEY (`customer_id`) REFERENCES `customers`(`id`)
);
CREATE TABLE `orders_products`(
	`order_id` INT ,
    `product_id` INT,
    CONSTRAINT fk_orders_products_orders
    FOREIGN KEY (`order_id`) REFERENCES `orders`(`id`),
    CONSTRAINT fk_orders_products_products
    FOREIGN KEY (`product_id`) REFERENCES `products`(`id`)
);

# 02. Insert
INSERT INTO `reviews`(`content`, `rating`, `picture_url`, `published_at`)
	SELECT LEFT(`description`, 15), `price` / 8, REVERSE(`name`), TIMESTAMP('2010-10-10') FROM `products`
    WHERE `id` >= 5;

# 03. Update
UPDATE `products`
SET `quantity_in_stock` = `quantity_in_stock` - 5
WHERE `quantity_in_stock` BETWEEN 60 AND 70;

# 04. Delete
DELETE FROM `customers`
WHERE `id` NOT IN (SELECT `customer_id` FROM `orders` );

# 05. Categories
SELECT `id`, `name` FROM `categories`
ORDER BY `name` DESC;

# 06. Quantity
SELECT `id`, `brand_id`, `name`, `quantity_in_stock` FROM `products`
WHERE `price` > 1000 AND `quantity_in_stock` < 30
ORDER BY `quantity_in_stock`, `id`;

# 07. Review
SELECT `id`, `content`, `rating`, `picture_url`, `published_at` FROM `reviews`
WHERE `content` LIKE 'My%' AND CHAR_LENGTH(`content`) > 61
ORDER BY `rating` DESC;

# 08. First customers
SELECT CONCAT_WS(' ', `c`.`first_name`, `c`.`last_name`) AS 'full_name', `c`.`address`, `o`.`order_datetime` AS 'order_date' FROM `customers` AS `c`
JOIN `orders` AS `o` ON `c`.`id` = `o`.`customer_id`
WHERE YEAR(`o`.`order_datetime`) <= 2018
ORDER BY `full_name` DESC;

# 09. Best categories
SELECT 
	COUNT(*) AS 'items_count', 
	(SELECT `name` FROM `categories` WHERE `category_id` = `id`) AS 'name',
    SUM(`quantity_in_stock`) AS `total_quantity`
    FROM `products` 
GROUP BY `category_id`
ORDER BY `items_count` DESC, `total_quantity`
LIMIT 5;

# 10. Extract client cards count
DELIMITER $$

CREATE FUNCTION udf_customer_products_count(name VARCHAR(30))
RETURNS INT
DETERMINISTIC
BEGIN
	DECLARE c_id INT;
    DECLARE result INT;
    SET c_id = (SELECT `id` FROM `customers` WHERE `first_name` = name);
    
    SET result = (SELECT COUNT(*) FROM `orders_products` WHERE `order_id` IN (SELECT `id` FROM `orders` WHERE `customer_id` = c_id));
    
    RETURN result;
    

END$$

# 11. Reduce price
CREATE PROCEDURE udp_reduce_price(category_name VARCHAR(50))
BEGIN
	DECLARE c_id INT;
    SET c_id = (SELECT `id` FROM `categories` wHERE `name` = category_name);
    
    UPDATE `products`
    SET `price` = `price` * 0.7
    WHERE `category_id` = c_id AND `review_id` IN (SELECT `id` FROM `reviews` WHERE `rating` < 4);
END$$

CALL udp_reduce_price('Phones and tablets')$$

DELIMITER ;



