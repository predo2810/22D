using UnityEngine;

[CreateAssetMenu(menuName = "22D/Achievement")]
public class AchievementItem : ScriptableObject
{
    public string SavedValue;
    public string StoreBool;

    public bool IsInt;
    public bool IsDecreasing;

    public float ValueToReach;

    public AudioClip EarnedClip;
}
