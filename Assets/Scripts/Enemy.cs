using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Material enemyMat;

    // Start is called before the first frame update
    void Start()
    {
        enemyMat = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        MoodChange();
    }

    void MoodChange()
    {
        if(PlayerMovement.playerIsInDamageArea == true && Gun.didShoot == true)
        {
            enemyMat.color = Color.green;
        }
    }
}
