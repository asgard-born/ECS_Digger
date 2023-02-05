using System;
using UnityEngine;

namespace Code.Components
{
    [Serializable]
    public struct GoldComponent
    {
        public Transform transform;
        public RectTransform rectTransform;
        public CellComponent parentCell;
        public bool isDragging;
        public int id;
    }
}