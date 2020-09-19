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
            #region 1)
            BeginFadeGroup();
            BeginFoldoutHeaderGroup();
            BeginHorizontal();
            BeginScrollView();
            BeginToggleGroup();
            BeginVertical();
            BoundsField();
            ColorField();
            CurveField();
            DelayedDoubleField();
            DelayedTextField();
            DropdownButton();
            EditorToolbar();
            #endregion
            #region 2)
            EnumFlagsField();
            EnumPopup();
            Foldout();
            GetControlRect();
            GradientField();
            HelpBox();
            InspectorTitlebar();
            #endregion
            #region 3)
            IntPopup();
            IntSlider();
            #endregion
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

    #region 1)
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

    Color color;
    bool cf = false;
    void ColorField()
    {
        cf = EditorGUILayout.BeginFoldoutHeaderGroup(cf, "ColorField");
        if (cf)
        {
            color = EditorGUILayout.ColorField("ColorField", color);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        EditorGUILayout.Space(spase);
    }

    AnimationCurve animationCurve;
    bool cF = false;
    void CurveField()
    {
        cF = EditorGUILayout.BeginFoldoutHeaderGroup(cF, "CurveField");
        if (cF)
        {
            animationCurve = EditorGUILayout.CurveField("CurveField", animationCurve);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        EditorGUILayout.Space(spase);
    }

    double delayedDoubleField;
    bool ddf = false;
    void DelayedDoubleField()
    {
        ddf = EditorGUILayout.BeginFoldoutHeaderGroup(ddf, "DelayedDoubleField");
        if (ddf)
        {
            delayedDoubleField = EditorGUILayout.DelayedDoubleField("DelayedDoubleField", delayedDoubleField);
            delayedDoubleField = EditorGUILayout.DoubleField("DoubleField", delayedDoubleField);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        EditorGUILayout.Space(spase);
    }

    string delayedTextField;
    bool dtf = false;
    void DelayedTextField()
    {
        dtf = EditorGUILayout.BeginFoldoutHeaderGroup(dtf, "DelayedTextField");
        if (dtf)
        {
            delayedTextField = EditorGUILayout.DelayedTextField("DelayedTextField", delayedTextField);

            delayedTextField = EditorGUILayout.TextField("TextField", delayedTextField);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        EditorGUILayout.Space(spase);
    }

    bool db = false;
    void DropdownButton()
    {
        db = EditorGUILayout.BeginFoldoutHeaderGroup(db, "DropdownButton");
        if (db)
        {
            EditorGUILayout.LabelField("Не разобрался как работает (((");
            EditorGUILayout.LabelField("Везде используют \"Popup\"");

            if (EditorGUILayout.DropdownButton(new GUIContent("1", "ad"), FocusType.Keyboard))
            {
                var r = GUILayoutUtility.GetLastRect();
                var f = new GenericMenu();
                r.x += 50;
                f.AddDisabledItem(new GUIContent("1"));
                f.AddDisabledItem(new GUIContent("2"));
                f.AddDisabledItem(new GUIContent("3"));

                f.DropDown(r);
            }
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        EditorGUILayout.Space(spase);
    }

    bool et = false;
    void EditorToolbar()
    {
        et = EditorGUILayout.BeginFoldoutHeaderGroup(et, "EditorToolbar");
        if (et)
        {

            EditorGUILayout.LabelField("Большая тема.");
            EditorGUILayout.LabelField("Необходимо отдельно создавть \"EditorTools\".");
            //  EditorGUILayout.EditorToolbar(new tool);

        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        EditorGUILayout.Space(spase);
    }
    #endregion

    #region 2)
    enum EnumsFlags
    {
        None = 0, // Custom name for "Nothing" option
        A = 1 << 0,
        B = 1 << 1,
        AB = A | B, // Combination of two flags
        C = 1 << 2,
        All = ~0, // Custom name for "Everything" option
    }
    enum EnumFlags_1
    {
        a = 1 << 1,
        b = 1 << 2,
        c = 1 << 3,
    }
    EnumsFlags EFlag;
    EnumFlags_1 eFlag;
    bool eff = false;
    void EnumFlagsField()
    {
        eff = EditorGUILayout.BeginFoldoutHeaderGroup(eff, "EnumFlagsField");
        if (eff)
        {
            EditorGUILayout.LabelField("Битовая маска.");

            var content = new GUIContent("EnumFlagsField");

            EFlag = (EnumsFlags)EditorGUILayout.EnumFlagsField(content, EFlag);
            EditorGUILayout.LabelField(EFlag.ToString());
            EditorGUILayout.Space();

            eFlag = (EnumFlags_1)EditorGUILayout.EnumFlagsField(content, eFlag);
            EditorGUILayout.LabelField(eFlag.ToString());
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        EditorGUILayout.Space(spase);
    }

    enum EnumPopupEn
    { first, second, treeth }
    EnumPopupEn enumPopupEn;
    bool ep = false;
    void EnumPopup()
    {
        ep = EditorGUILayout.BeginFoldoutHeaderGroup(ep, "EnumPopup");
        if (ep)
        {
            enumPopupEn = (EnumPopupEn)EditorGUILayout.EnumPopup("EnumPopup", enumPopupEn);
            EditorGUILayout.TextField(enumPopupEn.ToString());
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        EditorGUILayout.Space(spase);
    }

    bool Fol = false;
    bool f = false;
    void Foldout()
    {
        var indent = EditorGUI.indentLevel;

        f = EditorGUILayout.BeginFoldoutHeaderGroup(f, "Foldout");
        if (f)
        {
            EditorGUI.indentLevel++;
            Fol = EditorGUILayout.Foldout(Fol, "Foldout");
            if (Fol)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.TextField("Foldout");
                EditorGUILayout.TextField("Foldout");
                EditorGUI.indentLevel = indent;
            }
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        EditorGUILayout.Space(spase);
    }

    bool gcr = false;
    void GetControlRect()
    {
        var indent = EditorGUI.indentLevel;

        gcr = EditorGUILayout.BeginFoldoutHeaderGroup(gcr, "GetControlRect");
        if (gcr)
        {
            EditorGUI.indentLevel++;

            var rect = EditorGUILayout.GetControlRect();
            EditorGUILayout.LabelField("???");
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        EditorGUI.indentLevel = indent;
        EditorGUILayout.Space(spase);
    }

    Gradient gradient;
    bool gf = false;
    void GradientField()
    {
        var indent = EditorGUI.indentLevel;

        gf = EditorGUILayout.BeginFoldoutHeaderGroup(gf, "GradientField");
        if (gf)
        {
            EditorGUI.indentLevel++;

            gradient = EditorGUILayout.GradientField("Gradient", gradient);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        EditorGUI.indentLevel = indent;
        EditorGUILayout.Space(spase);
    }

    bool hb = false;
    void HelpBox()
    {
        var indent = EditorGUI.indentLevel;

        hb = EditorGUILayout.BeginFoldoutHeaderGroup(hb, "HelpBox");
        if (hb)
        {
            EditorGUILayout.HelpBox("HelpBox", MessageType.None);
            EditorGUILayout.HelpBox("HelpBox", MessageType.Info);
            EditorGUILayout.HelpBox("HelpBox", MessageType.Warning);
            EditorGUILayout.HelpBox("HelpBox", MessageType.Error);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        EditorGUILayout.Space(spase);
    }

    bool IT = false;
    Transform transformIT;
    Vector4 rotationComponents;
    bool it = false;
    void InspectorTitlebar()
    {
        var indent = EditorGUI.indentLevel;

        if (Selection.activeGameObject)
        {
            var transformIT = Selection.activeGameObject.transform;

            it = EditorGUILayout.BeginFoldoutHeaderGroup(it, "InspectorTitlebar");
            if (it)
            {
                EditorGUI.indentLevel++;

                IT = EditorGUILayout.InspectorTitlebar(IT, transformIT);
                if (IT)
                {
                    transformIT.position = EditorGUILayout.Vector3Field("Position", transformIT.position);
                    EditorGUILayout.Space();
                    rotationComponents = EditorGUILayout.Vector4Field("Detailed Rotation", QuaternionToVector4(transformIT.localRotation));
                    EditorGUILayout.Space();
                    transformIT.localScale = EditorGUILayout.Vector3Field("Scale", transformIT.localScale);
                }

                transformIT.localRotation = ConvertToQuaternion(rotationComponents);
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
        }

        EditorGUI.indentLevel = indent;
        EditorGUILayout.Space(spase);
    }
    Vector4 QuaternionToVector4(Quaternion q)
    {
        return new Vector4(q.x, q.y, q.z, q.w);
    }
    Quaternion ConvertToQuaternion(Vector4 v4)
    {
        return new Quaternion(v4.x, v4.y, v4.z, v4.w);
    }
    #endregion

    #region 3)
    int SelectIP;
    string[] Names = new string[] { "Normal", "Double", "Quadruple" };
    int[] Sizes = { 1, 2, 4 };
    bool ip = false;
    void IntPopup()
    {
        var indent = EditorGUI.indentLevel;

        ip = EditorGUILayout.BeginFoldoutHeaderGroup(ip, "IntPopup");
        if (ip)
        {
            EditorGUI.indentLevel++;

            SelectIP = EditorGUILayout.IntPopup("IntPopup", SelectIP, Names, Sizes);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        EditorGUI.indentLevel = indent;
        EditorGUILayout.Space(spase);
    }

    int ISValue = 50;
    bool iS = false;
    void IntSlider()
    {
        var indent = EditorGUI.indentLevel;

        iS = EditorGUILayout.BeginFoldoutHeaderGroup(iS, "IntSlider");
        if (iS)
        {
            EditorGUI.indentLevel++;

            ISValue = EditorGUILayout.IntSlider("IntSlider", ISValue, 1, 100);
            SerializedObject obj = serializedObject;
            SerializedProperty prop = obj.FindProperty("a");
            prop.intValue = EditorGUILayout.IntSlider("IntSlider", prop.intValue, 1, 100);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        EditorGUI.indentLevel = indent;
        EditorGUILayout.Space(spase);
    }
    #endregion

    #endregion
}