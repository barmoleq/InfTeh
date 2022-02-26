namespace Task5
{
    public class ElectricGuitar : Guitar
    {
        private const int LengthSwitch = 10;
        private const int InputsOnSwitch = 2;

        protected int SwitchCount { get; set; }
        protected int InputsCount { get; set; }

        public ElectricGuitar(Material material, int lengthGrif, int lengthBody, int switchCount) : base(material, lengthGrif, lengthBody)
        {
            if (switchCount < 0 || switchCount > lengthBody / LengthSwitch)
            {
                SwitchCount = 0;
            }
            else
            {
                SwitchCount = switchCount;
            }
        }

        public int AddSwitch()
        {
            if (SwitchCount + 1 <= LengthBody / LengthSwitch)
            {
                SwitchCount++;
            }

            return SwitchCount;
        }

        public int RemoveShelf()
        {
            if (SwitchCount > 0)
            {
                SwitchCount--;
            }

            return SwitchCount;
        }

        public int GetSwitchCount()
        {
            return SwitchCount;
        }

        public int AddInput()
        {
            if (InputsCount + 1 <= SwitchCount * InputsOnSwitch)
            {
                InputsCount++;
            }

            return InputsCount;
        }

        public int RemoveInput()
        {
            if (InputsCount > 0)
            {
                InputsCount--;
            }

            return InputsCount;
        }

        public int GetInputsCount()
        {
            return InputsCount;
        }

        public override int CompareTo(IMusicalInstrument other)
        {
            if (Material.CompareTo(other.Material) == 0)
            {
                Guitar g = (Guitar) other;

                if (LengthGrif.CompareTo(g.GetLengthGrif()) == 0)
                {
                    if (LengthBody.CompareTo(g.GetLengthBody()) == 0)
                    {
                        ElectricGuitar eg = (ElectricGuitar)other;
                        if (SwitchCount.CompareTo(eg.SwitchCount) == 0)
                        {
                            return InputsCount.CompareTo(eg.InputsCount);
                        }

                        return SwitchCount.CompareTo(eg.SwitchCount);
                    }

                    return LengthBody.CompareTo(g.GetLengthBody());
                }

                return LengthGrif.CompareTo(g.GetLengthGrif());
            }

            return Material.CompareTo(other.Material);
        }
    }
}