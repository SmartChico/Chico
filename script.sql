USE [master]
GO
/****** Object:  Database [chico]    Script Date: 12/7/2016 11:47:54 AM ******/
CREATE DATABASE [chico]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'chico', FILENAME = N'd:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\chico.mdf' , SIZE = 12288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'chico_log', FILENAME = N'd:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\chico_log.ldf' , SIZE = 24384KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [chico] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [chico].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [chico] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [chico] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [chico] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [chico] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [chico] SET ARITHABORT OFF 
GO
ALTER DATABASE [chico] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [chico] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [chico] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [chico] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [chico] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [chico] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [chico] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [chico] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [chico] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [chico] SET  DISABLE_BROKER 
GO
ALTER DATABASE [chico] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [chico] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [chico] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [chico] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [chico] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [chico] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [chico] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [chico] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [chico] SET  MULTI_USER 
GO
ALTER DATABASE [chico] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [chico] SET DB_CHAINING OFF 
GO
ALTER DATABASE [chico] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [chico] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [chico] SET DELAYED_DURABILITY = DISABLED 
GO
USE [chico]
GO
/****** Object:  Schema [Bid]    Script Date: 12/7/2016 11:47:54 AM ******/
CREATE SCHEMA [Bid]
GO
/****** Object:  Schema [Bond]    Script Date: 12/7/2016 11:47:54 AM ******/
CREATE SCHEMA [Bond]
GO
/****** Object:  Schema [Party]    Script Date: 12/7/2016 11:47:54 AM ******/
CREATE SCHEMA [Party]
GO
/****** Object:  Schema [Project]    Script Date: 12/7/2016 11:47:54 AM ******/
CREATE SCHEMA [Project]
GO
/****** Object:  Table [Bid].[Bid]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Bid].[Bid](
	[BidID] [int] IDENTITY(1,1) NOT NULL,
	[OrganizationID] [bigint] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[Summary] [nvarchar](max) NULL,
	[CostEstimate] [float] NULL,
	[Currency] [int] NULL,
	[DeliveryDate] [date] NULL,
	[role] [char](20) NOT NULL,
	[bidxml] [xml] NULL,
 CONSTRAINT [PK_Bid] PRIMARY KEY CLUSTERED 
(
	[BidID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Bond].[Bond]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Bond].[Bond](
	[BondRequester] [bigint] NOT NULL,
	[SuretyAgent] [bigint] NOT NULL,
	[SuretyUnderwriter] [bigint] NOT NULL,
	[SuretyProgramID] [int] NOT NULL,
	[DecisionStatus] [nchar](10) NOT NULL,
	[RequestDate] [date] NOT NULL,
 CONSTRAINT [PK_Bond] PRIMARY KEY CLUSTERED 
(
	[BondRequester] ASC,
	[SuretyAgent] ASC,
	[SuretyUnderwriter] ASC,
	[SuretyProgramID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Bond].[SuretyProgram]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Bond].[SuretyProgram](
	[SuretyProgramID] [int] NOT NULL,
	[CreatorID] [bigint] NOT NULL,
	[Value] [float] NULL,
	[CurrencyID] [int] NULL,
 CONSTRAINT [PK_SuretyProgram] PRIMARY KEY CLUSTERED 
(
	[SuretyProgramID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[partyID] [bigint] NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Currency]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currency](
	[CurrencyID] [int] NOT NULL,
	[CurrencyName] [nchar](20) NOT NULL,
	[Acronym] [nchar](10) NULL,
	[DollarConversionRate] [float] NOT NULL,
	[rowguid] [uniqueidentifier] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED 
(
	[CurrencyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EntityType]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntityType](
	[EntityTypeID] [int] NOT NULL,
	[Name] [nchar](1000) NOT NULL,
 CONSTRAINT [PK_OrgType] PRIMARY KEY CLUSTERED 
(
	[EntityTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NAICS]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NAICS](
	[TypeID] [int] NOT NULL,
	[Description] [char](200) NOT NULL,
 CONSTRAINT [PK_NAICS2] PRIMARY KEY CLUSTERED 
(
	[Description] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Party].[Address]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Party].[Address](
	[AddressID] [bigint] IDENTITY(1,1) NOT NULL,
	[Country] [nvarchar](1000) NOT NULL,
	[State] [nvarchar](1000) NULL,
	[City] [nvarchar](2000) NOT NULL,
	[Street] [nvarchar](1000) NULL,
	[Apt] [nvarchar](100) NULL,
	[Zip] [nchar](10) NULL,
	[PostlCode] [nchar](20) NULL,
	[GeographicalLocation] [geography] NULL,
	[WebAddress] [xml] NULL,
	[rowguid] [uniqueidentifier] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Party].[Certificate]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Party].[Certificate](
	[CertificateID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](2000) NOT NULL,
	[IssuingBodyID] [bigint] NOT NULL,
	[IssueDate] [date] NULL,
	[ExpirationDate] [date] NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Certificate] PRIMARY KEY CLUSTERED 
(
	[CertificateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Party].[Email]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Party].[Email](
	[EmailID] [bigint] IDENTITY(1,1) NOT NULL,
	[Email] [nchar](1000) NOT NULL,
	[rowguid] [uniqueidentifier] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Email] PRIMARY KEY CLUSTERED 
(
	[EmailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Party].[FinancialInfo]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Party].[FinancialInfo](
	[PartyID] [bigint] NOT NULL,
	[AccountingFirm] [bigint] NULL,
	[ChiefAccountant] [bigint] NULL,
	[AccountingSoftware] [nvarchar](1000) NULL,
	[EstimateSoftware] [nchar](10) NULL,
	[JobCostSoftware] [nchar](10) NULL,
	[FinancialStatementBasis] [nchar](10) NULL,
	[FinancialStatementIssuePeriod] [nchar](10) NULL,
	[BankID] [bigint] NOT NULL,
	[TaxID] [nchar](10) NULL,
	[SSN] [nchar](10) NULL,
	[LargestBondValue] [nchar](10) NULL,
	[PercentageSubcontracted] [nchar](10) NULL,
	[leasedEquipment] [nchar](10) NULL,
	[BankruptcyDescription] [nchar](10) NULL,
	[LargestBacklog] [nchar](10) NULL,
 CONSTRAINT [PK_FinancialInfo] PRIMARY KEY CLUSTERED 
(
	[PartyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Party].[License]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Party].[License](
	[LicenseID] [int] IDENTITY(1,1) NOT NULL,
	[Number] [varchar](200) NOT NULL,
	[Name] [nvarchar](400) NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[IssuingOrgID] [bigint] NULL,
 CONSTRAINT [PK_License] PRIMARY KEY CLUSTERED 
(
	[LicenseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Party].[Org_Person]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Party].[Org_Person](
	[PersonID] [bigint] NOT NULL,
	[OrgID] [bigint] NOT NULL,
	[OrgRoleID] [int] NOT NULL,
	[sharesOwned] [int] NULL,
	[AffiliationStartDate] [date] NOT NULL,
 CONSTRAINT [PK_Org_Person] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC,
	[OrgID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Party].[Organization]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Party].[Organization](
	[PartyID] [bigint] NOT NULL,
	[Name] [nvarchar](4000) NOT NULL,
	[EntityTypeID] [int] NOT NULL,
	[NAICSCode] [char](200) NULL,
	[RegisteredAgent] [bigint] NULL,
	[ActiveStatus] [bit] NOT NULL,
	[NumberOfEmployees] [int] NULL,
	[Purpose] [nvarchar](max) NULL,
	[EstablishmentDate] [date] NULL,
	[ChicoSignUpDate] [datetime] NULL,
	[IncludeInListing] [bit] NOT NULL,
	[rowguid] [uniqueidentifier] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED 
(
	[PartyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Party].[OrganizationRole]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Party].[OrganizationRole](
	[OrgRoleID] [int] NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_CompanyRole] PRIMARY KEY CLUSTERED 
(
	[OrgRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Party].[Party]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Party].[Party](
	[PartyID] [bigint] IDENTITY(1,1) NOT NULL,
	[rowguid] [uniqueidentifier] NOT NULL,
	[ModfiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Party] PRIMARY KEY CLUSTERED 
(
	[PartyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Party].[Party_Address]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Party].[Party_Address](
	[PartyID] [bigint] NOT NULL,
	[AddressID] [bigint] NOT NULL,
 CONSTRAINT [PK_Party_Address] PRIMARY KEY CLUSTERED 
(
	[PartyID] ASC,
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Party].[Party_Certificate]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Party].[Party_Certificate](
	[PartyID] [bigint] NOT NULL,
	[CertificateID] [int] NOT NULL,
	[Comments] [nvarchar](max) NULL,
 CONSTRAINT [PK_Party_Certificate] PRIMARY KEY CLUSTERED 
(
	[PartyID] ASC,
	[CertificateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Party].[Party_Email]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Party].[Party_Email](
	[PartyID] [bigint] NOT NULL,
	[EmailID] [bigint] NOT NULL,
 CONSTRAINT [PK_Party_Email] PRIMARY KEY CLUSTERED 
(
	[PartyID] ASC,
	[EmailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Party].[Party_License]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Party].[Party_License](
	[PartyID] [bigint] NOT NULL,
	[LicenseID] [int] NOT NULL,
	[Comments] [nvarchar](max) NULL,
 CONSTRAINT [PK_Party_License] PRIMARY KEY CLUSTERED 
(
	[PartyID] ASC,
	[LicenseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Party].[Party_Phone]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Party].[Party_Phone](
	[PartyID] [bigint] IDENTITY(1,1) NOT NULL,
	[PhoneID] [bigint] NOT NULL,
 CONSTRAINT [PK_Party_Phone] PRIMARY KEY CLUSTERED 
(
	[PartyID] ASC,
	[PhoneID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Party].[Person]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Party].[Person](
	[partyID] [bigint] NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[FirstName] [nvarchar](2000) NOT NULL,
	[MiddleName] [nvarchar](100) NULL,
	[LastName] [nvarchar](2000) NOT NULL,
	[DateOfBirth] [date] NULL,
	[SpouseName] [nvarchar](4000) NULL,
	[SpouseDateOfBirth] [date] NULL,
	[rowguid] [uniqueidentifier] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[partyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Party].[Phone]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Party].[Phone](
	[PhoneNumberID] [bigint] IDENTITY(1,1) NOT NULL,
	[PhoneNumberType] [nchar](10) NOT NULL,
	[PhoneNumber] [nchar](20) NOT NULL,
	[rowguid] [uniqueidentifier] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Phone] PRIMARY KEY CLUSTERED 
(
	[PhoneNumberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Project].[Event]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Project].[Event](
	[EventID] [bigint] NOT NULL,
	[Type] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[Duration]  AS (datediff(hour,[StartDate],coalesce([EndDate],[StartDate]))),
	[ProjectID] [int] NULL,
	[Comments] [nvarchar](max) NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Project].[Project]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Project].[Project](
	[ProjectID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](2000) NOT NULL,
	[CurrentMileStone] [int] NOT NULL,
	[Summary] [nvarchar](max) NULL,
	[Priority] [int] NULL,
	[TotalBudget] [float] NULL,
	[Currency] [int] NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Project].[Project_Party]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Project].[Project_Party](
	[ProjectID] [int] NOT NULL,
	[PartyID] [bigint] NOT NULL,
	[PartyRoleInProject] [int] NOT NULL,
	[AssignmentDate] [datetime] NOT NULL,
	[OverseeingPartyID] [bigint] NULL,
 CONSTRAINT [PK_Project_Party] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC,
	[PartyID] ASC,
	[PartyRoleInProject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Project].[ProjectEventType]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Project].[ProjectEventType](
	[EventTypeID] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_EventTypeID] PRIMARY KEY CLUSTERED 
(
	[EventTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Project].[Role]    Script Date: 12/7/2016 11:47:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Project].[Role](
	[RoleID] [int] NOT NULL,
	[Name] [nchar](500) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 12/7/2016 11:47:54 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 12/7/2016 11:47:54 AM ******/
