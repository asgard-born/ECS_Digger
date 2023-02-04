using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Code.Components
{
    [Serializable]
    public struct InputComponent
    {
        public GraphicRaycaster graphicRaycaster;
        [NonSerialized]
        public List<RaycastResult> clickResults;
    }
}