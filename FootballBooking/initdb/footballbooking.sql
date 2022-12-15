/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[Name]
      ,[Price]
      ,[StadiumOwnerId]
  FROM [FootballBooking].[dbo].[Stadium]



	-- innit data booker
    INSERT INTO [Booker](Id, Name, PhoneNumber) VALUES(NEWID(),'Trung', '0334517232');  

	-- innit data stadium owner
	INSERT INTO [StadiumOwner](Id, Name, PhoneNumber) VALUES(NEWID(),'A chu san cau Hoa Xuan','0334517232'); 
	INSERT INTO [StadiumOwner](Id, Name, PhoneNumber) VALUES(NEWID(),'A chu san Win Win','0334517233'); 
	INSERT INTO [StadiumOwner](Id, Name, PhoneNumber) VALUES(NEWID(),'A chu san ChuyenViet','0334517234'); 
	INSERT INTO [StadiumOwner](Id, Name, PhoneNumber) VALUES(NEWID(),'A chu san TuyenSon','0334517235'); 

	-- Innit data stadium
	INSERT INTO [Stadium](Id, Name, Price, StadiumOwnerId) 
		Select top (1) NEWID(),'Cau Hoa Xuan','300000', Id  as StadiumOwnerId
		from [StadiumOwner] where Name like '%Cau Hoa Xuan%'; 
	INSERT INTO [Stadium](Id, Name, Price, StadiumOwnerId) 
		Select top (1) NEWID(),'Cau Hoa Xuan','300000', Id  as StadiumOwnerId
		from [StadiumOwner] where Name like '%Cau Hoa Xuan%'; 
	INSERT INTO [Stadium](Id, Name, Price, StadiumOwnerId) 
		Select top (1) NEWID(),'Win Win','300000', Id  as StadiumOwnerId
		from [StadiumOwner] where Name like '%win win%'; 
	INSERT INTO [Stadium](Id, Name, Price, StadiumOwnerId) 
		Select top (1) NEWID(),'ChuyenViet','300000', Id  as StadiumOwnerId
		from [StadiumOwner] where Name like '%ChuyenViet%'; 
	INSERT INTO [Stadium](Id, Name, Price, StadiumOwnerId) 
		Select top (1) NEWID(),'TuyenSon','300000', Id  as StadiumOwnerId
		from [StadiumOwner] where Name like '%TuyenSon%';


	-- innit data booker address
	INSERT INTO [Address](Id, BookerId, City, Country, PostalCode, Street, Region) 
	VALUES(NEWID(),'9148204A-F0C5-4C21-8E52-34EE234E380A','Da Nang','Viet Nam','12345', '08 Khue My Dong 09', 'Not'); 

	-- innit data stadium address
		INSERT INTO [Address](Id, StadiumId, City, Country, PostalCode, Street, Region) 
	VALUES(NEWID(),'DA732FF7-FA1F-4653-A774-08DC0593A383','Da Nang','Viet Nam','12345', '123 win win', 'Not'); 
			INSERT INTO [Address](Id, StadiumId, City, Country, PostalCode, Street, Region) 
	VALUES(NEWID(),'DA732FF7-FA1F-4653-A774-08DC0593A383','Da Nang','Viet Nam','12345', '123 cau hoa xuan', 'Not'); 
				INSERT INTO [Address](Id, StadiumId, City, Country, PostalCode, Street, Region) 
	VALUES(NEWID(),'C2FB5C6C-538E-497B-BE3B-A101A66E0987','Da Nang','Viet Nam','12345', '123 tuyen son', 'Not'); 
				INSERT INTO [Address](Id, StadiumId, City, Country, PostalCode, Street, Region) 
	VALUES(NEWID(),'8F0E010A-8F42-45C0-90F0-C8ADD6982916','Da Nang','Viet Nam','12345', '123 chuyen viet 1', 'Not'); 
		INSERT INTO [Address](Id, StadiumId, City, Country, PostalCode, Street, Region) 
	VALUES(NEWID(),'7563C133-F0CE-4F79-B106-121261844E65','Da Nang','Viet Nam','12345', '123 cau hoa xuan 1', 'Not'); 
	
	SELECT * FROM Booking


