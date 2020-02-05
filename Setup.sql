USE shoeshoe;


-- CREATE TABLE shoes (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     size FLOAT(3, 1) NOT NULL,
--     price DECIMAL(6, 2) NOT NULL,
--     PRIMARY KEY (id)
-- );




-- Student
-- CREATE TABLE students (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id)
-- );


-- -- Classroom
-- CREATE TABLE classrooms (
--     id int NOT NULL AUTO_INCREMENT,
--     subject VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id)
-- );



-- ClassroomStudent
-- CREATE TABLE classroomstudents (
--     id int NOT NULL AUTO_INCREMENT,
--     studentId int NOT NULL,
--     classroomId int NOT NULL,
--     PRIMARY KEY (id),

--     FOREIGN KEY (studentId)
--         REFERENCES students(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (classroomId)
--         REFERENCES classrooms(id)
--         ON DELETE CASCADE
-- )


-- CREATE TABLE assignments (
--     id int NOT NULL AUTO_INCREMENT,
--     studentId int NOT NULL,
--     classroomId int NOT NULL,
--     grade VARCHAR(2),
--     PRIMARY KEY (id),

--     FOREIGN KEY (studentId)
--         REFERENCES students(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (classroomId)
--         REFERENCES classrooms(id)
--         ON DELETE CASCADE
-- )



-- INSERT INTO students (name) VALUES ("TIM");
-- INSERT INTO students (name) VALUES ("JIM");
-- INSERT INTO students (name) VALUES ("KIM");
-- INSERT INTO classrooms (subject) VALUES ("MATH");
-- INSERT INTO classrooms (subject) VALUES ("SCI");
-- INSERT INTO classrooms (subject) VALUES ("P.E.");


-- INSERT INTO classroomstudents (studentId, classroomId) VALUES (1, 1);
-- INSERT INTO classroomstudents (studentId, classroomId) VALUES (1, 3);
-- INSERT INTO classroomstudents (studentId, classroomId) VALUES (2, 1);
-- INSERT INTO classroomstudents (studentId, classroomId) VALUES (2, 2);
-- INSERT INTO classroomstudents (studentId, classroomId) VALUES (2, 3);
-- INSERT INTO classroomstudents (studentId, classroomId) VALUES (3, 2);
-- INSERT INTO classroomstudents (studentId, classroomId) VALUES (3, 3);



-- JOIN TABLE QUERY (Classroom Id => students)
-- SELECT * FROM classroomstudents cs
-- INNER JOIN students s ON s.id = cs.studentId
-- WHERE classroomId = 3;


-- JOIN TABLE QUERY (student Id => classes)
SELECT * FROM classroomstudents cs
JOIN classrooms c ON c.id = cs.classroomId
WHERE studentId = 1;

