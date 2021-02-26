using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoshaDudar.Data.Models;

namespace GoshaDudar.Data.Interfaces
{
    public interface ICarsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
