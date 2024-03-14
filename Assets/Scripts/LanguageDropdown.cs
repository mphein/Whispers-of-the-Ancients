using UnityEngine;
using TMPro; 
using UnityEngine.Localization.Settings; 

public class LanguageDropdown : MonoBehaviour
{
    public TMP_Dropdown languageDropdown;

    private void Start()
    {
        PopulateLanguageDropdown();
    }

    private void PopulateLanguageDropdown()
    {
        languageDropdown.options.Clear(); 
        var locales = LocalizationSettings.AvailableLocales.Locales;

        foreach (var locale in locales)
        {
            TMP_Dropdown.OptionData newOption = new TMP_Dropdown.OptionData(locale.Identifier.CultureInfo.NativeName);
            languageDropdown.options.Add(newOption); 
        }
        languageDropdown.value = locales.IndexOf(LocalizationSettings.SelectedLocale);
        languageDropdown.RefreshShownValue();
        languageDropdown.onValueChanged.AddListener(ChangeLanguage);
    }

    public void ChangeLanguage(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }
}