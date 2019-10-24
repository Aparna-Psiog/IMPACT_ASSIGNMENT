-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2019-10-24 10:08:21.335

-- tables
-- Table: Admin
CREATE TABLE Admin (
    AdminID int NOT NULL,
    Name varchar(50) NOT NULL,
    Age int NOT NULL,
    Contact varchar(100) NOT NULL,
    EmailID varchar(100) NOT NULL,
    Password varchar(100) NOT NULL,
    CONSTRAINT Admin_pk PRIMARY KEY (AdminID)
);

-- Table: AdminCourses
CREATE TABLE AdminCourses (
    AdminCoursesID int NOT NULL,
    Courses_CourseID int NOT NULL,
    Admin_AdminID int NOT NULL,
    CONSTRAINT AdminCourses_pk PRIMARY KEY (AdminCoursesID)
);

-- Table: Attendance
CREATE TABLE Attendance (
    AttenID int NOT NULL,
    Percentage varchar(100) NOT NULL,
    CONSTRAINT Attendance_pk PRIMARY KEY (AttenID)
);

-- Table: Courses
CREATE TABLE Courses (
    CourseID int NOT NULL,
    CourseName varchar(100) NOT NULL,
    Coursecode varchar(100) NOT NULL,
    CONSTRAINT Courses_pk PRIMARY KEY (CourseID)
);

-- Table: Department
CREATE TABLE Department (
    DeptName varchar(100) NOT NULL,
    DeptCode varchar(100) NOT NULL,
    DeptID int NOT NULL,
    CONSTRAINT Department_pk PRIMARY KEY (DeptID)
);

-- Table: DepartmentCourses
CREATE TABLE DepartmentCourses (
    DeptCoursesID int NOT NULL,
    Department_DeptID int NOT NULL,
    Courses_CourseID int NOT NULL,
    CONSTRAINT DepartmentCourses_pk PRIMARY KEY (DeptCoursesID)
);

-- Table: DepartmentFaculty
CREATE TABLE DepartmentFaculty (
    DeptFacultyID int NOT NULL,
    Faculty_FacultyID int NOT NULL,
    Department_DeptID int NOT NULL,
    CONSTRAINT DepartmentFaculty_pk PRIMARY KEY (DeptFacultyID)
);

-- Table: DepartmentSection
CREATE TABLE DepartmentSection (
    Section_SectionID int NOT NULL,
    DeptSectionID int NOT NULL,
    Department_DeptID int NOT NULL,
    CONSTRAINT DepartmentSection_pk PRIMARY KEY (DeptSectionID)
);

-- Table: Exam
CREATE TABLE Exam (
    ExamID int NOT NULL,
    Marks varchar(100) NOT NULL,
    Subjectname varchar(100) NOT NULL,
    Exam_type_ExamtypeID int NOT NULL,
    CONSTRAINT Exam_pk PRIMARY KEY (ExamID)
);

-- Table: Exam_type
CREATE TABLE Exam_type (
    ExamtypeID int NOT NULL,
    Examtype varchar(100) NOT NULL,
    CONSTRAINT Exam_type_pk PRIMARY KEY (ExamtypeID)
);

-- Table: Faculty
CREATE TABLE Faculty (
    FacultyID int NOT NULL,
    Facultyname int NOT NULL,
    Age int NOT NULL,
    Salary varchar(100) NOT NULL,
    Contact varchar(100) NOT NULL,
    Email varchar(100) NOT NULL,
    CONSTRAINT Faculty_pk PRIMARY KEY (FacultyID)
);

-- Table: Fee_type
CREATE TABLE Fee_type (
    TypeID int NOT NULL,
    Feetype varchar(100) NOT NULL,
    CONSTRAINT Fee_type_pk PRIMARY KEY (TypeID)
);

-- Table: Fees
CREATE TABLE Fees (
    FeeID int NOT NULL,
    ReceiptNo int NOT NULL,
    Date_of_receipt date NOT NULL,
    Fee_type_TypeID int NOT NULL,
    CONSTRAINT Fees_pk PRIMARY KEY (FeeID)
);

