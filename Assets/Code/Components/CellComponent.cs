using System;
using UnityEngine;

namespace Code.Components
{
    [Serializable]
    public struct CellComponent
    {
        [NonSerialized] public int id;
        [NonSerialized] public int state;
        [NonSerialized] public bool hasGold;
        [NonSerialized] public RectTransform transform;
    }
}