using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Models;

namespace BankApplication.Services.Interface
{
    public interface IBankStatistics
    {
        BankStatisticsViewModel GetStats();
    }
}
