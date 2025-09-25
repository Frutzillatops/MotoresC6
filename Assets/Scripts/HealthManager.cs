using UnityEngine;

public class HealthManager : MonoBehaviour, IHealth
{
     int health;

    public int Health { get { return health; } set { health = value; } }
    public void TakeDamage(float damage) { }

    public void Death() { }

    void Update() 
    {
    }
}