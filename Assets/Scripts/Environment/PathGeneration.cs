using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PathGeneration : MonoBehaviour
{
    public GameObject baseTile;
    public float pathLengthScale;

    public GameObject platformPrefab;
    public GameObject checkpointPlatformPrefab;
    public GameObject finalePlatformPrefab;

    private int totalPathLength;
    // Start is called before the first frame update
    void Start()
    {  
        baseTile = GenerateCurvyPath(baseTile, 10, false);
        baseTile = GenerateCurvyPath(baseTile, 10, false);
        GenerateCurvyPath(baseTile, 15, true);
    }

    private GameObject GenerateCurvyPath(GameObject baseTile, int pathLength, bool isFinale)
    {
        GameObject checkpointPlatform;

        float frontPath = (baseTile.transform.localScale.x + platformPrefab.transform.localScale.x) * 5 + baseTile.transform.localPosition.x;
        float sidePaths = (baseTile.transform.localScale.x - platformPrefab.transform.localScale.x) * 5 + baseTile.transform.localPosition.x;

        for (int i = 0; i < Mathf.Round(pathLength * pathLengthScale) - 1; i++)
        {
            Instantiate(platformPrefab, new Vector3(frontPath, baseTile.transform.localPosition.y, baseTile.transform.localPosition.z), platformPrefab.transform.rotation, transform);
            frontPath += 3;
        }

        for (int i = 0; i < Mathf.Round(pathLength * pathLengthScale) + 1; i++)
        {
            Instantiate(platformPrefab, new Vector3(sidePaths, baseTile.transform.localPosition.y, baseTile.transform.localPosition.z + ((baseTile.transform.localScale.x + platformPrefab.transform.localScale.x) * 5)), platformPrefab.transform.rotation, transform);
            Instantiate(platformPrefab, new Vector3(sidePaths, baseTile.transform.localPosition.y, baseTile.transform.localPosition.z - ((baseTile.transform.localScale.x + platformPrefab.transform.localScale.x) * 5)), platformPrefab.transform.rotation, transform);
            sidePaths += 3;
        }

        if (isFinale)
        {
            checkpointPlatform = Instantiate(finalePlatformPrefab, new Vector3(baseTile.transform.localPosition.x + pathLength * platformPrefab.transform.localScale.x * 10 + ((baseTile.transform.localScale.x + platformPrefab.transform.localScale.x) * 5 + 1), baseTile.transform.localPosition.y, baseTile.transform.localPosition.z), finalePlatformPrefab.transform.rotation, transform);
        }
        else
        {
            checkpointPlatform = Instantiate(checkpointPlatformPrefab, new Vector3(baseTile.transform.localPosition.x + pathLength * platformPrefab.transform.localScale.x * 10 + ((baseTile.transform.localScale.x + platformPrefab.transform.localScale.x) * 5 + 1), baseTile.transform.localPosition.y, baseTile.transform.localPosition.z), checkpointPlatformPrefab.transform.rotation, transform);
        }

        return checkpointPlatform;
    }
}
