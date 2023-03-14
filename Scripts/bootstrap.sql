-- bootstrap script for VirtualAgent application
-- Please run before attempting to start the application
------ uncomment next few lines if you'd *really* like to recreate the database
-- use master;
-- go
-- ALTER DATABASE  [VirtualAgent]
-- SET SINGLE_USER
-- WITH ROLLBACK IMMEDIATE
-- drop database [VirtualAgent]
-- go
------ normal creation after here
use master;
go
if not exists (select name from master..syslogins where name = 'VirtualAgentWeb')
    begin
        create login VirtualAgentWeb with password = 'P4$$w0rd';
    end;
go


if not exists (select name from master..sysdatabases where name = 'VirtualAgent')
begin
create database VirtualAgent
end;
GO

use VirtualAgent
if not exists (select * from sysusers where name = 'VirtualAgentWeb')
begin
create user VirtualAgentWeb
	for login VirtualAgentWeb
	with default_schema = dbo
end;
GO
grant connect to VirtualAgentWeb
go
exec sp_addrolemember N'db_datareader', N'VirtualAgentWeb';
go
exec sp_addrolemember N'db_datawriter', N'VirtualAgentWeb';
go
exec sp_addrolemember N'db_owner', N'VirtualAgentWeb';
GO
use master;
GO

