using ControlDeRiesgoFinanciero.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeRiesgoFinanciero.AccesoADatos
{
    public class Contexto : DbContext
{
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonasTabla>().ToTable("PERSONAS_TABLA");
        modelBuilder.Entity<ActividadPersonaTabla>().ToTable("ACTIVIDAD_PERSONA_TABLA");
        modelBuilder.Entity<ArchivoAnalisisTabla>().ToTable("ARCHIVO_ANALISIS_TABLA");
        modelBuilder.Entity<BitacoraEventosTabla>().ToTable("BITACORA_EVENTOS_TABLA");
        modelBuilder.Entity<ActividadFinancieraTabla>().ToTable("ACTIVIDAD_FINANCIERA_TABLA");
        modelBuilder.Entity<PalabrasClaveTabla>().ToTable("PALABRAS_CLAVE_TABLA");
        modelBuilder.Entity<AnalizarPersonaTabla>().ToTable("ANALISIS_PERSONA_TABLA");
        }

    public DbSet<PersonasTabla> PersonasTabla { get; set; }
    public DbSet<ActividadPersonaTabla> ActividadPersonaTabla { get; set; }
    public DbSet<ArchivoAnalisisTabla> ArchivoAnalisisTabla { get; set; }
    public DbSet<BitacoraEventosTabla> BitacoraEventosTabla { get; set; }
    public DbSet<ActividadFinancieraTabla> ActividadFinancieraTabla { get; set; }
    public DbSet<PalabrasClaveTabla> PalabrasClaveTabla { get; set; }
    public DbSet<AnalizarPersonaTabla> AnalizarPersonaTabla { get; set; }
    }
}
