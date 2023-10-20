using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        float randomXPosition = Random.Range(-transform.localPosition.x - 5, transform.localPosition.x + 5);
        float randomZPosition = Random.Range(-transform.localPosition.z - 5, transform.localPosition.z + 5);
        Vector3 playerCoordinates = new Vector3(randomXPosition, 0.3f, randomZPosition);
        player.transform.localPosition = playerCoordinates;
        //Instantiate(player, playerCoordinates, player.transform.rotation, transform.parent);
    }
}
