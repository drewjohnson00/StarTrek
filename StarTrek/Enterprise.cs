using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarTrek.Models;

namespace StarTrek
{
    public static class Enterprise
    {
        private static KnownGalaxy _knownGalaxy;

        static Enterprise()
        {
            _knownGalaxy = new KnownGalaxy();
        }

        public static KnownGalaxy KnownGalaxy => _knownGalaxy;

    }
}
