using ATIEnvioSMS.LayerData.Models.Entities.cod;
using ATIEnvioSMS.LayerData.Models.Entities.sms;
using ATIEnvioSMS.LayerData.Models.Entities.sys;
using Microsoft.EntityFrameworkCore;

namespace ATIEnvioSMS.LayerData.Data;

public partial class SistemaDbContext : DbContext
{
    public SistemaDbContext()
    {
    }

    public SistemaDbContext(DbContextOptions<SistemaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auditorium> Auditoria { get; set; }

    public virtual DbSet<ConfigApitodu> ConfigApitodus { get; set; }

    public virtual DbSet<Contacto> Contactos { get; set; }

    public virtual DbSet<ContactosGrupoRelacion> ContactosGrupoRelacions { get; set; }

    public virtual DbSet<GrupoContactos> GrupoContactos { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Notificacione> Notificaciones { get; set; }

    public virtual DbSet<Provincia> Provincias { get; set; }

    public virtual DbSet<RegSms> RegSms { get; set; }

    public virtual DbSet<RegSmsDetallesContacto> RegSmsDetallesContactos { get; set; }

    public virtual DbSet<RegSmsDetallesContactosGrupo> RegSmsDetallesContactosGrupos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=BDConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Auditorium>(entity =>
        {
            entity.HasKey(e => e.Idlog).HasName("logs_pkey");

    entity.ToTable("auditoria", "sys");

            entity.Property(e => e.Idlog)
                .HasDefaultValueSql("nextval('sys.logs_idlog_seq'::regclass)")
                .HasColumnName("idlog");
    entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .HasColumnName("descripcion");
    entity.Property(e => e.DireccionIp)
                .HasMaxLength(15)
                .HasColumnName("direccion_ip");
    entity.Property(e => e.Fecha).HasColumnName("fecha");
    entity.Property(e => e.Hora)
                .HasPrecision(0)
                .HasColumnName("hora");
    entity.Property(e => e.Idusuario).HasColumnName("idusuario");
});

        modelBuilder.Entity<ConfigApitodu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("config_apidesoft_pkey");

entity.ToTable("config_apitodus", "sys");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('sys.config_apidesoft_id_seq'::regclass)")
                .HasColumnName("id");
        });


        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.HasKey(e => e.Idcontacto).HasName("contactos_pkey");

            entity.ToTable("contactos", "sms");

            entity.HasIndex(e => e.LineaCorporativa, "contactos_linea_corporativa_key").IsUnique();

