DELIMITER ||

# 1. Employees with Salary Above 35000
CREATE PROCEDURE usp_get_employees_salary_above_35000()
BEGIN
	DROP TEMPORARY TABLE IF EXISTS `_temp_table`;

	CREATE TEMPORARY TABLE `_temp_table`
		SELECT `first_name`, `last_name` FROM `employees`
		WHERE `salary` > 35000
        ORDER BY `first_name`, `last_name`, `employee_id`;
	SELECT * FROM `_temp_table`;

        
END||

CALL usp_get_employees_salary_above_35000||

# 2. Employees with Salary Above Number

CREATE PROCEDURE usp_get_employees_salary_above (f_salary DECIMAL(19, 4))
BEGIN
		DROP TEMPORARY TABLE IF EXISTS `_temp_table`;
        
		CREATE TEMPORARY TABLE `_temp_table`
		SELECT `first_name`, `last_name` FROM `employees`
			WHERE `salary` >= f_salary
            ORDER BY `first_name`, `last_name`, `employee_id`;
		
        SELECT * FROM `_temp_table`;
END||

CALL usp_get_employees_salary_above(45000)||

# 3. Town Names Starting With
CREATE PROCEDURE usp_get_towns_starting_with (t_name VARCHAR(50))
BEGIN 
	DROP TEMPORARY TABLE IF EXISTS `_temp_table`;
	CREATE TEMPORARY TABLE `_temp_table`
		SELECT `name` AS 'town_name' FROM `towns`
			WHERE `name` LIKE CONCAT(t_name, '%');
            
	SELECT * FROM `_temp_table`
    ORDER BY `town_name`;
END||

CALL usp_get_towns_starting_with ('b')||

# 4. Employees from Town

CREATE PROCEDURE usp_get_employees_from_town(f_name VARCHAR(50))
BEGIN
	DROP TEMPORARY TABLE IF EXISTS `_temp_table`;

	CREATE TEMPORARY TABLE `_temp_table`
		SELECT `e`.`first_name`, `e`.`last_name` FROM `employees` AS `e`
        JOIN `addresses` AS `a` ON `e`.`address_id` = `a`.`address_id`
        JOIN `towns` AS `t` ON `a`.`town_id` = `t`.`town_id`
        WHERE `t`.`name` = f_name
        ORDER BY `e`.`first_name`, `e`.`last_name`, `e`.`employee_id`;
        
	SELECT * FROM `_temp_table`;
        
END||

CALL usp_get_employees_from_town('Sofia')||

# 5. Salary Level Function
CREATE FUNCTION ufn_get_salary_level(employee_salary DECIMAL(19, 4))
RETURNS VARCHAR(10)
DETERMINISTIC
BEGIN 
	DECLARE result VARCHAR(10);
	SET result = CASE
		WHEN employee_salary < 30000  THEN'Low'
        WHEN employee_salary <= 50000 THEN 'Average'
        ELSE 'High'
	END;
    
    RETURN result;
END||

SELECT ufn_get_salary_level(15000)||

# 6. Employees by Salary Level
CREATE PROCEDURE usp_get_employees_by_salary_level(salary_level VARCHAR(10))
BEGIN
	DROP TEMPORARY TABLE IF EXISTS `_temp_table`;

	CREATE TEMPORARY TABLE `_temp_table`
    SELECT `first_name`, `last_name`, (CASE
					WHEN `salary` < 30000 THEN 'low'
                    WHEN `salary` <= 50000 THEN 'average'
                    ELSE 'high'
                END) AS 'level' FROM `employees`;
                
	SELECT `first_name`, `last_name` FROM `_temp_table`
    WHERE `level` = salary_level
    ORDER BY `first_name` DESC, `last_name` DESC;
END||

CALL usp_get_employees_by_salary_level('low')||

# 7. Define Function
CREATE FUNCTION ufn_is_word_comprised(set_of_letters varchar(50), word varchar(50))
RETURNS INT
DETERMINISTIC
BEGIN
	DECLARE result INT;
    
    DECLARE i INT;
    SET result = 1;
    SET i = 0;
	l1: LOOP 
		SET i = i + 1;
		IF i <= CHAR_LENGTH(word) THEN
            IF POSITION(LOWER(SUBSTR(word, i, 1)) IN LOWER(set_of_letters)) = 0 THEN
				SET result = 0;
			END IF;
			ITERATE l1;
		END IF;
      LEAVE l1;
    END LOOP l1;
    RETURN result;
END||


SELECT ufn_is_word_comprised('oistmiahf', 'sofia')||

# 8. Find Full Name
CREATE PROCEDURE usp_get_holders_full_name ()
BEGIN
	DROP TEMPORARY TABLE IF EXISTS `_temp_table`;
	
	CREATE TEMPORARY TABLE `_temp_table`
    SELECT CONCAT_WS(' ', `first_name`, `last_name`) AS 'full_name' FROM `account_holders` AS `a`
    ORDER BY `full_name`, `a`.`id`;
    SELECT * FROM `_temp_table`;
