using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoMovement : MonoBehaviour
{
    public float speed = 5f; // Скорость движения торнадо
    public float changeDirectionInterval = 2f; // Интервал изменения направления
    private Vector3 targetDirection;

    void Start()
    {
        // Устанавливаем начальное направление
        ChangeDirection();
        InvokeRepeating("ChangeDirection", changeDirectionInterval, changeDirectionInterval);
    }

    void Update()
    {
        // Двигаем торнадо в выбранном направлении
        transform.Translate(targetDirection * speed * Time.deltaTime);
    }

    void ChangeDirection()
    {
        // Генерируем случайное направление
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        targetDirection = new Vector2(randomX, randomY).normalized; // Нормализуем вектор направления
    }
}
