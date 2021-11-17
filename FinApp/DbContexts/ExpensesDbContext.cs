using System;
using FinApp.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FinApp.Api.DbContexts
{
    public class ExpensesDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }

        public DbSet<ConsumptionType> ConsumptionTypes { get; set; }

        public ExpensesDbContext(DbContextOptions<ExpensesDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var gasGuid = Guid.Parse("f6eb3f75-7afb-4577-bf62-5ea66e69acd8");
            var electicityGuid = Guid.Parse("251fb0f9-1632-485b-9a10-22e901253c73");


            modelBuilder.Entity<ConsumptionType>().HasData(new ConsumptionType
            {
                Id = electicityGuid,
                Name = "Prąd",
                Unit = UnitType.kWh
            }, new ConsumptionType
            {
                Id = gasGuid,

                Name = "Gaz",
                Unit = UnitType.CubicMeters
            });

            modelBuilder.Entity<Expense>().HasData(new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2019-07-11 22:40:09"),
                PaidAmount = 62.87M,
                ConsumptionTypeId = electicityGuid,
                ConsumptionAmount = 0
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2019-07-12 13:04:42"),
                PaidAmount = 50.24M,
                ConsumptionTypeId = gasGuid,
                ConsumptionAmount = 0
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2019-08-13 13:09:30"),
                PaidAmount = 33.93M,
                ConsumptionTypeId = gasGuid,
                ConsumptionAmount = 3
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2019-09-13 15:24:36"),
                PaidAmount = 37.25M,
                ConsumptionTypeId = gasGuid,
                ConsumptionAmount = 9
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2019-09-18 17:51:53"),
                PaidAmount = 171,
                ConsumptionTypeId = electicityGuid,
                ConsumptionAmount = 1
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2019-10-15 13:07:25"),
                PaidAmount = 99,
                ConsumptionTypeId = gasGuid,
                ConsumptionAmount = 43
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2019-11-11 11:06:50"),
                PaidAmount = 138.58M,
                ConsumptionTypeId = gasGuid,
                ConsumptionAmount = 51
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2019-11-19 09:36:26"),
                PaidAmount = 193.56M,
                ConsumptionTypeId = electicityGuid,
                ConsumptionAmount = 286
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2019-12-11 14:20:24"),
                PaidAmount = 348.87M,
                ConsumptionTypeId = gasGuid,
                ConsumptionAmount = 177
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2020-01-09 16:37:29"),
                PaidAmount = 261.98M,
                ConsumptionTypeId = electicityGuid,
                ConsumptionAmount = 405
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2020-01-14 13:50:55"),
                PaidAmount = 354,
                ConsumptionTypeId = gasGuid,
                ConsumptionAmount = 180
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2020-02-12 15:14:11"),
                PaidAmount = 388,
                ConsumptionTypeId = gasGuid,
                ConsumptionAmount = 202
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2020-03-13 13:55:33"),
                PaidAmount = 330,
                ConsumptionTypeId = gasGuid,
                ConsumptionAmount = 171
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2020-03-17 13:46:23"),
                PaidAmount = 409,
                ConsumptionTypeId = electicityGuid,
                ConsumptionAmount = 610
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2020-04-15 16:35:07"),
                PaidAmount = 239.15M,
                ConsumptionTypeId = gasGuid,
                ConsumptionAmount = 120
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2020-05-13 14:19:45"),
                PaidAmount = 99.66M,
                ConsumptionTypeId = gasGuid,
                ConsumptionAmount = 43
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2020-05-13 14:22:07"),
                PaidAmount = 293.21M,
                ConsumptionTypeId = electicityGuid,
                ConsumptionAmount = 411
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2020-06-15 13:13:37"),
                PaidAmount = 68M,
                ConsumptionTypeId = gasGuid,
                ConsumptionAmount = 26
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2020-07-14 11:43:59"),
                PaidAmount = 270M,
                ConsumptionTypeId = electicityGuid,
                ConsumptionAmount = 376
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2020-07-14 16:43:26"),
                PaidAmount = 47,
                ConsumptionTypeId = gasGuid,
                ConsumptionAmount = 15
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2020-08-14 12:18:07"),
                PaidAmount = 45,
                ConsumptionTypeId = gasGuid,
                ConsumptionAmount = 14
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2020-09-09 09:20:05"),
                PaidAmount = 273.24M,
                ConsumptionTypeId = electicityGuid,
                ConsumptionAmount = 381
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2020-09-30 15:28:29"),
                PaidAmount = 77.55M,
                ConsumptionTypeId = gasGuid,
                ConsumptionAmount = 30
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2020-10-21 19:46:44"),
                PaidAmount = 47.18M,
                ConsumptionTypeId = gasGuid,
                ConsumptionAmount = 19
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2020-11-06 07:34:13"),
                PaidAmount = 332.81M,
                ConsumptionTypeId = electicityGuid,
                ConsumptionAmount = 474
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2020-11-17 15:27:21"),
                PaidAmount = 240,
                ConsumptionTypeId = gasGuid,
                ConsumptionAmount = 129
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2020-12-17 16:49:06"),
                PaidAmount = 282.76M,
                ConsumptionTypeId = gasGuid,
                ConsumptionAmount = 156
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2021-01-15 21:42:42"),
                PaidAmount = 490,
                ConsumptionTypeId = electicityGuid,
                ConsumptionAmount = 668
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2021-01-18 22:35:50"),
                PaidAmount = 343,
                ConsumptionTypeId = gasGuid,
                ConsumptionAmount = 193
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2021-02-16 14:13:09"),
                PaidAmount = 401.13M,
                ConsumptionTypeId = gasGuid,
                ConsumptionAmount = 231
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2021-03-11 17:23:40"),
                PaidAmount = 452.38M,
                ConsumptionTypeId = electicityGuid,
                ConsumptionAmount = 613
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2021-03-17 19:36:57"),
                PaidAmount = 311,
                ConsumptionTypeId = gasGuid,
                ConsumptionAmount = 176
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2021-04-16 19:09:30"),
                PaidAmount = 250,
                ConsumptionTypeId = gasGuid,
                ConsumptionAmount = 140
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2021-05-11 22:21:08"),
                PaidAmount = 410,
                ConsumptionTypeId = electicityGuid,
                ConsumptionAmount = 550
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2021-05-14 06:44:10"),
                PaidAmount = 193,
                ConsumptionTypeId = gasGuid,
                ConsumptionAmount = 91
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2021-06-16 17:38:39"),
                PaidAmount = 70.79M,
                ConsumptionTypeId = gasGuid,
                ConsumptionAmount = 29
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2021-07-12 19:21:30"),
                PaidAmount = 266.71M,
                ConsumptionTypeId = electicityGuid,
                ConsumptionAmount = 321
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2021-07-14 20:38:44"),
                PaidAmount = 51.97M,
                ConsumptionTypeId = gasGuid,
                ConsumptionAmount = 18
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2021-08-17 10:08:26"),
                PaidAmount = 52.55M,
                ConsumptionTypeId = gasGuid,
                ConsumptionAmount = 18
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2021-09-09 21:29:21"),
                PaidAmount = 285,
                ConsumptionTypeId = electicityGuid,
                ConsumptionAmount = 356
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2021-10-20 17:27:53"),
                PaidAmount = 168,
                ConsumptionTypeId = gasGuid,
                ConsumptionAmount = 77
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2021-11-06 15:41:24"),
                PaidAmount = 321.84M,
                ConsumptionTypeId = electicityGuid,
                ConsumptionAmount = 413
            }, new Expense
            {
                Id = Guid.NewGuid(),
                OccuredAt = DateTime.Parse("2021-09-10 15:55:44"),
                PaidAmount = 58.35M,
                ConsumptionTypeId = gasGuid,
                ConsumptionAmount = 20
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
