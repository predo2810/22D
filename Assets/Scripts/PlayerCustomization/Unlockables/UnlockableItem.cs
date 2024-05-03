using UnityEngine;

[CreateAssetMenu(menuName = "22D/UnlockableItem")]
public class UnlockableItem : ScriptableObject
{
    public Vector2 Size;
    public Vector2 Offset;

    public Sprite ThisSprite;

    public enum UnlockableType
    {
        Eyes,
        Head,
        Face,
    }

    public UnlockableType Type;
}
