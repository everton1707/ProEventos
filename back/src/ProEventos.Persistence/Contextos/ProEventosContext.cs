﻿using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contextos
{

    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options) :
        base(options){ }
        public DbSet<Evento> Eventos { get;set;}
        public DbSet<Lote> Lotes { get;set;}
        public DbSet<Palestrante> Palestrantes { get;set;}
        public DbSet<PalestranteEvento> PalestrantesEventos { get;set;}
        public DbSet<RedeSocial> RedesSociais { get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new {PE.EventoId, PE.PalestranteId});
            
            modelBuilder.Entity<Evento>()
                .HasMany(e => e.RedesSociais)
                .WithOne(rs => rs.Evento)//cada rede social com um evento
                .OnDelete(DeleteBehavior.Cascade);//deletar em cascata 
            modelBuilder.Entity<Palestrante>()
                .HasMany(e => e.RedesSociais)
                .WithOne(rs => rs.Palestrante)//cada rede social de um palestrante
                .OnDelete(DeleteBehavior.Cascade);//deletar em cascata 
        }
        
    }
}
