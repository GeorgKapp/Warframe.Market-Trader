# Warframe.Market Infrastructure
Project that provides the data access models via Entity Framework 6

##How to use:
1. When adding a new class add them to the DataBaseContext Class as DbSet
2. The connection string is written as property in the app.config that then will be used by entity framework as reference

###Commands
1. enable-migrations: will be run only once for the lifetime of the project due to it creating an db-context and also checks whatever the database exists that is referenced
2. add-migration {Migration Name}: will be run everytime the infrastructure models were updated to add a new migration class, this migration class allows us to update or downgrade however we like
3. update-database: will be run after every migration to update the reference database tables
