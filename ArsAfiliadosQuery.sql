Create database ArsAfiliados_LuisEduardoFrias
go

use  ArsAfiliados_LuisEduardoFrias
go

Create table ESTATUS
(
	Id int primary key identity not null,
	Estatus bit
)

Insert into ESTATUS values (1), (0);
Select * from  ESTATUS;

--/////  Planes

Create table PLANES
(
	Id int primary key identity not null,
	Plan_ varchar(25) not null,
	MontoCobertura decimal not null,
	FechaRegistro datetime not null,
	Estatus bit not null,
)
Go

create proc MostrarPlanes
as
begin

	select * from PLANES

end
go

create proc CrearPlanes
@Plan varchar(25),
@MontoCobertura decimal,
@FechaRegistro datetime,
@Estatus bit
as
begin

	Insert into PLANES values (
	@Plan,
	@MontoCobertura,
	@FechaRegistro,
	@Estatus)

end
go

create proc ActualizarPlanes 
@Id int,
@Plan varchar(25),
@MontoCobertura decimal,
@FechaRegistro datetime,
@Estatus bit
as
begin

	Update PLANES set
	Plan_ = @Plan,             
	MontoCobertura = @MontoCobertura,				
	FechaRegistro = @FechaRegistro ,		
	Estatus = @Estatus
	where  
	Id = @Id

end
go

create proc BuscarPlanes @Id int
as
begin

	select * from PLANES where Id = @Id

end
go

Create proc InactivarPlanes @Id int, @Estatus int
as
begin

	Update PLANES set 
	Estatus = @Estatus
	where  
	Id = @Id

end
go

--/////  afiliados

Create table AFILIADOS
(
	Id int primary key identity not null,
	Nombre              varchar(50) not null, 
	Apellido			varchar(50) not null,
	Fecha				DateTime not null,
	Nacimiento 			varchar(25) not null,
	Sexo				char(1) not null,
	Cedula				char(11) not null,
	NumeroSeguroSocial	varchar(25) not null,
	FechaRegistro		datetime not null,
	MontoConsumido		decimal not null,
	EstatusId			int not null,
	PlanId				int not null,
	foreign key (EstatusId) references ESTATUS(Id),
	foreign key (PlanId) references PLANES(Id)
)
go

create proc MostrarAfiliado
as
begin

	select * from AFILIADOS as A 
	Join ESTATUS as E on A.EstatusId = E.Id 
	Join PLANES as P on A.PlanId = P.Id;

end
go

create proc CrearAfiliado
@Nombre              varchar(50),
@Apellido			varchar(50),
@Fecha				DateTime,
@Nacimiento 			varchar(25),
@Sexo				char(1),
@Cedula				char(11),
@NumeroSeguroSocial	varchar(25),
@FechaRegistro		datetime,
@MontoConsumido		decimal,
@EstatusId			int,
@PlanId				int
as
begin

	Insert into AFILIADOS values (
	 @Nombre             
	,@Apellido			
	,@Fecha				
	,@Nacimiento 		
	,@Sexo				
	,@Cedula				
	,@NumeroSeguroSocial	
	,@FechaRegistro		
	,@MontoConsumido		
	,@EstatusId			
	,@PlanId)

end
go

create proc ActualizarAfiliado 
@Id int,
@Nombre              varchar(50),
@Apellido			varchar(50),
@Fecha				DateTime,
@Nacimiento 			varchar(25),
@Sexo				char(1),
@Cedula				char(11),
@NumeroSeguroSocial	varchar(25),
@FechaRegistro		datetime,
@MontoConsumido		decimal,
@EstatusId			int,
@PlanId				int
as
begin

	Update AFILIADOS set
	Nombre= @Nombre,             
	Apellido= @Apellido,			
	Fecha= @Fecha	,			
	Nacimiento= @Nacimiento ,		
	Sexo= @Sexo	,			
	Cedula= @Cedula		,		
	NumeroSeguroSocial= @NumeroSeguroSocial	,
	FechaRegistro= @FechaRegistro		,
	MontoConsumido= @MontoConsumido	,	
	EstatusId= @EstatusId	,		
	PlanId= @PlanId	
	where  
	Id = @Id

end
go

Create proc BuscarAfiliado @Buscar varchar(50)
as
begin

	if(@Buscar <> 'Todos')
	begin

		select * from AFILIADOS as A 
		Join ESTATUS as E on A.EstatusId = E.Id 
		Join PLANES as P on A.PlanId = P.Id 
		where 
		Nombre = @Buscar or
		Apellido =  @Buscar or
		Cedula = @Buscar;

	end
	else
	begin

		select * from AFILIADOS as A 
		Join ESTATUS as E on A.EstatusId = E.Id 
		Join PLANES as P on A.PlanId = P.Id 

	end
end
go

Create proc InactivarAfiliado @cedula char(11), @Estatus int
as
begin

	Update AFILIADOS set 
	EstatusId = @Estatus
	where  
	Cedula = @cedula

end
go