using UnityEngine;
using System.Collections;

public class Train : MonoBehaviour {
    public Rigidbody _trainRigidBody;
    public float _acceleration;

    public GameObject _explosion; 

    bool colliderHit;

    public Transform _cameraTransform;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (colliderHit) return;
      
      Vector3 pos = transform.position;
        pos.z += _acceleration;
        transform.position = pos;
        
	}


    void OnTriggerEnter(Collider col)
    {
        if (colliderHit) return;
        Debug.Log("Trigger Entered");
        colliderHit = true;
        _cameraTransform.SetParent(null);
        _explosion.SetActive(true);
        StartCoroutine(FallDown());
    }

    IEnumerator FallDown()
    {
        int angle = 0;
        while(angle < 90)
        {
            angle++;
            transform.RotateAround(transform.forward, 1 * Mathf.Deg2Rad);
            yield return new WaitForEndOfFrame();
        }
    }
}
