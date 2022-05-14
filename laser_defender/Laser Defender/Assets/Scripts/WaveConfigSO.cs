using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;

    [SerializeField] float moveSpeed = 5f;

    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;



    public float getSpeed(){
         return moveSpeed;
    }

    public Transform getStartPoint(){
        return pathPrefab.GetChild(0);
    }

    public List<Transform> getWaypoints(){
        List<Transform> waypoints = new List<Transform>();

        foreach(Transform wp in pathPrefab){
            waypoints.Add(wp);
        }

        return waypoints;
    }

    public int getEnemyCount(){
        return enemyPrefabs.Count;
    }

    public GameObject getEnemyGameObject(int index){
        return enemyPrefabs[index];
    }


    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance,
                                        timeBetweenEnemySpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }


}
