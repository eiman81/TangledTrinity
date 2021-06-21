using UnityEngine;

public class Ability : ScriptableObject
{
    // Ability properties
    public int HealthAmount;
    public float coolDown;
    public GameObject effect;
    [HideInInspector]
    public float x;
    
    // Reference a character's stats so we can access properties such as health
    [HideInInspector]
    public Player player;

    public virtual void Use ()
    {
        player = GameObject.FindWithTag ("Player").GetComponent<Player>();
    }
}
