using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Creature))]
[CanEditMultipleObjects]
public class CreatureEditor : Editor
{
    SerializedProperty startingState;
    SerializedProperty states;

    SerializedProperty health;
    SerializedProperty sightRange;
    SerializedProperty agent;

    void OnEnable()
    {
        startingState = serializedObject.FindProperty("startingState");
        states = serializedObject.FindProperty("entries");
        health = serializedObject.FindProperty("health");
        sightRange = serializedObject.FindProperty("sightRange");
        agent = serializedObject.FindProperty("agent");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(startingState);
        EditorGUILayout.PropertyField(states);
        EditorGUILayout.PropertyField(health);
        EditorGUILayout.PropertyField(sightRange);
        EditorGUILayout.PropertyField(agent);
        serializedObject.ApplyModifiedProperties();
        
        EditorGUILayout.LabelField("(Above this object)");
    }
}