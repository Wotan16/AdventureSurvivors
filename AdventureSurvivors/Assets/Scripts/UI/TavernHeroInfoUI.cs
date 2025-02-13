using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TavernHeroInfoUI : MonoBehaviour
{
    public static event Action<HeroData> OnRecruitHeroButtonPressed;

    [SerializeField] private TextMeshProUGUI heroNameText;
    [SerializeField] private Image heroIcon;
    [SerializeField] private Button recruitButton;
    private HeroData heroData;

    public void UpdateHeroUI(HeroData heroData)
    {
        this.heroData = heroData;
        heroNameText.text = heroData.heroName;
        heroIcon.sprite = heroData.heroIcon;

        recruitButton.onClick.AddListener(() =>
        {
            OnRecruitHeroButtonPressed?.Invoke(heroData);
        });
    }
}
