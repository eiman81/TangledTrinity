using UnityEngine;

public class Ability : ScriptableObject
{
    // Ability properties
    public int amount;
    public float coolDown;
    
    // Reference a character's stats so we can access properties such as health
    [HideInInspector]
    public GameObject player;
    [HideInInspector]
    public PlayerStats stats;

    public virtual void Use ()
    {
        player = GameObject.FindWithTag ("Player");
        stats = player.GetComponent<PlayerStats> ();
    }
}
