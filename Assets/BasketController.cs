using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource aud;
    GameObject diector;

    void Start() {
        this.diector = GameObject.Find("GameDirector");
        this.aud = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other) {//colliderが引数に渡される
        if (other.gameObject.tag == "Apple") {
            this.diector.GetComponent<GameDirector>().GetApple();
            this.aud.PlayOneShot(this.appleSE);
        } else {
            this.diector.GetComponent<GameDirector>().GetBomb();
            this.aud.PlayOneShot(this.bombSE);
        }
        Destroy(other.gameObject); //colliderがついているオブジェクトを消す
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }
    }
}
