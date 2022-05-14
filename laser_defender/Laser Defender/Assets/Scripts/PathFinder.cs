using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO _WaveConfigSO;
    List<Transform> waypoints;
    int waypoint_index = 0;

    void Awake() {
        enemySpawner = FindObjectOfType<EnemySpawner>();    
    }

    void Start()
    {
        _WaveConfigSO = enemySpawner.getCurrentWaveConfig();
        waypoints = _WaveConfigSO.getWaypoints();
        transform.position = waypoints[waypoint_index].position;
    }

    void Update()
    {
        FollowPath();        

    }

    void FollowPath(){

        if(waypoint_index < waypoints.Count){
            
            Vector3 targetLocation = waypoints[waypoint_index].position;
            
            float delta = _WaveConfigSO.getSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetLocation, delta);
            if(transform.position == targetLocation) { waypoint_index++; }
        }
        else { Destroy(gameObject); }
    }

}
