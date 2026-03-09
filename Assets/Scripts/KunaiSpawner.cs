using UnityEngine;

public class KunaiSpawner : MonoBehaviour
{
    public GameObject kunaiPrefab;
    public bool isRight = true;
    public float interval = 0.5f;
    public float offsetX = 1f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            SpawnKunai();
            timer = 0f;
        }
    }

    void SpawnKunai()
    {
        Vector3 spawnPosition = transform.position + new Vector3(isRight ? offsetX : -offsetX, 0, 0);
        GameObject kunai = Instantiate(kunaiPrefab, spawnPosition, Quaternion.identity);
        kunai.GetComponent<Kunai>().kunaiInit(isRight, false);
    }
}
