using System;
using System.Collections.Generic;
using UnityEngine;

public class Tavern : MonoBehaviour, IInteractable
{
    public static event Action<Tavern> OnAnyTavernOpened;

    [SerializeField] private bool empty = false;
    [SerializeField] private List<HeroData> heroesData;
    public List<HeroData> HeroesData {  get { return heroesData; } }

    public bool CanInteract()
    {
        return !empty;
    }

    public void OnInteract()
    {
        OnAnyTavernOpened?.Invoke(this);
    }

    public void SetTavernActive(bool active)
    {
        empty = !active;
    }
}
