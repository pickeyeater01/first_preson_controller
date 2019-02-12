using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class personcontroller : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float jumpHeight;

    private Vector3 direction;

    private int count;
    public Text countText;
    public Text winText;

    private float rotationSpeed = 1f;
    private float minY = -60f;
    private float maxY = 60f;
    private float rotationY = 0f;
    private float rotationX = 0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {

        direction = Vector3.zero;
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        direction = direction.normalized;


        rb.transform.Translate(direction.x * speed * Time.deltaTime, 0.0f, direction.z * speed * Time.deltaTime);

        rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * rotationSpeed;
        rotationY += Input.GetAxis("Mouse Y") * rotationSpeed;
        rotationY = Mathf.Clamp(rotationY, minY, maxY);
        rb.transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pick up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {

        countText.text = "Count:" + count.ToString();
        if (count >= 4)
        {
            winText.text = "You Win!!!";
        }
    }
}