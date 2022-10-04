using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables privadas
    private CharacterController controller;
    private bool canMove = true;
    private Vector3 moveP = Vector3.zero;
    private Vector3 direction;
    private int line = 1; //Carriles en los que se movera el jugador [0] [1] [2]
    private int targetLine = 1;

    //Variables publicas
    public float forwardSpeed = 10;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    private void Update()
    {
        direction.z = forwardSpeed;

        Vector3 pos = gameObject.transform.position;
        if (!line.Equals(targetLine))
        {
            if (targetLine == 0 && pos.x < -2)
            {
                gameObject.transform.position = new Vector3(-2f, pos.y, pos.z);
                line = targetLine;
                canMove = true;
                moveP.x = 0;
            }
            else if (targetLine == 1 && (pos.x > 0 || pos.x < 0))
            {
                if (line == 0 && pos.x > 0)
                {
                    gameObject.transform.position = new Vector3(0, pos.y, pos.z);
                    line = targetLine;
                    canMove = true;
                    moveP.x = 0;
                }
                else if (line == 2 && pos.x < 0)
                {
                    gameObject.transform.position = new Vector3(0, pos.y, pos.z);
                    line = targetLine;
                    canMove = true;
                    moveP.x = 0;
                }
            }
            else if (targetLine == 2 && pos.x > 2)
            {
                gameObject.transform.position = new Vector3(2f, pos.y, pos.z);
                line = targetLine;
                canMove = true;
                moveP.x = 0;
            }
        }

        checkInputs();

        controller.Move(moveP * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }

    void checkInputs()
    {
        if (Input.GetKeyDown(KeyCode.A) && canMove && line > 0)
        {
            targetLine--;
            canMove = false;
            moveP.x = -12; //Velocidad de movimiento en x
        }
        if (Input.GetKeyDown(KeyCode.D) && canMove && line < 2)
        {
            targetLine++;
            canMove = false;
            moveP.x = 12; //Velocidad de movimiento en x
        }
    }
}