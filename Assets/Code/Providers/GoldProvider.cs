using Code.Components;
using UnityEngine;
using Voody.UniLeo;

namespace Code.Providers
{
    public class GoldProvider : MonoProvider<GoldComponent>
    {
        public void Init(CellComponent cellComponent)
        {
            value.transform = transform;
            value.rectTransform = GetComponent<RectTransform>();
            value.parentCell = cellComponent;
        }
    }
}