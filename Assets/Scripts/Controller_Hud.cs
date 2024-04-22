using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class Controller_Hud : MonoBehaviour
{
    public static bool gameOver = false;
    public Text distanceText;
    public Text gameOverText;
    private float distance = 0;
    public int distanceint = 0;

    void Start()
    {
        gameOver = false;
        distance = 0;
        distanceText.text = distanceint.ToString();
        gameOverText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverText.text = "Game Over \n Total Distance: " + distanceint.ToString();
            gameOverText.gameObject.SetActive(true);
        }
        else
        {
            distance += Time.deltaTime;
            distanceint = (int)distance;
            //distance = (int)distance; intente pasarlo directamente pero no aumentaba asique cree otro int en donde guardar
            distanceText.text = distanceint.ToString();
        }
    }
}
