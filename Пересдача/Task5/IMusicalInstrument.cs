using System;

namespace Task5
{
    public interface IMusicalInstrument : IComparable<IMusicalInstrument>
    {
        Material Material { get; set; }

        int GetPriceCoefficient();

        int CompareTo(IMusicalInstrument other);
    }
}