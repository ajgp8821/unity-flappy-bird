using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {

    public int columnPoolSize = 5;
    public GameObject columnPrefab;
    public float spawnRate;
    
    private float columnMin = -1.2f;
    private float columnMax = 3.3f;
    private float spawnXPosition = 3.6f;

    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-5, 0);

    private float timeSinceLastSpawned;

    private int currentColumn;

    // Start is called before the first frame update
    private void Start() {
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++) {
            columns[i] = Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
        SpawnColumn();
    }

    // Update is called once per frame
    private void Update() {
        timeSinceLastSpawned += Time.deltaTime;
        if (!GameController.gameController.gameOver && timeSinceLastSpawned >= spawnRate) {
            timeSinceLastSpawned = 0;
            SpawnColumn();
        }
    }

    private void SpawnColumn() {
        float spawnYPosition = Random.Range(columnMin, columnMax);
        columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
        currentColumn++;
        if (currentColumn >= columnPoolSize) {
            currentColumn = 0;
        }
    }
}
