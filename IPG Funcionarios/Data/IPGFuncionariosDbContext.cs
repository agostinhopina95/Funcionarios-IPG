﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IPG_Funcionarios.Models;

namespace IPG_Funcionarios.Models
{
    public class IPGFuncionariosDbContext : DbContext
    {
        public IPGFuncionariosDbContext(DbContextOptions<IPGFuncionariosDbContext> options)
            : base(options)
        {

        }

        public DbSet<IPG_Funcionarios.Models.Professor> Professor { get; set; }
        public DbSet<IPG_Funcionarios.Models.Departamento> Departamento { get; set; }
        public DbSet<IPG_Funcionarios.Models.Funcionario> Funcionario { get; set; }
        public DbSet<IPG_Funcionarios.Models.Servico> Servico { get; set; }
        public DbSet<IPG_Funcionarios.Models.Escola> Escola { get; set; }
        public DbSet<IPG_Funcionarios.Models.Cargo> Cargo { get; set; }
        public DbSet<IPG_Funcionarios.Models.Tarefa> Tarefa { get; set; }
        public DbSet<IPG_Funcionarios.Models.Tipos_Tarefas> Tipos_Tarefas { get; set; }
        public DbSet<IPG_Funcionarios.Models.Tarefas_Professor> tarefas_Professors { get; set; }
         public DbSet<IPG_Funcionarios.Models.Feria> Feria  { get; set; }
  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relação 1 -> N ( Cada Departamento com vários Professores )
            modelBuilder.Entity<Professor>()
                .HasOne(mm => mm.Departamento)
                .WithMany(m => m.Professores)
                .HasForeignKey(mm => mm.DepartamentoForeignKey)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);

            //Relação 1 -> N ( Cada Escola com vários Departamentos )
            modelBuilder.Entity<Departamento>()
                .HasOne(mm => mm.Escola)
                .WithMany(m => m.Departamentos)
                .HasForeignKey(mm => mm.EscolaForeignKey)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);

            //Relação 1 -> N ( Cada Funcionário com vários Serviços )
            modelBuilder.Entity<Servico>()
                .HasOne(mm => mm.Funcionario)
                .WithMany(m => m.servicos)
                .HasForeignKey(mm => mm.FuncionarioForeignKey)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);

            //Relação 1 -> N ( Cada Funcionário com várias Férias )
            modelBuilder.Entity<Feria>()
                .HasOne(mm => mm.Funcionario)
                .WithMany(m => m.Feria)
                .HasForeignKey(mm => mm.FuncionarioForeignKey)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }

    }

}
