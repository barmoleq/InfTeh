namespace Task5
{
    public class Guitar : IMusicalInstrument
    {
        public Material Material { get; set; }
        protected int LengthGrif { get; set; }
        protected int LengthBody { get; set; }


        public Guitar(Material material, int lengthGrif, int lengthBody)
        {
            Material = material;
            LengthGrif = lengthGrif;
            LengthBody = lengthBody;
        }

        public int GetPriceCoefficient()
        {
            return (int) Material * LengthGrif * LengthBody / 100;
        }

        public virtual int CompareTo(IMusicalInstrument other)
        {
            if (Material.CompareTo(other.Material) == 0)
            {
                Guitar g = (Guitar) other;

                if (LengthGrif.CompareTo(g.GetLengthGrif()) == 0)
                {
                    return LengthBody.CompareTo(g.GetLengthBody());
                }

                return LengthGrif.CompareTo(g.GetLengthGrif());
            }

            return Material.CompareTo(other.Material);
        }

        public int GetLengthGrif()
        {
            return LengthGrif;
        }

        public int GetLengthBody()
        {
            return LengthBody;
        }
    }
}