using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoSingleton<HealthBar>
{
    [SerializeField] private Image healthBar;
    [SerializeField] [Range(0, 1)] private float damagePerSecond;
    [SerializeField] [Range(0, 1)] private float damagePerJump; 
    [SerializeField] [Range(0, 100)] private int damagePerHit;
    [SerializeField] [Range(0, 1)] private float healthGain; 
    private float _maxHealth;
    private float _currentHealth;
    private void Start()
    {
        _maxHealth = 100;
        _currentHealth = _maxHealth;
    }
    
    public void ApplyJumpDamage()
    {
        _currentHealth -= damagePerJump;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, 100);
    }

    public void ApplyHitDamage()
    {
        _currentHealth -= damagePerHit;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, 100);
    }

    public void ApplyHealthGain()
    {
        _currentHealth += healthGain;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, 100);
    }

    public float GetHealth()
    {
        return _currentHealth;
    }

    public void ApplyAutomaticDamage()
    {
        _currentHealth -= damagePerSecond;
        healthBar.fillAmount = _currentHealth/_maxHealth;
    }
}
