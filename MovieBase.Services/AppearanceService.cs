using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Services
{
    public class AppearanceService
    {
        private readonly Guid _userId;

        public AppearanceService(Guid userId)
        {
            _userId = userId;
        }
    }
}
