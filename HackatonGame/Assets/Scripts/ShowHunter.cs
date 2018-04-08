using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHunter : MonoBehaviour {

    // Создание переменной «враг»
    public Transform enemy;
    public Transform world;
    public Transform rhino;
    public List<Transform> spawns;
    // Временные промежутки между событиями, кол-во врагов
    public float timeBeforeSpawning = 1.5f;
    public float timeBetweenEnemies = 0.25f;
    public float timeBeforeWaves = 2.0f;
    public int enemiesPerWave = 3;
    private int currentNumberOfEnemies = 0;

    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnHunters());
    }

    // Появление волн врагов
    IEnumerator SpawnHunters()
    {
        // Начальная задержка перед первым появлением врагов
        yield return new WaitForSeconds(timeBeforeSpawning);
        // Когда таймер истекёт, начинаем производить эти действия
        while (true)
        {
            // Не создавать новых врагов, пока не уничтожены старые
            if (currentNumberOfEnemies < enemiesPerWave)
            {
                // Задаём случайные переменные для расстояния и направления
                float randDistance = Random.Range(5, 10);
                float randDirection = Random.Range(0, 360);
                // Используем переменные для задания координат появления врага
                int index = Random.Range(0, spawns.Count);
                Transform spawn = spawns[index];
                Vector3 pos = rhino.TransformVector(spawn.position);

                // Создаём врага на заданных координатах
                Instantiate(enemy, new Vector3(pos.x, pos.y, 5), this.transform.rotation);
                currentNumberOfEnemies++;
            }
            // Ожидание до следующей проверки
            yield return new WaitForSeconds(1);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void RemoveOne()
    {
        currentNumberOfEnemies--;
    }

    public void AddOne()
    {
        if(enemiesPerWave >= 3)
        {
            return;
        }
        enemiesPerWave++;
    }
}
