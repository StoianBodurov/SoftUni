# 1. Find Names of All Employees by First Name
SELECT `first_name`, `last_name` FROM `employees`
WHERE LEFT(`first_name`, 2) = 'Sa'
ORDER BY `employee_id`;

# 2. Find Names of All Employees by Last Name
SELECT `first_name`, `last_name` FROM `employees`
WHERE LOCATE('ei', `last_name`) != 0
ORDER BY `employee_id`;

# 3. Find First Names of All Employees
SELECT `first_name` FROM `employees`
WHERE (`department_id` = 3 OR `department_id` = 10)
AND (`hire_date` BETWEEN DATE('1995-01-01') AND DATE('2005-12-31'))
ORDER BY `employee_id`;

# 4. Find All Employees Except Engineers
SELECT `first_name`, `last_name` FROM `employees`
WHERE LOCATE('engineer', `job_title`) = 0
ORDER BY `employee_id`;

# 5. Find Towns with Name Length
SELECT `name` FROM `towns`
WHERE CHAR_LENGTH(`name`) = 5 OR CHAR_LENGTH(`name`) = 6
ORDER BY `name`;

# 6. Find Towns Starting With
SELECT `town_id`, `name` FROM `towns`
WHERE UPPER(LEFT(`name`, 1)) = 'M' OR UPPER(LEFT(`name`, 1)) = 'K' OR UPPER(LEFT(`name`, 1)) = 'B' OR UPPER(LEFT(`name`, 1)) = 'E'
ORDER BY `name`;

# 7. Find Towns Not Starting With
SELECT `town_id`, `name` FROM `towns`
WHERE LOWER(LEFT(`name`, 1)) != 'r' AND LOWER(LEFT(`name`, 1)) != 'b' AND LOWER(LEFT(`name`, 1)) != 'd'
ORDER BY `name`;

# 8. Create View Employees Hired After
CREATE VIEW v_employees_hired_after_2000 AS
SELECT `first_name`, `last_name` FROM `employees`
WHERE YEAR(`hire_date`) > 2000;

SELECT * FROM v_employees_hired_after_2000;

# 9. Length of Last Name
SELECT `first_name`, `last_name` FROM `employees`
WHERE CHAR_LENGTH(`last_name`) = 5;

# 10. Countries Holding 'A' 3 or More Times
SELECT `country_name`, `iso_code` FROM `countries`
WHERE CHAR_LENGTH(`country_name`) - CHAR_LENGTH(REPLACE(LOWER(`country_name`), 'a', '')) >= 3
ORDER BY `iso_code`;

# 11. Mix of Peak and River Names
SELECT `peak_name`, `river_name`, LOWER(CONCAT(`peak_name`, SUBSTRING(`river_name`, 2))) AS 'mix' FROM `peaks`, `rivers`
WHERE LOWER(RIGHT(`peak_name`, 1)) = LOWER(LEFT(`river_name`, 1))
ORDER BY `mix`;

# 12. Games from 2011 and 2012 Year
SELECT `name`, DATE_FORMAT(`start`, '%Y-%m-%d') FROM `games`
WHERE YEAR(`start`) BETWEEN 2011 AND 2012
ORDER BY `start`, `name`
LIMIT 50;

# 13. User Email Providers
SELECT `user_name`, SUBSTRING(`email`, LOCATE('@', `email`) + 1) AS 'email provider' FROM `users`
ORDER BY `email provider`, `user_name`;

# 14. Get Users with IP Address Like Pattern
SELECT `user_name`, `ip_address` FROM `users`
WHERE `ip_address` LIKE '___.1%.%.___'
ORDER BY `user_name`;

# 15. Show All Games with Duration and Part of the Day
SELECT `name` AS 'game', 
CASE
	WHEN HOUR(`start`) BETWEEN 0 AND 11 THEN 'Morning'
    WHEN HOUR(`start`) BETWEEN 12 ANd 17 THEN 'Afternoon'
    ELSE 'Evening'
    END AS 'Part of the Day', 
CASE 
	WHEN `duration` <= 3 THEN 'Extra Short'
    WHEN `duration` <= 6 THEN 'Short'
    WHEN `duration` <= 10 THEN 'Long'
    ELSE 'Extra Long'
    END AS 'Duration'
FROM `games`;

# 16. Orders Table
SELECT 
	`product_name`, 
	`order_date`, 
    DATE_ADD(`order_date`, INTERVAL 3 DAY) AS 'pay_due',
    DATE_ADD(`order_date`, INTERVAL 1 MONTH) as 'deliver_due'
FROM `orders`;






