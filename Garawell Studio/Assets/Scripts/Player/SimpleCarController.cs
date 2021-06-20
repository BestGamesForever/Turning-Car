using UnityEngine;
using System.Collections;
public class SimpleCarController : MonoBehaviour
{
    private float throttle;
    private Vector3 myRight;
    private Vector3 velo;
    private Vector3 flatVelo;
    private Vector3 relativeVelocity;
    private Vector3 dir;
    private Vector3 flatDir;
    private Vector3 carUp;
    private Transform carTransform;
    private Rigidbody carRigidbody;
    private Vector3 engineForce;
    private bool exploded;
    private Vector3 turnVec;
    private Vector3 imp;
    // private float rev;
    private float actualTurn;
    private float carMass;
    private float actualGrip;
    private float horizontal;
    public float maxSpeedToTurn = 18f;
    public GameObject explodePrefab;

    public Transform rearLeftSkidGenerator;
    public Transform rearRightSkidGenerator;
    public Transform carBody;

    public float power = 300;
    public float maxSpeed = 50;
    public float minimumSlideSpeed = 13;
    public float carGrip = 70;
    [Range(2, 6)]
    [SerializeField] float selectTurnType;
    public float turnSpeed; //3f;

    private float slideSpeed;
    private float mySpeed;
    public Transform centerOfMass;

    private Vector3 carRight;
    private Vector3 carFwd;
    private Vector3 tempVEC;

    public Transform skidTrailPrefab;

    public static Transform skidTrailsDetachedParentLeft;
    private Transform skidTrailLeft;
    public static Transform skidTrailsDetachedParentRight;
    private Transform skidTrailRight;
    private bool buttonDown = false;
    private bool leavingSkidTrail;

    int turnNumber;
    [SerializeField] GameObject TurningBall;
    private Touch touch;

    // Use this for initialization
    void Start()
    {
        Initialize();
    }

