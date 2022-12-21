Create Table TblSchoolRegistration
(
SchoolID int Primary Key Identity(1,1),
StateID int ,
DistrictID int,
SchoolName Varchar(100),
SchoolTypeID int,
SchoolLevel Varchar(50),
SchoolPhoto Varchar(Max)
);


Create Table TblState
(
StateID int Primary Key Identity(1,1),
StateName Varchar(50)
);



Insert Into TblState
Values('Odisha')

Insert Into TblState
Values('West Bengal')

Insert Into TblState
Values('Andra Pradesh')

Insert Into TblState
Values('Madhya Pradesh')

Insert Into TblState
Values('Bihar')

Create Table TblDistrict
(
DistrictID int Primary Key Identity(1,1),
StateID int,
DistrictName Varchar(50)
);



Insert Into TblDistrict
Values(1,'Cuttack')

Insert Into TblDistrict
Values(1,'Khudra')

Insert Into TblDistrict
Values(1,'Jajpur')

Insert Into TblDistrict
Values(2,'Hugil')

Insert Into TblDistrict
Values(2,'Malda')

Insert Into TblDistrict
Values(2,'Kolkata')

Insert Into TblDistrict
Values(3,'Guntur')

Insert Into TblDistrict
Values(3,'Vizag')

Insert Into TblDistrict
Values(3,'Araku')

Insert Into TblDistrict
Values(4,'Bhopal')

Insert Into TblDistrict
Values(4,'Umaria')

Insert Into TblDistrict
Values(5,'Chapra')

Insert Into TblDistrict
Values(5,'Arwal')

Insert Into TblDistrict
Values(5,'Bhojpur')

Insert Into TblDistrict
Values(5,'Nalanda')

Create Table SchoolType
(
SchoolTypeID int Primary Key Identity(1,1),
SchoolTypeName Varchar(50)
);

Insert into SchoolType Values('Goverment')
Insert into SchoolType Values('Private')



Alter Procedure SP_SchoolRegistration
(
@SchoolID int = 0,
@SchoolName Varchar(100) = null,
@SchoolTypeID int = 0,
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
Select A.SchoolID,B.StateName,C.DistrictName,A.SchoolName,D.SchoolTypeName,A.SchoolLevel,A.SchoolPhoto From TblSchoolRegistration A,TblState B, TblDistrict C, SchoolType D Where A.StateID=B.StateID and A.DistrictID=C.DistrictID and A.SchoolTypeID = D.SchoolTypeID
Else if(@Action='SelectOne')
Select * From TblSchoolRegistration Where SchoolID=@SchoolID
Else if(@Action='InsertOrUpdate')
Begin
If(@SchoolID=0)
insert into TblSchoolRegistration values(@StateID,@DistrictID,@SchoolName,@SchoolTypeID,@SchoolLevel,@SchoolPhoto)
Else
Update TblSchoolRegistration set 
StateID=@StateID,DistrictID=@DistrictID,SchoolName=@SchoolName,SchoolTypeID=@SchoolTypeID,SchoolLevel=@SchoolLevel,SchoolPhoto=@SchoolPhoto Where SchoolID=@SchoolID
End
Else if(@Action='Delete')
Delete From TblSchoolRegistration Where SchoolID=@SchoolID
End
