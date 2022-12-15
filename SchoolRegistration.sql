Create Table TblSchoolRegistration
(
SchoolID int Primary Key Identity(1,1),
SchoolName Varchar(100),
SchoolType Varchar(50),
SchoolLevel Varchar(50),
SchoolPhoto Varchar(Max),
StateID int ,
DistrictID int
);


Create Table TblState
(
StateID int Primary Key Identity(1,1),
StateName Varchar(50)
);

Create Table TblDistrict
(
DistrictID int Primary Key Identity(1,1),
StateID int,
DistrictName Varchar(50)
);


Create Procedure SP_SchoolRegistration
(
@SchoolID int = 0,
@SchoolName Varchar(100) = null,
@SchoolType Varchar(50) = null,
@SchoolLevel Varchar(50) = null,
@SchoolPhoto Varchar(Max) = null,
@StateID int = 0,
@DistrictID int = 0,
@Action varchar(50)
)
As
Begin
If(@Action='FillState')
Select * From TblState
Else if(@Action='FillDistrict')
Select * From TblDistrict Where StateID=@StateID
Else if(@Action='FillTable')
Select A.*,B.StateName,C.DistrictName From TblSchoolRegistration A,TblState B, TblDistrict C Where C.StateID=B.StateID
Else if(@Action='SelectOne')
Select * From TblSchoolRegistration Where SchoolID=@SchoolID
Else if(@Action='InsertOrUpdate')
Begin
If(@SchoolID=0)
insert into TblSchoolRegistration values(@StateID,@DistrictID,@SchoolName,@SchoolType,@SchoolLevel,@SchoolPhoto)
Else
Update TblSchoolRegistration set 
StateID=@StateID,DistrictID=@DistrictID,SchoolName=@SchoolName,SchoolType=@SchoolType,SchoolLevel=@SchoolLevel,SchoolPhoto=@SchoolPhoto Where SchoolID=@SchoolID
End
Else if(@Action='Delete')
Delete From TblSchoolRegistration Where SchoolID=@SchoolID
End