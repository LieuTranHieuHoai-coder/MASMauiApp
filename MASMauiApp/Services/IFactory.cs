using MASMauiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASMauiApp.Services
{
    public interface IFactory
    {
        Task<List<FactoryModel>> GetAllFactories();
    }
}
