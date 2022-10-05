# 1. Count Employees by Town

DELIMITER $$

CREATE FUNCTION ufn_count_employees_by_town(town_name VARCHAR(50))
RETURNS INT 
DETERMINISTIC
BEGIN
	DECLARE e_count INT;
    DECLARE town_id INT;
    SET town_id := (SELECT `town_id` FROM `towns` WHERE `name` = town_name);
    SET e_count := (SELECT COUNT(*) FROM `employees` AS `e` 
				JOIN `addresses` AS `a` ON `e`.`address_id` = `a`.`address_id`
                JOIN `towns` AS `t` ON `a`.`town_id` = `t`.`town_id`
                WHERE `t`.`name` = town_name);
    
    RETURN (e_count);

END$$

# 2. Employees Promotion
CREATE PROCEDURE usp_raise_salaries(department_name VARCHAR(50))
BEGIN
	UPDATE `employees`
    SET `salary` = `salary` * 1.05
    WHERE `department_id` = (SELECT `department_id` FROM `departments`
								WHERE `name` = department_name);
END$$ 


CALL usp_raise_salaries('Engineering')$$

# 3. Employees Promotion by ID
CREATE PROCEDURE usp_raise_salary_by_id(id INT)
BEGIN
	UPDATE `employees`
    SET `salary` = `salary` * 1.05
    WHERE `employee_id` = id;
END$$  

CALL usp_raise_salary_by_id(178)$$

# 4. Triggered

CREATE TABLE `deleted_employees`(
`employee_id` INT PRIMARY KEY AUTO_INCREMENT,
 `first_name` VARCHAR(50),
 `last_name` VARCHAR(50),
 `middle_name` VARCHAR(50),
 `job_title` VARCHAR(50),
 `department_id` INT,
 `salary` DECIMAL(19, 4)
)$$

CREATE TRIGGER tr_delete_employees
AFTER DELETE
ON `employees`
FOR EACH ROW
BEGIN
	INSERT INTO `deleted_employees`(`first_name`, `last_name`, `middle_name`, `job_title`, `department_id`, `salary`)
		VALUES(OLD.`first_name`, OLD.`last_name`, OLD.`middle_name`, OLD.`job_title`, OLD.`department_id`, OLD.`salary`);
END$$ 

DELETE FROM `employees` WHERE `employee_id` IN (1)$$



