# the investigation on Properties which not linked with relationshop

# flow
	Add-migration "Init"
	update-database
	remove-migration
	drop-database

	Add-Migration "init" -c SimpleDbContext -o Migrations/Simple
	Update-Database -Context SimpleDbContext
	Remove-Migration -Context SimpleDbContext -Force
	Drop-Database -Context SimpleDbContext

	Add-Migration "init" -c NoRelationDbContext -o Migrations/NoRelation
	Update-Database -Context NoRelationDbContext
	Remove-Migration -Context NoRelationDbContext -Force
	Drop-Database -Context NoRelationDbContext

	Add-Migration "init" -c SplitOwnContext -o Migrations/SplitOwn
	Update-Database -Context SplitOwnContext
	Remove-Migration -Context SplitOwnContext -Force
	Drop-Database -Context SplitOwnContext
	

# unapply migurations
	
-	To unapply a specific migration(s)
	dotnet ef database update LastGoodMigrationName 
	Update-Database -Migration LastGoodMigrationName

-	To unapply all migrations:
	dotnet ef database update 0 ||
	Update-Database -Migration 0

-	To remove last migration
	dotnet ef migrations remove ||
	Remove-Migration

-	To remove last few migrations (not all)
	need to remove migrations one by one

-	To unapply and remove last migration
	dotnet ef migrations remove --force ||
	Remove-Migration -Force

# Steps for revert migrations

-	Revert migration from database
-	Update model snapshot: PM> Remove-Migration

## Backing fields usage:

-	Hiding sensitive data—Hiding a person’s date of birth in a private field and making their age in years available to the rest of the software
-	Catching changes—Detecting an update of a property by storing the data in a private field and adding code in the setter to detect the update of a property. You
will use this technique in chapter 12, when you use property change to trigger an event -	Creating Domain-Driven Design (DDD) entity classes—Creating DDD entity classes
in which all the entity classes’ properties need to be read-only. Backing fields allow you to lock down navigational collection properties