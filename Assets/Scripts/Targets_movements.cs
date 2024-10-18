using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets_movements : MonoBehaviour
{
   /* public string level;
    public float speed = 2f; // Base speed for movement

    private Vector3 startPosition;
    private float timeCounter = 0;

    void Start()
    {
        // Store initial position of the target
        startPosition = transform.position;

        // Retrieve the level from PlayerPrefs or another source if needed
        level = PlayerPrefs.GetString("level", "easy"); // Default to "easy"
    }

    void Update()
    {
        // Update movement based on difficulty level
        MoveTarget(level);
    }

    void MoveTarget(string level)
    {
        timeCounter += Time.deltaTime * speed; // Keep track of time for motion
        
        switch (level)
        {
            case "easy":
                // Straight line movement
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                break;

            case "medium":
                // Circular movement
                float x = Mathf.Cos(timeCounter) * 2; // radius = 2
                float y = Mathf.Sin(timeCounter) * 2;
                transform.position = startPosition + new Vector3(x, y, 0);
                break;

            case "hard":
                // Random movement
                transform.position = startPosition + new Vector3(
                    Mathf.PerlinNoise(timeCounter, 0) * 5,
                    Mathf.PerlinNoise(0, timeCounter) * 5,
                    0);
                break;

            default:
                break;
        }
    }
    */

    public int level; // Niveau de difficulté : 1 = facile, 2 = moyen, 3 = difficile
    public float speed = 2f; // Vitesse de base pour le mouvement
    public float distance = 5f; // Distance pour l'aller-retour

    private Vector3 startPosition;
    private float timeCounter = 0;

    void Start()
    {
        // Enregistre la position initiale de la cible
        startPosition = transform.position;
    }

    void Update()
    {
        // Mise à jour du mouvement en fonction du niveau de difficulté
        MoveTarget(level);
    }

    void MoveTarget(int level)
    {
        // Compteur de temps basé sur la vitesse
        timeCounter += Time.deltaTime * speed;

        switch (level)
        {
            case 1: // Facile - Aller-retour sur un axe X
                // Utilisation de PingPong pour faire un aller-retour sur l'axe X
                float posX = Mathf.PingPong(timeCounter * speed, distance);
                transform.position = startPosition + new Vector3(posX, 0, 0);
                break;

            case 2: // Moyen - Aller-retour en cercle
                float x = Mathf.Cos(timeCounter) * distance;
                float y = Mathf.Sin(timeCounter) * distance;
                transform.position = startPosition + new Vector3(x, y, 0);
                break;

            case 3: // Difficile - Aller-retour aléatoire
                // Déplacement aléatoire entre deux points avec Perlin Noise, mais lissé pour des allers-retours
                float randomX = Mathf.PingPong(Mathf.PerlinNoise(timeCounter, 0) * distance, distance);
                float randomY = Mathf.PingPong(Mathf.PerlinNoise(0, timeCounter) * distance, distance);
                transform.position = startPosition + new Vector3(randomX, randomY, 0);
                break;

            default:
                break;
        }
    }
}
