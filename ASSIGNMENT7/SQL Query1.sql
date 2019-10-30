

-- tables
-- Table: Attendance
CREATE TABLE Attendance (
    AttendanceID int  NOT NULL,
    Date date  NOT NULL,
    Student_ID int  NOT NULL,
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
    CourseName varchar(100)  NOT NULL,
    Coursecode varchar(100)  NOT NULL,
    CONSTRAINT Courses_pk PRIMARY KEY  (CourseID)
);

-- Table: Department
CREATE TABLE Department (
    DeptName varchar(100)  NOT NULL,
    DeptCode varchar(100)  NOT NULL,
    DeptID int  NOT NULL,
    CONSTRAINT Department_pk PRIMARY KEY  (DeptID)
);

-- Table: DepartmentCourses
CREATE TABLE DepartmentCourses (
    DeptCoursesID int  NOT NULL,
    Department_DeptID int  NOT NULL,
    Courses_CourseID int  NOT NULL,
    CONSTRAINT DepartmentCourses_pk PRIMARY KEY  (DeptCoursesID)
);

-- Table: DepartmentFaculty
CREATE TABLE DepartmentFaculty (
    DeptFacultyID int  NOT NULL,
    Faculty_FacultyID int  NOT NULL,
    Department_DeptID int  NOT NULL,
    CONSTRAINT DepartmentFaculty_pk PRIMARY KEY  (DeptFacultyID)
);

-- Table: Faculty
CREATE TABLE Faculty (
    FacultyID int  NOT NULL,
    Facultyname int  NOT NULL,
    Age int  NOT NULL,
    Salary varchar(100)  NOT NULL,
    Contact varchar(100)  NOT NULL,
    Email varchar(100)  NOT NULL,
    CONSTRAINT Faculty_pk PRIMARY KEY  (FacultyID)
);

-- Table: Fee_type
CREATE TABLE Fee_type (
    TypeID int  NOT NULL,
    Feetype varchar(100)  NOT NULL,
    CONSTRAINT Fee_type_pk PRIMARY KEY  (TypeID)
);

-- Table: Fees
CREATE TABLE Fees (
    FeeID int  NOT NULL,
    ReceiptNo int  NOT NULL,
    Date_of_receipt date  NOT NULL,
    Fee_type_TypeID int  NOT NULL,
    CONSTRAINT Fees_pk PRIMARY KEY  (FeeID)
);

-- Table: Lecture
CREATE TABLE Lecture (
    LectureID int  NOT NULL,
    Start_time time  NOT NULL,
    End_time int  NOT NULL,
    Classroom_ClassID int  NOT NULL,
    DepartmentFaculty_DeptFacultyID int  NOT NULL,
    DepartmentCourses_DeptCoursesID int  NOT NULL,
    Attendance_AttendanceID int  NOT NULL,
    CONSTRAINT Lecture_pk PRIMARY KEY  (LectureID,End_time)
);

-- Table: Student
CREATE TABLE Student (
    ID int  NOT NULL,
    Name varchar(40)  NOT NULL,
    Age int  NOT NULL,
    BirthDate date  NOT NULL,
    Address varchar(100)  NOT NULL,
    Contact varchar(50)  NOT NULL,
    Hobbies varchar(100)  NOT NULL,
    CONSTRAINT Student_pk PRIMARY KEY  (ID)
);

-- Table: StudentDepartment
CREATE TABLE StudentDepartment (
    StudDeptID int  NOT NULL,
    Student_ID int  NOT NULL,
    Department_DeptID int  NOT NULL,
    CONSTRAINT StudentDepartment_pk PRIMARY KEY  (StudDeptID)
);

-- Table: StudentFees
CREATE TABLE StudentFees (
    StudFeesID int  NOT NULL,
    Student_ID int  NOT NULL,
    Fees_FeeID int  NOT NULL,
    CONSTRAINT StudentFees_pk PRIMARY KEY  (StudFeesID)
);

-- foreign keys
-- Reference: Attendance_Student (table: Attendance)
ALTER TABLE Attendance ADD CONSTRAINT Attendance_Student
    FOREIGN KEY (Student_ID)
    REFERENCES Student (ID);

-- Reference: DepartmentCourses_Courses (table: DepartmentCourses)
ALTER TABLE DepartmentCourses ADD CONSTRAINT DepartmentCourses_Courses
    FOREIGN KEY (Courses_CourseID)
    REFERENCES Courses (CourseID);

-- Reference: DepartmentCourses_Department (table: DepartmentCourses)
ALTER TABLE DepartmentCourses ADD CONSTRAINT DepartmentCourses_Department
    FOREIGN KEY (Department_DeptID)
    REFERENCES Department (DeptID);

-- Reference: DepartmentFaculty_Department (table: DepartmentFaculty)
ALTER TABLE DepartmentFaculty ADD CONSTRAINT DepartmentFaculty_Department
    FOREIGN KEY (Department_DeptID)
    REFERENCES Department (DeptID);

-- Reference: DepartmentFaculty_Faculty (table: DepartmentFaculty)
ALTER TABLE DepartmentFaculty ADD CONSTRAINT DepartmentFaculty_Faculty
    FOREIGN KEY (Faculty_FacultyID)
    REFERENCES Faculty (FacultyID);

-- Reference: Fees_Fee_type (table: Fees)
ALTER TABLE Fees ADD CONSTRAINT Fees_Fee_type
    FOREIGN KEY (Fee_type_TypeID)
    REFERENCES Fee_type (TypeID);

-- Reference: Lecture_Attendance (table: Lecture)
ALTER TABLE Lecture ADD CONSTRAINT Lecture_Attendance
    FOREIGN KEY (Attendance_AttendanceID)
    REFERENCES Attendance (AttendanceID);

-- Reference: Lecture_Classroom (table: Lecture)
ALTER TABLE Lecture ADD CONSTRAINT Lecture_Classroom
    FOREIGN KEY (Classroom_ClassID)
    REFERENCES Classroom (ClassID);

-- Reference: Lecture_DepartmentCourses (table: Lecture)
ALTER TABLE Lecture ADD CONSTRAINT Lecture_DepartmentCourses
    FOREIGN KEY (DepartmentCourses_DeptCoursesID)
    REFERENCES DepartmentCourses (DeptCoursesID);

-- Reference: Lecture_DepartmentFaculty (table: Lecture)
ALTER TABLE Lecture ADD CONSTRAINT Lecture_DepartmentFaculty
    FOREIGN KEY (DepartmentFaculty_DeptFacultyID)
    REFERENCES DepartmentFaculty (DeptFacultyID);

-- Reference: StudentDepartment_Department (table: StudentDepartment)
ALTER TABLE StudentDepartment ADD CONSTRAINT StudentDepartment_Department
    FOREIGN KEY (Department_DeptID)
    REFERENCES Department (DeptID);

-- Reference: StudentDepartment_Student (table: StudentDepartment)
ALTER TABLE StudentDepartment ADD CONSTRAINT StudentDepartment_Student
    FOREIGN KEY (Student_ID)
    REFERENCES Student (ID);

-- Reference: StudentFees_Fees (table: StudentFees)
ALTER TABLE StudentFees ADD CONSTRAINT StudentFees_Fees
    FOREIGN KEY (Fees_FeeID)
    REFERENCES Fees (FeeID);

-- Reference: StudentFees_Student (table: StudentFees)
ALTER TABLE StudentFees ADD CONSTRAINT StudentFees_Student
    FOREIGN KEY (Student_ID)
    REFERENCES Student (ID);

-- End of file.

