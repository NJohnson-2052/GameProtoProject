using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int currentWeapon = 0;

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime;

        if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        // Swap between weapon 0 and 1
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentWeapon = (currentWeapon + 1) % 2;
            Debug.Log("Current weapon: " + currentWeapon);
        }
    }
}

