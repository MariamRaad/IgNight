using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(FirePlayerCharacter))]
public class FirePlayerControl : MonoBehaviour
{
    private FirePlayerCharacter m_Character;
    private bool m_Jump;
    private float pos;
    public float minHeightForDeath = -20;
    //public GameObject gameOverMenu;

    private void Awake()
    {
        m_Character = GetComponent<FirePlayerCharacter>();
        //gameOverMenu = GameObject.Find("GameOverMenu");
    }


    private void Update()
    {
        if (!m_Jump)
        {
            // Read the jump input in Update so button presses aren't missed.
            m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }

        pos = m_Character.transform.position.y;
        // Debug.Log("Position: " + pos);

        if (m_Character.transform.position.y < minHeightForDeath)
        {
            //Time.timeScale = 0;
            //gameOverMenu.SetActive(true);
            
            // GAME OVER
            gameOver();
            
            
        }
    }


    private void gameOver()
    {
        m_Character.transform.position = SavepointController.lastActiveCheckpoint.position;
    }
    
    private void FixedUpdate()
    {
        // Read the inputs.
        var crouch = Input.GetKey(KeyCode.LeftControl);
        var h = CrossPlatformInputManager.GetAxis("Horizontal");
        // Pass all parameters to the character control script.
        m_Character.Move(h, crouch, m_Jump);
        m_Jump = false;
    }
}