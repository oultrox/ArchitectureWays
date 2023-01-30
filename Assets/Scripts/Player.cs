using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 100;
    [SerializeField] private GameManager _gameManager;

    private void OnCollisionEnter(Collision collision)
    {
        _gameManager.LoseGame();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
    }

    public void MoveLeft()
    {
        if (transform.position.x > -6f)
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }

    public void MoveRight()
    {
        if (transform.position.x < 6f)
        {
            transform.position = transform.position +  new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }
}