END||

CALL usp_get_holders_full_name()||

# 9. People with Balance Higher Than
CREATE PROCEDURE usp_get_holders_with_balance_higher_than(f_sum DECIMAL(19, 4))
BEGIN
	DROP TEMPORARY TABLE IF EXISTS `_temp_table`;
    
    CREATE TEMPORARY TABLE `_temp_table`
    SELECT `first_name`, `last_name`, SUM(`a`.`balance`) AS 'holder_balance', `a_h`.`id` AS 'id' FROM `account_holders` AS `a_h`
	
    JOIN `accounts` AS `a` ON `a_h`.`id` = `a`.`account_holder_id`
    GROUP BY `id`
    ORDER BY `id`;

    
    SELECT DISTINCT `first_name`, `last_name` FROM `_temp_table`
    WHERE `holder_balance` > f_sum;
   
END||

CALL usp_get_holders_with_balance_higher_than(7000)||

# 10. Future Value Function

CREATE FUNCTION ufn_calculate_future_value(i_sum DECIMAL(19, 4), y_interest DOUBLE(19, 4), years INT)
RETURNS DECIMAL(19,4)
DETERMINISTIC
BEGIN
	DECLARE result DECIMAL(19, 4);
    
    SET result = i_sum * (POWER((1 + y_interest), years));
    
    RETURN result;
END||

SELECT ufn_calculate_future_value(1000, 0.5, 5)||

# 11. Calculating Interest
CREATE PROCEDURE usp_calculate_future_value_for_account(a_id INT, interest DECIMAL(19, 4))
BEGIN
	DROP TEMPORARY TABLE IF EXISTS `_temp_table`;
	
	CREATE TEMPORARY TABLE `_temp_table`
    SELECT `a`.`id` AS 'account_id', `first_name`, `last_name`, `balance` AS 'current_balance', ufn_calculate_future_value(`balance`, interest, 5) AS 'balance_in_5_years' FROM `accounts` AS `a`
    JOIN `account_holders` AS `a_h` ON `a`.`account_holder_id` = `a_h`.`id`
    WHERE `a`.`id` = a_id;
    
    SELECT * FROM `_temp_table`;
END||

CALL usp_calculate_future_value_for_account(1, 0.1)||

DROP PROCEDURE usp_calculate_future_value_for_account||

# 12. Deposit Money
CREATE PROCEDURE usp_deposit_money(account_id INT, money_amount DECIMAL(19, 4))
	BEGIN
		IF money_amount <= 0 THEN 
		ROLLBACK; 
		ELSE
			UPDATE `accounts` 
			SET `balance` = `balance` + money_amount
			WHERE `id` = `account_id`;
		END IF;
	END||

CALL usp_deposit_money(1, 10)||

DROP PROCEDURE usp_deposit_money||

# 13. Withdraw Money
CREATE PROCEDURE usp_withdraw_money(account_id INT, money_amount DECIMAL(19, 4))
BEGIN
	IF (SELECT `balance` FROM `accounts`
		WHERE `id` = account_id) <= money_amount OR money_amount < 0 THEN
		ROLLBACK;
	ELSE
		UPDATE `accounts` 
		SET `balance` = `balance` - money_amount
		WHERE `id` = account_id;
	END IF;
END||

CALL usp_withdraw_money(1, 105)||

DROP PROCEDURE usp_withdraw_money||

# 14. Money Transfer
CREATE PROCEDURE usp_transfer_money(from_account_id INT, to_account_id INT, amount DECIMAL(19, 4))
BEGIN

	IF (SELECT `id` FROM `accounts` WHERE `id` = from_account_id) IS NULL 
		OR (SELECT `id` FROM `accounts` WHERE `id` = to_account_id) IS NULL 
        OR from_account_id = to_account_id OR amount < 0
        OR (SELECT `balance` FROM `accounts` WHERE `id` = from_account_id) < amount THEN
			ROLLBACK;
    ELSE
		UPDATE `accounts`
        SET `balance` = `balance` + amount
        WHERE `id` = to_account_id;
        UPDATE `accounts`
        SET `balance` = `balance` - amount
        WHERE `id` = from_account_id;
    END IF;
END||

CALL usp_transfer_money(1, 2, 10)||

DROP PROCEDURE usp_transfer_money||

# 15. Log Accounts Trigger

CREATE TABLE `logs`(
	`log_id` INT PRIMARY KEY AUTO_INCREMENT,
    `account_id` INT,
    `old_sum` DECIMAL(19, 4),
    `new_sum` DECIMAL(19, 4)
)||

CREATE TRIGGER tr_update_accounts_balance
AFTER UPDATE ON `accounts`
FOR EACH ROW
BEGIN
	IF (NEW.`balance` != OLD.`balance`) THEN
		INSERT INTO `logs` (`account_id`, `old_sum`, `new_sum`)
        VALUES (NEW.`id`, OLD.`balance`, NEW.`balance`);
    END IF;
END||


