using System.Collections;
using UnityEngine;

public class InstantiateGameObject : MonoBehaviour
{
    
    [SerializeField] private GameObject gameObject; // 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(MakeGameObject()); // Activates MakeGameObject one time
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator MakeGameObject()
    {
        yield return new WaitForSeconds(3); // Waits for 3 seconds then continues with code under
        
        Instantiate(gameObject, transform.position, transform.rotation); // creates the gameObject at this scripts position
        yield return null;
    }
}
