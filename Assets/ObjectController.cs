using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField] bool isEnemy;
    [SerializeField] GameObject effectPrefab;

    public bool isDeath;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            if (!isEnemy)
            {
                GameController.Instance.GameOver();
            }
            else
            {
                GameObject obj = Instantiate(effectPrefab);
                obj.transform.position = transform.position;
                Destroy(obj, 0.2f);
                obj.GetComponent<Animator>().Play("bang");
                GameController.Instance.UpdateScore(1);

                isDeath = true;
                gameObject.GetComponent<Animator>().Play("Idle");
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 3;
            }
            
            Destroy(this.gameObject, 3f);
            Destroy(collision.gameObject);
        }
    }

    public bool IsEnemy()
    {
        return isEnemy;
    }
}
