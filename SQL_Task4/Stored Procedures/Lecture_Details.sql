USE [CollegeDatabase]
GO
/****** Object:  StoredProcedure [dbo].[Lecture_details]    Script Date: 04-11-2019 17:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Lecture_details]  @LectureID int
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select FacultyCourses.DeptCoursesID,Date,Lecture.Start_time,Lecture.End_time from FacultyCourses
	join Lecture on Lecture.DeptFacultyID=FacultyCourses.DeptFacultyID
	join DepartmentCourses on DepartmentCourses.DeptCoursesID=FacultyCourses.DeptCoursesID
	where Lecture.LectureID=@LectureID 
END