            entity.Property(e => e.Idcontacto).HasColumnName("idcontacto");
            entity.Property(e => e.Cargo)
                .HasMaxLength(50)
                .HasColumnName("cargo");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.FechaAct).HasColumnName("fecha_act");
            entity.Property(e => e.Idempresa).HasColumnName("idempresa");
            entity.Property(e => e.IdusuarioAct).HasColumnName("idusuario_act");
            entity.Property(e => e.IdusuarioAgrega).HasColumnName("idusuario_agrega");
            entity.Property(e => e.LineaCorporativa)
                .HasMaxLength(10)
                .HasColumnName("linea_corporativa");
            entity.Property(e => e.NombreTrabajador)
                .HasMaxLength(50)
                .HasColumnName("nombre_trabajador");

            entity.HasOne(d => d.IdempresaNavigation).WithMany(p => p.Contactos)
                .HasForeignKey(d => d.Idempresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contactos_fk_empresa");

            entity.HasOne(d => d.IdusuarioActNavigation).WithMany(p => p.ContactoIdusuarioActNavigations)
                .HasForeignKey(d => d.IdusuarioAct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contactos_fk_act");

            entity.HasOne(d => d.IdusuarioAgregaNavigation).WithMany(p => p.ContactoIdusuarioAgregaNavigations)
                .HasForeignKey(d => d.IdusuarioAgrega)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contactos_fk_agrega");
        });

        modelBuilder.Entity<ContactosGrupoRelacion>(entity =>
        {
            entity.HasKey(e => e.IdContactoGrupo).HasName("contactos_grupo_relacion_pkey");

            entity.ToTable("contactos_grupo_relacion", "sms");

            entity.Property(e => e.IdContactoGrupo)
                .HasDefaultValueSql("nextval('sms.grupo_contactos_idgrupo_contacto_seq'::regclass)")
                .HasComment("tabla para la relacion de muchos a muchos")
                .HasColumnName("idcontacto_grupo");
            entity.Property(e => e.Idcontacto).HasColumnName("idcontacto");
            entity.Property(e => e.IdContactoGrupo).HasColumnName("idgrupo_contacto");

            entity.HasOne(d => d.IdcontactoNavigation).WithMany(p => p.ContactosGrupoRelacions)
                .HasForeignKey(d => d.Idcontacto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("grupo_contactos_fk");

            entity.HasOne(d => d.IdgrupoContactoNavigation).WithMany(p => p.ContactosGrupoRelacions)
                .HasForeignKey(d => d.IdContactoGrupo)
                .HasConstraintName("contactos_grupo_fk_grupo_contactos");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.Idempresa).HasName("empresas_pkey");

            entity.ToTable("empresas", "cod");

            entity.Property(e => e.Idempresa).HasColumnName("idempresa");
            entity.Property(e => e.Activa)
                .HasDefaultValue(true)
                .HasColumnName("activa");
            entity.Property(e => e.Fecha)
                .HasComment("fecha de creado el registro")
                .HasColumnName("fecha");
            entity.Property(e => e.Hora)
                .HasPrecision(0)
                .HasColumnName("hora");
            entity.Property(e => e.Idprovincia).HasColumnName("idprovincia");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdprovinciaNavigation).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.Idprovincia)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("empresas_fk");
        });

        modelBuilder.Entity<GrupoContactos>(entity =>
        {
            entity.HasKey(e => e.IdGrupoContacto).HasName("grupos_contactos_pkey");

            entity.ToTable("grupos_contactos", "sms");

            entity.Property(e => e.IdGrupoContacto)
                .HasDefaultValueSql("nextval('sms.contactos_grupos_idcontacto_grupo_seq'::regclass)")
                .HasColumnName("idgrupo_contacto");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.FechaAct).HasColumnName("fecha_act");
            entity.Property(e => e.General)
                .HasDefaultValue(false)
                .HasComment("para verificar si es visible para todos los usuarios de la empresa")
                .HasColumnName("general");
            entity.Property(e => e.Global)
                .HasDefaultValue(false)
                .HasComment("para verificar si es visible para todos los usuarios de todas las empresas")
                .HasColumnName("global");
            entity.Property(e => e.GrupoContacto)
                .HasMaxLength(100)
                .HasColumnName("grupo_contacto");
            entity.Property(e => e.Idempresa)
                .HasComment("entidad del grupo de contactos general(entidad donde se va a ver el grupo)")
                .HasColumnName("idempresa");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.IdusuarioAct).HasColumnName("idusuario_act");
            entity.Property(e => e.IdusuarioAgrega).HasColumnName("idusuario_agrega");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.GruposContactos)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("grupos_contactos_fk");
        });

        modelBuilder.Entity<Notificacione>(entity =>
        {
            entity.HasKey(e => e.Idnotificacion).HasName("notificaciones_pkey");

            entity.ToTable("notificaciones", "sys");

            entity.Property(e => e.Idnotificacion).HasColumnName("idnotificacion");
            entity.Property(e => e.Destinatario).HasColumnName("destinatario");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Hora)
                .HasPrecision(6)
                .HasColumnName("hora");
            entity.Property(e => e.Notificacion)
                .HasMaxLength(300)
                .HasColumnName("notificacion");
            entity.Property(e => e.Remitente).HasColumnName("remitente");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.Idprovincia).HasName("provincias_pkey");

            entity.ToTable("provincias", "cod");

            entity.HasIndex(e => e.Provincia1, "provincias_provincia_key").IsUnique();

            entity.Property(e => e.Idprovincia).HasColumnName("idprovincia");
            entity.Property(e => e.Provincia1)
                .HasMaxLength(20)
                .HasColumnName("provincia");
        });

        modelBuilder.Entity<RegSms>(entity =>
        {
            entity.HasKey(e => e.Idsms).HasName("reg_sms_pkey");

            entity.ToTable("reg_sms", "sms");

            entity.Property(e => e.Idsms).HasColumnName("idsms");
            entity.Property(e => e.Enviado).HasColumnName("enviado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.FechaConfirmacion).HasColumnName("fecha_confirmacion");
            entity.Property(e => e.Hora)
                .HasPrecision(0)
                .HasColumnName("hora");
            entity.Property(e => e.HoraConfirmacion)
                .HasPrecision(0)
                .HasColumnName("hora_confirmacion");
            entity.Property(e => e.Idusuario)
                .HasComment("usuario que envia el sms")
                .HasColumnName("idusuario");
            entity.Property(e => e.Pendiente).HasColumnName("pendiente");
            entity.Property(e => e.Sms)
                .HasMaxLength(300)
                .HasColumnName("sms");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.RegSms)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("reg_sms_fk");
        });

        modelBuilder.Entity<RegSmsDetallesContacto>(entity =>
        {
            entity.HasKey(e => e.IdsmsDetalleContacto).HasName("reg_sms_detalles_contactos_pkey");

            entity.ToTable("reg_sms_detalles_contactos", "sms");

            entity.Property(e => e.IdsmsDetalleContacto).HasColumnName("idsms_detalle_contacto");
            entity.Property(e => e.Idcontacto).HasColumnName("idcontacto");
            entity.Property(e => e.Idsms).HasColumnName("idsms");

            entity.HasOne(d => d.IdcontactoNavigation).WithMany(p => p.RegSmsDetallesContactos)
                .HasForeignKey(d => d.Idcontacto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reg_sms_detalles_contactos_fk_contactos");

            entity.HasOne(d => d.IdsmsNavigation).WithMany(p => p.RegSmsDetallesContactos)
                .HasForeignKey(d => d.Idsms)
                .HasConstraintName("reg_sms_detalles_contactos_fk_sms");
        });

        modelBuilder.Entity<RegSmsDetallesContactosGrupo>(entity =>
        {
            entity.HasKey(e => e.IdsmsDetalleContactoGrupo).HasName("reg_sms_detalles_contactos_grupos_pkey");

            entity.ToTable("reg_sms_detalles_contactos_grupos", "sms");

            entity.Property(e => e.IdsmsDetalleContactoGrupo)
                .HasDefaultValueSql("nextval('sms.reg_sms_detalles_contactos_gru_idsms_detalle_grupo_contacto_seq'::regclass)")
                .HasColumnName("idsms_detalle_contacto_grupo");
            entity.Property(e => e.IdcontactoGrupo).HasColumnName("idcontacto_grupo");
            entity.Property(e => e.Idsms).HasColumnName("idsms");

            entity.HasOne(d => d.IdcontactoGrupoNavigation).WithMany(p => p.RegSmsDetallesContactosGrupos)
                .HasForeignKey(d => d.IdcontactoGrupo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reg_sms_detalles_contactos_grupos_fk");

            entity.HasOne(d => d.IdsmsNavigation).WithMany(p => p.RegSmsDetallesContactosGrupos)
                .HasForeignKey(d => d.Idsms)
                .HasConstraintName("reg_sms_detalles_contactos_grupos_fk1");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("usuarios_pkey");

            entity.ToTable("usuarios", "sys");

            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .HasColumnName("apellidos");
            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .HasColumnName("clave");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.FechaAct).HasColumnName("fecha_act");
            entity.Property(e => e.Foto).HasColumnName("foto");
            entity.Property(e => e.Idempresa).HasColumnName("idempresa");
            entity.Property(e => e.IdusuarioAct).HasColumnName("idusuario_act");
            entity.Property(e => e.IdusuarioAgrega).HasColumnName("idusuario_agrega");
            entity.Property(e => e.Isadmin)
                .HasDefaultValue(false)
                .HasColumnName("isadmin");
            entity.Property(e => e.IssuperAdmin)
                .HasDefaultValue(false)
                .HasColumnName("issuper_admin");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.SmsAsignados)
                .HasDefaultValue(0)
                .HasColumnName("sms_asignados");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(20)
                .HasColumnName("usuario");

            entity.HasOne(d => d.IdempresaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Idempresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuarios_fk");

            entity.HasOne(d => d.IdusuarioActNavigation).WithMany(p => p.InverseIdusuarioActNavigation)
                .HasForeignKey(d => d.IdusuarioAct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuarios_fk_user_act");

            entity.HasOne(d => d.IdusuarioAgregaNavigation).WithMany(p => p.InverseIdusuarioAgregaNavigation)
                .HasForeignKey(d => d.IdusuarioAgrega)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuarios_fk_user_agrega");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
