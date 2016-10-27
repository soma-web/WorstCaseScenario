using UnityEngine;
using System.Collections;

public class Plane : MonoBehaviour {

    public Rigidbody _trainRigidBody;
    public float _flightSpeed, _fallDownSpeed;
    bool colliderHit;

    public GameObject _explosion;

    public Transform _cameraTransform;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (colliderHit) return;

        Vector3 pos = transform.position;
        pos.z += _flightSpeed;
        transform.position = pos;

    }


    void OnTriggerEnter(Collider col)
    {
        if (colliderHit) return;
        Debug.Log("Trigger Entered");
        colliderHit = true;
        //_cameraTransform.SetParent(null);
        _explosion.SetActive(true);
        StartCoroutine(FallDown());
    }

    IEnumerator FallDown()
    {
        SceneManager.Instance.MeteroitHitMetalBird();
        float height = transform.position.y;
        transform.GetChild(0).Rotate(new Vector3(20, 45, 60));
        while (height > 0)
        {
            height -= Time.deltaTime * _fallDownSpeed;
            transform.position = new Vector3(transform.position.x, height, transform.position.z);
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(0.5f);
        SceneManager.Instance.MetalBirdLanded();
    }
}
