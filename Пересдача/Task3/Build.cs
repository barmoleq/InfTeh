using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Build
    {
        private List<Мusic> _music;

        public Build(List<Мusic> music)
        {
            _music = music;
        }

        public List<Мusic> Music => _music;

    }
}
