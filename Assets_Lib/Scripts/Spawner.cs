using UnityEngine;

public class Spawner : MonoBehaviour 
{
    public GameObject fish1;
    public GameObject fish2;
    public GameObject fish3;
    public float in1 = 1f;
    public float in2 = 5f;
    public float in3 = 10f;
    public float de1 = 6f;
    public float de2 = 8f;
    public float de3 = 10f;

    void Start()  // Changed from 'start' to 'Start'
    {
        InvokeRepeating("Spawna", in1, de1);  // Changed method names to match exactly
        InvokeRepeating("Spawnb", in2, de2);
        InvokeRepeating("Spawnc", in3, de3);
    }

    void Spawna()  // Changed method name to match InvokeRepeating call
    {
        Vector3 randomSpawnPositiona = new Vector3(Random.Range(-4.5f,4.5f), -30, Random.Range(48f,60f));  // Corrected variable name
        Instantiate(fish1, randomSpawnPositiona,Quaternion.Euler(0,90,0));
    }

    void Spawnb()  // Changed method name to match InvokeRepeating call
    {
        Vector3 randomSpawnPositionb = new Vector3(Random.Range(-4.5f, 4.5f), -30,  Random.Range(48f,60f));  // Corrected variable name
        Instantiate(fish2, randomSpawnPositionb,Quaternion.Euler(0,90,0));
    }

    void Spawnc()  // Changed method name to match InvokeRepeating call
    {
        Vector3 randomSpawnPositionc = new Vector3(Random.Range(-4.5f, 4.5f), -30, Random.Range(48f,60f));  // Corrected variable name
        Instantiate(fish3, randomSpawnPositionc,Quaternion.Euler(0,90,0));
    }
}
