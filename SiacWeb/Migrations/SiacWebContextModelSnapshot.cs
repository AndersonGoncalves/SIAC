﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SiacWeb.Models;

namespace SiacWeb.Migrations
{
    [DbContext(typeof(SiacWebContext))]
    partial class SiacWebContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SiacWeb.Models.CentroDeCusto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ativo");

                    b.Property<string>("CNPJ")
                        .HasMaxLength(14);

                    b.Property<string>("CPF")
                        .HasMaxLength(11);

                    b.Property<string>("Celular")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("DataAlteracao");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime?>("DataDeNascimento");

                    b.Property<int>("EmUso");

                    b.Property<string>("Email")
                        .HasMaxLength(100);

                    b.Property<int>("EmpresaId");

                    b.Property<string>("Facebook")
                        .HasMaxLength(100);

                    b.Property<string>("IE")
                        .HasMaxLength(14);

                    b.Property<string>("IM")
                        .HasMaxLength(20);

                    b.Property<string>("Instagram")
                        .HasMaxLength(100);

                    b.Property<string>("Maquina")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("NomeFantasia")
                        .HasMaxLength(50);

                    b.Property<string>("NomeMae")
                        .HasMaxLength(80);

                    b.Property<string>("NomePai")
                        .HasMaxLength(80);

                    b.Property<string>("Observacao");

                    b.Property<string>("RG")
                        .HasMaxLength(20);

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("Site")
                        .HasMaxLength(100);

                    b.Property<string>("Telegram")
                        .HasMaxLength(20);

