using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KevinCastejon.MoreAttributes
{
    public class QuickAssetsSO : ScriptableObject
    {
        [SerializeField] private List<Object> _quickAssets;
    }
}