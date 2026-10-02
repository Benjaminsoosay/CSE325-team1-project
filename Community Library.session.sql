-- List tables
SELECT table_schema, table_name
FROM information_schema.tables
WHERE table_schema NOT IN ('pg_catalog', 'information_schema')
ORDER BY table_schema, table_name;

SELECT
    u."Id",
    u."UserName",
    u."Email",
    r."Name" AS "Role"
FROM "AspNetUsers" u
LEFT JOIN "AspNetUserRoles" ur
    ON u."Id" = ur."UserId"
LEFT JOIN "AspNetRoles" r
    ON ur."RoleId" = r."Id"
ORDER BY u."UserName";

CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (                                                                
      "MigrationId" character varying(150) NOT NULL,                                                                    
      "ProductVersion" character varying(32) NOT NULL,                                                                  
      CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")                                                 
  );                                                                                                                    
                                                                                                                        
  INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")                                                 
  VALUES                                                                                               
      ('20260928163321_InitialCreate', '10.0.0'),                                                                       
      ('20260928215539_AddSecurityWordToUser', '10.0.0')                                                                
  ON CONFLICT ("MigrationId") DO NOTHING;