using Code.Components;
using UnityEngine;
using Voody.UniLeo;

namespace Code.Providers
{
    public class CellProvider : MonoProvider<CellComponent>
    {
        public CellComponent Value => value;

        public void Init(int id, RectTransform transform)
        {
            value.id = id;
            value.transform = transform;
        }
    }
}