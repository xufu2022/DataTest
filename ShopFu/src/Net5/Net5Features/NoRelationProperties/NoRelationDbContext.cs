﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Net5Features.NoRelationProperties
{
    public class NoRelationDbContext: DbContext
    {
        public NoRelationDbContext(DbContextOptions<NoRelationDbContext> options) : base(options)
        {
        }
        public DbSet<MyEntityClass> MyEntities { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<IndexClass> IndexClasses { get; set; }

        public DbSet<ValueConversionExample> ConversionExamples { get; set; }

        public DbSet<BaseClass> BaseClasses { get; set; }
        public DbSet<DupClass> DupClasses { get; set; }
        public DbSet<SchemaAttributeExample> SchemaAttributeExamples { get; set; }
        public DbSet<SchemaFluentExample> SchemaFluentExamples { get; set; }
        public DbSet<CollationsClass> Collations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ValueConversionExample>()
                .Property(e => e.StageViaFluent)
                .HasConversion<string>();

            modelBuilder.Entity<ValueConversionExample>()
                .Property(e => e.StageCanBeNull)
                .HasConversion<string>();

            modelBuilder.Entity<ValueConversionExample>()
                .Property(e => e.EnumFlags)
                .HasConversion<string>();

            var utcConverter = new ValueConverter<DateTime, DateTime>( //#A
                toDb => toDb,                                      //#B
                fromDb =>                                              //#C
                    DateTime.SpecifyKind(fromDb, DateTimeKind.Utc));   //#C

            modelBuilder.Entity<ValueConversionExample>()              //#D
                .Property(e => e.DateTimeUtcUtcOnReturn)               //#D
                .HasConversion(utcConverter);                          //#E
            /*********************************************************
            #A This creates a ValueConverter from DateTime to DateTime
            #B This saves the DateTime to the database in the normal way, i.e. no conversion
            #C On reading from the database we add the UTC setting to the DateTime
            #D This selects the property we want to configure
            #E And this adds the utcConverter to that property
             **********************************************/
            modelBuilder.Entity<ValueConversionExample>()
                .Property(e => e.DateTimeUtcSaveAsString)
                .HasConversion(new DateTimeToStringConverter());

            modelBuilder.Entity<BaseClass>()
                .ToTable("KeyTestTable");

            modelBuilder.Entity<DupClass>()
                .ToView("KeyTestTable");

            modelBuilder.Entity<MyEntityClass>()
                .ToTable("MyTable");

            modelBuilder.Entity<MyEntityClass>()
                .Property(p => p.NormalProp)
                .HasColumnName( //#A
                    Database.IsSqlite() //#B
                        ? "SqliteDatabaseCol" //#C
                        : "GenericDatabaseCol"); //#C
            /*Database provider specific command example **************************
            #A In this case I am setting a column name, but the same would work for ToTable
            #B Each database provider has an extension called Is<DatabaseName> that returns true if the database is of that type
            #C Using the tests I pick a specific name for the column if its a Sqlite database, otherwise a generic name for any other database type
            * *******************************************************************/

            modelBuilder.Entity<MyEntityClass>()
                .Property<DateTime>("UpdatedOn"); //#A
            /*Shadow property******************************************************
            #A I use the Property<T> method to define the shadow property type
             * ********************************************************************/

            modelBuilder.Entity<MyEntityClass>()
                .Property(x => x.ReadOnlyIntMapped); //#A

            modelBuilder.Entity<Person>()
                .Property<DateTime>("_dateOfBirth") //#A
                .HasColumnName("DateOfBirth"); //#B
            /*Backing fields ********************************************************* 
             #A This configures a field-only property with no linked public property 
             #B This sets the column name to "DateOfBirth"
             * **************************************************************************/

            if (Database.IsSqlServer())
            {
                modelBuilder.Entity<CollationsClass>()
                    .Property(x => x.CaseSensitiveString)
                    .UseCollation("Latin1_General_CS_AS");
                modelBuilder.Entity<CollationsClass>()
                    .Property(x => x.CaseSensitiveStringWithIndex)
                    .UseCollation("Latin1_General_CS_AS");
                modelBuilder.Entity<CollationsClass>()
                    .HasIndex(x => x.CaseSensitiveStringWithIndex)
                    .HasDatabaseName("CaseSensitive");
            }

            modelBuilder.Entity<Person>()
                .Property(b => b.BackingFieldViaFluentApi)
                .HasField("_fieldName2")
                .UsePropertyAccessMode(PropertyAccessMode.PreferProperty);

            modelBuilder.Entity<IndexClass>()
                .HasIndex(p => p.IndexNonUnique);

            modelBuilder.Entity<IndexClass>()
                .HasIndex(p => p.IndexUnique)
                .IsUnique()
                .HasDatabaseName("MyUniqueIndex");

            modelBuilder.Entity<SchemaFluentExample>()
                .ToTable("SchemaFluent", schema: "Schema2");

            modelBuilder.Entity<MyEntityClass>()
                .Ignore(b => b.LocalString); //#A

            modelBuilder.Ignore<ExcludeClass>(); //#B
        }
    }
}
