using carabini.region;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carabini.events
{
    public interface ICauseEvent
    {
        IExtractedEvent? CauseEvent(List<IRegion> regions);
    }
}
