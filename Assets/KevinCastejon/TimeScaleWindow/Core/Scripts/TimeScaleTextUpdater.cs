using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace KevinCastejon.TimeScaleWindow
{
    public class TimeScaleTextUpdater : MonoBehaviour
    {
        TextMeshProUGUI _text;
        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }
        // Update is called once per frame
        void Update()
        {
            _text.text = (Time.timeScale.ToString("F2")+" x").PadLeft(7, '0');
        }
    }
}