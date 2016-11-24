using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Chico.Models
{
    public partial class chicoContext : DbContext
    {
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Bid> Bid { get; set; }
        public virtual DbSet<Bond> Bond { get; set; }
        public virtual DbSet<Certificate> Certificate { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<Email> Email { get; set; }
        public virtual DbSet<EntityType> EntityType { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<FinancialInfo> FinancialInfo { get; set; }
        public virtual DbSet<License> License { get; set; }
        public virtual DbSet<Naics> Naics { get; set; }
        public virtual DbSet<OrgPerson> OrgPerson { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<OrganizationRole> OrganizationRole { get; set; }
        public virtual DbSet<Party> Party { get; set; }
        public virtual DbSet<PartyAddress> PartyAddress { get; set; }
        public virtual DbSet<PartyCertificate> PartyCertificate { get; set; }
        public virtual DbSet<PartyEmail> PartyEmail { get; set; }
        public virtual DbSet<PartyLicense> PartyLicense { get; set; }
        public virtual DbSet<PartyPhone> PartyPhone { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Phone> Phone { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectEventType> ProjectEventType { get; set; }
        public virtual DbSet<ProjectParty> ProjectParty { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<SuretyProgram> SuretyProgram { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=ROOZBIT\SQLEXPRESS;Database=chico;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address", "Party");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.Apt).HasMaxLength(100);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.PostlCode).HasColumnType("nchar(20)");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("newid()");

                entity.Property(e => e.State).HasMaxLength(1000);

                entity.Property(e => e.Street).HasMaxLength(1000);

                entity.Property(e => e.WebAddress).HasColumnType("xml");

                entity.Property(e => e.Zip).HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex");

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PK_AspNetUserLogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(450);

                entity.Property(e => e.ProviderKey).HasMaxLength(450);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_AspNetUserRoles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetUserRoles_RoleId");

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.Property(e => e.RoleId).HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PK_AspNetUserTokens");

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.Property(e => e.LoginProvider).HasMaxLength(450);

                entity.Property(e => e.Name).HasMaxLength(450);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.PartyId).HasColumnName("partyID");

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Bid>(entity =>
            {
                entity.ToTable("Bid", "Bid");

                entity.Property(e => e.BidId).HasColumnName("BidID");

                entity.Property(e => e.DeliveryDate).HasColumnType("date");

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("role")
                    .HasColumnType("char(20)");

                entity.HasOne(d => d.CurrencyNavigation)
                    .WithMany(p => p.Bid)
                    .HasForeignKey(d => d.Currency)
                    .HasConstraintName("FK_Bid_Currency");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Bid)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Bid_Organization");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Bid)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Bid_Project");
            });

            modelBuilder.Entity<Bond>(entity =>
            {
                entity.HasKey(e => new { e.BondRequester, e.SuretyAgent, e.SuretyUnderwriter, e.SuretyProgramId })
                    .HasName("PK_Bond");

                entity.ToTable("Bond", "Bond");

                entity.Property(e => e.SuretyProgramId).HasColumnName("SuretyProgramID");

                entity.Property(e => e.DecisionStatus)
                    .IsRequired()
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.RequestDate).HasColumnType("date");

                entity.HasOne(d => d.SuretyProgram)
                    .WithMany(p => p.Bond)
                    .HasForeignKey(d => d.SuretyProgramId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Bond_SuretyProgram");
            });

            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.ToTable("Certificate", "Party");

                entity.Property(e => e.CertificateId).HasColumnName("CertificateID");

                entity.Property(e => e.ExpirationDate).HasColumnType("date");

                entity.Property(e => e.IssueDate).HasColumnType("date");

                entity.Property(e => e.IssuingBodyId).HasColumnName("IssuingBodyID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.HasOne(d => d.IssuingBody)
                    .WithMany(p => p.Certificate)
                    .HasForeignKey(d => d.IssuingBodyId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Certificate_Organization");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.Property(e => e.CurrencyId)
                    .HasColumnName("CurrencyID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Acronym).HasColumnType("nchar(10)");

                entity.Property(e => e.CurrencyName)
                    .IsRequired()
                    .HasColumnType("nchar(20)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("newid()");
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.ToTable("Email", "Party");

                entity.Property(e => e.EmailId).HasColumnName("EmailID");

                entity.Property(e => e.Email1)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasColumnType("nchar(1000)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("newid()");
            });

            modelBuilder.Entity<EntityType>(entity =>
            {
                entity.Property(e => e.EntityTypeId)
                    .HasColumnName("EntityTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("nchar(1000)");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event", "Project");

                entity.Property(e => e.EventId)
                    .HasColumnName("EventID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Duration)
                    .HasComputedColumnSql("datediff(hour,[StartDate],coalesce([EndDate],[StartDate]))")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_Event_Project");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Event_ProjectEventType");
            });

            modelBuilder.Entity<FinancialInfo>(entity =>
            {
                entity.HasKey(e => e.PartyId)
                    .HasName("PK_FinancialInfo");

                entity.ToTable("FinancialInfo", "Party");

                entity.Property(e => e.PartyId)
                    .HasColumnName("PartyID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountingSoftware).HasMaxLength(1000);

                entity.Property(e => e.BankId).HasColumnName("BankID");

                entity.Property(e => e.BankruptcyDescription).HasColumnType("nchar(10)");

                entity.Property(e => e.EstimateSoftware).HasColumnType("nchar(10)");

                entity.Property(e => e.FinancialStatementBasis).HasColumnType("nchar(10)");

                entity.Property(e => e.FinancialStatementIssuePeriod).HasColumnType("nchar(10)");

                entity.Property(e => e.JobCostSoftware).HasColumnType("nchar(10)");

                entity.Property(e => e.LargestBacklog).HasColumnType("nchar(10)");

                entity.Property(e => e.LargestBondValue).HasColumnType("nchar(10)");

                entity.Property(e => e.LeasedEquipment)
                    .HasColumnName("leasedEquipment")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.PercentageSubcontracted).HasColumnType("nchar(10)");

                entity.Property(e => e.Ssn)
                    .HasColumnName("SSN")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.TaxId)
                    .HasColumnName("TaxID")
                    .HasColumnType("nchar(10)");

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.FinancialInfo)
                    .HasForeignKey(d => d.BankId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_FinancialInfo_Organization");
            });

            modelBuilder.Entity<License>(entity =>
            {
                entity.ToTable("License", "Party");

                entity.Property(e => e.LicenseId).HasColumnName("LicenseID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.IssuingOrgId).HasColumnName("IssuingOrgID");

                entity.Property(e => e.Name).HasMaxLength(400);

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.IssuingOrg)
                    .WithMany(p => p.License)
                    .HasForeignKey(d => d.IssuingOrgId)
                    .HasConstraintName("FK_License_Organization");
            });

            modelBuilder.Entity<Naics>(entity =>
            {
                entity.HasKey(e => e.Description)
                    .HasName("PK_NAICS2");

                entity.ToTable("NAICS");

                entity.Property(e => e.Description).HasColumnType("char(200)");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");
            });

            modelBuilder.Entity<OrgPerson>(entity =>
            {
                entity.HasKey(e => new { e.PersonId, e.OrgId })
                    .HasName("PK_Org_Person");

                entity.ToTable("Org_Person", "Party");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.OrgId).HasColumnName("OrgID");

                entity.Property(e => e.AffiliationStartDate).HasColumnType("date");

                entity.Property(e => e.OrgRoleId).HasColumnName("OrgRoleID");

                entity.Property(e => e.SharesOwned).HasColumnName("sharesOwned");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.OrgPerson)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Org_Person_Organization");

                entity.HasOne(d => d.OrgRole)
                    .WithMany(p => p.OrgPerson)
                    .HasForeignKey(d => d.OrgRoleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Org_Person_OrganizationRole");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.OrgPerson)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Org_Person_Person");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.HasKey(e => e.PartyId)
                    .HasName("PK_Organization");

                entity.ToTable("Organization", "Party");

                entity.Property(e => e.PartyId)
                    .HasColumnName("PartyID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActiveStatus).HasDefaultValueSql("0");

                entity.Property(e => e.ChicoSignUpDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.EntityTypeId).HasColumnName("EntityTypeID");

                entity.Property(e => e.EstablishmentDate).HasColumnType("date");

                entity.Property(e => e.IncludeInListing).HasDefaultValueSql("0");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Naicscode)
                    .HasColumnName("NAICSCode")
                    .HasColumnType("char(200)");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("newid()");

                entity.HasOne(d => d.EntityType)
                    .WithMany(p => p.Organization)
                    .HasForeignKey(d => d.EntityTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Organization_EntityType");

                entity.HasOne(d => d.NaicscodeNavigation)
                    .WithMany(p => p.Organization)
                    .HasForeignKey(d => d.Naicscode)
                    .HasConstraintName("FK_Organization_NAICS");

                entity.HasOne(d => d.Party)
                    .WithOne(p => p.Organization)
                    .HasForeignKey<Organization>(d => d.PartyId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Organization_Party");

                entity.HasOne(d => d.RegisteredAgentNavigation)
                    .WithMany(p => p.Organization)
                    .HasForeignKey(d => d.RegisteredAgent)
                    .HasConstraintName("FK_Organization_Person");
            });

            modelBuilder.Entity<OrganizationRole>(entity =>
            {
                entity.HasKey(e => e.OrgRoleId)
                    .HasName("PK_CompanyRole");

                entity.ToTable("OrganizationRole", "Party");

                entity.Property(e => e.OrgRoleId)
                    .HasColumnName("OrgRoleID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);
            });

            modelBuilder.Entity<Party>(entity =>
            {
                entity.ToTable("Party", "Party");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.ModfiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("newid()");
            });

            modelBuilder.Entity<PartyAddress>(entity =>
            {
                entity.HasKey(e => new { e.PartyId, e.AddressId })
                    .HasName("PK_Party_Address");

                entity.ToTable("Party_Address", "Party");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.PartyAddress)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Party_Address_Address");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.PartyAddress)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Party_Address_Party");
            });

            modelBuilder.Entity<PartyCertificate>(entity =>
            {
                entity.HasKey(e => new { e.PartyId, e.CertificateId })
                    .HasName("PK_Party_Certificate");

                entity.ToTable("Party_Certificate", "Party");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.CertificateId).HasColumnName("CertificateID");

                entity.HasOne(d => d.Certificate)
                    .WithMany(p => p.PartyCertificate)
                    .HasForeignKey(d => d.CertificateId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Party_Certificate_Certificate");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.PartyCertificate)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Party_Certificate_Party");
            });

            modelBuilder.Entity<PartyEmail>(entity =>
            {
                entity.HasKey(e => new { e.PartyId, e.EmailId })
                    .HasName("PK_Party_Email");

                entity.ToTable("Party_Email", "Party");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.EmailId).HasColumnName("EmailID");

                entity.HasOne(d => d.Email)
                    .WithMany(p => p.PartyEmail)
                    .HasForeignKey(d => d.EmailId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Party_Email_Email");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.PartyEmail)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Party_Email_Party");
            });

            modelBuilder.Entity<PartyLicense>(entity =>
            {
                entity.HasKey(e => new { e.PartyId, e.LicenseId })
                    .HasName("PK_Party_License");

                entity.ToTable("Party_License", "Party");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.LicenseId).HasColumnName("LicenseID");

                entity.HasOne(d => d.License)
                    .WithMany(p => p.PartyLicense)
                    .HasForeignKey(d => d.LicenseId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Party_License_License");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.PartyLicense)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Party_License_Party");
            });

            modelBuilder.Entity<PartyPhone>(entity =>
            {
                entity.HasKey(e => new { e.PartyId, e.PhoneId })
                    .HasName("PK_Party_Phone");

                entity.ToTable("Party_Phone", "Party");

                entity.Property(e => e.PartyId)
                    .HasColumnName("PartyID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PhoneId).HasColumnName("PhoneID");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.PartyPhone)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Party_Phone_Party");

                entity.HasOne(d => d.Phone)
                    .WithMany(p => p.PartyPhone)
                    .HasForeignKey(d => d.PhoneId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Party_Phone_Phone");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.PartyId)
                    .HasName("PK_Person");

                entity.ToTable("Person", "Party");

                entity.Property(e => e.PartyId)
                    .HasColumnName("partyID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.MiddleName).HasMaxLength(100);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("newid()");

                entity.Property(e => e.SpouseDateOfBirth).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Party)
                    .WithOne(p => p.Person)
                    .HasForeignKey<Person>(d => d.PartyId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Person_Party");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.HasKey(e => e.PhoneNumberId)
                    .HasName("PK_Phone");

                entity.ToTable("Phone", "Party");

                entity.Property(e => e.PhoneNumberId).HasColumnName("PhoneNumberID");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnType("nchar(20)");

                entity.Property(e => e.PhoneNumberType)
                    .IsRequired()
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("newid()");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project", "Project");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("ProjectID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.CurrencyNavigation)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.Currency)
                    .HasConstraintName("FK_Project_Currency");
            });

            modelBuilder.Entity<ProjectEventType>(entity =>
            {
                entity.HasKey(e => e.EventTypeId)
                    .HasName("PK_EventTypeID");

                entity.ToTable("ProjectEventType", "Project");

                entity.Property(e => e.EventTypeId)
                    .HasColumnName("EventTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<ProjectParty>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.PartyId, e.PartyRoleInProject })
                    .HasName("PK_Project_Party");

                entity.ToTable("Project_Party", "Project");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.AssignmentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.OverseeingPartyId).HasColumnName("OverseeingPartyID");

                entity.HasOne(d => d.OverseeingParty)
                    .WithMany(p => p.ProjectPartyOverseeingParty)
                    .HasForeignKey(d => d.OverseeingPartyId)
                    .HasConstraintName("FK_Project_Party_Party");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.ProjectPartyParty)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Project_Party_Party1");

                entity.HasOne(d => d.PartyRoleInProjectNavigation)
                    .WithMany(p => p.ProjectParty)
                    .HasForeignKey(d => d.PartyRoleInProject)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Project_Party_Role");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectParty)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Project_Party_Project");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role", "Project");

                entity.Property(e => e.RoleId)
                    .HasColumnName("RoleID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("nchar(500)");
            });

            modelBuilder.Entity<SuretyProgram>(entity =>
            {
                entity.ToTable("SuretyProgram", "Bond");

                entity.Property(e => e.SuretyProgramId)
                    .HasColumnName("SuretyProgramID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatorId).HasColumnName("CreatorID");

                entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.SuretyProgram)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SuretyProgram_Organization");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.SuretyProgram)
                    .HasForeignKey(d => d.CurrencyId)
                    .HasConstraintName("FK_SuretyProgram_Currency");
            });
        }
    }
}