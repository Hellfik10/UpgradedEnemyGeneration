using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _repeatRate = 3;
    [SerializeField] private List<SpawnPoint> _spawnPoints = new List<SpawnPoint>();

    private void Start()
    {
        StartCoroutine(GetEnemy());
    }

    private IEnumerator GetEnemy()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_repeatRate);

        while (enabled)
        {
            int spawnPointIndex = Random.Range(0, _spawnPoints.Count);
            _spawnPoints[spawnPointIndex].Spawn();

            yield return waitForSeconds;
        }
    }
}
