using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{       
    [SerializeField] List<WaveConfigSO> waveConfigs;
    WaveConfigSO currentWaveConfig;
    [SerializeField] bool isSpawnEnemy = true;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    public WaveConfigSO getCurrentWaveConfig(){
        return currentWaveConfig;
    } 

    IEnumerator SpawnEnemies(){

        do{
            foreach(WaveConfigSO wave in waveConfigs){
                currentWaveConfig = wave;
                for(int i=0; i<currentWaveConfig.getEnemyCount(); ++i){
                    Instantiate(currentWaveConfig.getEnemyGameObject(i), currentWaveConfig.getStartPoint().position, Quaternion.identity, transform);
                    yield return new WaitForSeconds(currentWaveConfig.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(currentWaveConfig.GetRandomSpawnTime());
        
            }
        }while(isSpawnEnemy); 
    }

}
