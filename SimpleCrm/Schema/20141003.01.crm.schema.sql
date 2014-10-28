/* 
search regex pattern: public\s[\w\?]*\s(\w*)\s.*
*/

CREATE TABLE [User] (
	UserId Text(50) primary key,
	UserName Text(50),
	Password Text(50) not null,
	RoleList Text(50),
	Status Text(10),
	VersionNo Integer,
	CreateTime Text(30) not null,
	UpdatedBy Text(50) not null,
	UpdateTime Text(30) not null
);

CREATE TABLE SystemParamerer (
	Code Text(50) primary key,
	Config Text,
	VersionNo Integer,
	CreateTime Text(30) not null,
	UpdatedBy Text(50) not null,
	UpdateTime Text(30) not null
);


CREATE TABLE RefNo 
(
	code text(50) primary key,
	seq integer
);

Create Table Customer
(
	CustomerId integer primary key autoincrement,
	CustomerName Text(50) not null,
	IdType Text(30),
	IdCardNo Text(30),
	Gender Text(10),
	Birthday Text(30),
	Unit Text(100),
	Position Text(50),
	HouseInfo Text(4000),
	FamilyInfo Text(4000),
	IncomingInfo Text(4000),
	CarInfo Text(4000),
	OtherInfo Text(4000),
	Status Text(50),
	CustomerClass Text(50),
	Phase Text(20),
	CustomerSource Text(50),
	Introducer Text(50),
	VersionNo Integer,
	CreateTime Text(30) not null,
	UpdatedBy Text(50) not null,
	UpdateTime Text(30) not null
)
;

CREATE TABLE CustomerRelation
(
	CustomerRelationId integer primary key autoincrement,
    BaseCustomerId integer not null,
	AgainstCustomerId integer not null,
	Relation text(50),
	VersionNo Integer,
	CreateTime Text(30) not null,
	UpdatedBy Text(50) not null,
	UpdateTime Text(30) not null,
	CONSTRAINT "CustomerRelation_Base_Customer_FK" FOREIGN KEY (BaseCustomerId) REFERENCES "Customer" ("CustomerId")
	CONSTRAINT "CustomerRelation_Against_Customer_FK" FOREIGN KEY (AgainstCustomerId) REFERENCES "Customer" ("CustomerId")
);

create index CustomerRelation_Customer_IDX on CustomerRelation(BaseCustomerId, AgainstCustomerId);

Create Table FollowUpRecord
(
	FollowUpRecordId  integer primary key autoincrement,
	CustomerId integer,
	FollowDate Text(30),
	Content Text(4000),
	NextFollowUpDate Text(30),
	IntentPhase Text(20),
	InputDate Text(30),
	InputtedBy Text(50),
	FollowedBy Text(50),
	VersionNo Integer,
	CreateTime Text(30) not null,
	UpdatedBy Text(50) not null,
	UpdateTime Text(30) not null,
	CONSTRAINT "FollowUpRecord_Customer_FK" FOREIGN KEY ("CustomerId") REFERENCES "Customer" ("CustomerId")
)
;

Create Table ContactInfo
(
	ContactInfoId integer primary key autoincrement,
	CustomerId integer,
	ContactType Text(50),
	ContactMethod Text(400),
	IsActive integer,
	Remark Text(300),
	VersionNo Integer,
	CreateTime Text(30) not null,
	UpdatedBy Text(50) not null,
	UpdateTime Text(30) not null,
	CONSTRAINT "ContactInfo_Customer_FK" FOREIGN KEY ("CustomerId") REFERENCES "Customer" ("CustomerId")
)
;

Create Table InsurancePolicy
(
	InsurancePolicyId integer primary key autoincrement,
	CustomerId integer,
	InsurancePolicyNo Text(100),
	EffectiveDate Text(30),
	InsuredYear integer,
	Category Text(20),
	Premium Real,
	Status Text(50),
	PrimaryIpName Text(100),
	PrimaryIpInfo Text(4000),
	SecondaryIPName Text(200),
	SecondaryIpInfo Text(4000),
	Remark Text(4000),
	VersionNo Integer,
	CreateTime Text(30) not null,
	UpdatedBy Text(50) not null,
	UpdateTime Text(30) not null,
	CONSTRAINT "InsurancePolicy_Customer_FK" FOREIGN KEY ("CustomerId") REFERENCES "Customer" ("CustomerId")
)
;

Create Table InsurancePolicyCustomer
(
	IPCId integer primary key autoincrement,
	IPId integer,
	CustomerId integer,
	Role Text(50),
	Relation Text(50),
	VersionNo Integer,
	CreateTime Text(30) not null,
	UpdatedBy Text(50) not null,
	UpdateTime Text(30) not null,
	CONSTRAINT "InsurancePolicyCustomer_InsurancePolicy_FK" FOREIGN KEY ("IPId") REFERENCES "InsurancePolicy" ("InsurancePolicyId"),
	CONSTRAINT "InsurancePolicyCustomer_Customer_FK" FOREIGN KEY ("CustomerId") REFERENCES "Customer" ("CustomerId")
)
;

Create Table Lov
(
	LovId integer primary key autoincrement,
	LovType Text(50),
	Seq Integer,
	Code Text(50),
	Name Text(100),
	ParentId integer,
	Owner Text(10),
	Attribute1 Text(50),
	Attribute2 Text(50),
	Attribute3 Text(50),
	Attribute4 Text(50),
	VersionNo Integer,
	CreateTime Text(30) not null,
	UpdatedBy Text(50) not null,
	UpdateTime Text(30) not null
)
;

CREATE TABLE AppointmentInfo (
	AppointmentInfoId integer primary key autoincrement,
	Category Text(50) not null,
	CustomerId integer,
	StartTime Text(30) not null,
	EndTime Text(30) not null,
	Subject Text(30) not null,
	Content Text(30),
	CategoryColor Text(50),
	TimerMarker Text(50),
	Owner Text(50) not null,
	VersionNo Integer,
	CreateTime Text(30) not null,
	UpdatedBy Text(50) not null,
	UpdateTime Text(30) not null
);

create index AppointmentInfoOwnerDateIDX on AppointmentInfo(owner, StartTime, EndTime);

CREATE TABLE PendingItem (
	PendingItemId integer primary key autoincrement,
	Category Text(50) not null,
	RefId integer not null,
	ActionDate Text(30) not null,
	HandleResult Text(30),
	HandleDate Text(30),
	Remark Text(400),
	VersionNo Integer,
	CreateTime Text(30) not null,
	UpdatedBy Text(50) not null,
	UpdateTime Text(30) not null
);

create index PendingItemCategoryRefIdIDX on PendingItem(Category, RefId);