using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CnControls;


public class Player : MonoBehaviour {

    public float speed;
    public Text txt;
    public Text txt_win;
    public GameObject button;

    private Rigidbody rb;
    private int count;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        txt_win.text = "";
        
    }

    private void FixedUpdate()
    {
        float translation = Input.GetAxis("Vertical");
        float rotation = Input.GetAxis("Horizontal");

        //Vector3 force = new Vector3(rotation, 0, translation);
        //rb.AddForce(force * speed);

        Vector3 movement = new Vector3(CnInputManager.GetAxis("Horizontal"), 0f, CnInputManager.GetAxis("Vertical"));
        rb.AddForce(movement * speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        txt.text = "C: " + count.ToString();
        if (count >= 12)
        {
            txt_win.text = "You Win!";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    public void botton()
    {
        Debug.Log("ksakdjhfgaoi");
    }

}
