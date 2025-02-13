using UnityEngine;

public class TavernManager : MonoBehaviour
{
    [SerializeField] private TavernUI tavernUI;
    private Tavern activeTavern;

    private void Start()
    {
        tavernUI.Hide();

        tavernUI.OnCloseButtonPressed += TavernUI_OnCloseButtonPressed;

        Tavern.OnAnyTavernOpened += Tavern_OnAnyTavernOpened;
        TavernHeroInfoUI.OnRecruitHeroButtonPressed += TavernHeroInfoUI_OnRecruitHeroButtonPressed;
    }

    private void TavernUI_OnCloseButtonPressed()
    {
        tavernUI.Hide();
        activeTavern = null;
    }

    private void TavernHeroInfoUI_OnRecruitHeroButtonPressed(HeroData data)
    {
        //recruit validation
        if (PlayerCharacters.Instance.partyFull)
            return;

        tavernUI.Hide();
        activeTavern.SetTavernActive(false);
        PlayerCharacters.Instance.AddHero(data);
    }

    private void Tavern_OnAnyTavernOpened(Tavern tavern)
    {
        activeTavern = tavern;
        tavernUI.UpdateHeroesInfo(activeTavern.HeroesData);
        tavernUI.Show();
    }

    private void OnDestroy()
    {
        Tavern.OnAnyTavernOpened -= Tavern_OnAnyTavernOpened;
        TavernHeroInfoUI.OnRecruitHeroButtonPressed -= TavernHeroInfoUI_OnRecruitHeroButtonPressed;
    }
}
