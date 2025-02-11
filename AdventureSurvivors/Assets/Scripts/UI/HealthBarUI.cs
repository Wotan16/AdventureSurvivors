using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : WindowUI
{
    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private Image filler;

    private void Start()
    {
        UpdateHealthBar();
        healthSystem.OnHealthChanged += UpdateHealthBar;
    }

    private void UpdateHealthBar()
    {
        if(healthSystem.IsHealthFull || healthSystem.IsDead)
        {
            Hide();
            return;
        }
        
        Show();
        filler.fillAmount = healthSystem.GetHealthNormalized();
    }
}
