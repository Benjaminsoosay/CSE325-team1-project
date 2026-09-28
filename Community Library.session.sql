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