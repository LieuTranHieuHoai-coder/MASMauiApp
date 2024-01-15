using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASMauiApp.Models.QmsModels
{
    public class UserWorkPlace
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public string WorkingSite { get; set; }
        public string WorkingFact { get; set; }
        public string WorkingLine { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
