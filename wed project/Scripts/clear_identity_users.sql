-- Wipes ASP.NET Core Identity user data; run on the BigShope database.
SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;

BEGIN TRY
    BEGIN TRANSACTION;
    DELETE FROM [AspNetUserTokens];
    DELETE FROM [AspNetUserLogins];
    DELETE FROM [AspNetUserRoles];
    DELETE FROM [AspNetUserClaims];
    DELETE FROM [AspNetUsers];
    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    THROW;
END CATCH;
