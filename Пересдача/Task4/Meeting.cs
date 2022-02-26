using System;
using System.Text;

namespace Task4
{
    public class Meeting
    {
        protected string name;
        protected int speakers;
        protected int participant;
        protected float q;

        public Meeting(string name, int speakers, int participant)
        {
            this.name = name;
            this.speakers = speakers;
            this.participant = participant;
            findQ();
        }

        protected virtual void findQ()
        {
            this.q = (float)speakers / participant;
        }

        public virtual String getInfo()
        {
            return name + (name.Length >= 16 ? "\t" : "\t\t") + "Ораторы: " + speakers + "\tУчастники: " + participant + "\tРейтинг: " + q;
        }

        public string Name => name;

        public int Speakers => speakers;

        public int Participant => participant;

        public float Q => q;
    }
}