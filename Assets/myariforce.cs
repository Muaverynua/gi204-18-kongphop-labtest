using UnityEngine;

public class myariforce : MonoBehaviour
{

    public Rigidbody rb;
    public float enginePower = 50f;
    public float liftBooster = 0.5f;
    public float dragDamp = 0.003f;
    public float angularDrag = 0.003f;

    public float yawPower = 50f;
    public float pitchPower = 50f;
    public float rollPower = 50f;

    public global::System.Single YawPower { get => yawPower; set => yawPower = value; }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        //Thrust
        if( Input.GetKey(KeyCode.Space) )
        {
            rb.AddForce(transform.forward * enginePower);
        }
        

        //Lift
        Vector3 lift = Vector3.Project( rb.linearVelocity , transform.forward);
        rb.AddForce(transform.up * lift.magnitude * liftBooster);

        //Drag
        rb.linearVelocity -= rb.linearVelocity * dragDamp;
        rb.angularVelocity -= rb.angularVelocity * angularDrag;

        //Control
        float yaw = Input.GetAxis( "Horizontal" ) * yawPower;
        rb.AddTorque( transform.up * yaw );
 
        float pitch = Input.GetAxis( "Vertical" ) * pitchPower;
        rb.AddTorque( -transform.right * pitch );
 
        float roll = Input.GetAxis( "Roll" ) * rollPower;
        rb.AddTorque( -transform.forward * roll );
    }
}
