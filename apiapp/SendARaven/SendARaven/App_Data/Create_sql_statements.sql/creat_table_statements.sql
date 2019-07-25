DROP TABLE developer;

create table developer (
  apiKey varchar(128),
  tenantId varchar(128),
  email varchar(100) NOT NULL,
  companyName varchar(50),
  tenantName varchar(50),
  UNIQUE (apiKey),
  UNIQUE (email),
  PRIMARY KEY (tenantId)
);

insert into developer VALUES('api_tenant1_id1','tenant1','tenat1@microsoft.com','T1 Company','T1 tenant')
insert into developer VALUES('api_tenant1_id2','tenant2','tenant2@microsoft.com','T2 Company','T2 tenant')

DROP TABLE user1;

DROP TABLE user1; 

create table user1 (
  userId varchar(128),
  tenantId varchar(128),
  attributes nvarchar(max),
  UNIQUE (tenantId,userId),
  PRIMARY KEY (userId)
);



DROP PROCEDURE InsertUser;

go
CREATE PROCEDURE InsertUser(@userId nvarchar(200),@tenantId nvarchar(200) , @json nvarchar(max))
AS BEGIN
    insert into user1(userId,tenantId, attributes)
    values(@userId,@tenantId, @json)
END


EXEC InsertUser 'user_3', 'tenant1', '{"city":"Bangalore","zipcode":"454446"}'; 
EXEC InsertUser 'user_4', 'tenant4', '{"city":"Dhar","zipcode":"454446"}' ;


select userId, JSON_VALUE(attributes, '$.city'), JSON_VALUE(attributes, '$.zipcode') as zipcode
from user1;

select * from user1 where JSON_VALUE(attributes, '$.zipcode') = 454446;

select * from user1 where JSON_VALUE(attributes, '$.city') = 'Dhar';




