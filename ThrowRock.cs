using UnityEngine;

public class ThrowRock : MonoBehaviour {
 

    [SerializeField]
    public float FlightDurationInSeconds=2;

    private Rigidbody _rigidbody;
    private bool isshot;
	// Use this for initialization
	void Start () {
		_rigidbody=GetComponent<Rigidbody>();
 


	}
  
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("click");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                Debug.Log("info");
                Shootwithvelocity(hitInfo.point);
            //    var rig = hitInfo.collider.GetComponent<Rigidbody>();
          
                  //  Debug.Log("shot");
                   // rig.AddForceAtPosition(ray.direction * 50f, hitInfo.point, ForceMode.VelocityChange);
                
            }
        }

	}
    private void Shootwithvelocity(Vector3 Targetposition){
        MoveWithVelocity((Targetposition-transform.position)/FlightDurationInSeconds);
    }

    public void MoveWithVelocity(Vector3 Velocity){
        _rigidbody.velocity=Velocity;
    }
}