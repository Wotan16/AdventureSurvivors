using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TavernUI : WindowUI
{
    public event Action OnCloseButtonPressed;

    [SerializeField] private Transform heroInfoParent;
    [SerializeField] private TavernHeroInfoUI heroInfoPrefab;
    [SerializeField] private List<TavernHeroInfoUI> activeInfos;
    [SerializeField] private Button closeButton;

    private void Awake()
    {
        closeButton.onClick.AddListener(() =>
        {
            OnCloseButtonPressed?.Invoke();
        });
    }

    public void UpdateHeroesInfo(List<HeroData> heroesData)
    {
        ClearInfos();
        foreach (HeroData data in heroesData)
        {
            TavernHeroInfoUI info = Instantiate(heroInfoPrefab, heroInfoParent);
            info.UpdateHeroUI(data);
            activeInfos.Add(info);
        }
    }

    private void ClearInfos()
    {
        foreach (TavernHeroInfoUI info in activeInfos)
        {
            Destroy(info.gameObject);
        }
        activeInfos.Clear();
    }
}
