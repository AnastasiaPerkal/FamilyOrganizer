using FamilyOrganizer.User;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FamilyOrganizer.DB.Seed
{
    public static class Seed
    {
        public static void SeedTransactions(FamilyOrganizerContext context)
        {
            if (context.Transactions.Any())
                return;

            var transactionsJson = (File.ReadAllText(@".\DB\Seed\TransactionsSeed.json"));
            var transactions = JsonSerializer.Deserialize<IEnumerable<Transaction>>(transactionsJson);

            context.Transactions.AddRange(transactions);
            context.SaveChanges();
        }
        
        public static void SeedBalances(FamilyOrganizerContext context)
        {
            if (context.Balances.Any())
                return;

            var balancesJson = (File.ReadAllText(@".\DB\Seed\BalancesSeed.json"));
            var balances = JsonSerializer.Deserialize<IEnumerable<Balance>>(balancesJson);

            context.Balances.AddRange(balances);
            context.SaveChanges();
        }
    }
}
