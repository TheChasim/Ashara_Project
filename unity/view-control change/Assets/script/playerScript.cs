using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    [SerializeField] private int speed = 5;
    [SerializeField] private int rotationSpeed = 300;
    internal bool focus = false;
    private Vector3 input;
    public Rigidbody rb;
    [SerializeField] private GameObject target;
    float xAxis;

    // Update is called once per frame
    void Update()
    {
        //get les input du clavier
        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");
        xAxis = ViewChanger.Instance.GetXAxis();
        //si le joueur a le focus il peut bouger
        if (focus)
        {
            input = Quaternion.AngleAxis(xAxis, Vector3.up) * input;

            rb.velocity = new Vector3(input.x * speed, 0, input.z * speed);

            Quaternion toQuaternion = Quaternion.LookRotation(input, Vector3.up);
            transform.rotation= Quaternion.RotateTowards(transform.rotation, toQuaternion, rotationSpeed);

            Debug.Log(toQuaternion.ToString());


            
        }
        
    }
}
