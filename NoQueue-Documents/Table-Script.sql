
Create Table CountryMaster  
(
	CountryId int primary key not null,
	CountryName nvarchar(50) not null,
	CountryCode nvarchar(20) not null,
	IsActive bit default 1
)
GO

Create Table StateMaster  
(
	StateId int primary key not null,
	CountryId int foreign key references CountryMaster(CountryId),
	StateName nvarchar(50) not null,
	StateCode nvarchar(20) not null,
	IsActive bit default 1
)

GO

Create Table DistrictMaster  
(
	DistrictId int primary key not null,
	StateId int foreign key references StateMaster(StateId),
	DistrictName nvarchar(50) not null,
	IsActive bit default 1
)

GO

Create Table CityMaster  
(
	CityId int primary key not null,
	DistrictId int foreign key references DistrictMaster(DistrictId),
	CityName nvarchar(50) not null,
	IsActive bit default 1
)

GO

Create Table StatusMaster   --// Cutomer, Admin, SuperAdmin, Account, Cashier, KitchenSupervisor, Steward, StewardSupervisor
(
	StatusId int primary key not null,
	Name nvarchar(50) not null,
	IsActive bit default 1
)
GO

Create Table ProfileMaster   --// Cutomer, Admin, SuperAdmin, Account, Cashier, KitchenSupervisor, Steward, StewardSupervisor
(
	ProfileId int primary key not null,
	ProfileName nvarchar(50) not null,
	ProfileCode nvarchar(20) not null,
	IsActive bit default 1
)
GO

Create Table CategoryMaster   --// Hotel, Restaurant, Take Away
(
	CategoryId int primary key not null,
	CategoryName nvarchar(50) not null,
	CategoryCode nvarchar(20) not null,
	IsActive bit default 1
)

GO

Create Table CompanyMaster
(
	CompanyId int identity(1,1) primary key not null,
	CategoryId int foreign key references CategoryMaster(CategoryId),
	CompanyName nvarchar(100) not null,
	Mobile nvarchar(30) not null,
	Phone nvarchar(30),
	Email nvarchar(100),
	ContactPerson nvarchar(100) not null,
	[Status] int foreign key references StatusMaster(StatusId),
	StatusUpdatedBy int,
	StatusUpdatedDate datetime,
	Remarks	nvarchar(500),
	IsActive bit default 1,
	CreatedBy int,
	CreatedDate datetime,
	ModifiedBy int,
	ModifiedDate datetime,
	IPAddress nvarchar(100),
	Browser nvarchar(100)

)

GO

Create Table Branch
(
	BranchId int identity(1,1) primary key not null,
	CompanyId int foreign key references CompanyMaster(CompanyId),
	BranchName nvarchar(100) not null,
	BranchCode nvarchar(100) not null, 
	Mobile nvarchar(30) not null,
	Phone nvarchar(30),
	Email nvarchar(100),
	ContactPerson nvarchar(100) not null,
	[Address] nvarchar(2000),
	CityId int foreign key references CityMaster(CityId),
	OtherCity nvarchar(200),
	DistrictId int foreign key references DistrictMaster(DistrictId),
	StateId int foreign key references StateMaster(StateId),
	CountryId int foreign key references CountryMaster(CountryId),
	PinCode int,
	Latitude nvarchar(20),
	Longtitude nvarchar(20),
	MapLocation	nvarchar(500),
	[Status] int foreign key references StatusMaster(StatusId),
	StatusUpdatedBy int,
	StatusUpdatedDate datetime,
	Remarks	nvarchar(500),
	IsPrimary bit default 0,
	IsActive bit default 1,
	CreatedBy int,
	CreatedDate datetime,
	ModifiedBy int,
	ModifiedDate datetime,
	IPAddress nvarchar(100),
	Browser nvarchar(100)

)

GO

CREATE TABLE PhotoCategoryMaster
(
	PhotoCategoryId int primary key not null,
	CategoryName	NVARCHAR(100) NOT NULL,
	IsActive		BIT DEFAULT 1
)

GO

Create Table BranchPhotos
(
	PhotoId int identity(1,1) primary key not null,
	BranchId int foreign key references Branch(BranchId),
	PhotoCategoryId int foreign key references PhotoCategoryMaster(PhotoCategoryId),
	Photo	nvarchar(100),
	Sequenct int,
	IsCoverPhoto bit default 0,
	[Description] nvarchar(500),
	IsActive bit default 1,
	CreatedBy int,
	CreatedDate datetime,
	ModifiedBy int,
	ModifiedDate datetime,
	IPAddress nvarchar(100),
	Browser nvarchar(100)
)

GO

Create Table BankDetails
(
	BankDetailId int identity(1,1) primary key not null,
	BranchId int foreign key references Branch(BranchId),
	BankName	nvarchar(100) not null,
	IFSCCode	nvarchar(20) not null,
	AccountNo	nvarchar(50) not null,
	AccountHolderName nvarchar(100) not null,
	BankBranch nvarchar(100),
	IsDefaultAccount bit default 0,
	IsVerified bit default 0,
	IsActive bit default 1,
	CreatedBy int,
	CreatedDate datetime,
	ModifiedBy int,
	ModifiedDate datetime,
	IPAddress nvarchar(100),
	Browser nvarchar(100)
)

GO