    void Initialize()
    {

        carTransform = transform;

        carRigidbody = GetComponent<Rigidbody>();

        carUp = carTransform.up;

        carMass = carRigidbody.mass;

        carFwd = Vector3.forward;

        carRight = Vector3.right;

        carRigidbody.centerOfMass = centerOfMass.localPosition;

        if (skidTrailsDetachedParentLeft == null)
        {
            skidTrailsDetachedParentLeft = new GameObject("Skid Trails Left").transform;
        }

        if (skidTrailsDetachedParentRight == null)
        {
            skidTrailsDetachedParentRight = new GameObject("Skid Trails Right").transform;
        }
    }
    private void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hitinfo;
        Debug.DrawRay(transform.position, Vector3.down * 100, Color.red, 2f);
        if (Physics.Raycast(ray, out hitinfo, 10))
        {
        }
        else
        {
            carRigidbody.constraints = RigidbodyConstraints.None;
        }

    }
    void FixedUpdate()
    {
        roateBody();
        carPhysicsUpdate();
        doSkidTrail();

        if (SystemInfo.deviceType == DeviceType.Desktop && !buttonDown)
        {
            horizontal = Input.GetAxis("Horizontal");
        }
        if (!exploded)
        {
            throttle = 1;
        }
        else
        { //we exploded do not move 
            horizontal = 0;
            throttle = 0;
            return;
        }

        if (mySpeed < maxSpeed)
        {
            carRigidbody.AddForce(engineForce * Time.deltaTime);
        }

        if (mySpeed > maxSpeedToTurn && (minimumSlideSpeed > slideSpeed && slideSpeed > -minimumSlideSpeed))
        {
            carRigidbody.AddTorque(turnVec * Time.deltaTime);
            carRigidbody.AddForce(new Vector3(0, -20, 0) * Time.deltaTime);
        }
        else if (mySpeed < maxSpeedToTurn)
        {
            return;
        }
        carRigidbody.AddForce(imp * Time.deltaTime);
    }

    void carPhysicsUpdate()
    {
        myRight = carTransform.right;
        velo = carRigidbody.velocity;
        tempVEC = new Vector3(velo.x, 0.0f, velo.z);
        flatVelo = tempVEC;

        dir = transform.TransformDirection(carFwd);

        tempVEC = new Vector3(dir.x, 0.0f, dir.z);

        flatDir = Vector3.Normalize(tempVEC);

        relativeVelocity = carTransform.InverseTransformDirection(flatVelo);

        slideSpeed = Vector3.Dot(myRight, flatVelo);

        mySpeed = flatVelo.magnitude;

        engineForce = (flatDir * (power * throttle) * carMass);

        actualTurn = horizontal;
        turnVec = (((carUp * turnSpeed) * actualTurn) * carMass) * 800;

        actualGrip = Mathf.Lerp(1500, carGrip, mySpeed * 0.02f);
        imp = myRight * (-slideSpeed * carMass * actualGrip);


    }

    void roateBody()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                if (touch.deltaPosition.x>0)
                {
                    horizontal = 1;
                }
                else if (touch.deltaPosition.x < 0)
                {                    
                        horizontal = -1;
                }
                else
                {
                    horizontal = 0;
                }
            }
        }
        else
        {
            horizontal = 0;
        }
            Quaternion target;
        if (horizontal > 0)
        { //later change this to what button is pressed intead of horizontal 

            target = Quaternion.Euler(0, 0, 3.78f);
            carBody.localRotation = Quaternion.Lerp(carBody.transform.localRotation, target, Time.deltaTime);

        }
        else if (horizontal < 0)
        {

            target = Quaternion.Euler(0, 0, -3.78f);
            carBody.localRotation = Quaternion.Lerp(carBody.transform.localRotation, target, Time.deltaTime);

        }
        else if (horizontal == 0)
        {
            target = Quaternion.Euler(0, 0, 0);
            carBody.localRotation = Quaternion.Lerp(carBody.transform.localRotation, target, Time.deltaTime);
        }
    }

    void doSkidTrail()
    {
        if (skidTrailPrefab != null)
        {
            if (horizontal != 0) //we are turning
            {
                if (!leavingSkidTrail)
                {
                    skidTrailLeft = Instantiate(skidTrailPrefab) as Transform;
                    if (skidTrailLeft != null)
                    {
                        skidTrailLeft.parent = transform;
                        skidTrailLeft.localPosition = rearLeftSkidGenerator.transform.localPosition;
                    }

                    skidTrailRight = Instantiate(skidTrailPrefab) as Transform;
                    if (skidTrailRight != null)
                    {
                        skidTrailRight.parent = transform;
                        skidTrailRight.localPosition = rearRightSkidGenerator.transform.localPosition;
                    }

                    leavingSkidTrail = true;
                }

            }
            else
            {
                if (leavingSkidTrail)
                {
                    skidTrailLeft.parent = skidTrailsDetachedParentLeft;
                    Destroy(skidTrailLeft.gameObject, 10);

                    skidTrailRight.parent = skidTrailsDetachedParentRight;
                    Destroy(skidTrailRight.gameObject, 10);

                    leavingSkidTrail = false;
                }


            }
        }

    }
    public void turnRight()
    {

        horizontal = 1;
        buttonDown = true;

    }

    public void turnLeft()
    {
        horizontal = -1;
        buttonDown = true;
    }

    public void stopTuning()
    {

        horizontal = 0;
        buttonDown = false;
    }

     private void OnTriggerEnter(Collider other)
     {
         if (other.gameObject.CompareTag("Faster"))
         {
             other.gameObject.SetActive(false);
             turnNumber = 5;
             StartCoroutine(fastTurn());
         }
    
     }
    
     IEnumerator fastTurn()
     {
         while (turnNumber>0)
         {
             Debug.Log(turnNumber);
            TurningBall.GetComponent<Rigidbody>().isKinematic = true;
             TurningBall.transform.localRotation = Quaternion.Euler(Vector3.up * 100);
             yield return null;
         }
        
     }
}

