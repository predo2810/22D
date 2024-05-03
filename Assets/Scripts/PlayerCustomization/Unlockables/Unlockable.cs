using UnityEngine;
using UnityEngine.UI;

public class Unlockable : MonoBehaviour
{
    [SerializeField] private float RequiredPoints;

    [SerializeField] private TMPro.TMP_Text RequiredText;
    
    [SerializeField] private Button ThisButton;

    [SerializeField] private GameObject LockedFilter;

    private void Awake()
    {
        RequiredText.text = RequiredPoints.ToString();

        bool unlocked = PlayerPrefs.GetFloat("Record") >= RequiredPoints;

        ThisButton.interactable = unlocked;
        LockedFilter.SetActive(!unlocked);
    }
}
