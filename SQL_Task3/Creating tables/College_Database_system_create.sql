

-- tables
-- Table: Attendance
CREATE TABLE Attendance (
    AttendanceID int  NOT NULL,
    LectureID int  NOT NULL,
    RollNo int  NOT NULL,
    CONSTRAINT Attendance_pk PRIMARY KEY  (AttendanceID)
);

-- Table: Classroom
CREATE TABLE Classroom (
    ClassID int  NOT NULL,
    Capacity int  NOT NULL,
    CONSTRAINT Classroom_pk PRIMARY KEY  (ClassID)
);

-- Table: Courses
CREATE TABLE Courses (
    CourseID int  NOT NULL,
    CourseName nvarchar(max)  NOT NULL,
    CONSTRAINT Courses_pk PRIMARY KEY  (CourseID)
);

-- Table: Department
CREATE TABLE Department (
    DeptName nvarchar(max)  NOT NULL,
    DeptID int  NOT NULL,
    CONSTRAINT Department_pk PRIMARY KEY  (DeptID)
);

-- Table: DepartmentCourses
CREATE TABLE DepartmentCourses (
    DeptCoursesID int  NOT NULL,
    DeptID int  NOT NULL,
    CourseID int  NOT NULL,
    CONSTRAINT DepartmentCourses_pk PRIMARY KEY  (DeptCoursesID)
);

-- Table: Faculty
CREATE TABLE Faculty (
    FacultyID int  NOT NULL,
    Facultyname int  NOT NULL,
    BirthDate date  NOT NULL,
    Salary nvarchar(max)  NOT NULL,
    Contact nvarchar(max)  NOT NULL,
    Email nvarchar(max)  NOT NULL,
    Address nvarchar(max)  NOT NULL,
    Gender nvarchar(max)  NOT NULL,
    CONSTRAINT Faculty_pk PRIMARY KEY  (FacultyID)
);

-- Table: FacultyCourses
CREATE TABLE FacultyCourses (
    DeptFacultyID int  NOT NULL,
    FacultyID int  NOT NULL,
    DeptCoursesID int  NOT NULL,
    CONSTRAINT FacultyCourses_pk PRIMARY KEY  (DeptFacultyID)
);

-- Table: Lecture
CREATE TABLE Lecture (
    LectureID int  NOT NULL,
    Start_time time  NOT NULL,
    End_time int  NOT NULL,
    ClassID int  NOT NULL,
    Date date  NOT NULL,
    DeptFacultyID int  NOT NULL,
    Day nvarchar(max)  NOT NULL,
    CONSTRAINT Lecture_pk PRIMARY KEY  (LectureID)
);

-- Table: Student
CREATE TABLE Student (
    RollNo int  NOT NULL,
    Name nvarchar(max)  NOT NULL,
    BirthDate date  NOT NULL,
    Address nvarchar(max)  NOT NULL,
    Contact nvarchar(max)  NOT NULL,
    Gender nvarchar(max)  NOT NULL,
    Email nvarchar(max)  NOT NULL,
    Year int  NOT NULL,
    DeptID int  NOT NULL,
    CONSTRAINT Student_pk PRIMARY KEY  (RollNo)
);

-- foreign keys
-- Reference: Attendance_Lecture (table: Attendance)
ALTER TABLE Attendance ADD CONSTRAINT Attendance_Lecture
    FOREIGN KEY (LectureID)
    REFERENCES Lecture (LectureID);

-- Reference: Attendance_Student (table: Attendance)
ALTER TABLE Attendance ADD CONSTRAINT Attendance_Student
    FOREIGN KEY (RollNo)
    REFERENCES Student (RollNo);

-- Reference: DepartmentCourses_Courses (table: DepartmentCourses)
ALTER TABLE DepartmentCourses ADD CONSTRAINT DepartmentCourses_Courses
    FOREIGN KEY (CourseID)
    REFERENCES Courses (CourseID);

-- Reference: DepartmentCourses_Department (table: DepartmentCourses)
ALTER TABLE DepartmentCourses ADD CONSTRAINT DepartmentCourses_Department
    FOREIGN KEY (DeptID)
    REFERENCES Department (DeptID);

-- Reference: DepartmentFaculty_Faculty (table: FacultyCourses)
ALTER TABLE FacultyCourses ADD CONSTRAINT DepartmentFaculty_Faculty
    FOREIGN KEY (FacultyID)
    REFERENCES Faculty (FacultyID);

-- Reference: FacultyCourses_DepartmentCourses (table: FacultyCourses)
ALTER TABLE FacultyCourses ADD CONSTRAINT FacultyCourses_DepartmentCourses
    FOREIGN KEY (DeptCoursesID)
    REFERENCES DepartmentCourses (DeptCoursesID);

-- Reference: Lecture_Classroom (table: Lecture)
ALTER TABLE Lecture ADD CONSTRAINT Lecture_Classroom
    FOREIGN KEY (ClassID)
    REFERENCES Classroom (ClassID);

-- Reference: Lecture_FacultyCourses (table: Lecture)
ALTER TABLE Lecture ADD CONSTRAINT Lecture_FacultyCourses
    FOREIGN KEY (DeptFacultyID)
    REFERENCES FacultyCourses (DeptFacultyID);

-- Reference: Student_Department (table: Student)
ALTER TABLE Student ADD CONSTRAINT Student_Department
    FOREIGN KEY (DeptID)
    REFERENCES Department (DeptID);

-- End of file.

