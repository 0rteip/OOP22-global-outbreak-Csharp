using System.Collections.Generic;
using System.ComponentModel;

namespace farabegoli.temp;
public interface IRegion
{
    long Population { get; }
    float Poor { get; }
    float Urban { get; }
    long Deaths { get; }
    long Infected { get; }
    IClimate Climate { get; }
    void IncDeathPeople(long calculateNewDeaths);
    void IncOrDecInfectedPeople(long calculateNewInfected);
}
