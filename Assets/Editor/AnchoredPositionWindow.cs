using UnityEditor;
using UnityEngine;

public class AnchoredPositionWindow : EditorWindow
{
    private RectTransform selectedRectTransform;

    [MenuItem("Window/Anchored Position Window")]
    public static void ShowWindow()
    {
        AnchoredPositionWindow window = GetWindow<AnchoredPositionWindow>();
        window.titleContent = new GUIContent("Anchored Position");
        window.Show();
    }

    private void OnGUI()
    {
        selectedRectTransform = Selection.activeTransform as RectTransform;

        if (selectedRectTransform != null)
        {
            EditorGUILayout.LabelField("Selected Object:", selectedRectTransform.name);
            EditorGUILayout.Vector2Field("Anchored Position:", selectedRectTransform.anchoredPosition);
            EditorGUILayout.FloatField("PositionY:", selectedRectTransform.rect.position.y);
        }
        else
        {
            EditorGUILayout.LabelField("No RectTransform selected.");
        }
    }
}
