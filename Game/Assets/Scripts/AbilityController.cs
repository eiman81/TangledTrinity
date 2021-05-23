using UnityEngine;

public class AbilityController : MonoBehaviour
{
    public Ability[] ability;

    public GameObject fireball;

    PlayerStats stats;

    void Awake()
    {
        stats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        ability[0].Use();
        ability[1].Use();
    }


}
