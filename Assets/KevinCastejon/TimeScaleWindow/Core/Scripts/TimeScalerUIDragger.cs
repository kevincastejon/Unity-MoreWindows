using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace KevinCastejon.TimeScaleWindow
{
    internal class TimeScalerUIDragger : MonoBehaviour
    {
        [SerializeField] private bool _isDraggable = true;
        RectTransform _transform;

        Vector2 _offset;
        private void Awake()
        {
            _transform = GetComponent<RectTransform>();
        }
        public void DragBegin(BaseEventData evt)
        {
            Vector2 mousePos = evt.currentInputModule.input.mousePosition;
            _offset = mousePos - ((Vector2)_transform.position);
        }
        public void Drag(BaseEventData evt)
        {
            if (_isDraggable)
            {
                Vector2 mousePos = evt.currentInputModule.input.mousePosition;
                _transform.position = mousePos - _offset;
            }
        }
    }
}