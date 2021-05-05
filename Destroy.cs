using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float time;

    void Update()
    {
        Destroy(gameObject, time);
    }
}
