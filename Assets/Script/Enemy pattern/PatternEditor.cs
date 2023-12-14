using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Enemy)), CanEditMultipleObjects]

public class PatternEditor : Editor
{

    protected virtual void OnSceneGUI()
    {

        Enemy Enemy = (Enemy)target;
        EditorGUI.BeginChangeCheck();
        if (Enemy.patternOn)
        {

            for (int i = 0; i < Enemy.Pattern.Length; i++)
            {
                Vector2 newTargetPosition = Handles.PositionHandle(Enemy.Pattern[i], Quaternion.identity);

                if (EditorGUI.EndChangeCheck())
                {
                    Enemy.Pattern[i] = newTargetPosition;
                }
            }
        }
    }
}