USE [master]
GO
/****** Object:  Database [controleponto]    Script Date: 31/12/2021 04:23:34 ******/
CREATE DATABASE [controleponto]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'controleponto', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.BUSINESSSERVER\MSSQL\DATA\controleponto.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'controleponto_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.BUSINESSSERVER\MSSQL\DATA\controleponto_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [controleponto] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [controleponto].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [controleponto] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [controleponto] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [controleponto] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [controleponto] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [controleponto] SET ARITHABORT OFF 
GO
ALTER DATABASE [controleponto] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [controleponto] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [controleponto] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [controleponto] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [controleponto] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [controleponto] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [controleponto] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [controleponto] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [controleponto] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [controleponto] SET  ENABLE_BROKER 
GO
ALTER DATABASE [controleponto] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [controleponto] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [controleponto] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [controleponto] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [controleponto] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [controleponto] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [controleponto] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [controleponto] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [controleponto] SET  MULTI_USER 
GO
ALTER DATABASE [controleponto] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [controleponto] SET DB_CHAINING OFF 
GO
ALTER DATABASE [controleponto] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [controleponto] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [controleponto] SET DELAYED_DURABILITY = DISABLED 
GO
USE [controleponto]
GO
/****** Object:  Table [dbo].[TabDepartamento]    Script Date: 31/12/2021 04:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TabDepartamento](
	[DepartamentoID] [int] NOT NULL,
	[Responsavel] [nchar](20) NULL,
	[Login] [nchar](10) NULL,
	[Email] [nchar](20) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TabFuncionario]    Script Date: 31/12/2021 04:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TabFuncionario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[CPF] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Telefone] [nvarchar](max) NULL,
	[Habilitacao] [bit] NOT NULL,
	[Categoria] [nvarchar](max) NULL,
	[LinguaEstrangeira] [nvarchar](max) NULL,
	[Estado] [nvarchar](max) NULL,
	[Cidade] [nvarchar](max) NULL,
	[CEP] [nvarchar](max) NULL,
	[Logradouro] [nvarchar](max) NULL,
	[Numero] [nvarchar](max) NULL,
	[Complemento] [nvarchar](max) NULL,
	[Cargo] [nvarchar](max) NULL,
	[SalarioProposto] [nvarchar](max) NULL,
	[DiadaSemana] [nvarchar](max) NULL,
	[HoraInicio] [nvarchar](max) NULL,
	[HoraFim] [nvarchar](max) NULL,
	[TempodeDescanso] [nvarchar](max) NULL,
	[CargaHoraria] [nvarchar](max) NULL,
	[CargaHorariaSEmanal] [nvarchar](max) NULL,
 CONSTRAINT [PK_TabFuncionario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[_insertdepartamento]    Script Date: 31/12/2021 04:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_insertdepartamento]

AS
BEGIN

declare @Existe int  =0 
declare @Retorno varchar(50)=''


set @Existe= (select count(1) from [controleponto].[dbo].[TapDepartamento] where DepartamentoID  = '2')


if ( @Existe = 0) /* se não existe Insere um novo*/
  begin
     Insert into [controleponto].[dbo].[TapDepartamento] (DepartamentoID, Responsavel,Login, Email) values ('2', 'apolinario', 'sistema','leal@gmail.com')
	 set @Retorno='Registro Inserido' 
  end
  else begin /* se  existe Altera*/
			Update [controleponto].[dbo].[TapDepartamento] 
			set DepartamentoID = '1', 
				Responsavel = 'Leal',
				Login = 'teste',
				Email = 'teste@gmail.com'
								
				where DepartamentoID = '1'  	 
			set @Retorno='Registro Alterado'
       end

	   END
GO
/****** Object:  StoredProcedure [dbo].[inserirdepartamento]    Script Date: 31/12/2021 04:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[inserirdepartamento]
@DepartamentoID INT,
@VResponsavel varchar(20),
@VLogin varchar (10),
@VEmail varchar (20)

AS 
BEGIN
 
 INSERT INTO [controleponto].[dbo].[TapDepartamento]

 ( 
 
 DepartamentoID,
 Responsavel,
 Login,
 Email

 )

 VALUES

 (
 @DepartamentoID,
 @VResponsavel,
 @VLogin,
 @VEmail

 )



END



GO
/****** Object:  StoredProcedure [dbo].[Proc_departamento]    Script Date: 31/12/2021 04:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_departamento]( @vDepartamentoID INT, @VResponsavel varchar(20), @VLogin varchar (10), @VEmail varchar (20))

AS
BEGIN

declare @Existe int  =0 
declare @Retorno varchar(50)=''


set @Existe= (select count(1) from [controleponto].[dbo].[TapDepartamento] where DepartamentoID  = @vDepartamentoID)


if ( @Existe = 0) /* se não existe Insere um novo*/
  begin
     Insert into [controleponto].[dbo].[TapDepartamento] (DepartamentoID, Responsavel,Login, Email) values (@vDepartamentoID, @VResponsavel, @VLogin, @VEmail)
	 set @Retorno='Registro Inserido' 
  end
  else begin /* se  existe Altera*/
			Update [controleponto].[dbo].[TabDepartamento] 
			set 
				Responsavel = @VResponsavel,
				Login = @VLogin,
				Email = @VEmail
								
				where DepartamentoID = @vDepartamentoID 	 
			set @Retorno='Registro Alterado'
       end

	select @Retorno RETORNO
END
GO
USE [master]
GO
ALTER DATABASE [controleponto] SET  READ_WRITE 
GO
