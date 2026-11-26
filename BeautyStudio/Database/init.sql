SET NOCOUNT ON;
GO

IF DB_ID(N'IdentityDb') IS NULL
BEGIN
    PRINT 'IdentityDb does not exist. Skipping seed.';
END
ELSE
BEGIN
    USE IdentityDb;
    
    -- ==========================================
    -- 1. SEED ROLES
    -- ==========================================
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

        PRINT 'Roles seeded successfully.';
    END

    -- ==========================================
    -- 2. SEED BOSS USER with email: boss@beautystudio.com and password: Boss123!
    -- ==========================================
    IF OBJECT_ID(N'dbo.Users', N'U') IS NOT NULL
    BEGIN
        DECLARE @BossEmail NVARCHAR(100) = N'boss@beautystudio.com';
        DECLARE @BossPasswordHash NVARCHAR(255) = N'$2a$12$jj9iBZ/UI5jzHyzIhylBlu1cE4BvYEq3bhvTVT.zX75g3Nm7Zid5W'; -- BCrypt hash за "Boss123!"
        DECLARE @BossUserId INT;

        -- Проверка дали Boss потребителят вече съществува
        IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Email = @BossEmail)
        BEGIN
            -- Вмъкване на потребителя
            INSERT INTO dbo.Users (
                Email, UserName, FirstName, LastName, PhoneNumber, 
                PasswordHash, IsActive, IsBlocked, EmailVerified, PhoneVerified, 
                CreatedAt
            )
            VALUES (
                @BossEmail, 
                N'Boss', 
                N'Boss', 
                N'Admin', 
                N'+359888000000', 
                @BossPasswordHash, 
                1, 0, 1, 1, 
                GETUTCDATE()
            );

            SET @BossUserId = SCOPE_IDENTITY();
            PRINT 'Boss user created with ID: ' + CAST(@BossUserId AS NVARCHAR(10));
        END
        ELSE
        BEGIN
            SELECT @BossUserId = Id FROM dbo.Users WHERE Email = @BossEmail;
            PRINT 'Boss user already exists with ID: ' + CAST(@BossUserId AS NVARCHAR(10));
        END

        -- ==========================================
        -- 3. ASSIGN BOSS ROLE
        -- ==========================================
        IF OBJECT_ID(N'dbo.UserRoles', N'U') IS NOT NULL
        BEGIN
            DECLARE @BossRoleId INT;
            SELECT @BossRoleId = Id FROM dbo.Roles WHERE Name = N'Boss';

            IF @BossRoleId IS NOT NULL
            BEGIN
                IF NOT EXISTS (SELECT 1 FROM dbo.UserRoles WHERE UserId = @BossUserId AND RoleId = @BossRoleId)
                BEGIN
                    INSERT INTO dbo.UserRoles (UserId, RoleId)
                    VALUES (@BossUserId, @BossRoleId);
                    PRINT 'Boss role assigned to user.';
                END
                ELSE
                BEGIN
                    PRINT 'Boss already has the Boss role.';
                END
            END
            ELSE
            BEGIN
                PRINT 'Boss role not found. Cannot assign.';
            END
        END
    END
    ELSE
    BEGIN
        PRINT 'Users table does not exist. Skipping Boss user seed.';
    END
END
GO