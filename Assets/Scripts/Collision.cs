using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Collision : MonoBehaviour
{
    [SerializeField][Range(0f, 1f)]public float speeder = 0.1f;

    [SerializeField] public Color32 hasPackageColor;
    [SerializeField] public Color32 noPackageColor = new Color32(1,1,1,1);
    
    [SerializeField] public List<Transform> packages_pos = new List<Transform>();
    [SerializeField] public GameObject package;
    [SerializeField] public bool hasPackage;
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] public int score = 0;
    
    SpriteRenderer sp;
    void Start()
    {
        Debug.Log(hasPackage);
        sp = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
       if(other.collider.CompareTag("Bumpers"))
            SceneManager.LoadScene(0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Booster"))
            throw new NotImplementedException();
        if (other.CompareTag("Package") && !hasPackage)
        {
            hasPackage = true;
            Destroy(other.gameObject);
            sp.color = hasPackageColor;
        }
        else if (other.CompareTag("Customer") && hasPackage){
            sp.color = noPackageColor;
            score++;
            hasPackage = false;
            scoreText.text = score.ToString();
            Instantiate(package, packages_pos[UnityEngine.Random.Range(0, 7)].transform.position, package.transform.rotation);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Booster"))
            GetComponent<Driver>().moveSpeed = GetComponent<Driver>().moveSpeed + speeder;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Booster"))
            GetComponent<Driver>().moveSpeed = GetComponent<Driver>().altMoveSpeed;
    }
}
