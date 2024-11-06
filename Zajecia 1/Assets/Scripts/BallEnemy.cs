using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallEnemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] private AudioClip enemyHit;
    private void FixedUpdate()
    {
        transform.Translate(transform.forward * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            StartCoroutine(WaitForDeath(3, collision.gameObject));
        }
    }

    IEnumerator WaitForDeath(float seconds, GameObject player)
    {
        yield return new WaitForSeconds(seconds);
        Character.Instance.PlaySound(enemyHit);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