                    b.Property<int>("TipoDePessoa");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Whatsapp")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("CentroDeCusto");
                });

            modelBuilder.Entity("SiacWeb.Models.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ativo");

                    b.Property<string>("CEI")
                        .HasMaxLength(12);

                    b.Property<string>("CPF")
                        .HasMaxLength(11);

                    b.Property<string>("CnpjBase")
                        .HasMaxLength(8);

                    b.Property<DateTime?>("DataAlteracao");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("EmUso");

                    b.Property<string>("Maquina")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Observacao");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("Site")
                        .HasMaxLength(100);

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("SiacWeb.Models.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ativo");

                    b.Property<string>("CNPJ")
                        .HasMaxLength(14);

                    b.Property<string>("CPF")
                        .HasMaxLength(11);

                    b.Property<string>("Celular")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("DataAlteracao");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime?>("DataDeNascimento");

                    b.Property<int>("EmUso");

                    b.Property<string>("Email")
                        .HasMaxLength(100);

                    b.Property<int>("EmpresaId");

                    b.Property<string>("Facebook")
                        .HasMaxLength(100);

                    b.Property<string>("IE")
                        .HasMaxLength(14);

                    b.Property<string>("IM")
                        .HasMaxLength(20);

                    b.Property<string>("Instagram")
                        .HasMaxLength(100);

                    b.Property<string>("Maquina")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("NomeFantasia")
                        .HasMaxLength(50);

                    b.Property<string>("NomeMae")
                        .HasMaxLength(80);

                    b.Property<string>("NomePai")
                        .HasMaxLength(80);

                    b.Property<string>("Observacao");

                    b.Property<string>("RG")
                        .HasMaxLength(20);

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("Site")
                        .HasMaxLength(100);

                    b.Property<string>("Telegram")
                        .HasMaxLength(20);

                    b.Property<int>("TipoDePessoa");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Whatsapp")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Fornecedor");
                });

            modelBuilder.Entity("SiacWeb.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apelido")
                        .HasMaxLength(50);

                    b.Property<int>("Ativo");

                    b.Property<string>("CPF")
                        .HasMaxLength(11);

                    b.Property<string>("Celular")
                        .HasMaxLength(20);

                    b.Property<int?>("CentroDeCustoId");

                    b.Property<double>("Comissao");

                    b.Property<DateTime?>("DataAlteracao");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime?>("DataDeNascimento");

                    b.Property<int>("EmUso");

                    b.Property<string>("Email")
                        .HasMaxLength(100);

                    b.Property<int>("EmpresaId");

                    b.Property<string>("Facebook")
                        .HasMaxLength(100);

                    b.Property<string>("Instagram")
                        .HasMaxLength(100);

                    b.Property<string>("Maquina")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("NomeMae")
                        .HasMaxLength(80);

                    b.Property<string>("NomePai")
                        .HasMaxLength(80);

                    b.Property<string>("Observacao");

                    b.Property<string>("RG")
                        .HasMaxLength(20);

                    b.Property<string>("Telegram")
                        .HasMaxLength(20);

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Whatsapp")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("CentroDeCustoId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("SiacWeb.Models.CentroDeCusto", b =>
                {
                    b.HasOne("SiacWeb.Models.Empresa", "Empresa")
                        .WithMany("CentroDeCustos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("SiacWeb.Models.Comum.DadosBancarios", "DadosBancarios", b1 =>
                        {
                            b1.Property<int>("CentroDeCustoId1")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Agencia")
                                .HasMaxLength(10);

                            b1.Property<int>("CentroDeCustoId");

                            b1.Property<string>("CodigoBanco")
                                .HasMaxLength(10);

                            b1.Property<string>("Conta")
                                .HasMaxLength(20);

                            b1.ToTable("CentroDeCusto");

                            b1.HasOne("SiacWeb.Models.CentroDeCusto")
                                .WithOne("DadosBancarios")
                                .HasForeignKey("SiacWeb.Models.Comum.DadosBancarios", "CentroDeCustoId1")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("SiacWeb.Models.Comum.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<int>("CentroDeCustoId1")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Bairro")
                                .HasMaxLength(50);

                            b1.Property<string>("CEP")
                                .HasMaxLength(10);

                            b1.Property<int>("CentroDeCustoId");

                            b1.Property<string>("Cidade")
                                .HasMaxLength(50);

                            b1.Property<string>("Logradouro")
                                .HasMaxLength(150);

                            b1.Property<string>("Telefone")
                                .HasMaxLength(20);

                            b1.Property<string>("TipoDeLogradouro")
                                .HasMaxLength(10);

                            b1.Property<string>("UF")
                                .HasMaxLength(2);

                            b1.ToTable("CentroDeCusto");

                            b1.HasOne("SiacWeb.Models.CentroDeCusto")
                                .WithOne("Endereco")
                                .HasForeignKey("SiacWeb.Models.Comum.Endereco", "CentroDeCustoId1")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("SiacWeb.Models.Fornecedor", b =>
                {
                    b.HasOne("SiacWeb.Models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("SiacWeb.Models.Comum.DadosBancarios", "DadosBancarios", b1 =>
                        {
                            b1.Property<int>("FornecedorId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Agencia")
                                .HasMaxLength(10);

                            b1.Property<string>("CodigoBanco")
                                .HasMaxLength(10);

                            b1.Property<string>("Conta")
                                .HasMaxLength(20);

                            b1.ToTable("Fornecedor");

                            b1.HasOne("SiacWeb.Models.Fornecedor")
                                .WithOne("DadosBancarios")
                                .HasForeignKey("SiacWeb.Models.Comum.DadosBancarios", "FornecedorId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("SiacWeb.Models.Comum.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<int>("FornecedorId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Bairro")
                                .HasMaxLength(50);

                            b1.Property<string>("CEP")
                                .HasMaxLength(10);

                            b1.Property<string>("Cidade")
                                .HasMaxLength(50);

                            b1.Property<string>("Logradouro")
                                .HasMaxLength(150);

                            b1.Property<string>("Telefone")
                                .HasMaxLength(20);

                            b1.Property<string>("TipoDeLogradouro")
                                .HasMaxLength(10);

                            b1.Property<string>("UF")
                                .HasMaxLength(2);

                            b1.ToTable("Fornecedor");

                            b1.HasOne("SiacWeb.Models.Fornecedor")
                                .WithOne("Endereco")
                                .HasForeignKey("SiacWeb.Models.Comum.Endereco", "FornecedorId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("SiacWeb.Models.Funcionario", b =>
                {
                    b.HasOne("SiacWeb.Models.CentroDeCusto", "CentroDeCusto")
                        .WithMany()
                        .HasForeignKey("CentroDeCustoId");

                    b.HasOne("SiacWeb.Models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("SiacWeb.Models.Comum.DadosBancarios", "DadosBancarios", b1 =>
                        {
                            b1.Property<int>("FuncionarioId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Agencia")
                                .HasMaxLength(10);

                            b1.Property<string>("CodigoBanco")
                                .HasMaxLength(10);

                            b1.Property<string>("Conta")
                                .HasMaxLength(20);

                            b1.ToTable("Funcionario");

                            b1.HasOne("SiacWeb.Models.Funcionario")
                                .WithOne("DadosBancarios")
                                .HasForeignKey("SiacWeb.Models.Comum.DadosBancarios", "FuncionarioId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("SiacWeb.Models.Comum.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<int>("FuncionarioId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Bairro")
                                .HasMaxLength(50);

                            b1.Property<string>("CEP")
                                .HasMaxLength(10);

                            b1.Property<string>("Cidade")
                                .HasMaxLength(50);

                            b1.Property<string>("Logradouro")
                                .HasMaxLength(150);

                            b1.Property<string>("Telefone")
                                .HasMaxLength(20);

                            b1.Property<string>("TipoDeLogradouro")
                                .HasMaxLength(10);

                            b1.Property<string>("UF")
                                .HasMaxLength(2);

                            b1.ToTable("Funcionario");

                            b1.HasOne("SiacWeb.Models.Funcionario")
                                .WithOne("Endereco")
                                .HasForeignKey("SiacWeb.Models.Comum.Endereco", "FuncionarioId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
