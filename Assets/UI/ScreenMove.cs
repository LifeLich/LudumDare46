using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenMove : Frezzeble
{
    [SerializeField] int speed = 5;
    Transform player;

    private void Start()
    {
        player = GameControllor.singelton.runner.transform;
        SaveFrezze();
    }
    // Update is called once per frame
    void Update()
    {
        if (frozen)
        {
            if (Input.mousePosition.y >= Screen.height * 0.95)
            {
                if (Camera.main.transform.position.y < 10)
                {
                    Camera.main.transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);
                }
            }
            else
            {
                if (Camera.main.transform.position.y > 0)
                {
                    if (Input.mousePosition.y <= (Screen.height - (Screen.height * 0.95)))
                    {
                        Camera.main.transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
                    }
                }
            }

            if (Input.mousePosition.x >= Screen.width * 0.95)
            {
                if (Camera.main.transform.position.x < 30)
                {
                    Camera.main.transform.Translate(Vector3.right * Time.deltaTime * 5 * 3, Space.World);
                }
            }
            else
            {
                if (Camera.main.transform.position.x > 0)
                {
                    if (Input.mousePosition.x <= (Screen.width - (Screen.width * 0.95)))
                    {
                        Camera.main.transform.Translate(Vector3.left * Time.deltaTime * 5 * 3, Space.World);
                    }
                }
            }
        }
        else
        {
            float y = player.position.y / 2;
            Camera.main.transform.position = new Vector3(player.position.x, y, -10);
        }

    }
}
