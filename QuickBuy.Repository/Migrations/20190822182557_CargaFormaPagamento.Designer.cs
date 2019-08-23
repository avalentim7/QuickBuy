﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickBuy.Repository.Context;

namespace QuickBuy.Repository.Migrations
{
    [DbContext(typeof(QuickBuyContext))]
    [Migration("20190822182557_CargaFormaPagamento")]
    partial class CargaFormaPagamento
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("QuickBuy.Domain.Entities.ItemPedido", b =>
                {
                    b.Property<int>("IdItemPedido")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdProduto");

                    b.Property<int?>("PedidoIdPedido");

                    b.Property<int>("Quantidade")
                        .HasMaxLength(14);

                    b.HasKey("IdItemPedido");

                    b.HasIndex("PedidoIdPedido");

                    b.ToTable("ItensPedidos");
                });

            modelBuilder.Entity("QuickBuy.Domain.Entities.Pedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("DataPedido");

                    b.Property<DateTime>("DataPrevisaoEntrega");

                    b.Property<string>("EnderecoCompleto")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("FormaPagamentoId");

                    b.Property<int>("IdUsuario");

                    b.Property<int>("NumeroEndereco")
                        .HasMaxLength(10);

                    b.HasKey("IdPedido");

                    b.HasIndex("FormaPagamentoId");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("QuickBuy.Domain.Entities.Produto", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<decimal>("Valor");

                    b.HasKey("IdProduto");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("QuickBuy.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("QuickBuy.Domain.ValueObject.FormaPagamento", b =>
                {
                    b.Property<int>("IdFormaPagamento")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("IdFormaPagamento");

                    b.ToTable("FormaPagamento");

                    b.HasData(
                        new
                        {
                            IdFormaPagamento = 1,
                            Descricao = "Forma de Pagamento Boleto",
                            Nome = "Boleto"
                        },
                        new
                        {
                            IdFormaPagamento = 2,
                            Descricao = "Forma de Pagamento Cartão de Crédito",
                            Nome = "Cartão de Crédito"
                        },
                        new
                        {
                            IdFormaPagamento = 3,
                            Descricao = "Forma de Pagamento Depósito",
                            Nome = "Depósito"
                        });
                });

            modelBuilder.Entity("QuickBuy.Domain.Entities.ItemPedido", b =>
                {
                    b.HasOne("QuickBuy.Domain.Entities.Pedido")
                        .WithMany("ItensPedido")
                        .HasForeignKey("PedidoIdPedido");
                });

            modelBuilder.Entity("QuickBuy.Domain.Entities.Pedido", b =>
                {
                    b.HasOne("QuickBuy.Domain.ValueObject.FormaPagamento", "FormaPagamento")
                        .WithMany()
                        .HasForeignKey("FormaPagamentoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QuickBuy.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
