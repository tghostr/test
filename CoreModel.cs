using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace test_avto;

public partial class CoreModel : DbContext
{
    public CoreModel()
    {
    }
    private static CoreModel instance;
    public static CoreModel init()
    {
        if(instance ==null)
            instance = new CoreModel();
        return instance;
    }
    public CoreModel(DbContextOptions<CoreModel> options)
        : base(options)
    {
    }

    public virtual DbSet<Dolzhnost> Dolzhnosts { get; set; }

    public virtual DbSet<Dostup> Dostups { get; set; }

    public virtual DbSet<Pacient> Pacients { get; set; }

    public virtual DbSet<Poseshenie> Poseshenies { get; set; }

    public virtual DbSet<Smena> Smenas { get; set; }

    public virtual DbSet<Sotrudnik> Sotrudniks { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Vid> Vids { get; set; }

    public virtual DbSet<Vrach> Vraches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("port=3306;server=cfif31.ru;character set=utf8;database=ISPr23-35_TazetdinovRR_DrMag;userid=ISPr23-35_TazetdinovRR;password=ISPr23-35_TazetdinovRR", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Dolzhnost>(entity =>
        {
            entity.HasKey(e => e.IdDolzhnost).HasName("PRIMARY");

            entity.ToTable("Dolzhnost");

            entity.Property(e => e.IdDolzhnost).HasColumnName("idDolzhnost");
            entity.Property(e => e.NameDolzhnost).HasColumnType("text");
        });

        modelBuilder.Entity<Dostup>(entity =>
        {
            entity.HasKey(e => e.IdDostup).HasName("PRIMARY");

            entity.ToTable("Dostup");

            entity.Property(e => e.IdDostup).HasColumnName("idDostup");
            entity.Property(e => e.DostupName).HasMaxLength(45);
        });

        modelBuilder.Entity<Pacient>(entity =>
        {
            entity.HasKey(e => e.IdPacient).HasName("PRIMARY");

            entity.ToTable("Pacient");

            entity.Property(e => e.IdPacient).HasColumnName("idPacient");
            entity.Property(e => e.Oms).HasColumnName("OMS");
            entity.Property(e => e.PacientEmail)
                .HasMaxLength(450)
                .HasColumnName("PacientEMAIL");
            entity.Property(e => e.PacientFamiliya).HasMaxLength(450);
            entity.Property(e => e.PacientImya).HasMaxLength(450);
            entity.Property(e => e.PacientOtch).HasMaxLength(450);
        });

        modelBuilder.Entity<Poseshenie>(entity =>
        {
            entity.HasKey(e => e.IdPoseshenie).HasName("PRIMARY");

            entity.ToTable("Poseshenie");

            entity.HasIndex(e => e.PacientIdPacient, "fk_Poseshenie_Pacient1_idx");

            entity.HasIndex(e => e.VidIdVid, "fk_Poseshenie_VID1_idx");

            entity.HasIndex(e => e.VrachIdVrach, "fk_Poseshenie_Vrach1_idx");

            entity.Property(e => e.IdPoseshenie).HasColumnName("idPoseshenie");
            entity.Property(e => e.DateOfPriem).HasColumnType("datetime");
            entity.Property(e => e.PacientIdPacient).HasColumnName("Pacient_idPacient");
            entity.Property(e => e.VidIdVid).HasColumnName("VID_idVID");
            entity.Property(e => e.VrachIdVrach).HasColumnName("Vrach_idVrach");

            entity.HasOne(d => d.PacientIdPacientNavigation).WithMany(p => p.Poseshenies)
                .HasForeignKey(d => d.PacientIdPacient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Poseshenie_Pacient1");

            entity.HasOne(d => d.VidIdV).WithMany(p => p.Poseshenies)
                .HasForeignKey(d => d.VidIdVid)
                .HasConstraintName("fk_Poseshenie_VID1");

            entity.HasOne(d => d.VrachIdVrachNavigation).WithMany(p => p.Poseshenies)
                .HasForeignKey(d => d.VrachIdVrach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Poseshenie_Vrach1");
        });

        modelBuilder.Entity<Smena>(entity =>
        {
            entity.HasKey(e => e.IdSmena).HasName("PRIMARY");

            entity.ToTable("Smena");

            entity.Property(e => e.IdSmena).HasColumnName("idSmena");
            entity.Property(e => e.NameSmena).HasMaxLength(45);
        });

        modelBuilder.Entity<Sotrudnik>(entity =>
        {
            entity.HasKey(e => e.IdSotrudnik).HasName("PRIMARY");

            entity.ToTable("Sotrudnik");

            entity.HasIndex(e => e.DostupIdDostup, "fk_Sotrudnik_Dostup1_idx");

            entity.Property(e => e.IdSotrudnik).HasColumnName("idSotrudnik");
            entity.Property(e => e.DostupIdDostup).HasColumnName("Dostup_idDostup");
            entity.Property(e => e.SotrudnikFamiliya).HasMaxLength(450);
            entity.Property(e => e.SotrudnikImya).HasMaxLength(450);
            entity.Property(e => e.SotrudnikLogin).HasMaxLength(450);
            entity.Property(e => e.SotrudnikOtch).HasMaxLength(450);
            entity.Property(e => e.SotrudnikPass).HasMaxLength(450);

            entity.HasOne(d => d.DostupIdDostupNavigation).WithMany(p => p.Sotrudniks)
                .HasForeignKey(d => d.DostupIdDostup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Sotrudnik_Dostup1");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("PRIMARY");

            entity.ToTable("Status");

            entity.Property(e => e.IdStatus).HasColumnName("idStatus");
            entity.Property(e => e.NameStatus).HasMaxLength(100);
        });

        modelBuilder.Entity<Vid>(entity =>
        {
            entity.HasKey(e => e.IdVid).HasName("PRIMARY");

            entity.ToTable("VID");

            entity.Property(e => e.IdVid).HasColumnName("idVID");
            entity.Property(e => e.Vid1)
                .HasMaxLength(45)
                .HasColumnName("VID");
        });

        modelBuilder.Entity<Vrach>(entity =>
        {
            entity.HasKey(e => e.IdVrach).HasName("PRIMARY");

            entity.ToTable("Vrach");

            entity.HasIndex(e => e.DolzhnostIdDolzhnost, "fk_Vrach_Dolzhnost1_idx");

            entity.HasIndex(e => e.SmenaIdSmena, "fk_Vrach_Smena_idx");

            entity.HasIndex(e => e.StatusIdStatus, "fk_Vrach_Status1_idx");

            entity.Property(e => e.IdVrach).HasColumnName("idVrach");
            entity.Property(e => e.DolzhnostIdDolzhnost).HasColumnName("Dolzhnost_idDolzhnost");
            entity.Property(e => e.SmenaIdSmena).HasColumnName("Smena_idSmena");
            entity.Property(e => e.StatusIdStatus).HasColumnName("Status_idStatus");
            entity.Property(e => e.VrachFamiliya).HasMaxLength(450);
            entity.Property(e => e.VrachImya).HasMaxLength(100);
            entity.Property(e => e.VrachOtch).HasMaxLength(100);

            entity.HasOne(d => d.DolzhnostIdDolzhnostNavigation).WithMany(p => p.Vraches)
                .HasForeignKey(d => d.DolzhnostIdDolzhnost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Vrach_Dolzhnost1");

            entity.HasOne(d => d.SmenaIdSmenaNavigation).WithMany(p => p.Vraches)
                .HasForeignKey(d => d.SmenaIdSmena)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Vrach_Smena");

            entity.HasOne(d => d.StatusIdStatusNavigation).WithMany(p => p.Vraches)
                .HasForeignKey(d => d.StatusIdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Vrach_Status1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
