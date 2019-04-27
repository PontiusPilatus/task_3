DROP TABLE IF EXISTS module_task_table;

CREATE TABLE module_task_table (
   id SERIAL primary key,
   name varchar(50) unique not null,
   hours real not null
);

INSERT INTO module_task_table (name, hours)
VALUES ('Linear algebra', 200.2), ('Mathematical analysis', 200);

SELECT * FROM module_task_table;