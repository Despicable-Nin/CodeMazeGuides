﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;

namespace EFCorePowerToolsExample.Data
{
    public partial class DBContext
    {

        [DbFunction("CountBooksInCategory_FN", "dbo")]
        public static int? CountBooksInCategory_FN(int? CategoryID)
        {
            throw new NotSupportedException("This method can only be called from Entity Framework Core queries");
        }

        protected void OnModelCreatingGeneratedFunctions(ModelBuilder modelBuilder)
        {
        }
    }
}
