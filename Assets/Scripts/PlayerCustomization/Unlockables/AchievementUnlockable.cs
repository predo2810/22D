using UnityEngine.UI;
using UnityEngine;

public class AchievementUnlockable : MonoBehaviour
{
    [SerializeField] private string AchievementString;
    
    [SerializeField] private Button ThisButton;

    [SerializeField] private GameObject LockedFilter;

    private void Awake()
    {
        bool unlocked = GameManager.GetPrefsBool(AchievementString, false);

        ThisButton.interactable = unlocked;
        LockedFilter.SetActive(!unlocked);
    }
}