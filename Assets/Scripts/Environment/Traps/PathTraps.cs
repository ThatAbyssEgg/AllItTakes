using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTraps : MonoBehaviour
{
    public int trapChance;
    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range (1, 100) < trapChance) 
        {
            switch (Random.Range(1, 3))
            {
                case 1: gameObject.AddComponent<ExplosionTrap>(); break;
                case 2: gameObject.AddComponent<WindTrap>(); break;
                case 3: gameObject.AddComponent<ShrinkingTrap>(); break;
            }
        }
    }
}
