using UnityEngine;
using UnityEngine.UI;

public class Achievement : MonoBehaviour
{
    [SerializeField] private Animator AchievementToast;

    [SerializeField] private Button AchievementButton;
    [SerializeField] private Image AchievementBorder;

    [SerializeField] private TMPro.TMP_Text AchievementName;

    [SerializeField] private TranslationIntermediate ToastTranslator;

    [SerializeField] private AchievementItem ThisAchievement;

    [SerializeField] private Color UnlockedColor, LockedColor;


    private void Start()
    {
        bool b = GameManager.GetPrefsBool(ThisAchievement.StoreBool, false);

        Color c = b ? UnlockedColor : LockedColor;

        AchievementName.color = c;
        AchievementBorder.color = c;

        AchievementButton.interactable = b;
    }

    private void Update()
    {
        if (GameManager.GetPrefsBool(ThisAchievement.StoreBool, false))
            return;

        if (ThisAchievement.IsDecreasing)
        {
            if (ThisAchievement.IsInt)
                if (PlayerPrefs.GetInt(ThisAchievement.SavedValue) <= ThisAchievement.ValueToReach)
                    Unlock();
            else
                if (PlayerPrefs.GetFloat(ThisAchievement.SavedValue) <= ThisAchievement.ValueToReach)
                    Unlock();
        }
        else
        {
            if (ThisAchievement.IsInt)
                if (PlayerPrefs.GetInt(ThisAchievement.SavedValue) >= ThisAchievement.ValueToReach)
                    Unlock();
            else
                if (PlayerPrefs.GetFloat(ThisAchievement.SavedValue) >= ThisAchievement.ValueToReach)
                    Unlock();
        }
    }

    private void Unlock()
    {
        ToastTranslator.TranslateTarget();
        AchievementToast.Play("FadeIn");
        AchievementToast.GetComponent<AudioSource>().PlayOneShot(ThisAchievement.EarnedClip);
        GameManager.StorePrefsBool(true, ThisAchievement.StoreBool);
    }
}