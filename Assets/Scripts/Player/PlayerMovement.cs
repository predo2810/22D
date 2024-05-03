using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float MoveSpeed = 5f;
    [SerializeField] private float MoveSpeedIncrease = 0.005f;
    [SerializeField] private float JumpForce = 10f;
    [SerializeField] private float StompForce = 10f;

    [SerializeField] private Transform PlayerParts;
    
    [SerializeField] private TranslationIntermediate PointsTranslator;
    [SerializeField] private TranslationIntermediate JumpButtonTranslator;

    [SerializeField] private AudioSource Source;
    [SerializeField] private Rigidbody2D RB2D;
    [SerializeField] private Animator PlayerAnimator;

    [SerializeField] private AudioClip JumpSound, Stomp;

    [SerializeField] private AudioSourceUtil HitGround;

    public float Points;

    private bool CanJump;
    private bool CanStomp;
    
    public bool GameStarted;

    private void Update()
    {
        if (GameStarted)
        {
            PlayerParts.rotation = Quaternion.Euler(PlayerParts.eulerAngles.x, PlayerParts.eulerAngles.y, RB2D.velocity.y);

            Points = float.Parse((RB2D.position.x + 10).ToString("f1"));

            PointsTranslator.Translate(Points.ToString());

            MoveSpeed += MoveSpeedIncrease;

            RB2D.velocity = new Vector2(MoveSpeed, RB2D.velocity.y);

            if (Input.GetKeyDown(KeyCode.Space))
                Jump();

            PlayerAnimator.speed = MoveSpeed;


            JumpButtonTranslator.TranslateWithList(CanJump ? 0 : (CanStomp ? 1 : 2));
        }

        PlayerPrefs.SetFloat("Run", Points);

        RB2D.velocity = new Vector2(RB2D.velocity.x, Mathf.Clamp(RB2D.velocity.y, int.MinValue, JumpForce));
    }

    public void StartGame()
    {
        GameStarted = true;
    }

    public void Jump()
    {
        if (CanJump)
        {
            Source.PlayOneShot(JumpSound);
            RB2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            PlayerPrefs.SetInt("Jumps", PlayerPrefs.GetInt("Jumps", 0) + 1);
            CanJump = false;
        }
        else if (CanStomp)
        {
            Source.PlayOneShot(Stomp);
            RB2D.AddForce(Vector2.down * StompForce, ForceMode2D.Impulse);
            PlayerPrefs.SetInt("Stomps", PlayerPrefs.GetInt("Stomps", 0) + 1);
            CanStomp = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Floor")
        {
            HitGround.PlayRandomSound();
            CanJump = true;
            CanStomp = true;
        }
    }
}
