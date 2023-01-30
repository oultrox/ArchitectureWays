using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float _speed = 100;

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
            transform.position -= new Vector3(_speed * Time.deltaTime, 0, 0);
        }
    }

    public void MoveRight()
    {
        if (transform.position.x < 6f)
        {
            transform.position = transform.position + new Vector3(_speed * Time.deltaTime, 0, 0);
        }
    }
}