-- Table: Section
CREATE TABLE Section (
    SectionID int NOT NULL,
    SectionName varchar(100) NOT NULL,
    CONSTRAINT Section_pk PRIMARY KEY (SectionID)
);

-- Table: Student
CREATE TABLE Student (
    ID int NOT NULL,
    Name varchar(40) NOT NULL,
    Age int NOT NULL,
    BirthDate date NOT NULL,
    Address varchar(100) NOT NULL,
    Contact varchar(50) NOT NULL,
    Hobbies varchar(100) NOT NULL,
    CONSTRAINT Student_pk PRIMARY KEY (ID)
);

-- Table: StudentAttendance
CREATE TABLE StudentAttendance (
    StudAttenID int NOT NULL,
    Student_ID int NOT NULL,
    Attendance_AttenID int NOT NULL,
    CONSTRAINT StudentAttendance_pk PRIMARY KEY (StudAttenID)
);

-- Table: StudentDepartment
CREATE TABLE StudentDepartment (
    StudDeptID int NOT NULL,
    Department_DeptID int NOT NULL,
    Student_ID int NOT NULL,
    CONSTRAINT StudentDepartment_pk PRIMARY KEY (StudDeptID)
);

-- Table: StudentExam
CREATE TABLE StudentExam (
    StudExamID int NOT NULL,
    Student_ID int NOT NULL,
    Exam_ExamID int NOT NULL,
    DepartmentCourses_DeptCoursesID int NOT NULL,
    CONSTRAINT StudentExam_pk PRIMARY KEY (StudExamID)
);

-- Table: StudentFees
CREATE TABLE StudentFees (
    StudFeesID int NOT NULL,
    Student_ID int NOT NULL,
    Fees_FeeID int NOT NULL,
    CONSTRAINT StudentFees_pk PRIMARY KEY (StudFeesID)
);

-- Table: StudentSection
CREATE TABLE StudentSection (
    StudSectionID int NOT NULL,
    Student_ID int NOT NULL,
    Section_SectionID int NOT NULL,
    CONSTRAINT StudentSection_pk PRIMARY KEY (StudSectionID)
);

-- foreign keys
-- Reference: AdminCourses_Admin (table: AdminCourses)
ALTER TABLE AdminCourses ADD CONSTRAINT AdminCourses_Admin FOREIGN KEY AdminCourses_Admin (Admin_AdminID)
    REFERENCES Admin (AdminID);

-- Reference: AdminCourses_Courses (table: AdminCourses)
ALTER TABLE AdminCourses ADD CONSTRAINT AdminCourses_Courses FOREIGN KEY AdminCourses_Courses (Courses_CourseID)
    REFERENCES Courses (CourseID);

-- Reference: CoursesSection_Section (table: DepartmentSection)
ALTER TABLE DepartmentSection ADD CONSTRAINT CoursesSection_Section FOREIGN KEY CoursesSection_Section (Section_SectionID)
    REFERENCES Section (SectionID);

-- Reference: DepartmentCourses_Courses (table: DepartmentCourses)
ALTER TABLE DepartmentCourses ADD CONSTRAINT DepartmentCourses_Courses FOREIGN KEY DepartmentCourses_Courses (Courses_CourseID)
    REFERENCES Courses (CourseID);

-- Reference: DepartmentCourses_Department (table: DepartmentCourses)
ALTER TABLE DepartmentCourses ADD CONSTRAINT DepartmentCourses_Department FOREIGN KEY DepartmentCourses_Department (Department_DeptID)
    REFERENCES Department (DeptID);

-- Reference: DepartmentFaculty_Department (table: DepartmentFaculty)
ALTER TABLE DepartmentFaculty ADD CONSTRAINT DepartmentFaculty_Department FOREIGN KEY DepartmentFaculty_Department (Department_DeptID)
    REFERENCES Department (DeptID);

