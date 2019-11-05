


SELECT RollNo from Attendance where LectureID=14;

--Displaying the roll number of students who attended the lecture on tuesday and thursday
Create View [Student_Rollno] as
SELECT RollNo from Attendance
where LectureID IN (Select LectureID from Lecture where Day='Monday' OR Day='Thursday');

--Subqueries
--Retrieving the name of students who attended the lecture on wednesday and thursday
create View [Student_names] as
SELECT Name from Student,Attendance 
where Attendance.RollNo=Student.RollNo AND LectureID 
IN (Select LectureID from Lecture where Day='Wednesday' OR Day='Thursday');


--displaying the number of students who attended the lecture on monday and friday
SELECT COUNT(RollNo) from Attendance where LectureID IN 
(Select LectureID from Lecture where Day='Monday' or Day='Tuesday');



--Joins
--Displaying the course name belonging to department computer science
SELECT CourseName from Courses,DepartmentCourses
where DepartmentCourses.CourseID=Courses.CourseID AND DeptID=101 ORDER BY CourseName DESC;

