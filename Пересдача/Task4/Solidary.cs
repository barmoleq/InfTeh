using System;

namespace Task4
{
    public class Solidary : Meeting
    {
        private int p;

        public Solidary(string name, int speakers, int participant, int p) : base(name, speakers, participant)
        {
            this.p = p;
            findQ();
        }

        protected override void findQ()
        {
            base.findQ();
            this.q += (float)p/participant;
        }

        public override string getInfo()
        {
            return base.getInfo() + "\tЛюди, с одинаковым мнением: " + p.ToString();
        }
    }
}