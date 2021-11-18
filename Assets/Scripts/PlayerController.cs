using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Start()
    {
        
    }
    [Header("Скорость перемещения персонажа")]
    public float speed = 7f;

    [Header("Скорость бега персонажа")]
    public float runSpeed = 7f;

    [Header("Сила прыжка")]
    public float jumpPower = 200f;

    [Header("Есть земля?И кто на земле?")]
    public bool ground; //новая переменая для прыжка

    public Rigidbody rb;
    
    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift)) //даем ускорение
            {
                transform.localPosition += transform.forward * runSpeed * Time.deltaTime;
            }
            else //если ускорения нет мы идем
            {
                transform.localPosition += transform.forward * speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.LeftShift)) //даем ускорение
            {
                transform.localPosition += -transform.forward * runSpeed * Time.deltaTime;
            }
            else
            {
                transform.localPosition += -transform.forward * speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift)) //даем ускорение
            {
                transform.localPosition += -transform.right * runSpeed * Time.deltaTime;
            }
            else
            {
                transform.localPosition += -transform.right * speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift)) //даем ускорение
            {
                transform.localPosition += transform.right * runSpeed * Time.deltaTime;
            }
            else
            {
                transform.localPosition += transform.right * speed * Time.deltaTime;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ground == true) //если мы на земле
            {
                rb.AddForce(transform.up * jumpPower); //придаем силу вверх
            }
        }
    }
    private void OnCollisionEnter(Collision collision) //создали метод с какой колизей сталкиваемся?
    {
        if (collision.gameObject.tag == "Ground") //если сталкиваемся с объектом земли
        {
            ground = true;
        }
    }
    private void OnCollisionExit(Collision collision) //создали метод с какой колизей выходим
    {
        if (collision.gameObject.tag == "Ground") //если сталкиваемся с объектом земли
        {
            ground = false;
        }
    }
}
