using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TamQuoc
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _healthBarSprite;

        public void UpdateHealthBar(float maxHealth, float currentHealth)
        {
            if (maxHealth < 1) maxHealth = 1;
            float pros = currentHealth / maxHealth;
            if(pros <0 ) { pros = 0; }
            if (pros > 1) { pros = 1; }
            _healthBarSprite.fillAmount = currentHealth / maxHealth;
        }
    }
}
