namespace Warframe.Market_Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Warframe.Market_Infrastructure.Models.Enums;

    internal sealed class Configuration : DbMigrationsConfiguration<DataBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataBaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.OrderType.AddOrUpdate(
                x => x.Id,
                Enum.GetValues(typeof(OrderTypeEnum))
                    .OfType<OrderTypeEnum>()
                    .Select(x => new OrderType() { Id = x, Name = x.ToString() })
                    .ToArray());

            context.Language.AddOrUpdate(
                x => x.Id,
                Enum.GetValues(typeof(LanguageEnum))
                    .OfType<LanguageEnum>()
                    .Select(x => new Language() { Id = x, Text = x.ToString() })
                    .ToArray());

            context.IconFormat.AddOrUpdate(
                x => x.Id,
                Enum.GetValues(typeof(IconFormatEnum))
                    .OfType<IconFormatEnum>()
                    .Select(x => new IconFormat() { Id = x, Name = x.ToString() })
                    .ToArray());
        }
    }
}
