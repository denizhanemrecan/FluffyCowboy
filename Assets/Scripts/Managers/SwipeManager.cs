using UnityEngine;

public enum Swipe { None, Up, Down, Left, Right, Tap };

public class SwipeManager : MonoBehaviour
{
    public float minSwipeLength = 100f;

    //public float mintaplength = 1f;
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    Vector2 firstClickPos;
    Vector2 secondClickPos;

    private Player player;

    [SerializeField] ParticleSystem blast = null;

    public GameObject effect;

    public static Swipe swipeDirection;

    private void Start()
    {
        player = ManagerProvider.Instance.GetPlayer().GetComponent<Player>();
    }

    void Update()
    {
        DetectSwipe();
    }

    public void DetectSwipe()
    {
        
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            

            if (t.phase == TouchPhase.Began)
            {
                firstPressPos = new Vector2(t.position.x, t.position.y);
                
            }

            if (t.phase == TouchPhase.Ended && ManagerProvider.Instance.GetNoteManager().GetNotes().Count > 0)
            {
                secondPressPos = new Vector2(t.position.x, t.position.y);
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
                //blast.Stop();

                // Make sure it was a legit swipe, not a tap
                if (currentSwipe.magnitude < minSwipeLength)
                {
                    swipeDirection = Swipe.Tap;
                    //ManagerProvider.Instance.GetNoteManager().DeleteNote();
                    //ManagerProvider.Instance.GetNoteManager().ChangeNotes();
                    //ManagerProvider.Instance.GetNoteProducer().isRandomSprite = true;
                    player.GetComponent<PlayerShoot>().Shot();
                    effect.SetActive(true);
                    Blast();
                    return;
                }

                currentSwipe.Normalize();

                // Swipe up
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    swipeDirection = Swipe.Up;
                    if (ManagerProvider.Instance.GetNoteProducer().isRandomSprite == false)
                    {
                        player.Move(Vector3.forward);
                        effect.SetActive(true);
                        Blast();
                    }
                    else
                    {
                        ManagerProvider.Instance.GetPlayer().GetComponent<PlayerShoot>().SetCurrentSwipe(swipeDirection);
                    }
                    
                    
                    ManagerProvider.Instance.GetNoteManager().DeleteNote();
                    
                    // Swipe down
                }
                else if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    swipeDirection = Swipe.Down;
                    if (ManagerProvider.Instance.GetNoteProducer().isRandomSprite == false)
                    {
                        player.Move(Vector3.forward * -1);
                        effect.SetActive(true);
                        Blast();
                    }
                    else
                    {
                        ManagerProvider.Instance.GetPlayer().GetComponent<PlayerShoot>().SetCurrentSwipe(swipeDirection);
                    }
                    ManagerProvider.Instance.GetNoteManager().DeleteNote();
                    // Swipe left
                }
                else if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    swipeDirection = Swipe.Left;
                     if (ManagerProvider.Instance.GetNoteProducer().isRandomSprite == false)
                    {
                        player.Move(Vector3.left);
                        effect.SetActive(true);
                        Blast();
                    }
                    else
                    {
                        ManagerProvider.Instance.GetPlayer().GetComponent<PlayerShoot>().SetCurrentSwipe(swipeDirection);
                    }
                    ManagerProvider.Instance.GetNoteManager().DeleteNote();
                    // Swipe right
                }
                else if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    swipeDirection = Swipe.Right;
                    if (ManagerProvider.Instance.GetNoteProducer().isRandomSprite == false)
                    {
                        player.Move(Vector3.right);
                        effect.SetActive(true);
                        Blast();
                    }
                    else
                    {
                        ManagerProvider.Instance.GetPlayer().GetComponent<PlayerShoot>().SetCurrentSwipe(swipeDirection);
                    }

                    ManagerProvider.Instance.GetNoteManager().DeleteNote();
                }
            }
        }
        else
        {

            if (Input.GetMouseButtonDown(0))
            {
                firstClickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            }
            else
            {
                swipeDirection = Swipe.None;
                Debug.Log("None");
                //blast.Stop();
            }
            if (Input.GetMouseButtonUp(0) && ManagerProvider.Instance.GetNoteManager().GetNotes().Count > 0)
            {
                secondClickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                currentSwipe = new Vector3(secondClickPos.x - firstClickPos.x, secondClickPos.y - firstClickPos.y);

                // Make sure it was a legit swipe, not a tap
                if (currentSwipe.magnitude < minSwipeLength)
                {
                    swipeDirection = Swipe.Tap;
                    player.GetComponent<PlayerShoot>().Shot();
                    //ManagerProvider.Instance.GetNoteManager().DeleteNote();
                    ////ManagerProvider.Instance.GetNoteManager().ChangeNotes();
                    //ManagerProvider.Instance.GetNoteProducer().isRandomSprite = true;
                    //Debug.Log("Tap");
                    return;
                }

                currentSwipe.Normalize();

                //Swipe directional check
                // Swipe up
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    swipeDirection = Swipe.Up;
                    if (ManagerProvider.Instance.GetNoteProducer().isRandomSprite == false)
                    {
                        player.Move(Vector3.forward);
                        effect.SetActive(true);
                        Blast();
                    }
                    else
                    {
                        ManagerProvider.Instance.GetPlayer().GetComponent<PlayerShoot>().SetCurrentSwipe(swipeDirection);
                    }


                    ManagerProvider.Instance.GetNoteManager().DeleteNote();
                    //Debug.Log("Up");
                    // Swipe down
                }
                else if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    swipeDirection = Swipe.Down;

                    if (ManagerProvider.Instance.GetNoteProducer().isRandomSprite == false)
                    {
                        player.Move(Vector3.forward * -1);
                        effect.SetActive(true);
                        Blast();
                    }
                    else
                    {
                        ManagerProvider.Instance.GetPlayer().GetComponent<PlayerShoot>().SetCurrentSwipe(swipeDirection);
                    }
                    ManagerProvider.Instance.GetNoteManager().DeleteNote();

                    //Debug.Log("Down");
                    // Swipe left
                }
                else if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    swipeDirection = Swipe.Left;

                    if (ManagerProvider.Instance.GetNoteProducer().isRandomSprite == false)
                    {
                        player.Move(Vector3.left);
                        effect.SetActive(true);
                        Blast();
                    }
                    else
                    {
                        ManagerProvider.Instance.GetPlayer().GetComponent<PlayerShoot>().SetCurrentSwipe(swipeDirection);
                    }
                    ManagerProvider.Instance.GetNoteManager().DeleteNote();

                    //Debug.Log("Left");
                    // Swipe right
                }
                else if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    swipeDirection = Swipe.Right;

                    if (ManagerProvider.Instance.GetNoteProducer().isRandomSprite == false)
                    {
                        player.Move(Vector3.right);
                        effect.SetActive(true);
                        Blast();
                    }
                    else
                    {
                        ManagerProvider.Instance.GetPlayer().GetComponent<PlayerShoot>().SetCurrentSwipe(swipeDirection);
                    }

                    ManagerProvider.Instance.GetNoteManager().DeleteNote();

                    //Debug.Log("right");
                }

                ManagerProvider.Instance.GetPlayer().GetComponent<PlayerShoot>().CountCombo();
            }


        } 
       
    }

    public void Blast()
    {
        blast.Play();
    }
}