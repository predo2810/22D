using UnityEngine;

[RequireComponent(typeof(TMPro.TMP_Text))]
public class TranslatedText : MonoBehaviour
{
    [SerializeField] private string[] Translations;

    private void Start()
    {
        GetComponent<TMPro.TMP_Text>().text = Translations[PlayerPrefs.GetInt("Language", 0)];
    }
}
