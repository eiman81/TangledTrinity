using UnityEngine;

public class Ability : ScriptableObject
{
    // Ability properties
    public int HealthAmount;

    // The cooldown of the ability
    public float coolDown;

    // The visual effect we can create when the ability is used
    public GameObject effect;

    [HideInInspector]
    // This is the timer for the cooldown so this number depletes when the ability is on cooldown
    public float x;
    
    // Reference a character's stats so we can access properties such as health
    [HideInInspector]
    public Player player;

    public virtual void Use ()
    {
        // Set the player to the gameobject with the tag "Player" in the world
        player = GameObject.FindWithTag ("Player").GetComponent<Player>();
    }
}
