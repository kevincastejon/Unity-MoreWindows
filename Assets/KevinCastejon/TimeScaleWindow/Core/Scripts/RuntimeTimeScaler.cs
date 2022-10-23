using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KevinCastejon.TimeScaleWindow
{
    internal class RuntimeTimeScaler : MonoBehaviour
    {
        private void Start()
        {
            GetComponentInChildren<Slider>().value = Time.timeScale;
        }
        public void SetTimeScale(float value)
        {
            Time.timeScale = value;
        }
    }
}