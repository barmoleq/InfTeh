using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Task3
{
    public class Мusic
    {
        private string _name;
        private Мusician _musician;
        private List<МusicStyle> _style;
        private Int16 _longs;

        public Мusic(string name, Мusician musician, List<МusicStyle> style, short longs)
        {
            _name = name;
            _musician = musician;
            _style = style;
            _longs = longs;
        }

        public string Name => _name;

        public List<МusicStyle> Style => _style;

        public Мusician Musician => _musician;

        public short Longs => _longs;
    }
}