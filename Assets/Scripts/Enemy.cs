using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public int health = 3;
    public int weakness = 1;

    private SpriteRenderer sr;
    private Color originalColor;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            originalColor = sr.color;
        }
    }

    public void TakeDamage(int weaponType, int damage)
    {
        bool isCrit = (weaponType == weakness);

        if (isCrit)
        {
            damage *= 3;
        }

        health -= damage;
        Debug.Log(name + " health: " + health + (isCrit ? " (CRIT!)" : ""));

        if (sr != null)
        {
            StopAllCoroutines();
            StartCoroutine(FlashColor(isCrit ? Color.white : Color.red, health <= 0));
        }
        else if (health <= 0)
        {
            // No sprite renderer to flash, just die immediately
            Destroy(gameObject);
        }
    }

    IEnumerator FlashColor(Color flashColor, bool destroyAfter)
    {
        sr.color = flashColor;
        yield return new WaitForSeconds(0.15f);

        if (destroyAfter)
        {
            Destroy(gameObject);
        }
        else
        {
            sr.color = originalColor;
        }
    }
}