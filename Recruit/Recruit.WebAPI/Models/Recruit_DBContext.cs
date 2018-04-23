using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Recruit.WebAPI.Models
{
    public partial class Recruit_DBContext : DbContext
    {
        public virtual DbSet<TAdmConfiguracion> TAdmConfiguracion { get; set; }
        public virtual DbSet<TAdmEmpresa> TAdmEmpresa { get; set; }
        public virtual DbSet<TAdmReclutador> TAdmReclutador { get; set; }
        public virtual DbSet<TOfertaReclutador> TOfertaReclutador { get; set; }
        public virtual DbSet<TRecCandidato> TRecCandidato { get; set; }
        public virtual DbSet<TRecCandmail> TRecCandmail { get; set; }
        public virtual DbSet<TRecDetmailkword> TRecDetmailkword { get; set; }
        public virtual DbSet<TRecEntrevista> TRecEntrevista { get; set; }
        public virtual DbSet<TRecEstado> TRecEstado { get; set; }
        public virtual DbSet<TRecIdioma> TRecIdioma { get; set; }
        public virtual DbSet<TRecKeyword> TRecKeyword { get; set; }
        public virtual DbSet<TRecOfertatrabajo> TRecOfertatrabajo { get; set; }
        public virtual DbSet<TRecProbabilidad> TRecProbabilidad { get; set; }
        public virtual DbSet<TSegBitacora> TSegBitacora { get; set; }
        public virtual DbSet<TSegMenu> TSegMenu { get; set; }
        public virtual DbSet<TSegRol> TSegRol { get; set; }
        public virtual DbSet<TSegUsuario> TSegUsuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=LAB2-PC10;Database=Recruit_DB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TAdmConfiguracion>(entity =>
            {
                entity.HasKey(e => e.PKCONFIGURACION);

                entity.ToTable("t_adm_configuracion");

                entity.Property(e => e.PKCONFIGURACION)
                    .HasColumnName("PKCONFIGURACION")
                    .ValueGeneratedNever();

                entity.Property(e => e.CORREOCONFIGURACION)
                    .IsRequired()
                    .HasColumnName("CORREOCONFIGURACION")
                    .HasColumnType("nchar(50)");

                entity.Property(e => e.PATHCONFIGURACION)
                    .IsRequired()
                    .HasColumnName("PATHCONFIGURACION")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TAdmEmpresa>(entity =>
            {
                entity.HasKey(e => e.Pkempresa);

                entity.ToTable("t_adm_empresa");

                entity.Property(e => e.Pkempresa)
                    .HasColumnName("PKEMPRESA")
                    .ValueGeneratedNever();

                entity.Property(e => e.Contactoempresa)
                    .HasColumnName("CONTACTOEMPRESA")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'Sin Información')");

                entity.Property(e => e.Direccionempresa)
                    .HasColumnName("DIRECCIONEMPRESA")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'Sin Información')");

                entity.Property(e => e.Emailempresa)
                    .HasColumnName("EMAILEMPRESA")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'Sin Información')");

                entity.Property(e => e.Estadoempresa)
                    .HasColumnName("ESTADOEMPRESA")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombreempresa)
                    .IsRequired()
                    .HasColumnName("NOMBREEMPRESA")
                    .HasMaxLength(50);

                entity.Property(e => e.Telefonoempresa)
                    .HasColumnName("TELEFONOEMPRESA")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("(N'Sin Información')");
            });

            modelBuilder.Entity<TAdmReclutador>(entity =>
            {
                entity.HasKey(e => e.Pkreclutador);

                entity.ToTable("t_adm_reclutador");

                entity.Property(e => e.Pkreclutador)
                    .HasColumnName("PKRECLUTADOR")
                    .ValueGeneratedNever();

                entity.Property(e => e.Correoreclutador)
                    .HasColumnName("CORREORECLUTADOR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estadoreclutador).HasColumnName("ESTADORECLUTADOR");

                entity.Property(e => e.Nombrereclutador)
                    .HasColumnName("NOMBRERECLUTADOR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefonoreclutador)
                    .HasColumnName("TELEFONORECLUTADOR")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TOfertaReclutador>(entity =>
            {
                entity.HasKey(e => new { e.Pkofertatrabajo, e.Pkreclutador });

                entity.ToTable("t_oferta_reclutador");

                entity.Property(e => e.Pkofertatrabajo).HasColumnName("PKOFERTATRABAJO");

                entity.Property(e => e.Pkreclutador).HasColumnName("PKRECLUTADOR");

                entity.HasOne(d => d.PkofertatrabajoNavigation)
                    .WithMany(p => p.TOfertaReclutador)
                    .HasForeignKey(d => d.Pkofertatrabajo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_oferta_reclutador_t_rec_ofertatrabajo");

                entity.HasOne(d => d.PkreclutadorNavigation)
                    .WithMany(p => p.TOfertaReclutador)
                    .HasForeignKey(d => d.Pkreclutador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_oferta_reclutador_t_adm_reclutador");
            });

            modelBuilder.Entity<TRecCandidato>(entity =>
            {
                entity.HasKey(e => e.Pkcandidato);

                entity.ToTable("t_rec_candidato");

                entity.Property(e => e.Pkcandidato).HasColumnName("PKCANDIDATO");

                entity.Property(e => e.Añosexperiencia).HasColumnName("AÑOSEXPERIENCIA");

                entity.Property(e => e.Blacklist).HasColumnName("BLACKLIST");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnName("CORREO")
                    .HasMaxLength(50);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("DIRECCION")
                    .HasMaxLength(50);

                entity.Property(e => e.Estado).HasColumnName("ESTADO");

                entity.Property(e => e.Estadocivil).HasColumnName("ESTADOCIVIL");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(50);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("TELEFONO")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<TRecCandmail>(entity =>
            {
                entity.HasKey(e => e.Pkcandmail);

                entity.ToTable("t_rec_candmail");

                entity.Property(e => e.Pkcandmail).HasColumnName("PKCANDMAIL");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnName("CORREO")
                    .HasMaxLength(50);

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasColumnName("FILENAME")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<TRecDetmailkword>(entity =>
            {
                entity.HasKey(e => e.Pkdetmailkword);

                entity.ToTable("t_rec_detmailkword");

                entity.Property(e => e.Pkdetmailkword).HasColumnName("PKDETMAILKWORD");

                entity.Property(e => e.Fkcandmail).HasColumnName("FKCANDMAIL");

                entity.Property(e => e.Fkkword).HasColumnName("FKKWORD");

                entity.HasOne(d => d.FkcandmailNavigation)
                    .WithMany(p => p.TRecDetmailkword)
                    .HasForeignKey(d => d.Fkcandmail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_rec_detmailkword_t_rec_candmail");

                entity.HasOne(d => d.FkkwordNavigation)
                    .WithMany(p => p.TRecDetmailkword)
                    .HasForeignKey(d => d.Fkkword)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_rec_detmailkword_t_rec_keyword");
            });

            modelBuilder.Entity<TRecEntrevista>(entity =>
            {
                entity.HasKey(e => e.Pkentrevista);

                entity.ToTable("t_rec_entrevista");

                entity.Property(e => e.Pkentrevista).HasColumnName("PKENTREVISTA");

                entity.Property(e => e.Expectsalentrevista)
                    .HasColumnName("EXPECTSALENTREVISTA")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Experienciaentrevita)
                    .IsRequired()
                    .HasColumnName("EXPERIENCIAENTREVITA")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Fkcandidato).HasColumnName("FKCANDIDATO");

                entity.Property(e => e.Fkestado).HasColumnName("FKESTADO");

                entity.Property(e => e.Fkidioma).HasColumnName("FKIDIOMA");

                entity.Property(e => e.Fkprobabilidad).HasColumnName("FKPROBABILIDAD");

                entity.Property(e => e.Referenciasentrevista)
                    .IsRequired()
                    .HasColumnName("REFERENCIASENTREVISTA")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Trabajoantentrevista)
                    .IsRequired()
                    .HasColumnName("TRABAJOANTENTREVISTA")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkestadoNavigation)
                    .WithMany(p => p.TRecEntrevista)
                    .HasForeignKey(d => d.Fkestado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_rec_entrevista_t_rec_estado");

                entity.HasOne(d => d.FkidiomaNavigation)
                    .WithMany(p => p.TRecEntrevista)
                    .HasForeignKey(d => d.Fkidioma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_rec_entrevista_t_rec_idioma");

                entity.HasOne(d => d.FkprobabilidadNavigation)
                    .WithMany(p => p.TRecEntrevista)
                    .HasForeignKey(d => d.Fkprobabilidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_rec_entrevista_t_rec_probabilidad");
            });

            modelBuilder.Entity<TRecEstado>(entity =>
            {
                entity.HasKey(e => e.Pkestado);

                entity.ToTable("t_rec_estado");

                entity.Property(e => e.Pkestado).HasColumnName("PKESTADO");

                entity.Property(e => e.Descripcionestado)
                    .IsRequired()
                    .HasColumnName("DESCRIPCIONESTADO")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TRecIdioma>(entity =>
            {
                entity.HasKey(e => e.Pkidioma);

                entity.ToTable("t_rec_idioma");

                entity.Property(e => e.Pkidioma).HasColumnName("PKIDIOMA");

                entity.Property(e => e.Descripcionidioma)
                    .IsRequired()
                    .HasColumnName("DESCRIPCIONIDIOMA")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TRecKeyword>(entity =>
            {
                entity.HasKey(e => e.Pkkword);

                entity.ToTable("t_rec_keyword");

                entity.Property(e => e.Pkkword).HasColumnName("PKKWORD");

                entity.Property(e => e.Keyword)
                    .IsRequired()
                    .HasColumnName("KEYWORD")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<TRecOfertatrabajo>(entity =>
            {
                entity.HasKey(e => e.Pkofertatrabajo);

                entity.ToTable("t_rec_ofertatrabajo");

                entity.Property(e => e.Pkofertatrabajo).HasColumnName("PKOFERTATRABAJO");

                entity.Property(e => e.BeneficiosLab)
                    .IsRequired()
                    .HasColumnName("BENEFICIOS_LAB")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ConocimientosDes)
                    .HasColumnName("CONOCIMIENTOS_DES")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ConocimientosReq)
                    .HasColumnName("CONOCIMIENTOS_REQ")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Empresa).HasColumnName("EMPRESA");

                entity.Property(e => e.Idioma)
                    .HasColumnName("IDIOMA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Labores)
                    .HasColumnName("LABORES")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NivelIdioma).HasColumnName("NIVEL_IDIOMA");

                entity.Property(e => e.Salario)
                    .HasColumnName("SALARIO")
                    .HasColumnType("numeric(13, 2)");
            });

            modelBuilder.Entity<TRecProbabilidad>(entity =>
            {
                entity.HasKey(e => e.Pkprobabilidad);

                entity.ToTable("t_rec_probabilidad");

                entity.Property(e => e.Pkprobabilidad).HasColumnName("PKPROBABILIDAD");

                entity.Property(e => e.Descripcionprobabilidad)
                    .HasColumnName("DESCRIPCIONPROBABILIDAD")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TSegBitacora>(entity =>
            {
                entity.HasKey(e => e.Pkbitacora);

                entity.ToTable("t_seg_bitacora");

                entity.Property(e => e.Pkbitacora)
                    .HasColumnName("PKBITACORA")
                    .ValueGeneratedNever();

                entity.Property(e => e.Accionbitacora)
                    .IsRequired()
                    .HasColumnName("ACCIONBITACORA")
                    .HasMaxLength(50);

                entity.Property(e => e.Fechabitacora)
                    .HasColumnName("FECHABITACORA")
                    .HasColumnType("datetime");

                entity.Property(e => e.Paginabitacora)
                    .IsRequired()
                    .HasColumnName("PAGINABITACORA")
                    .HasMaxLength(50);

                entity.Property(e => e.Registrobitacora)
                    .IsRequired()
                    .HasColumnName("REGISTROBITACORA")
                    .HasColumnType("text");

                entity.Property(e => e.Tablabitacora)
                    .IsRequired()
                    .HasColumnName("TABLABITACORA")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TSegMenu>(entity =>
            {
                entity.HasKey(e => e.Pkmenu);

                entity.ToTable("t_seg_menu");

                entity.Property(e => e.Pkmenu)
                    .HasColumnName("PKMENU")
                    .ValueGeneratedNever();

                entity.Property(e => e.Etiquetamenu)
                    .IsRequired()
                    .HasColumnName("ETIQUETAMENU")
                    .HasMaxLength(150);

                entity.Property(e => e.Fkrol).HasColumnName("FKROL");

                entity.Property(e => e.Staturegister)
                    .HasColumnName("STATUREGISTER")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Urlmenu)
                    .IsRequired()
                    .HasColumnName("URLMENU")
                    .HasMaxLength(500);

                entity.HasOne(d => d.FkrolNavigation)
                    .WithMany(p => p.TSegMenu)
                    .HasForeignKey(d => d.Fkrol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_SEG_MENU_T_SEG_ROL");
            });

            modelBuilder.Entity<TSegRol>(entity =>
            {
                entity.HasKey(e => e.Pkrol);

                entity.ToTable("t_seg_rol");

                entity.Property(e => e.Pkrol)
                    .HasColumnName("PKROL")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nombrerol)
                    .IsRequired()
                    .HasColumnName("NOMBREROL")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<TSegUsuario>(entity =>
            {
                entity.HasKey(e => e.Pkusuario);

                entity.ToTable("t_seg_usuario");

                entity.Property(e => e.Pkusuario)
                    .HasColumnName("PKUSUARIO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Activousuario)
                    .HasColumnName("ACTIVOUSUARIO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Cedulausuario)
                    .IsRequired()
                    .HasColumnName("CEDULAUSUARIO")
                    .HasMaxLength(50);

                entity.Property(e => e.Fkrol).HasColumnName("FKROL");

                entity.Property(e => e.Loginusuario)
                    .IsRequired()
                    .HasColumnName("LOGINUSUARIO")
                    .HasMaxLength(50);

                entity.Property(e => e.Nombreusuario)
                    .IsRequired()
                    .HasColumnName("NOMBREUSUARIO")
                    .HasMaxLength(500);

                entity.Property(e => e.Passwordusuario)
                    .IsRequired()
                    .HasColumnName("PASSWORDUSUARIO")
                    .HasMaxLength(500);

                entity.Property(e => e.Statusregister)
                    .HasColumnName("STATUSREGISTER")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.FkrolNavigation)
                    .WithMany(p => p.TSegUsuario)
                    .HasForeignKey(d => d.Fkrol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_SEG_USUARIO_T_SEG_ROL");
            });
        }
    }
}