CREATE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 12/7/2016 11:47:54 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 12/7/2016 11:47:54 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 12/7/2016 11:47:54 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [EmailIndex]    Script Date: 12/7/2016 11:47:54 AM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 12/7/2016 11:47:54 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Currency] ADD  CONSTRAINT [DF_Currency_rowguid]  DEFAULT (newid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[Currency] ADD  CONSTRAINT [DF_Currency_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [Party].[Address] ADD  CONSTRAINT [DF_Address_rowguid]  DEFAULT (newid()) FOR [rowguid]
GO
ALTER TABLE [Party].[Address] ADD  CONSTRAINT [DF_Address_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [Party].[Email] ADD  CONSTRAINT [DF_Email_rowguid]  DEFAULT (newid()) FOR [rowguid]
GO
ALTER TABLE [Party].[Email] ADD  CONSTRAINT [DF_Email_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [Party].[Organization] ADD  CONSTRAINT [DF_Organization_ActiveStatus]  DEFAULT ((0)) FOR [ActiveStatus]
GO
ALTER TABLE [Party].[Organization] ADD  CONSTRAINT [DF_Organization_ChicoSignUpDate]  DEFAULT (getdate()) FOR [ChicoSignUpDate]
GO
ALTER TABLE [Party].[Organization] ADD  CONSTRAINT [DF_Organization_IncludeInListing]  DEFAULT ((0)) FOR [IncludeInListing]
GO
ALTER TABLE [Party].[Organization] ADD  CONSTRAINT [DF_Organization_rowguid]  DEFAULT (newid()) FOR [rowguid]
GO
ALTER TABLE [Party].[Organization] ADD  CONSTRAINT [DF_Organization_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [Party].[Party] ADD  CONSTRAINT [DF_Party_rowguid]  DEFAULT (newid()) FOR [rowguid]
GO
ALTER TABLE [Party].[Party] ADD  CONSTRAINT [DF_Party_ModfiedDate]  DEFAULT (getdate()) FOR [ModfiedDate]
GO
ALTER TABLE [Party].[Person] ADD  CONSTRAINT [DF_Person_rowguid]  DEFAULT (newid()) FOR [rowguid]
GO
ALTER TABLE [Party].[Person] ADD  CONSTRAINT [DF_Person_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [Party].[Phone] ADD  CONSTRAINT [DF_Phone_rowguid]  DEFAULT (newid()) FOR [rowguid]
GO
ALTER TABLE [Party].[Phone] ADD  CONSTRAINT [DF_Phone_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [Project].[Project_Party] ADD  CONSTRAINT [DF_Project_Party_AssignmentDate]  DEFAULT (getdate()) FOR [AssignmentDate]
GO
ALTER TABLE [Bid].[Bid]  WITH CHECK ADD  CONSTRAINT [FK_Bid_Currency] FOREIGN KEY([Currency])
REFERENCES [dbo].[Currency] ([CurrencyID])
GO
ALTER TABLE [Bid].[Bid] CHECK CONSTRAINT [FK_Bid_Currency]
GO
ALTER TABLE [Bid].[Bid]  WITH CHECK ADD  CONSTRAINT [FK_Bid_Organization] FOREIGN KEY([OrganizationID])
REFERENCES [Party].[Organization] ([PartyID])
GO
ALTER TABLE [Bid].[Bid] CHECK CONSTRAINT [FK_Bid_Organization]
GO
ALTER TABLE [Bid].[Bid]  WITH CHECK ADD  CONSTRAINT [FK_Bid_Project] FOREIGN KEY([ProjectID])
REFERENCES [Project].[Project] ([ProjectID])
GO
ALTER TABLE [Bid].[Bid] CHECK CONSTRAINT [FK_Bid_Project]
GO
ALTER TABLE [Bond].[Bond]  WITH CHECK ADD  CONSTRAINT [FK_Bond_SuretyProgram] FOREIGN KEY([SuretyProgramID])
REFERENCES [Bond].[SuretyProgram] ([SuretyProgramID])
GO
ALTER TABLE [Bond].[Bond] CHECK CONSTRAINT [FK_Bond_SuretyProgram]
GO
ALTER TABLE [Bond].[SuretyProgram]  WITH CHECK ADD  CONSTRAINT [FK_SuretyProgram_Currency] FOREIGN KEY([CurrencyID])
REFERENCES [dbo].[Currency] ([CurrencyID])
GO
ALTER TABLE [Bond].[SuretyProgram] CHECK CONSTRAINT [FK_SuretyProgram_Currency]
GO
ALTER TABLE [Bond].[SuretyProgram]  WITH CHECK ADD  CONSTRAINT [FK_SuretyProgram_Organization] FOREIGN KEY([CreatorID])
REFERENCES [Party].[Organization] ([PartyID])
GO
ALTER TABLE [Bond].[SuretyProgram] CHECK CONSTRAINT [FK_SuretyProgram_Organization]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [Party].[Certificate]  WITH CHECK ADD  CONSTRAINT [FK_Certificate_Organization] FOREIGN KEY([IssuingBodyID])
REFERENCES [Party].[Organization] ([PartyID])
GO
ALTER TABLE [Party].[Certificate] CHECK CONSTRAINT [FK_Certificate_Organization]
GO
ALTER TABLE [Party].[FinancialInfo]  WITH CHECK ADD  CONSTRAINT [FK_FinancialInfo_Organization] FOREIGN KEY([BankID])
REFERENCES [Party].[Organization] ([PartyID])
GO
ALTER TABLE [Party].[FinancialInfo] CHECK CONSTRAINT [FK_FinancialInfo_Organization]
GO
ALTER TABLE [Party].[License]  WITH CHECK ADD  CONSTRAINT [FK_License_Organization] FOREIGN KEY([IssuingOrgID])
REFERENCES [Party].[Organization] ([PartyID])
GO
ALTER TABLE [Party].[License] CHECK CONSTRAINT [FK_License_Organization]
GO
ALTER TABLE [Party].[Org_Person]  WITH CHECK ADD  CONSTRAINT [FK_Org_Person_Organization] FOREIGN KEY([OrgID])
REFERENCES [Party].[Organization] ([PartyID])
GO
ALTER TABLE [Party].[Org_Person] CHECK CONSTRAINT [FK_Org_Person_Organization]
GO
ALTER TABLE [Party].[Org_Person]  WITH CHECK ADD  CONSTRAINT [FK_Org_Person_OrganizationRole] FOREIGN KEY([OrgRoleID])
REFERENCES [Party].[OrganizationRole] ([OrgRoleID])
GO
ALTER TABLE [Party].[Org_Person] CHECK CONSTRAINT [FK_Org_Person_OrganizationRole]
GO
ALTER TABLE [Party].[Org_Person]  WITH CHECK ADD  CONSTRAINT [FK_Org_Person_Person] FOREIGN KEY([PersonID])
REFERENCES [Party].[Person] ([partyID])
GO
ALTER TABLE [Party].[Org_Person] CHECK CONSTRAINT [FK_Org_Person_Person]
GO
ALTER TABLE [Party].[Organization]  WITH CHECK ADD  CONSTRAINT [FK_Organization_EntityType] FOREIGN KEY([EntityTypeID])
REFERENCES [dbo].[EntityType] ([EntityTypeID])
GO
ALTER TABLE [Party].[Organization] CHECK CONSTRAINT [FK_Organization_EntityType]
GO
ALTER TABLE [Party].[Organization]  WITH CHECK ADD  CONSTRAINT [FK_Organization_NAICS] FOREIGN KEY([NAICSCode])
REFERENCES [dbo].[NAICS] ([Description])
GO
ALTER TABLE [Party].[Organization] CHECK CONSTRAINT [FK_Organization_NAICS]
GO
ALTER TABLE [Party].[Organization]  WITH CHECK ADD  CONSTRAINT [FK_Organization_Party] FOREIGN KEY([PartyID])
REFERENCES [Party].[Party] ([PartyID])
GO
ALTER TABLE [Party].[Organization] CHECK CONSTRAINT [FK_Organization_Party]
GO
ALTER TABLE [Party].[Organization]  WITH CHECK ADD  CONSTRAINT [FK_Organization_Person] FOREIGN KEY([RegisteredAgent])
REFERENCES [Party].[Person] ([partyID])
GO
ALTER TABLE [Party].[Organization] CHECK CONSTRAINT [FK_Organization_Person]
GO
ALTER TABLE [Party].[Party_Address]  WITH CHECK ADD  CONSTRAINT [FK_Party_Address_Address] FOREIGN KEY([AddressID])
REFERENCES [Party].[Address] ([AddressID])
GO
ALTER TABLE [Party].[Party_Address] CHECK CONSTRAINT [FK_Party_Address_Address]
GO
ALTER TABLE [Party].[Party_Address]  WITH CHECK ADD  CONSTRAINT [FK_Party_Address_Party] FOREIGN KEY([PartyID])
REFERENCES [Party].[Party] ([PartyID])
GO
ALTER TABLE [Party].[Party_Address] CHECK CONSTRAINT [FK_Party_Address_Party]
GO
ALTER TABLE [Party].[Party_Certificate]  WITH CHECK ADD  CONSTRAINT [FK_Party_Certificate_Certificate] FOREIGN KEY([CertificateID])
REFERENCES [Party].[Certificate] ([CertificateID])
GO
ALTER TABLE [Party].[Party_Certificate] CHECK CONSTRAINT [FK_Party_Certificate_Certificate]
GO
ALTER TABLE [Party].[Party_Certificate]  WITH CHECK ADD  CONSTRAINT [FK_Party_Certificate_Party] FOREIGN KEY([PartyID])
REFERENCES [Party].[Party] ([PartyID])
GO
ALTER TABLE [Party].[Party_Certificate] CHECK CONSTRAINT [FK_Party_Certificate_Party]
GO
ALTER TABLE [Party].[Party_Email]  WITH CHECK ADD  CONSTRAINT [FK_Party_Email_Email] FOREIGN KEY([EmailID])
REFERENCES [Party].[Email] ([EmailID])
GO
ALTER TABLE [Party].[Party_Email] CHECK CONSTRAINT [FK_Party_Email_Email]
GO
ALTER TABLE [Party].[Party_Email]  WITH CHECK ADD  CONSTRAINT [FK_Party_Email_Party] FOREIGN KEY([PartyID])
REFERENCES [Party].[Party] ([PartyID])
GO
ALTER TABLE [Party].[Party_Email] CHECK CONSTRAINT [FK_Party_Email_Party]
GO
ALTER TABLE [Party].[Party_License]  WITH CHECK ADD  CONSTRAINT [FK_Party_License_License] FOREIGN KEY([LicenseID])
REFERENCES [Party].[License] ([LicenseID])
GO
ALTER TABLE [Party].[Party_License] CHECK CONSTRAINT [FK_Party_License_License]
GO
ALTER TABLE [Party].[Party_License]  WITH CHECK ADD  CONSTRAINT [FK_Party_License_Party] FOREIGN KEY([PartyID])
REFERENCES [Party].[Party] ([PartyID])
GO
ALTER TABLE [Party].[Party_License] CHECK CONSTRAINT [FK_Party_License_Party]
GO
ALTER TABLE [Party].[Party_Phone]  WITH CHECK ADD  CONSTRAINT [FK_Party_Phone_Party] FOREIGN KEY([PartyID])
REFERENCES [Party].[Party] ([PartyID])
GO
ALTER TABLE [Party].[Party_Phone] CHECK CONSTRAINT [FK_Party_Phone_Party]
GO
ALTER TABLE [Party].[Party_Phone]  WITH CHECK ADD  CONSTRAINT [FK_Party_Phone_Phone] FOREIGN KEY([PhoneID])
REFERENCES [Party].[Phone] ([PhoneNumberID])
GO
ALTER TABLE [Party].[Party_Phone] CHECK CONSTRAINT [FK_Party_Phone_Phone]
GO
ALTER TABLE [Party].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Party] FOREIGN KEY([partyID])
REFERENCES [Party].[Party] ([PartyID])
GO
ALTER TABLE [Party].[Person] CHECK CONSTRAINT [FK_Person_Party]
GO
ALTER TABLE [Project].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Project] FOREIGN KEY([ProjectID])
REFERENCES [Project].[Project] ([ProjectID])
GO
ALTER TABLE [Project].[Event] CHECK CONSTRAINT [FK_Event_Project]
GO
ALTER TABLE [Project].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_ProjectEventType] FOREIGN KEY([Type])
REFERENCES [Project].[ProjectEventType] ([EventTypeID])
GO
ALTER TABLE [Project].[Event] CHECK CONSTRAINT [FK_Event_ProjectEventType]
GO
ALTER TABLE [Project].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Currency] FOREIGN KEY([Currency])
REFERENCES [dbo].[Currency] ([CurrencyID])
GO
ALTER TABLE [Project].[Project] CHECK CONSTRAINT [FK_Project_Currency]
GO
ALTER TABLE [Project].[Project_Party]  WITH CHECK ADD  CONSTRAINT [FK_Project_Party_Party] FOREIGN KEY([OverseeingPartyID])
REFERENCES [Party].[Party] ([PartyID])
GO
ALTER TABLE [Project].[Project_Party] CHECK CONSTRAINT [FK_Project_Party_Party]
GO
ALTER TABLE [Project].[Project_Party]  WITH CHECK ADD  CONSTRAINT [FK_Project_Party_Party1] FOREIGN KEY([PartyID])
REFERENCES [Party].[Party] ([PartyID])
GO
ALTER TABLE [Project].[Project_Party] CHECK CONSTRAINT [FK_Project_Party_Party1]
GO
ALTER TABLE [Project].[Project_Party]  WITH CHECK ADD  CONSTRAINT [FK_Project_Party_Project] FOREIGN KEY([ProjectID])
REFERENCES [Project].[Project] ([ProjectID])
GO
ALTER TABLE [Project].[Project_Party] CHECK CONSTRAINT [FK_Project_Party_Project]
GO
ALTER TABLE [Project].[Project_Party]  WITH CHECK ADD  CONSTRAINT [FK_Project_Party_Role] FOREIGN KEY([PartyRoleInProject])
REFERENCES [Project].[Role] ([RoleID])
GO
ALTER TABLE [Project].[Project_Party] CHECK CONSTRAINT [FK_Project_Party_Role]
GO
USE [master]
GO
ALTER DATABASE [chico] SET  READ_WRITE 
GO
