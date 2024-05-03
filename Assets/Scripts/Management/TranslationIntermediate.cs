using UnityEngine;

[System.Serializable]
public class Translations
{
    public string[] TranslatedTexts;
}

public class TranslationIntermediate : MonoBehaviour
{
    [SerializeField] private string[] TranslatedStrings;

    [SerializeField] private string[] TranslatedStringsStart;
    [SerializeField] private string[] TranslatedStringsEnd;

    [SerializeField] private Translations[] TranslatedStringsList;

    [SerializeField] private TMPro.TMP_Text Target;

    public void Translate(string middleString)
    {
        int savedIndex = PlayerPrefs.GetInt("Language", 0);

        Target.text = $"{TranslatedStringsStart[savedIndex]}{middleString}{TranslatedStringsEnd[savedIndex]}";
    }

    public void TranslateWithList(int listIndex)
    {
        Target.text = TranslatedStringsList[listIndex].TranslatedTexts[PlayerPrefs.GetInt("Language", 0)];
    }

    public void TranslateWithListStartEnd(int listIndex)
    {
        int savedIndex = PlayerPrefs.GetInt("Language", 0);

        Target.text = $"{TranslatedStringsStart[savedIndex]}{TranslatedStringsList[listIndex].TranslatedTexts[savedIndex]}{TranslatedStringsEnd[savedIndex]}";
    }

    public void TranslateTarget()
    {
        Target.text = TranslatedStrings[PlayerPrefs.GetInt("Language", 0)];
    }
}
