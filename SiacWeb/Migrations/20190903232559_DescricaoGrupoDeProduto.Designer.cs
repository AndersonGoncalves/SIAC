﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SiacWeb.Models;

namespace SiacWeb.Migrations
{
    [DbContext(typeof(SiacWebContext))]
    [Migration("20190903232559_DescricaoGrupoDeProduto")]
    partial class DescricaoGrupoDeProduto
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SiacWeb.Models.Auditoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Dados")
                        .IsRequired();

                    b.Property<DateTime>("DataCadastro");

                    b.Property<int>("EmpresaId");

                    b.Property<string>("Maquina")
                        .HasMaxLength(256);

                    b.Property<int>("Modulo");

                    b.Property<int>("Operacao");

                    b.Property<int>("SubModulo");

                    b.Property<string>("Usuario")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Auditoria");
                });

            modelBuilder.Entity("SiacWeb.Models.Autonomo", b =>
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
                        .HasMaxLength(256);

                    b.Property<string>("Whatsapp")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Autonomo");
                });

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
                        .HasMaxLength(256);

                    b.Property<string>("Whatsapp")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("CentroDeCusto");
                });

            modelBuilder.Entity("SiacWeb.Models.Cliente", b =>
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
                        .HasMaxLength(256);

                    b.Property<string>("Whatsapp")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Cliente");
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
                        .HasMaxLength(256);

                    b.Property<string>("Whatsapp")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("CentroDeCustoId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("SiacWeb.Models.GrupoDeProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ativo");

                    b.Property<DateTime?>("DataAlteracao");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("EmUso");

                    b.Property<int>("EmpresaId");

                    b.Property<string>("Maquina")
                        .HasMaxLength(256);

                    b.Property<string>("Observacao");

                    b.Property<string>("Usuario")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("GrupoDeProduto");
                });

            modelBuilder.Entity("SiacWeb.Models.Transportadora", b =>
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
                        .HasMaxLength(256);

                    b.Property<string>("Whatsapp")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Transportadora");
                });

            modelBuilder.Entity("SiacWeb.Models.Auditoria", b =>
                {
                    b.HasOne("SiacWeb.Models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SiacWeb.Models.Autonomo", b =>
                {
                    b.HasOne("SiacWeb.Models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("SiacWeb.Models.Comum.DadosBancarios", "DadosBancarios", b1 =>
                        {
                            b1.Property<int>("AutonomoId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Agencia")
                                .HasMaxLength(10);

                            b1.Property<string>("CodigoBanco")
                                .HasMaxLength(10);

                            b1.Property<string>("Conta")
                                .HasMaxLength(20);

                            b1.HasKey("AutonomoId");

                            b1.ToTable("Autonomo");

                            b1.HasOne("SiacWeb.Models.Autonomo")
                                .WithOne("DadosBancarios")
                                .HasForeignKey("SiacWeb.Models.Comum.DadosBancarios", "AutonomoId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("SiacWeb.Models.Comum.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<int>("AutonomoId")
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

                            b1.HasKey("AutonomoId");

                            b1.ToTable("Autonomo");

                            b1.HasOne("SiacWeb.Models.Autonomo")
                                .WithOne("Endereco")
                                .HasForeignKey("SiacWeb.Models.Comum.Endereco", "AutonomoId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("SiacWeb.Models.CentroDeCusto", b =>
                {
                    b.HasOne("SiacWeb.Models.Empresa", "Empresa")
                        .WithMany("CentroDeCustos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("SiacWeb.Models.Comum.DadosBancarios", "DadosBancarios", b1 =>
                        {
                            b1.Property<int>("CentroDeCustoId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Agencia")
                                .HasMaxLength(10);

                            b1.Property<string>("CodigoBanco")
                                .HasMaxLength(10);

                            b1.Property<string>("Conta")
                                .HasMaxLength(20);

                            b1.HasKey("CentroDeCustoId");

                            b1.ToTable("CentroDeCusto");

                            b1.HasOne("SiacWeb.Models.CentroDeCusto")
                                .WithOne("DadosBancarios")
                                .HasForeignKey("SiacWeb.Models.Comum.DadosBancarios", "CentroDeCustoId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("SiacWeb.Models.Comum.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<int>("CentroDeCustoId")
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

                            b1.HasKey("CentroDeCustoId");

                            b1.ToTable("CentroDeCusto");

                            b1.HasOne("SiacWeb.Models.CentroDeCusto")
                                .WithOne("Endereco")
                                .HasForeignKey("SiacWeb.Models.Comum.Endereco", "CentroDeCustoId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("SiacWeb.Models.Cliente", b =>
                {
                    b.HasOne("SiacWeb.Models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("SiacWeb.Models.Comum.DadosBancarios", "DadosBancarios", b1 =>
                        {
                            b1.Property<int>("ClienteId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Agencia")
                                .HasMaxLength(10);

                            b1.Property<string>("CodigoBanco")
                                .HasMaxLength(10);

                            b1.Property<string>("Conta")
                                .HasMaxLength(20);

                            b1.HasKey("ClienteId");

                            b1.ToTable("Cliente");

                            b1.HasOne("SiacWeb.Models.Cliente")
                                .WithOne("DadosBancarios")
                                .HasForeignKey("SiacWeb.Models.Comum.DadosBancarios", "ClienteId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("SiacWeb.Models.Comum.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<int>("ClienteId")
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

                            b1.HasKey("ClienteId");

                            b1.ToTable("Cliente");

                            b1.HasOne("SiacWeb.Models.Cliente")
                                .WithOne("Endereco")
                                .HasForeignKey("SiacWeb.Models.Comum.Endereco", "ClienteId")
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

                            b1.HasKey("FornecedorId");

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

                            b1.HasKey("FornecedorId");

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

                            b1.HasKey("FuncionarioId");

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

                            b1.HasKey("FuncionarioId");

                            b1.ToTable("Funcionario");

                            b1.HasOne("SiacWeb.Models.Funcionario")
                                .WithOne("Endereco")
                                .HasForeignKey("SiacWeb.Models.Comum.Endereco", "FuncionarioId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("SiacWeb.Models.GrupoDeProduto", b =>
                {
                    b.HasOne("SiacWeb.Models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SiacWeb.Models.Transportadora", b =>
                {
                    b.HasOne("SiacWeb.Models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("SiacWeb.Models.Comum.DadosBancarios", "DadosBancarios", b1 =>
                        {
                            b1.Property<int>("TransportadoraId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Agencia")
                                .HasMaxLength(10);

                            b1.Property<string>("CodigoBanco")
                                .HasMaxLength(10);

                            b1.Property<string>("Conta")
                                .HasMaxLength(20);

                            b1.HasKey("TransportadoraId");

                            b1.ToTable("Transportadora");

                            b1.HasOne("SiacWeb.Models.Transportadora")
                                .WithOne("DadosBancarios")
                                .HasForeignKey("SiacWeb.Models.Comum.DadosBancarios", "TransportadoraId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("SiacWeb.Models.Comum.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<int>("TransportadoraId")
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

                            b1.HasKey("TransportadoraId");

                            b1.ToTable("Transportadora");

                            b1.HasOne("SiacWeb.Models.Transportadora")
                                .WithOne("Endereco")
                                .HasForeignKey("SiacWeb.Models.Comum.Endereco", "TransportadoraId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}