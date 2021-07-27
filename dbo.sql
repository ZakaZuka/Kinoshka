insert into [dbo].[AspNetRoles](Id, Name, NormalizedName, ConcurrencyStamp)
values(NEWID(), 'admin', 'ADMIN', NEWID())

insert into [dbo].[AspNetRoles](Id, Name, NormalizedName, ConcurrencyStamp)
values(NEWID(), 'client', 'CLIENT', NEWID())

insert into [dbo].[AspNetRoles](Id, Name, NormalizedName, ConcurrencyStamp)
values(NEWID(), 'moderator', 'MODERATOR', NEWID())



insert into [planner].[dbo].[Statuses] (Title, Icon, CreatedAt, CreatedBy, ModifiedAt, ModifiedBy, Deleted, DeletedAt, DeletedBy)
values ('Created', 'fa fa-clock', GETDATE(), 'admin', getdate(), 'admin', 0, null, null)

insert into [planner].[dbo].[Statuses] (Title, Icon, CreatedAt, CreatedBy, ModifiedAt, ModifiedBy, Deleted, DeletedAt, DeletedBy)
values ('Updated', 'fa fa-clock', GETDATE(), 'admin', getdate(), 'admin', 0, null, null)

insert into [planner].[dbo].[Statuses] (Title, Icon, CreatedAt, CreatedBy, ModifiedAt, ModifiedBy, Deleted, DeletedAt, DeletedBy)
values ('Assigned', 'fa fa-clock', GETDATE(), 'admin', getdate(), 'admin', 0, null, null)

insert into [planner].[dbo].[Statuses] (Title, Icon, CreatedAt, CreatedBy, ModifiedAt, ModifiedBy, Deleted, DeletedAt, DeletedBy)
values ('Completed', 'fa fa-clock', GETDATE(), 'admin', getdate(), 'admin', 0, null, null)

insert into [planner].[dbo].[Statuses] (Title, Icon, CreatedAt, CreatedBy, ModifiedAt, ModifiedBy, Deleted, DeletedAt, DeletedBy)
values ('Closed', 'fa fa-clock', GETDATE(), 'admin', getdate(), 'admin', 0, null, null)