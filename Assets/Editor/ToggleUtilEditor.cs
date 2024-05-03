using UnityEditor;

[CustomEditor(typeof(ToggleUtil))]
public class ToggleUtilEditor : Editor
{
    private SerializedProperty PrefsValueProp;
    private SerializedProperty SaveValueProp;
    private SerializedProperty DefaultValueProp;
    private SerializedProperty TranslatorProp;
    private SerializedProperty EventsEnabledProp;
    private SerializedProperty TrueEventProp;
    private SerializedProperty FalseEventProp;

    private void OnEnable()
    {
        PrefsValueProp = serializedObject.FindProperty("PrefsValue");
        SaveValueProp = serializedObject.FindProperty("SaveValue");
        DefaultValueProp = serializedObject.FindProperty("DefaultValue");
        TranslatorProp = serializedObject.FindProperty("Translator");
        EventsEnabledProp = serializedObject.FindProperty("UseEvents");
        TrueEventProp = serializedObject.FindProperty("TrueCall");
        FalseEventProp = serializedObject.FindProperty("FalseCall");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.LabelField("Saving", EditorStyles.boldLabel);
        
        SaveValueProp.boolValue = EditorGUILayout.Toggle("Save Value", SaveValueProp.boolValue);

        EditorGUILayout.Space();

        EditorGUI.BeginDisabledGroup(!SaveValueProp.boolValue);

        EditorGUILayout.PropertyField(DefaultValueProp);
        EditorGUILayout.PropertyField(PrefsValueProp);

        EditorGUI.EndDisabledGroup();

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Display Text", EditorStyles.boldLabel);

        EditorGUILayout.PropertyField(TranslatorProp);

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Actions", EditorStyles.boldLabel);

        EventsEnabledProp.boolValue = EditorGUILayout.Toggle("Use Events", EventsEnabledProp.boolValue);

        EditorGUILayout.Space();

        EditorGUI.BeginDisabledGroup(!EventsEnabledProp.boolValue);

        EditorGUILayout.PropertyField(TrueEventProp);        
        EditorGUILayout.PropertyField(FalseEventProp);        

        EditorGUI.EndDisabledGroup();

        serializedObject.ApplyModifiedProperties();
    }
}
