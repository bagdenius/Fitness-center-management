using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    public class DbContextOptionsFactory
    {
        public static DbContextOptions<FitnessContext> Get()
        {
            var builder = new DbContextOptionsBuilder<FitnessContext>();
            builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FitnessContextDb");
            return builder.Options;
        }
    }
}
