using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class LevelChanger : MonoBehaviour
{
    public int SceneNumber;
   private void OnTriggerEnter2D(Collider2D other) {
           SceneManager.LoadScene(SceneNumber);
   }

}
