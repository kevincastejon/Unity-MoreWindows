using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEditorInternal;
using UnityEngine;

namespace KevinCastejon.MoreWindows
{
    public class QuickAssetsWindow : EditorWindow
    {
        private SerializedObject _so;
        private SerializedProperty _assets;
        private ReorderableList _list;
        [MenuItem("Window/QuickAssets Window", false, 222)]
        internal static void OpenWindow()
        {
            EditorWindow window = GetWindow(typeof(QuickAssetsWindow));
            window.titleContent = new GUIContent("QuickAssets");
        }
        private void OnEnable()
        {
            string[] paths = AssetDatabase.FindAssets("t:QuickAssetsSo").Select(x => AssetDatabase.GUIDToAssetPath(x)).ToArray();
            _so = new SerializedObject(AssetDatabase.LoadAssetAtPath<Object>(paths[0]));
            _assets = _so.FindProperty("_quickAssets");
            _list = new ReorderableList(_so, _assets, true, false, true, true);
            _list.elementHeight = 50f;
            _list.onAddCallback = OnAddCallback;
            _list.drawElementCallback = DrawElementCallback;
        }
        private void OnGUI()
        {
            _so.Update();
            _list.DoLayoutList();
            _so.ApplyModifiedProperties();
        }
        private void DrawElementCallback(Rect rect, int index, bool isActive, bool isFocused)
        {
            EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width-52f, rect.height), _assets.GetArrayElementAtIndex(index), GUIContent.none);
            EditorGUI.BeginDisabledGroup(_assets.GetArrayElementAtIndex(index).objectReferenceValue == null);
            GUIContent label = EditorGUIUtility.IconContent("d_SearchJump Icon");
            label.tooltip = "Open without selection";
            if (GUI.Button(new Rect(rect.x + (rect.width - 50f), rect.y, 50f, rect.height), label))
            {
                AssetDatabase.OpenAsset(_assets.GetArrayElementAtIndex(index).objectReferenceValue);
            }
            EditorGUI.EndDisabledGroup();
        }

        private void OnAddCallback(ReorderableList list)
        {
            int index = list.index == -1 ? 0 : _list.index;
            _assets.InsertArrayElementAtIndex(index);
            _assets.GetArrayElementAtIndex(index).objectReferenceValue = null;
            list.Select(index);
        }
    }
}