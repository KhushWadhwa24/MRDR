using UnityEngine;

public class Target : MonoBehaviour
{
    public int health = 8; // Health of the target

    // Call this method to reduce the health of the target
    public void ReduceHealth()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject); // Destroy the target when health reaches 0
        }
    }


}
