using UnityEngine;

public class CustomizationManager : MonoBehaviour
{
    [SerializeField] private UnlockableItem[] EyeItems;
    [SerializeField] private UnlockableItem[] HeadItems;
    [SerializeField] private UnlockableItem[] FaceItems;
    [SerializeField] private TrailRenderer[] Trails;

    [SerializeField] private SpriteRenderer EyeEquip, HeadEquip, FaceEquip;

    [SerializeField] private TrailRenderer PlayerTrail;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("HeadEquip"))
            PlayerPrefs.SetInt("HeadEquip", -1);

        if (!PlayerPrefs.HasKey("EyeEquip"))
            PlayerPrefs.SetInt("EyeEquip", -1);

        if (!PlayerPrefs.HasKey("FaceEquip"))
            PlayerPrefs.SetInt("FaceEquip", -1);

        if (!PlayerPrefs.HasKey("TrailEquip"))
            PlayerPrefs.SetInt("TrailEquip", -1);

        EquipHead(PlayerPrefs.GetInt("HeadEquip"));
        EquipEye(PlayerPrefs.GetInt("EyeEquip"));
        EquipFace(PlayerPrefs.GetInt("FaceEquip"));
        EquipTrail(PlayerPrefs.GetInt("TrailEquip"));
    }

    public void EquipEye(int itemID)
    {
        if (itemID == -1)
        {
            EyeEquip.sprite = null;
            EyeEquip.transform.localScale = Vector2.one;
            EyeEquip.transform.localPosition = Vector2.zero;
            PlayerPrefs.SetInt("EyeEquip", -1);
            return;
        }

        UnlockableItem item = EyeItems[itemID];

        EyeEquip.sprite = item.ThisSprite;
        EyeEquip.transform.localScale = item.Size;
        EyeEquip.transform.localPosition = item.Offset;
        PlayerPrefs.SetInt("EyeEquip", itemID);
    }

    public void EquipHead(int itemID)
    {
        if (itemID == -1)
        {
            HeadEquip.sprite = null;
            HeadEquip.transform.localScale = Vector2.one;
            HeadEquip.transform.localPosition = Vector2.zero;
            PlayerPrefs.SetInt("HeadEquip", -1);
            return;
        }

        UnlockableItem item = HeadItems[itemID];
        
        HeadEquip.sprite = item.ThisSprite;
        HeadEquip.transform.localScale = item.Size;
        HeadEquip.transform.localPosition = item.Offset;
        PlayerPrefs.SetInt("HeadEquip", itemID);
    }

    public void EquipFace(int itemID)
    {
        if (itemID == -1)
        {
            FaceEquip.sprite = null;
            FaceEquip.transform.localScale = Vector2.one;
            FaceEquip.transform.localPosition = Vector2.zero;
            PlayerPrefs.SetInt("FaceEquip", -1);
            return;
        }

        UnlockableItem item = FaceItems[itemID];
        
        FaceEquip.sprite = item.ThisSprite;
        FaceEquip.transform.localScale = item.Size;
        FaceEquip.transform.localPosition = item.Offset;
        PlayerPrefs.SetInt("FaceEquip", itemID);
    }

    public void EquipTrail(int itemID)
    {
        if (itemID == -1)
        {
            PlayerTrail.enabled = false;
            PlayerPrefs.SetInt("TrailEquip", -1);
            return;
        }

        PlayerTrail.enabled = true;

        CopyTrailValues(Trails[itemID], PlayerTrail);

        PlayerPrefs.SetInt("TrailEquip", itemID);
    }

    private void CopyTrailValues(TrailRenderer source, TrailRenderer destination)
    {
        // destination.startWidth = source.startWidth;
        // destination.endWidth = source.endWidth;
        destination.widthCurve = source.widthCurve;
        destination.time = source.time;
        destination.colorGradient = source.colorGradient;
    }
}