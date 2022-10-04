# 1. Employee Address
SELECT 
    `employee_id`,
    `job_title`,
    `e`.`address_id`,
    `a`.`address_text`
FROM
    `employees` AS `e`
        JOIN
    `addresses` AS `a` ON `e`.`address_id` = `a`.`address_id`
ORDER BY `a`.`address_id`
LIMIT 5;
	
# 2. Addresses with Towns
SELECT 
    `e`.`first_name`,
    `e`.`last_name`,
    `t`.`name` AS 'town',
    `a`.`address_text`
FROM
    `employees` AS `e`
        JOIN
    `addresses` AS `a` ON `e`.`address_id` = `a`.`address_id`
        JOIN
    `towns` AS `t` ON `a`.`town_id` = `t`.`town_id`
ORDER BY `first_name` , `last_name`
LIMIT 5;

# 3. Sales Employee
SELECT 
    `e`.`employee_id`,
    `e`.`first_name`,
    `e`.`last_name`,
    `d`.`name` AS 'department_name'
FROM
    `employees` AS `e`
        JOIN
    `departments` AS `d` ON `e`.`department_id` = `d`.`department_id`
WHERE
    `d`.`name` = 'Sales'
ORDER BY `e`.`employee_id` DESC;

# 4. Employee Departments
SELECT 
    `employee_id`,
    `first_name`,
    `salary`,
    `d`.`name` AS 'department_name'
FROM
    `employees` AS `e`
        JOIN
    `departments` AS `d` ON `e`.`department_id` = `d`.`department_id`
WHERE
    `e`.`salary` > 15000
ORDER BY `e`.`department_id` DESC
LIMIT 5;

# 5. Employees Without Project
SELECT 
    `e`.`employee_id`, `e`.`first_name`
FROM
    `employees` AS `e`
        LEFT JOIN
    `employees_projects` AS `p` ON `e`.`employee_id` = `p`.`employee_id`
WHERE
    `p`.`project_id` IS NULL
ORDER BY `e`.`employee_id` DESC
LIMIT 3;

# 6. Employees Hired After
SELECT 
    `e`.`first_name`, `e`.`last_name`, `e`.`hire_date`, `d`.`name`
FROM
    `employees` AS `e`
        JOIN
    `departments` AS `d` ON `e`.`department_id` = `d`.`department_id`
WHERE
    `e`.`hire_date` > '1999-01-01'
        AND `d`.`name` = 'Sales'
        OR `d`.`name` = 'Finance'
ORDER BY `e`.`hire_date`;

# 7. Employees with Project
SELECT 
    `e`.`employee_id`,
    `e`.`first_name`,
    `p`.`name` AS 'project_name'
FROM
    `employees` AS `e`
        JOIN
    `employees_projects` AS `e_p` ON `e`.`employee_id` = `e_p`.`employee_id`
        JOIN
    `projects` AS `p` ON `e_p`.`project_id` = `p`.`project_id`
WHERE
    DATE(`p`.`start_date`) > '2002-08-13' AND `p`.`end_date` IS NULL
ORDER BY `e`.`first_name` ASC , `project_name` ASC
LIMIT 5;

# 8. Employee 24
SELECT 
    `e`.`employee_id`,
    `e`.`first_name`,
    IF(YEAR(`p`.`start_date`) >= 2005,
        NULL,
        `p`.`name`) AS 'project_name'
FROM
    `employees` AS `e`
        JOIN
    `employees_projects` AS `e_p` ON `e`.`employee_id` = `e_p`.`employee_id`
        JOIN
    `projects` AS `p` ON `e_p`.`project_id` = `p`.`project_id`
WHERE
    `e`.`employee_id` = 24
ORDER BY `project_name`;

# 9. Employee Manager
SELECT 
    `e`.`employee_id`,
    `e`.`first_name`,
    `e`.`manager_id`,
    `m`.`first_name` AS `manager_name`
FROM
    `employees` AS `e`
        JOIN
    `employees` AS `m` ON `e`.`manager_id` = `m`.`employee_id`
WHERE
    `e`.`manager_id` IN (3 , 7)
ORDER BY `e`.`first_name`;

# 10. Employee Summary
SELECT 
    `e`.`employee_id`,
    CONCAT_WS(' ', `e`.`first_name`, `e`.`last_name`) AS 'employee_name',
    CONCAT_WS(' ', `m`.`first_name`, `m`.`last_name`) AS 'manager_name',
    `d`.`name`
FROM
    `employees` AS `e`
        JOIN
    `employees` AS `m` ON `e`.`manager_id` = `m`.`employee_id`
		JOIN
	`departments` AS `d` ON `e`.`department_id` = `d`.`department_id`
ORDER BY `e`.`employee_id`
LIMIT 5;

# 11. Min Average Salary
SELECT 
    AVG(`salary`) AS 'min_average_salary'
FROM
    `employees`
GROUP BY `department_id`
ORDER BY `min_average_salary`
LIMIT 1;

# 12. Highest Peaks in Bulgaria
SELECT 
    `c`.`country_code`,
    `m`.`mountain_range`,
    `p`.`peak_name`,
    `p`.`elevation`
FROM
    `countries` AS `c`
        JOIN
    `mountains_countries` AS `m_c` ON `c`.`country_code` = `m_c`.`country_code`
        JOIN
    `mountains` AS `m` ON `m_c`.`mountain_id` = `m`.`id`
        JOIN
    `peaks` AS `p` ON `m`.`id` = `p`.`mountain_id`
WHERE
    `c`.`country_code` IN ('BG')
        AND `p`.`elevation` > 2835
ORDER BY `p`.`elevation` DESC;

# 13. Count Mountain Ranges
SELECT 
    `country_code`, COUNT(`mountain_id`) AS 'mountain_range'
FROM
    `mountains_countries`
GROUP BY `country_code`
HAVING `country_code` IN ('BG' , 'US', 'RU')
ORDER BY `mountain_range` DESC;

# 14. Countries with Rivers
SELECT 
    `c`.`country_name`, `r`.`river_name`
FROM
    `countries` AS `c`
        LEFT JOIN
    `countries_rivers` AS `c_r` ON `c`.`country_code` = `c_r`.`country_code`
        LEFT JOIN
    `rivers` AS `r` ON `c_r`.`river_id` = `r`.`id`
WHERE
    `c`.`continent_code` = 'AF'
ORDER BY `c`.`country_name`
LIMIT 5;

# 16. Countries Without Any Mountains
SELECT 
    COUNT(*) AS 'country_count'
FROM
    `countries` AS `c`
WHERE `c`.`country_code` NOT IN (SELECT `country_code` FROM `mountains_countries`);
            
# 17. Highest Peak and Longest River by Country
SELECT 
    `c`.`country_name`,
    MAX(`p`.`elevation`) AS 'highest_peak_elevation',
    MAX(`r`.`length`) AS 'longest_river_length'
FROM
    `countries` AS `c`
        JOIN
    `countries_rivers` AS `c_r` ON `c`.`country_code` = `c_r`.`country_code`
        JOIN
    `rivers` AS `r` ON `c_r`.`river_id` = `r`.`id`
        JOIN
    `mountains_countries` AS `m_c` ON `c`.`country_code` = `m_c`.`country_code`
        JOIN
    `peaks` AS `p` ON `m_c`.`mountain_id` = `p`.`mountain_id`
GROUP BY `c`.`country_name`
ORDER BY `highest_peak_elevation` DESC , `longest_river_length` DESC
LIMIT 5;
