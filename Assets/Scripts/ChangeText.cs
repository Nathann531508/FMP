using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public Text text;
    private bool Jumped=false;
    private bool HasToJump = false;
    private bool hastograpple = false;
    

    private bool Grapples = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(function());
    }
    public IEnumerator function()
    {
        text.text = "You actually got it?";
        yield return new WaitForSeconds(3f);
        text.text = "Nice work, you need to get out of there though.";
        yield return new WaitForSeconds(5f);
        text.text = "Press SPACE to jump.";   
        HasToJump= true;
        


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !Jumped && HasToJump)
        {
            Jumped = true;
            HasToJump = false;
            StartCoroutine(function2());
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && !Grapples && hastograpple)
        {
            Grapples = true;
            hastograpple = false;
            StartCoroutine(function3());
        }
        
    }

    public IEnumerator function2()
    {
        text.text = "Nice moves, try reaching the elevator on the left by jumping";
        yield return new WaitForSeconds(5f);


        text.text = "Right click on the yellow pipe above to grapple onto it then swing over to the other side";
        hastograpple= true;
    }
    public IEnumerator function3()
    {
      
        text.text = "Great, try to reach the exit.";
        yield return new WaitForSeconds(10f);
        text.text = "They put up an energy field to block the exit, shoot it down!";
    }
}

