using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public GameObject platformObject;
    public GameObject climbObject;
    public GameObject emptyObject;
    public GameObject enemyMelee;
    public GameObject enemyCharged;
    public GameObject enemyRanged;
    public Transform terrainParent;
    public int platformNumber;
    int platformCount;
    int distanceTakenUp;
    int currentGap;
    int currentPlatform;
    float currentHeight = -4.75f;
    bool firstPlatform = true;
    bool lastPlatformIsPlatform = true;
    bool isDirectionRight = true;
    // Start is called before the first frame update
    void Start()
    {
        /*float perlinNoiseX = Random.Range(-999f, 999f);
        float perlinNoiseY = Random.Range(-999f, 999f);
        float offsetX = 0f;
        float offsetY = 0f;
        float scaleX = 0f;
        while(platformCount < 6)
        {
            if (Mathf.PerlinNoise(perlinNoiseX + offsetX, perlinNoiseY + offsetX) > 0.5)
            {
                Vector3 pos = new Vector3(-8.94f + offsetX + scaleX, -4.94f + Mathf.FloorToInt(offsetX / 8), 0);
                GameObject platform = Instantiate(terrainObject, pos, Quaternion.identity);
                float newScaleX = Random.Range(0.5f, 4f);
                platform.transform.localScale = new Vector3(newScaleX, Random.Range(1f, 1.2f), 1);
                scaleX = newScaleX;
                platformCount++;
            }
            offsetX++;
            offsetY++; 
        }*/

        for (int i = 0; i < platformNumber; i++)
        {
            if (firstPlatform)
            {
                Vector3 pos = new Vector3(-7.89f + distanceTakenUp, currentHeight, 0);
                GameObject Terrain = Instantiate(platformObject, pos, Quaternion.identity, terrainParent);
                Terrain.layer = 8;
                distanceTakenUp += 2;
                currentGap = 0;
                firstPlatform = false;
            }
            else
            {
                int blockChosen = Random.Range(1, 10);
                if ((blockChosen > 6 || currentGap >= 3) && currentPlatform < 3)
                {
                    Vector3 pos = new Vector3 (0,0,0);
                    if(-7.89f + distanceTakenUp >= 8 && isDirectionRight)
                    {
                        isDirectionRight = false;
                        currentHeight += 2;
                        distanceTakenUp = 0;
                    }
                    else if (8f - distanceTakenUp <= -7.9f && !isDirectionRight)
                    {
                        isDirectionRight = true;
                        currentHeight += 2;
                        distanceTakenUp = 0;
                    }
                    if (isDirectionRight)
                    {
                        pos = new Vector3(-7.89f + distanceTakenUp, currentHeight, 0);
                    } else if (!isDirectionRight)
                    {
                        pos = new Vector3(8f - distanceTakenUp, currentHeight, 0);
                    }
                    GameObject Terrain = Instantiate(platformObject, pos, Quaternion.identity, terrainParent);
                    Terrain.layer = 8;
                    distanceTakenUp += 2;
                    currentGap = 0;
                    currentPlatform += 1;
                    lastPlatformIsPlatform = true;

                    if (currentPlatform >=2 && Random.Range(0f,1f) > 0.5)
                    {
                        pos = pos + new Vector3 (0f, 0.5f, 0f);
                        float random = Random.Range(0f, 1f);
                        if (random > 0.4f)
                            Instantiate(enemyMelee, pos, Quaternion.identity);
                        if (random <= 0.4f && random > 0.1f)
                            Instantiate(enemyRanged, pos, Quaternion.identity);
                        if (random <= 0.1f)
                            Instantiate(enemyCharged, pos, Quaternion.identity);
                    }
                }
                else if (blockChosen == 5 && lastPlatformIsPlatform)
                {
                    Vector3 pos = new Vector3(0, 0, 0);
                    if (-7.89f + distanceTakenUp - 0.5f >= 8.6 && isDirectionRight)
                    {
                        isDirectionRight = false;
                        currentHeight += 2;
                        distanceTakenUp = 0;
                    }
                    else if (8f - distanceTakenUp + 0.5f <= -8.6f && !isDirectionRight)
                    {
                        isDirectionRight = true;
                        currentHeight += 2;
                        distanceTakenUp = 0;
                    }
                    if (isDirectionRight)
                    {
                        pos = new Vector3(-7.89f + distanceTakenUp - 0.5f, currentHeight, 0);
                    }
                    else if (!isDirectionRight)
                    {
                        pos = new Vector3(8f - distanceTakenUp + 0.5f, currentHeight, 0);
                    }
                    GameObject climbThing = Instantiate(climbObject, pos, Quaternion.identity, terrainParent);
                    climbThing.layer = 8;
                    if (!isDirectionRight)
                    {
                        climbThing.transform.Rotate(0, 180, 0);
                    }
                    distanceTakenUp += 1;
                    currentHeight += 0.5f;
                    currentGap = 0;
                    currentPlatform = 0;
                    lastPlatformIsPlatform = false;
                }
                else
                {
                    Vector3 pos = new Vector3(0, 0, 0);
                    if (-7.89f + distanceTakenUp - 0.5f >= 8.6 && isDirectionRight)
                    {
                        isDirectionRight = false;
                        currentHeight += 2;
                        distanceTakenUp = 0;
                    }
                    else if (8f - distanceTakenUp + 0.5f <= -8.6f && !isDirectionRight)
                    {
                        isDirectionRight = true;
                        currentHeight += 2;
                        distanceTakenUp = 0;
                    }
                    if (isDirectionRight)
                    {
                        pos = new Vector3(-7.89f + distanceTakenUp - 0.5f, currentHeight, 0);
                    }
                    else if (!isDirectionRight)
                    {
                        pos = new Vector3(8f - distanceTakenUp + 0.5f, currentHeight, 0);
                    }
                    Instantiate(emptyObject, pos, Quaternion.identity, terrainParent);
                    distanceTakenUp += 1;
                    currentGap += 1;
                    currentPlatform = 0;
                    lastPlatformIsPlatform = false;
                }
            }
        }   
    }
}
