using UnityEngine;

public class PlayerColorManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] PlayerParts;

    [SerializeField] private TrailRenderer PlayerTrail;

    [SerializeField] private TMPro.TMP_Text Title;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("PlayerColorR"))
            PlayerPrefs.SetFloat("PlayerColorR", 1);
    }

    private void Update()
    {
        Color c = new Color(PlayerPrefs.GetFloat("PlayerColorR"), PlayerPrefs.GetFloat("PlayerColorG"), PlayerPrefs.GetFloat("PlayerColorB"));

        foreach (SpriteRenderer renderer in PlayerParts)
            renderer.color = c;

        if (Title)
            Title.color = c;

        PlayerTrail.startColor = c;
    }
}