SET NOCOUNT ON;
GO

IF DB_ID(N'IdentityDb') IS NULL
BEGIN
    PRINT 'IdentityDb does not exist. Skipping seed.';
END
ELSE
BEGIN
    USE IdentityDb;
    

    IF OBJECT_ID(N'dbo.Roles', N'U') IS NULL
    BEGIN
        PRINT 'Roles table does not exist. Skipping seed.';
    END
    ELSE
    BEGIN
        INSERT INTO dbo.Roles (Name, RoleLevel)
        SELECT v.Name, v.RoleLevel
        FROM (VALUES
            (N'Apprentice', 1),
            (N'Junior Assistant', 2),
            (N'Junior Stylist', 3),
            (N'Stylist', 4),
            (N'Senior Stylist', 5),
            (N'Top Stylist', 6),
            (N'Head Stylist', 7),
            (N'Salon Manager', 8),
            (N'Salon Director', 9),
            (N'Boss', 10)
        ) AS v(Name, RoleLevel)
        WHERE NOT EXISTS
        (
            SELECT 1
            FROM dbo.Roles AS r
            WHERE r.Name = v.Name
        );

        PRINT 'IdentityDb seed completed successfully.';
    END
END
GO