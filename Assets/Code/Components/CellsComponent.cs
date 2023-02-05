using System;
using System.Collections.Generic;
using Code.Providers;

namespace Code.Components
{
    [Serializable]
    public struct CellsComponent
    {
        public List<CellProvider> cells;
    }
}