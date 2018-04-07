using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHunter : MonoBehaviour {

    // Создание переменной «враг»
    public Transform enemy;
    public Transform world;
    public Transform rhino;
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
            if (currentNumberOfEnemies <= 0)
            {
                float randDirection;
                float randDistance;
                // Создать 10 врагов в случайных местах за экраном
                for (int i = 0; i < enemiesPerWave; i++)
                {
                    // Задаём случайные переменные для расстояния и направления
                    randDistance = Random.Range(5, 10);
                    randDirection = Random.Range(0, 360);
                    // Используем переменные для задания координат появления врага
                    float posX = this.rhino.transform.position.x + (Mathf.Cos((randDirection) * Mathf.Deg2Rad) * randDistance);
                    float posY = this.rhino.transform.position.y - randDistance;
                    
                    // Создаём врага на заданных координатах
                    Instantiate(enemy, new Vector3(posX, posY, 5), this.transform.rotation);
                    currentNumberOfEnemies++;
                    yield return new WaitForSeconds(timeBetweenEnemies);
                }
            }
            // Ожидание до следующей проверки
            yield return new WaitForSeconds(timeBeforeWaves);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
