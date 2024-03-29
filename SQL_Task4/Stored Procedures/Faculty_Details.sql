--Display faculty details respect to a department course id

USE [CollegeDatabase]
GO
/****** Object:  StoredProcedure [dbo].[Faculty_Details]    Script Date: 04-11-2019 17:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Faculty_Details]  @DeptCoursesID int
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select Faculty.FacultyID,Faculty.Facultyname,Faculty.BirthDate,Faculty.Gender from Faculty
	join FacultyCourses on Faculty.FacultyID=FacultyCourses.FacultyID
	join DepartmentCourses on DepartmentCourses.DeptCoursesID=FacultyCourses.DeptCoursesID
	where  DepartmentCourses.DeptCoursesID=@DeptCoursesID;
END
