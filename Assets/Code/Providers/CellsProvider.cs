﻿using Code.Components;
using UnityEngine;
using Voody.UniLeo;

namespace Code.Providers
{
    public class CellsProvider : MonoProvider<CellsComponent>
    {
        public void Init()
        {
            for (int i = 0; i < value.cells.Count; i++)
            {
                var cell = value.cells[i];
                var rectTransform = cell.GetComponent<RectTransform>();
                cell.Init(i + 1, rectTransform);
            }
        }
    }
}