﻿// <auto-generated />
using System;
using Merp.Accountancy.Drafts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Merp.Accountancy.Drafts.Migrations
{
    [DbContext(typeof(AccountancyDraftsDbContext))]
    [Migration("20181004073820_Add-OutgoingInvoiceDraft")]
    partial class AddOutgoingInvoiceDraft
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Merp.Accountancy.Drafts.Model.DraftLineItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("Description");

                    b.Property<Guid?>("OutgoingInvoiceDraftId");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("TotalPrice");

                    b.Property<decimal>("UnitPrice");

                    b.Property<decimal>("Vat");

                    b.HasKey("Id");

                    b.HasIndex("OutgoingInvoiceDraftId");

                    b.ToTable("DraftLineItems");
                });

            modelBuilder.Entity("Merp.Accountancy.Drafts.Model.NonTaxableItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<string>("Description");

                    b.Property<Guid?>("OutgoingInvoiceDraftId");

                    b.HasKey("Id");

                    b.HasIndex("OutgoingInvoiceDraftId");

                    b.ToTable("DraftNonTaxableItems");
                });

            modelBuilder.Entity("Merp.Accountancy.Drafts.Model.OutgoingInvoiceDraft", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Currency");

                    b.Property<DateTime?>("Date");

                    b.Property<string>("Description");

                    b.Property<string>("PaymentTerms");

                    b.Property<bool>("PricesAreVatIncluded");

                    b.Property<string>("PurchaseOrderNumber");

                    b.Property<decimal>("TaxableAmount");

                    b.Property<decimal>("Taxes");

                    b.Property<decimal>("TotalPrice");

                    b.HasKey("Id");

                    b.HasIndex("Date");

                    b.HasIndex("PurchaseOrderNumber");

                    b.ToTable("OutgoingInvoiceDrafts");
                });

            modelBuilder.Entity("Merp.Accountancy.Drafts.Model.PriceByVat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("OutgoingInvoiceDraftId");

                    b.Property<decimal>("TaxableAmount");

                    b.Property<decimal>("TotalPrice");

                    b.Property<decimal>("VatAmount");

                    b.Property<decimal>("VatRate");

                    b.HasKey("Id");

                    b.HasIndex("OutgoingInvoiceDraftId");

                    b.ToTable("DraftPricesByVat");
                });

            modelBuilder.Entity("Merp.Accountancy.Drafts.Model.DraftLineItem", b =>
                {
                    b.HasOne("Merp.Accountancy.Drafts.Model.OutgoingInvoiceDraft")
                        .WithMany("LineItems")
                        .HasForeignKey("OutgoingInvoiceDraftId");
                });

            modelBuilder.Entity("Merp.Accountancy.Drafts.Model.NonTaxableItem", b =>
                {
                    b.HasOne("Merp.Accountancy.Drafts.Model.OutgoingInvoiceDraft")
                        .WithMany("NonTaxableItems")
                        .HasForeignKey("OutgoingInvoiceDraftId");
                });

            modelBuilder.Entity("Merp.Accountancy.Drafts.Model.OutgoingInvoiceDraft", b =>
                {
                    b.OwnsOne("Merp.Accountancy.Drafts.Model.PartyInfo", "Customer", b1 =>
                        {
                            b1.Property<Guid?>("OutgoingInvoiceDraftId");

                            b1.Property<string>("City");

                            b1.Property<string>("Country");

                            b1.Property<string>("Name")
                                .HasMaxLength(100);

                            b1.Property<string>("NationalIdentificationNumber");

                            b1.Property<Guid>("OriginalId");

                            b1.Property<string>("PostalCode");

                            b1.Property<string>("StreetName");

                            b1.Property<string>("VatIndex");

                            b1.HasIndex("Name");

                            b1.ToTable("OutgoingInvoiceDrafts");

                            b1.HasOne("Merp.Accountancy.Drafts.Model.OutgoingInvoiceDraft")
                                .WithOne("Customer")
                                .HasForeignKey("Merp.Accountancy.Drafts.Model.PartyInfo", "OutgoingInvoiceDraftId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Merp.Accountancy.Drafts.Model.PriceByVat", b =>
                {
                    b.HasOne("Merp.Accountancy.Drafts.Model.OutgoingInvoiceDraft")
                        .WithMany("PricesByVat")
                        .HasForeignKey("OutgoingInvoiceDraftId");
                });
#pragma warning restore 612, 618
        }
    }
}
