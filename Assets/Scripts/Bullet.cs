using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 1;
    public int weaponType = 0;
    public Rigidbody2D rb;

    public Color weapon0Color = Color.cyan;
    public Color weapon1Color = Color.yellow;

    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        rb.velocity = transform.right * speed;
        Destroy(gameObject, 3f);
    }

    public void SetWeaponType(int type)
    {
        weaponType = type;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.color = (weaponType == 0) ? weapon0Color : weapon1Color;
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("Trigger entered with: " + hitInfo.name + " | weaponType=" + weaponType);

        Enemy enemy = hitInfo.GetComponentInParent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(weaponType, damage);
        }

        Destroy(gameObject);
    }
}