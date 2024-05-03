using UnityEngine;
using UnityEngine.Events;

public class ToggleUtil : MonoBehaviour
{
    [SerializeField] private bool SaveValue = true;
    [SerializeField] private bool DefaultValue;

    [SerializeField] private string PrefsValue;

    [SerializeField] private TranslationIntermediate Translator;

    [SerializeField] private bool UseEvents;

    [SerializeField] private UnityEvent TrueCall;
    [SerializeField] private UnityEvent FalseCall;

    private bool Toggled = false;

    void Awake()
    {
        if (SaveValue)
        {
            Toggled = GameManager.GetPrefsBool(PrefsValue, DefaultValue);
            
            if (UseEvents)
                if (Toggled)
                    TrueCall.Invoke();
                else
                    FalseCall.Invoke();    
        }
            
        Translator.TranslateWithListStartEnd(Toggled ? 0 : 1);
    }

    public void Toggle()
    {
        Toggled = !Toggled;

        if (SaveValue)
            GameManager.StorePrefsBool(Toggled, PrefsValue);

        if (UseEvents)
            if (Toggled)
                TrueCall.Invoke();
            else
                FalseCall.Invoke();

        Translator.TranslateWithListStartEnd(Toggled ? 0 : 1);
    }
}