-- Reference: DepartmentFaculty_Faculty (table: DepartmentFaculty)
ALTER TABLE DepartmentFaculty ADD CONSTRAINT DepartmentFaculty_Faculty FOREIGN KEY DepartmentFaculty_Faculty (Faculty_FacultyID)
    REFERENCES Faculty (FacultyID);

-- Reference: DepartmentSection_Department (table: DepartmentSection)
ALTER TABLE DepartmentSection ADD CONSTRAINT DepartmentSection_Department FOREIGN KEY DepartmentSection_Department (Department_DeptID)
    REFERENCES Department (DeptID);

-- Reference: Exam_Exam_type (table: Exam)
ALTER TABLE Exam ADD CONSTRAINT Exam_Exam_type FOREIGN KEY Exam_Exam_type (Exam_type_ExamtypeID)
    REFERENCES Exam_type (ExamtypeID);

-- Reference: Fees_Fee_type (table: Fees)
ALTER TABLE Fees ADD CONSTRAINT Fees_Fee_type FOREIGN KEY Fees_Fee_type (Fee_type_TypeID)
    REFERENCES Fee_type (TypeID);

-- Reference: StudentAttendance_Attendance (table: StudentAttendance)
ALTER TABLE StudentAttendance ADD CONSTRAINT StudentAttendance_Attendance FOREIGN KEY StudentAttendance_Attendance (Attendance_AttenID)
    REFERENCES Attendance (AttenID);

-- Reference: StudentAttendance_Student (table: StudentAttendance)
ALTER TABLE StudentAttendance ADD CONSTRAINT StudentAttendance_Student FOREIGN KEY StudentAttendance_Student (Student_ID)
    REFERENCES Student (ID);

-- Reference: StudentDepartment_Department (table: StudentDepartment)
ALTER TABLE StudentDepartment ADD CONSTRAINT StudentDepartment_Department FOREIGN KEY StudentDepartment_Department (Department_DeptID)
    REFERENCES Department (DeptID);

-- Reference: StudentDepartment_Student (table: StudentDepartment)
ALTER TABLE StudentDepartment ADD CONSTRAINT StudentDepartment_Student FOREIGN KEY StudentDepartment_Student (Student_ID)
    REFERENCES Student (ID);

-- Reference: StudentExam_DepartmentCourses (table: StudentExam)
ALTER TABLE StudentExam ADD CONSTRAINT StudentExam_DepartmentCourses FOREIGN KEY StudentExam_DepartmentCourses (DepartmentCourses_DeptCoursesID)
    REFERENCES DepartmentCourses (DeptCoursesID);

-- Reference: StudentExam_Exam (table: StudentExam)
ALTER TABLE StudentExam ADD CONSTRAINT StudentExam_Exam FOREIGN KEY StudentExam_Exam (Exam_ExamID)
    REFERENCES Exam (ExamID);

-- Reference: StudentExam_Student (table: StudentExam)
ALTER TABLE StudentExam ADD CONSTRAINT StudentExam_Student FOREIGN KEY StudentExam_Student (Student_ID)
    REFERENCES Student (ID);

-- Reference: StudentFees_Fees (table: StudentFees)
ALTER TABLE StudentFees ADD CONSTRAINT StudentFees_Fees FOREIGN KEY StudentFees_Fees (Fees_FeeID)
    REFERENCES Fees (FeeID);

-- Reference: StudentFees_Student (table: StudentFees)
ALTER TABLE StudentFees ADD CONSTRAINT StudentFees_Student FOREIGN KEY StudentFees_Student (Student_ID)
    REFERENCES Student (ID);

-- Reference: StudentSection_Section (table: StudentSection)
ALTER TABLE StudentSection ADD CONSTRAINT StudentSection_Section FOREIGN KEY StudentSection_Section (Section_SectionID)
    REFERENCES Section (SectionID);

-- Reference: StudentSection_Student (table: StudentSection)
ALTER TABLE StudentSection ADD CONSTRAINT StudentSection_Student FOREIGN KEY StudentSection_Student (Student_ID)
    REFERENCES Student (ID);

-- End of file.

