using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Components
{
    [Serializable]
    public struct UIComponent
    {
        public Text paddlesText;
        public Text goldText;

        public GameObject winPanel;
        public GameObject loosePanel;
    }
}