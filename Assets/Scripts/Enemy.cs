using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] Material enemyMat;
    [SerializeField] TextMeshPro dialogueText;
    public static bool enemyCured;

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
        if (PlayerMovement.playerIsInDamageArea == true && Gun.didShoot == true)
        {
            enemyCured = true;
            PlayerMovement.playerIsInDamageArea = false;
            enemyMat.color = Color.green;
            dialogueText.text = "El perdón trae colores nuevos.";
            GameManager.Instance.ammo = 0.0f;
        }
        else if (PlayerMovement.playerIsInDamageArea == true && Gun.didShoot == true)
        {
            enemyCured = true;
            PlayerMovement.playerIsInDamageArea = false;
            enemyMat.color = Color.green;
            dialogueText.text = "El valor siempre estuvo dentro de ti.";
            GameManager.Instance.ammo = 0.0f;
        }
        else if (PlayerMovement.playerIsInDamageArea == true && Gun.didShoot == true)
        {
            enemyCured = true;
            PlayerMovement.playerIsInDamageArea = false;
            enemyMat.color = Color.green;
            dialogueText.text = "Siempre hay alguien que se preocupa por ti.";
            GameManager.Instance.ammo = 0.0f;
        }
        else if (PlayerMovement.playerIsInDamageArea == true && Gun.didShoot == true)
        {
            enemyCured = true;
            PlayerMovement.playerIsInDamageArea = false;
            enemyMat.color = Color.green;
            dialogueText.text = "Eres suficiente tal como eres.";
            GameManager.Instance.ammo = 0.0f;
        }
        else if (PlayerMovement.playerIsInDamageArea == true && Gun.didShoot == true)
        {
            enemyCured = true;
            PlayerMovement.playerIsInDamageArea = false;
            enemyMat.color = Color.green;
            dialogueText.text = "Siempre hay un nuevo amanecer, incluso tras la noche más oscura.";
            GameManager.Instance.ammo = 0.0f;
        }
    }
}
