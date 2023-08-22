using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessButterflyController : MonoBehaviour
{
    EndlessGameManager gameManager;
    [SerializeField] private bool isDead;

    [Header("Animator")]
    [SerializeField] private Animator animator;

    [Header("Up And Down Movement")]
    [SerializeField] [Range(0,100f)] private float value;
    [SerializeField] private float Maxvalue;
    [SerializeField] private float Minvalue;
    [SerializeField] private float lerpTime;

    [Header("Forward Movement")]
    [SerializeField] private float moveSpeed;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip daisySoundEffect;

    private void Start() 
    {
        gameManager = FindObjectOfType<EndlessGameManager>();
    }

    private void Update() 
    {
        ForwardMovement();
        UpAndDownMovement(value);
    }

    private void UpAndDownMovement(float value)
    {
        var pos = transform.position;
        var rate = value / Maxvalue;
        var posY = Mathf.Clamp(rate,Minvalue,Maxvalue);
        pos.y = posY;
        transform.position = Vector3.Lerp(transform.position,pos, lerpTime * Time.deltaTime);
    }

   private void ForwardMovement()
   {
        if (!isDead)
        {
            var pos = transform.position;
            pos.z += moveSpeed * Time.deltaTime;
            transform.position = pos;
        }
   }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Bee"))
        {
            isDead = true;
            EndlessGameManager.isDead = isDead;
        }
        else if(other.gameObject.CompareTag("Daisy"))
        {
            audioSource.PlayOneShot(daisySoundEffect);
            EndlessSpawnManager.spawnedDaisyCount--;
            EndlessSpawnManager.spawnedDaisyList.Remove(other.gameObject);
            Destroy(other.gameObject);
            EndlessGameManager.AddScore();
        }
        else if(other.gameObject.CompareTag("SpawnArea"))
        {
            gameManager.spawnNewArea();
        }
    }
}