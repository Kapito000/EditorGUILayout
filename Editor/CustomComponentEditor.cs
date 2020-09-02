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

    int spase = 5;

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
            BeginToggleGroup();
            BeginVertical();
            BoundsField();
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

        EditorGUILayout.Space(spase);
    }

    bool BFHG = false;
    string status = "Open";
    void BeginFoldoutHeaderGroup()
    {
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

        EditorGUILayout.Space(spase);
    }

    bool bh = false;
    void BeginHorizontal()
    {
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

        EditorGUILayout.Space(spase);
    }

    Vector2 scrollPosition = new Vector2(50, 50);
    bool bsv = false;
    void BeginScrollView()
    {
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

        EditorGUILayout.Space(spase);
    }

    bool BTG = false;
    bool btg = false;
    void BeginToggleGroup()
    {
        btg = EditorGUILayout.BeginFoldoutHeaderGroup(btg, "BeginToggleGroup:");
        if (btg)
        {
            BTG = EditorGUILayout.BeginToggleGroup("BeginToggleGroup:", BTG);

            cc.a = EditorGUILayout.IntField(cc.a); // Для "public" полей.
            cc.a = EditorGUILayout.IntField(cc.a); // Для "public" полей.
            serializedObject.FindProperty("b").intValue = EditorGUILayout.IntField(serializedObject.FindProperty("b").intValue); // // Для "[SerializeField]" полей.
            serializedObject.FindProperty("b").intValue = EditorGUILayout.IntField(serializedObject.FindProperty("b").intValue); // // Для "[SerializeField]" полей.

            EditorGUILayout.EndToggleGroup();
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        EditorGUILayout.Space(spase);
    }

    bool bv = false;
    void BeginVertical()
    {
        bv = EditorGUILayout.BeginFoldoutHeaderGroup(bv, "BeginVertical:");
        if (bv)
        {
            EditorGUILayout.BeginVertical("box");

            GUILayout.Label("BeginVertical");
            GUILayout.Label("BeginVertical");
            GUILayout.Label("BeginVertical");

            EditorGUILayout.EndVertical();
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        EditorGUILayout.Space(spase);
    }

    Bounds Bounds;
    bool bf = false;
    void BoundsField()
    {
        bf = EditorGUILayout.BeginFoldoutHeaderGroup(bf, "BoundsField");
        if (bf)
        {
            Bounds = EditorGUILayout.BoundsField("BoundsField", Bounds);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        EditorGUILayout.Space(spase);
    }
    #endregion
}