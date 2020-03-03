using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//cargar escenas
using UnityEngine.SceneManagement;
public class DeadZone : MonoBehaviour{

    public Text scorePlayerText;
    public Text scoreEnemyText;


    int ScorePlayerQuantity;
    int ScoreEnemyQuantity;
    
    public SceneChanger sceneChanger;
    public AudioSource PointAudio;

    void Sound(){
        PointAudio.Play();
    }
    private void OnTriggerEnter2D(Collider2D collision){
        
        if(gameObject.tag=="Izquierdo"){
            Sound();
            ScoreEnemyQuantity++;
            UpdateScoreLabel(scoreEnemyText, ScoreEnemyQuantity);
        }else if(gameObject.tag=="Derecho"){
            Sound();
            ScorePlayerQuantity++;
            UpdateScoreLabel(scorePlayerText, ScorePlayerQuantity);
        }
        collision.GetComponent<BallBehaviour>().gameStarted=false;
        CheckScore();
        
    }

    void CheckScore(){
        if(ScorePlayerQuantity>=3){
            sceneChanger.ChangeScene("WinScene");
        }else if(ScoreEnemyQuantity>=3){
            sceneChanger.ChangeScene("SadScene");
        }
    }

    void UpdateScoreLabel(Text label, int score){
        label.text=score.ToString();
    }
//  private void OnCollisionEnter2D(Collision2D collision){
    //    Debug.Log("AWEBO OE");
   // }

   


}
