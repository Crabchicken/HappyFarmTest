using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public CameraMovement cam;
    public Vector2 cameraChange;
    public Vector3 playerChange;
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cam.maxPosition += cameraChange;
            cam.minPosition += cameraChange;
            other.transform.position += playerChange;
            if (needText == true)
            {
                StartCoroutine(placeNameCo());
            }
        }
    }

    private IEnumerator placeNameCo()
    {
        
        text.SetActive(true);
        placeText.text = placeName;
        placeText.GetComponent<Text>().CrossFadeAlpha(0, 3.5f, false);
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
        
    }
}
