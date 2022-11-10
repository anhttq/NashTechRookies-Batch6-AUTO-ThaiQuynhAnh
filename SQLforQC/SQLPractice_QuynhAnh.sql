USE SQLforQC
GO

--question 1
SELECT department_id FROM employees WHERE last_name = 'Zlotkey';
SELECT last_name, hire_date FROM employees WHERE department_id = 80 AND last_name != 'Zlotkey';

SELECT last_name, hire_date FROM employees
WHERE department_id = 
(SELECT department_id FROM employees WHERE last_name = 'Zlotkey') 
AND last_name != 'Zlotkey';

SELECT e1.last_name, e1.hire_date FROM employees e1
LEFT JOIN employees e2 ON e1.department_id = e2.department_id
WHERE e2.last_name = 'Zlotkey' AND e1.last_name != 'Zlotkey';

--question 2
SELECT employee_id, last_name, salary FROM employees
WHERE salary >
(SELECT AVG(salary) FROM employees)
ORDER BY salary ASC;

--question 3
SELECT employee_id, last_name FROM employees
WHERE department_id IN
(SELECT department_id FROM employees WHERE last_name LIKE '%u%');

SELECT DISTINCT e1.employee_id, e1.last_name FROM employees e1
JOIN employees e2 on e1.department_id = e2.department_id
WHERE e2.last_name LIKE '%u%';

--question 4
SELECT last_name, e.department_id, job_id FROM employees e
JOIN departments d ON e.department_id = d.department_id
WHERE d.location_id = 1700;

--Bai giao them tren lop
SELECT last_name, e.department_id, job_id FROM employees e
JOIN departments d ON e.department_id = d.department_id
JOIN locations l ON d.location_id = l.location_id
WHERE l.city = 'Seattle';

--lay ra tat ca cac employee id va department name cua employee day
SELECT e.employee_id, d.department_name FROM employees e
LEFT JOIN departments d ON e.department_id = d.department_id;

--hien thi cac nhan vien co department name = 'Finance' va cac nhan vien co location_id 1700
SELECT e.employee_id FROM employees e
JOIN departments d ON e.department_id = d.department_id
WHERE d.department_name = 'Finance' OR d.location_id = 1700;

SELECT e.employee_id FROM employees e
JOIN departments d ON e.department_id = d.department_id WHERE d.department_name = 'Finance'
UNION ALL
SELECT e.employee_id FROM employees e
JOIN departments d ON e.department_id = d.department_id WHERE d.location_id = 1700;

--question 5
SELECT last_name, salary FROM employees
WHERE manager_id IN (
SELECT employee_id FROM employees WHERE last_name = 'King');

SELECT e1.last_name, e1.salary FROM employees e1
JOIN employees e2 on e1.manager_id = e2.employee_id
WHERE e2.last_name = 'King';

--question 6
SELECT department_id, last_name, job_id FROM employees
WHERE department_id IN (
SELECT department_id FROM departments WHERE department_name = 'Executive');

SELECT e.department_id, e.last_name, e.job_id FROM employees e
JOIN departments d ON e.department_id = d.department_id
WHERE d.department_name = 'Executive';

--question 7
--Trong trường hợp gây confused như câu 7 thì phải Q&A là who and who hay who earn and work?
SELECT employee_id, last_name, salary FROM employees
WHERE salary >
(SELECT AVG(salary) FROM employees)
OR department_id IN
(SELECT department_id FROM employees WHERE last_name LIKE '%u%');

SELECT employee_id, last_name, salary FROM employees
WHERE salary >
(SELECT AVG(salary) FROM employees)
UNION
SELECT employee_id, last_name, salary FROM employees
WHERE department_id IN
(SELECT department_id FROM employees WHERE last_name LIKE '%u%')

--contains only 1 letter "u"
SELECT employee_id, last_name, salary FROM employees
WHERE salary >
(SELECT AVG(salary) FROM employees)
UNION
SELECT employee_id, last_name, salary FROM employees
WHERE department_id IN
(SELECT department_id FROM employees WHERE last_name LIKE '%u%' and last_name NOT LIKE '%u%u%')

--question 8
SELECT ROUND(MAX(salary),0) 'Maximum',
ROUND(MIN(salary),0) 'Minimum',
ROUND(SUM(salary),0) 'Sum',
ROUND(AVG(salary),0) 'Average'
FROM employees;

SELECT CAST(MAX(salary) AS numeric(10,0)) 'Maximum',  
CAST(MIN(salary) AS numeric(10,0)) 'Minimim',
CAST(SUM(salary) AS numeric(10,0)) 'Sum',
CAST(AVG(salary) AS numeric(10,0)) 'Average'
FROM employees

--question 9
SELECT UPPER(LEFT(last_name, 1)) + SUBSTRING(LOWER(last_name), 2, LEN(last_name)) AS "Name", LEN(last_name) AS "Length of Last Name"
FROM employees
WHERE last_name LIKE 'J%' OR last_name LIKE 'A%' OR last_name LIKE 'M%'
ORDER BY last_name;

SELECT UPPER(LEFT(last_name, 1)) + LOWER(RIGHT(last_name, LEN(last_name) - 1)) AS "Name", LEN(last_name) AS "Length of Last Name"
FROM employees
WHERE last_name LIKE 'J%' OR last_name LIKE 'A%' OR last_name LIKE 'M%'
ORDER BY last_name;

--cách đúng để không bỏ sót data
SELECT UPPER(LEFT(last_name, 1)) + LOWER(RIGHT(last_name, LEN(last_name) - 1)) AS "Name", LEN(last_name) AS "Length of Last Name"
FROM employees
WHERE UPPER(SUBSTRING(last_name,1,1)) IN ('J','A','M')
ORDER BY last_name;

--question 10
SELECT employee_id, last_name, salary, ROUND(salary*(1+15.5/100), 0) AS "New Salary"
FROM employees;

SELECT employee_id, last_name, salary, CAST(salary*(1+15.5/100) AS numeric (10,0)) AS "New Salary"
FROM employees;

--SELECT CAST(1234.056 AS numeric(10,1)) => numeric ở đây vừa định dạng số vừa làm tròn

--question 11
--Mục đích của câu này là muốn lưu ý không được gộp các trường khác nhau mà phải đảm bảo trường nào vẫn là trường đấy về mặt ý nghĩa
SELECT last_name, department_id, CAST(null AS varchar) --AS department_name
FROM employees 
UNION 
SELECT CAST(null AS varchar), department_id, department_name
FROM departments;

SELECT last_name, department_id, null AS department_name
FROM employees 
UNION 
SELECT null, department_id, department_name
FROM departments;

--question 12
SELECT e.employee_id, e.first_name, e.last_name FROM employees e
JOIN employees m ON e.manager_id = m.employee_id
WHERE e.hire_date > m.hire_date
UNION 
SELECT e.employee_id, e.first_name, e.last_name FROM employees e
JOIN departments d ON e.department_id = d.department_id
JOIN locations l ON d.location_id = l.location_id
WHERE city = 'Toronto';
