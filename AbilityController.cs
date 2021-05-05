using UnityEngine;
using System.Collections;

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
        
        for (int i=0; i<3; i++)
        {
            if (ability[i].isCoolingDown)
            {
                //StartCoroutine(ability.)
            }
        }

        ability[1].Use();
    }

    public IEnumerator CoolDown(i)
    {
        yield return new WaitForSeconds(ability[i]);
        isCoolingDown = false;
    }
}
