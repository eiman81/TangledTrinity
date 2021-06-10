using UnityEngine;

[CreateAssetMenu (fileName = "Player")]
public class PlayerStats : ScriptableObject
{
    public string playerName;
    public string description;
    public int age;

    public float speed;
    public float health;

    public GameObject playerPrefab;

    public Ability[] abilities;
}
