using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contexts
{
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options) //de onde pega options
        : base(options){}
        public DbSet<Evento> Eventos { get; set; } //Referencia, mapeamento de uma classe para se transformar
                                                   //em BD
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>()
            .HasKey(PalestranteEvento => new{PalestranteEvento.EventoId, PalestranteEvento.PalestranteId});
            modelBuilder.Entity<Evento>()
            .HasMany(evento => evento.RedesSociais)
            .WithOne(redeSocial => redeSocial.Evento)
            .OnDelete(DeleteBehavior.Cascade);
        }

        
    }
}