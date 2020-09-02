using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(CustomComponent))]
public class CustomComponentEditor : Editor
{
    CustomComponent cc;
    GUIStyle style;

    private void OnEnable()
    {
        cc = (CustomComponent)target;
        style = new GUIStyle()
        {
            fontSize = 13,
            fontStyle = FontStyle.Bold,
            normal = new GUIStyleState() { textColor = Color.white }
        };
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.LabelField("EditorGUILayout:", style);
        EditorGUILayout.Space(10);

        // Примеры.
        {
            BeginFadeGroup();
            BeginFoldoutHeaderGroup();
            BeginHorizontal();
            BeginScrollView();
        }

        serializedObject.ApplyModifiedProperties();

        // Загрязнение сцены.
        if (GUI.changed)
        {
            EditorUtility.SetDirty(cc.gameObject);
            EditorSceneManager.MarkSceneDirty(cc.gameObject.scene);
        }
    }

    #region
    float BFG = 1f;
    bool bfg = false;
    void BeginFadeGroup()
    {
        EditorGUILayout.LabelField("BeginFadeGroup:", style);

        bfg = EditorGUILayout.BeginFoldoutHeaderGroup(bfg, "BeginFadeGroup:");
        if (bfg)
        {

            BFG = EditorGUILayout.FloatField("BeginFadeGroup", BFG);
            if (BFG < 0) BFG = 0;

            EditorGUILayout.BeginFadeGroup(BFG);

            EditorGUILayout.Space(5);

            EditorGUILayout.LabelField("BeginFadeGroup");
            EditorGUILayout.LabelField("BeginFadeGroup");
            EditorGUILayout.LabelField("BeginFadeGroup");

            EditorGUILayout.EndFadeGroup();
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        EditorGUILayout.Space(10);
    }

    bool BFHG = false;
    string status = "Open";
    void BeginFoldoutHeaderGroup()
    {
        EditorGUILayout.LabelField("BeginFoldoutHeaderGroup:", style);

        BFHG = EditorGUILayout.BeginFoldoutHeaderGroup(BFHG, status);
        if (BFHG)
        {
            EditorGUILayout.LabelField("BeginFoldoutHeaderGroup");
            EditorGUILayout.LabelField("BeginFoldoutHeaderGroup");
            EditorGUILayout.LabelField("BeginFoldoutHeaderGroup");

            status = "Open";
        }
        else status = "Close";
        EditorGUILayout.EndFoldoutHeaderGroup();

        EditorGUILayout.Space(10);
    }

    bool bh = false;
    void BeginHorizontal()
    {
        EditorGUILayout.LabelField("BeginHorizontal:", style);

        bh = EditorGUILayout.BeginFoldoutHeaderGroup(bh, "BeginHorizontal");
        if (bh)
        {
            EditorGUILayout.BeginHorizontal("box");

            GUILayout.Label("BeginHorizontal.");
            GUILayout.Label("BeginHorizontal.");
            GUILayout.Label("BeginHorizontal.");
            EditorGUILayout.LabelField("BeginHorizontal.");
            EditorGUILayout.LabelField("BeginHorizontal.");

            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        EditorGUILayout.Space(10);
    }

    Vector2 scrollPosition = new Vector2(50, 50);
    bool bsv = false;
    void BeginScrollView()
    {
        EditorGUILayout.LabelField("BeginScrollView:", style);

        bsv = EditorGUILayout.BeginFoldoutHeaderGroup(bsv, "BeginScrollView");
        if (bsv)
        {
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, true, true, GUILayout.Height(200));
            {
                GUILayout.Label("BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView");
                GUILayout.Label("BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView");
                GUILayout.Label("BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView");
                GUILayout.Label("BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView");
                GUILayout.Label("BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView");
                GUILayout.Label("BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView");
                GUILayout.Label("BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView");
                GUILayout.Label("BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView");
                GUILayout.Label("BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView");
                GUILayout.Label("BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView");
                GUILayout.Label("BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView");
                GUILayout.Label("BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView");
                GUILayout.Label("BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView");
                GUILayout.Label("BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView_BeginScrollView");
            }
            EditorGUILayout.EndScrollView();
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        EditorGUILayout.Space(10);
    }
    #endregion
}