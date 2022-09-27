USE `gamebar`;

/* 1. Create Table */
CREATE TABLE `employees`(
	`id` INT NOT NULL,
    `first_name` VARCHAR(50) NOT NULL,
    `last_name` VARCHAR(50) NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `categories`(
	`id` INT NOT NULL,
    `name` VARCHAR(50) NOT NULL,
    PRIMARY KEY (`id`)
);

CREATE TABLE `products`(
	`id` INT NOT NULL,
    `name` VARCHAR(50) NOT NULL,
    `category_id` INT NOT NULL,
    PRIMARY KEY (`id`)
);

/* 2. Insert Data in Tables */
INSERT INTO `employees`(`id`, `first_name`, `last_name`)
VALUES(1, 'pesho', 'Peshov');

INSERT INTO `employees`(`id`, `first_name`, `last_name`)
VALUES(2, 'Pesho', 'Peshov');

INSERT INTO `employees`(`id`, `first_name`, `last_name`)
VALUES(3, 'pesho', 'Peshov');

/* 3. Alter Table */
ALTER TABLE `employees`
ADD COLUMN `middle_name` VARCHAR(50);

/* 4. Adfding Constraints */
ALTER TABLE `products`
ADD CONSTRAINT fk_categories_id
FOREIGN KEY(category_id) REFERENCES categories(id);

/* 5. Modifying Columns */
ALTER TABLE `employees`
MODIFY COLUMN `middle_name` VARCHAR(100);