Create Table QRDetails
(
	QRDetailId int identity(1,1) primary key not null,
	BranchId int foreign key references Branch(BranchId),
	TableNo  int,
	QRCode	 nvarchar(500),
	IsActive bit default 1,
	CreatedBy int,
	CreatedDate datetime,
	ModifiedBy int,
	ModifiedDate datetime,
	IPAddress nvarchar(100),
	Browser nvarchar(100)
)

GO

Create Table FoodCategory
(
	FoodCategoryId int identity(1,1) primary key not null,
	BranchId int foreign key references Branch(BranchId),
	Name	nvarchar(50) not null,
	FoodCategoryImage nvarchar(100),
	IsActive bit default 1,
	CreatedBy int,
	CreatedDate datetime,
	ModifiedBy int,
	ModifiedDate datetime,
	IPAddress nvarchar(100),
	Browser nvarchar(100)
)

GO

Create Table FoodSubCategory
(
	FoodSubCategoryId int identity(1,1) primary key not null,
	FoodCategoryId int foreign key references FoodCategory(FoodCategoryId),
	Name	nvarchar(50) not null,
	FoodSubCategoryImage nvarchar(100),
	IsActive bit default 1,
	CreatedBy int,
	CreatedDate datetime,
	ModifiedBy int,
	ModifiedDate datetime,
	IPAddress nvarchar(100),
	Browser nvarchar(100)

)

GO

Create Table FoodItem
(
	FoodItemId int identity(1,1) primary key not null,
	BranchId int foreign key references Branch(BranchId),
	FoodCategoryId int foreign key references FoodCategory(FoodCategoryId),
	FoodSubCategoryId int foreign key references FoodSubCategory(FoodSubCategoryId),
	FoodName	nvarchar(100) not null,
	Price	money,
	FoodImage nvarchar(100),
	[Description] nvarchar(max),
	IsActive bit default 1,
	CreatedBy int,
	CreatedDate datetime,
	ModifiedBy int,
	ModifiedDate datetime,
	IPAddress nvarchar(100),
	Browser nvarchar(100)
)

GO

Create table Discount
(
	DiscountId int identity(1,1) primary key not null,
	BranchId int foreign key references Branch(BranchId),
	FoodItemId int foreign key references FoodItem(FoodItemId),
	FoodCategoryId int foreign key references FoodCategory(FoodCategoryId),
	FoodSubCategoryId int foreign key references FoodSubCategory(FoodSubCategoryId),
	AmountLimit money,
	PromoCode nvarchar(20),
	DiscountType nvarchar(10),
	[Value] money,
	MaxDiscountValue money,
	ValidFrom datetime,
	ValidTill datetime,
	IsActive bit default 1,
	CreatedBy int,
	CreatedDate datetime,
	ModifiedBy int,
	ModifiedDate datetime,
	IPAddress nvarchar(100),
	Browser nvarchar(100)
)



GO
Create Table UserMaster
(
	UserId int identity(1,1) primary key not null,
	BranchId int foreign key references Branch(BranchId),
	UserName nvarchar(50) not null,
	Mobile nvarchar(30) not null,
	Email nvarchar(100),
	[Pwd] nvarchar(500),
	IsActive bit default 1,
	CreatedBy int,
	CreatedDate datetime,
	ModifiedBy int,
	ModifiedDate datetime,
	IPAddress nvarchar(100),
	Browser nvarchar(100)
)
GO
Create Table UserProfileLink
(
	LinkId int identity(1,1) primary key not null,
	ProfileId int foreign key references ProfileMaster(ProfileId),
	UserId int foreign key references UserMaster(UserId),
	IsActive bit default 1,
	CreatedBy int,
	CreatedDate datetime,
	ModifiedBy int,
	ModifiedDate datetime,
	IPAddress nvarchar(100),
	Browser nvarchar(100)
)

GO

Create Table Customer
(
	CustomerId int identity(1,1) primary key not null,
	BranchId int foreign key references Branch(BranchId),
	Name	nvarchar(100),
	Mobile	nvarchar(20) not null,
	CreatedDate datetime,
	IPAddress nvarchar(100),
	Browser nvarchar(100),
	DeviceNo	nvarchar(100),
	IsActivated bit default 1
)

GO

Create Table Cart
(
	CartId int identity(1,1) primary key not null,
	CustomerId int foreign key references Customer(CustomerId),
	BranchId int foreign key references Branch(BranchId),
	Amount money,
	OtherCharge money,
	DicountAmount money,
	TaxDesc nvarchar(100),
	TaxRate money,
	TaxAmount money,
	PayAmount money,
	CreatedDate datetime ,
	IPAddress nvarchar(100),
	Browser nvarchar(100),
	Latitude	nvarchar(20),
	Longtitude	nvarchar(20)
)

GO

Create Table CartOtherCharges
(
	OtherChargesId int identity(1,1) primary key not null,
	CartId int foreign key references Cart(CartId),
	[Desc] nvarchar(100),
	Amount money,
	CreatedDate datetime ,
)

GO

Create Table CartItems
(
	CartItemId	int identity(1,1) primary key not null,
	CartId int foreign key references Cart(CartId),
	FoodItemId int foreign key references FoodItem(FoodItemId),
	Price money,
	Qty int,
	Amount money,
	CreatedDate datetime ,
)

GO

create table ErrorHandling
(
	Id int identity(1,1),
	[Message] nvarchar(max),
	[StackTrace] nvarchar(max),
	CreatedDate datetime
)