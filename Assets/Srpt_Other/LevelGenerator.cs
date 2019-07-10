using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Range(20,60)] public float size;
    [Range(0, 10)] public float frequency;
    public int polyCount;
    public bool maze;

    public GameObject boundObj;
    public GameObject wallObj;
    public GameObject polyObj;

    public int numPolys;

    void Awake()
    {
        // Making boundary
        GameObject a = Instantiate(boundObj, gameObject.transform);
        a.transform.position = transform.up * (size / 2);
        a.transform.localScale = new Vector2(size-3, 3);
        GameObject b = Instantiate(boundObj, gameObject.transform);
        b.transform.position = transform.right * (size / 2);
        b.transform.localScale = new Vector2(3, size+3);
        GameObject c = Instantiate(boundObj, gameObject.transform);
        c.transform.position = -transform.up * (size / 2);
        c.transform.localScale = new Vector2(size-3, 3);
        GameObject d = Instantiate(boundObj, gameObject.transform);
        d.transform.position = -transform.right * (size / 2);
        d.transform.localScale = new Vector2(3, size+3);

        // Maze map option
        if (maze)
        {
            int genObjCount = (int)(frequency * Random.Range(4, 7));
            for (int i = 0; i < genObjCount; i++)
            {
                a = Instantiate(wallObj, gameObject.transform);
                a.transform.position = new Vector2(Random.Range(-size / 2 + 10, size / 2 - 10), Random.Range(-size / 2 + 10, size / 2 - 10));
                a.transform.localScale = new Vector2(Random.Range(5, 15), Random.Range(5, 15));
            }
        }

        
    }

    float nextPolySpawn;
    private void Update()
    {
        // Spawn Polys
        if (numPolys < polyCount && Time.time > nextPolySpawn)
        {
            nextPolySpawn = Time.time + 0.1f;
            numPolys++;
            GameObject a = Instantiate(polyObj);
            a.transform.position = new Vector2(Random.Range(-size / 2 + 4, size / 2 - 4), Random.Range(-size / 2 + 4, size / 2 - 4));
        }
    }
}