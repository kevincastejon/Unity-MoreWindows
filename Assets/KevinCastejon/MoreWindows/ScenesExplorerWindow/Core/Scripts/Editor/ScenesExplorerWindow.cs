using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace KevinCastejon.MoreWindows
{
    public class ScenesExplorerWindow : EditorWindow
    {
        private bool _additive;
        [MenuItem("Window/Scenes Explorer Window", false, 222)]
        internal static void OpenWindow()
        {
            EditorWindow window = GetWindow(typeof(ScenesExplorerWindow));
            window.titleContent = new GUIContent("Scenes Explorer");
        }
        private void OnGUI()
        {
            _additive = EditorGUILayout.ToggleLeft("Additive Loading", _additive);
            string[] paths = AssetDatabase.FindAssets("t:Scene").Select(x => AssetDatabase.GUIDToAssetPath(x)).ToArray();
            SceneAsset[] scenes = paths.Select(x => AssetDatabase.LoadAssetAtPath<SceneAsset>(x)).ToArray();

            for (int i = 0; i < scenes.Length; i++)
            {
                GUIContent label = EditorGUIUtility.IconContent("d_SceneAsset Icon");
                label.tooltip = scenes[i].name;
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button(label,GUILayout.Width(50f), GUILayout.Height(50f)))
                {
                    EditorSceneManager.OpenScene(paths[i], _additive ? OpenSceneMode.Additive : OpenSceneMode.Single);
                }
                EditorGUILayout.LabelField(scenes[i].name,EditorStyles.boldLabel, GUILayout.Height(50f));
                EditorGUILayout.EndHorizontal();
            }
        }
    }

}