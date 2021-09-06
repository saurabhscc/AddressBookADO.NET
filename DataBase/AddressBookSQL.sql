Create Database AddressBookSystem

Use AddressBookSystem

Create Table AddressBook(
ContactId int identity(1,1) Primary Key,
FirstName varchar(20) not null,
LastName varchar(20) not null,
Address varchar(100) not null, 
City varchar(50) not null,
State varchar(200) not null,
Zip bigint not null ,
PhoneNumber bigint not null,3
Email varchar(50)not null
)

Select * From AddressBook

Insert into AddressBook (FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email) values('Shree', 'Patil', 'NMRoad', 'Nagpur', 'MH', '111111', '1111111111', 'shree@gmail.com')
Insert into AddressBook (FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email) values('Prem', 'Kumar', 'RMRoad', 'Nagpur', 'MH', '222222', '2222222222', 'prem@gmail.com')
Insert into AddressBook (FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email) values('Sonu', 'Nigam', 'kasara', 'Thane', 'MH', '333333', '3333333333', 'sonu@gmail.com')
Insert into AddressBook (FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email) values('Kumar', 'Sanu', 'Kailasha', 'Banglore', 'KA', '444444', '4444444444', 'kumar@gmail.com')
Insert into AddressBook (FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email) values('Jubin', 'Nautiyaal', 'Worli', 'Mumbai', 'MH', '555555', '5555555555', 'jubin@gmail.com')
Insert into AddressBook (FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email) values('Atif', 'Aslam', 'Bandra', 'Mumbai', 'MH', '666666', '6666666666', 'atif@gmail.com')

Select * From AddressBook
Update AddressBook Set Address='NewNagpur' Where FirstName='Shree'

Select * From AddressBook
Delete from AddressBook Where FirstName='Atif'

Select * From AddressBook
Select * From AddressBook Where City='Nagpur' or State='KA'

Select * From AddressBook

Select Count(City) as 'NumberOfContacts' from AddressBook Where City='Mumbai' Group by City

Select Count(State) as 'NumberOfContacts' from AddressBook Where State='MH' Group by State

Select * From AddressBook
Select * From AddressBook Where City='Nagpur' Order by FirstName ASC



Alter Table AddressBook 
Add AddressBookName varchar(50), AddressBookType varchar(50)
Update AddressBook set AddressBookName='Family AddressBook', AddressBookType='Family' Where FirstName='Shree'
Update AddressBook set AddressBookName='Family AddressBook', AddressBookType='Family' Where FirstName='Jubin'
Update AddressBook set AddressBookName='Friend AddressBook', AddressBookType='Friend' Where FirstName='Prem'
Update AddressBook set AddressBookName='Friend AddressBook', AddressBookType='Friend' Where FirstName='Sonu'
Update AddressBook set AddressBookName='Professional AddressBook', AddressBookType='Professional' Where FirstName='Kumar'

Select * From AddressBook
Select Count(AddressBookType)As 'NumberOfContacts' From AddressBook Where AddressBookType='Friend'

Insert into AddressBook values ('Vishal', 'Sonawane', 'kasarvadavali', 'Thane', 'MH', '333333', '3333333330', 'vs@gmail.com', 'Family AddressBook', 'Family'),
('Vishal', 'Sonawane', 'kasarvadavali', 'Thane', 'MH', '333333', '3333333330', 'vs@gmail.com', 'Friend AddressBook', 'Friend')

Use AddressBookSystem
Create Table Address
(
AddressId int not null Identity(1,1) Primary key,
Address varchar(200) not null,
City varchar(50) not null,
State varchar(50) not null,
Zip bigint not null
)
Select * From Address;
Insert Into Address values
('NMRoad', 'Nagpur', 'MH', '111111'),
('RMRoad', 'Nagpur', 'MH', '222222'),
('kasara', 'Thane', 'MH','333333'),
('Kailasha','Banglore', 'KA','444444'),
('Worli', 'Mumbai', 'MH','555555')

Select * From Address;


Create Table ContactType
(
ContactTypeId int not null Identity(1,1) Primary key,
ContactTypeName varchar(100) not null
)
select * from ContactType;
Insert Into ContactType values
('Family'),
('Friends'),
('Profession')

select * from ContactType;

Create Table Contact
(
ContactId int not null Identity(1,1) primary key,
FirstName varchar(30) not null,
LastName varchar(30) not null,
PhoneNumber bigint not null,
Email varchar(100) not null,
AddressId int not null Foreign Key References Address(AddressId),
ContactTypeId int not null Foreign key References ContactType(ContactTypeId)
)
Select * From Contact

Insert Into Contact values
('Shree', 'Patil','1111111111','shree@gmail.com','1','1'),
('Prem', 'Kumar','2222222222','prem@gmail.com','2','2'),
('Sonu', 'Nigam','3333333333','sonu@gmail,com','3','2'),
('Kumar', 'Sanu','4444444444','kumar@gmail,com','4','3'),
('Jubin', 'Nautiyaal','5555555555','jubin@gmail,com','5','1')

Select * From Contact

Select * From Contact c, Address a, ContactType ct
Where c.AddressId=a.AddressId And c.ContactTypeId=ct.ContactTypeId

/*UC13*-Retrive All queries UC6,UC7,UC8,UC10 */
 /*UC6*/
Select * From Contact
Join Address                                                         
on Contact.AddressId=Address.AddressId
Where City='Nagpur' or State='KA'

/*UC7*/
Select Count(FirstName) as 'NumberOfContacts' from Contact
Join Address 
on Contact.AddressId=Address.AddressId 
Where City='Mumbai' Group by City

Select Count(FirstName) as 'NumberOfContacts' from Contact
Join Address 
on Contact.AddressId=Address.AddressId
Where State='MH' Group by State

/*UC8*/
Select * From Contact 
Join Address 
on Contact.AddressId=Address.AddressId                                 
Where City='Nagpur' Order by FirstName ASC

/*UC10*/
Select Count(FirstName) as 'NumberOfContacts' from Contact
Join ContactType 
on Contact.ContactTypeId=ContactType.ContactTypeId                    
Where ContactTypeName='Friends' Group by ContactTypeName