using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CoupleRespawner : MonoBehaviour
{
    public GameObject parent; // The parent object containing all the spawn points
    public GameObject[] couples; // The couple prefabs to spawn

    public static bool coupleExists = false;
    private int spawnIndex;
    private int coupleIndex;

    private List<ARAnchor> spawnPointAnchors = new List<ARAnchor>();

    void Start()
    {
        // Initialize spawn points and ensure each has an ARAnchor component
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            GameObject spawnPoint = parent.transform.GetChild(i).gameObject;

            // Ensure the spawn point has an ARAnchor component
            ARAnchor anchor = spawnPoint.GetComponent<ARAnchor>();
            if (anchor == null)
            {
                anchor = spawnPoint.AddComponent<ARAnchor>();
            }

            spawnPointAnchors.Add(anchor);
        }

        // Randomly initialize spawn and couple indices
        spawnIndex = Random.Range(0, parent.transform.childCount);
        coupleIndex = Random.Range(0, couples.Length);
    }

    void Update()
    {
        if (!coupleExists)
        {
            spawnIndex = Random.Range(0, parent.transform.childCount);
            StartCoroutine(RespawnCoroutine(spawnIndex));
        }

        if (parent.transform.GetChild(spawnIndex).childCount < 1)
        {
            coupleExists = false;
        }
    }

    IEnumerator RespawnCoroutine(int index)
    {
        CoupleSpawn(index);
        coupleExists = true;
        yield return new WaitForSeconds(1f);
    }

    void CoupleSpawn(int index)
    {
        coupleIndex = Random.Range(0, couples.Length);

        Transform spawnPointTransform = parent.transform.GetChild(index);

        if (spawnPointTransform.childCount < 1)
        {
            GameObject couple = Instantiate(couples[coupleIndex], spawnPointTransform.position, spawnPointTransform.rotation);
            couple.transform.SetParent(spawnPointTransform, false);
        }
    }
}
