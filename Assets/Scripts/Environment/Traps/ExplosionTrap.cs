using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class ExplosionTrap : MonoBehaviour
{
    public Material classicTileMaterial;
    public Material explosionDangerMaterial;
    public Material explosionTriggerMaterial;

    private GameObject player;
    private float triggerTime;
    private float explosionTime;
    private bool isInDanger;
    private bool isInRadius;

    void Awake()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        isInRadius = Physics.CheckBox(transform.localPosition, transform.localScale, transform.localRotation, 6);
        if (isInRadius && !isInDanger)
        {
            Debug.Log("Trap triggered. Stay out!");
            gameObject.GetComponent<MeshRenderer>().material = explosionDangerMaterial;
            triggerTime = 5f;
            isInDanger = true;
        }

        if (isInDanger)
        {
            triggerTime -= Time.deltaTime;
        }

        if (triggerTime < 0)
        {
            gameObject.GetComponent<MeshRenderer>().material = explosionTriggerMaterial;
            explosionTime = 1;
        }

        if (explosionTime > 0)
        {
            explosionTime -= Time.deltaTime;
            if (isInRadius)
            {
                Debug.Log("Boom you died");
            }
        }  
        
        if (explosionTime <= 0)
        {
            isInDanger = false;
            gameObject.GetComponent<MeshRenderer>().material = classicTileMaterial;
        }
    }
}
