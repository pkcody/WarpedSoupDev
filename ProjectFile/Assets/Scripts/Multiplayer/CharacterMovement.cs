using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    public Text displayInventory;
    private PlayerControls playerInput;
    public GameObject body;

    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    //private float gravityValue = -9.81f;

    private Rigidbody _rb;
    private CapsuleCollider _col;
    private bool doJump = false;
    private bool inPotRange = false;

    public float distanceToGround = 0.1f;
    public LayerMask groundLayer;

    public Vector3 lastLook;
    public Vector2 movementInput;

    //For pickup
    public InventoryObject inventory;
    //public Text pickUpText;
    private List<GameObject> itemList = new List<GameObject>();
    private GameObject pots;

    public Animator animator;
    public Rigidbody RB;

    //Audio
    public AudioSource audioSource;
    public List<AudioClip> audioClips;

    private void Awake()
    {
        playerInput = new PlayerControls();
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        inventory.Container.Clear();
        //pickUpText.gameObject.SetActive(false);
        RB = GetComponent<Rigidbody>();
    }

    //player movement
    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && IsGrounded())
        {
            doJump = true;
        }
    }

    public void OnPickUp(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            foreach (GameObject obj in itemList)
            {
                var item = obj.GetComponent<Item>();
                if (item)
                {
                    inventory.AddItem(item.item, 1);
                    Destroy(obj.gameObject);
                }
            }
            itemList.Clear();

            if (inPotRange)
            {
                var potInventory = pots.GetComponent<Pots>();
                if (inventory.IfEmpty())
                {
                    //potInventory.PlayAnimation();
                }
                while (inventory.IfEmpty())
                {
                    var slot = inventory.RemoveItem();
                    potInventory.inventory.AddItem(slot.item, slot.amount);
                }
                potInventory.PlayAnimation();
            }
        }
    }
    //check if player on ground
    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);
        return grounded;
    }

    //Pick up functions
    public void OnTriggerStay(Collider collision)
    {
        //pickUpText.gameObject.SetActive(true);
    }

    public void OnTriggerExit(Collider collision)
    {
        //pickUpText.gameObject.SetActive(false);
        if (collision.GetComponent<Collider>().tag == "Item")
        {
            itemList.Remove(collision.gameObject);
        }
        else if (collision.GetComponent<Collider>().tag == "Pot")
        {
            pots = null;
            inPotRange = false;
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Collider>().tag == "Item")
        {
            itemList.Add(collision.gameObject);
        }
        else if (collision.GetComponent<Collider>().tag == "Pot")
        {
            pots = collision.gameObject;
            inPotRange = true;
        }

    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }

    //update
    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        Debug.Log(scene.name);

        transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * playerSpeed * Time.deltaTime);
        _rb.velocity = new Vector3(0f, _rb.velocity.y, 0f);
        if (movementInput.x != 0f || movementInput.y != 0f)
        {
            lastLook = new Vector3(movementInput.x, 0, movementInput.y);
        }
        body.transform.forward = lastLook;

        if (movementInput.x == 0f || movementInput.y == 0f)
        {
            animator.SetFloat("Speed", 0.0f);
            audioSource.Stop();
            if ((scene.name == "MakeGameSide"))
            {
                Debug.Log("IdleCarry");
                animator.SetBool("CarryScene", true);
            }
        }
        else if (movementInput.x > 0f || movementInput.y > 0f)
        {
            animator.SetFloat("Speed", 1.0f);
            if (!audioSource.isPlaying)
            {
                audioSource.clip = audioClips.Find(clipName => clipName.name == "Walking");
                audioSource.loop = true;
                audioSource.Play();
            }

            if ((scene.name == "MakeGameSide"))
            {
                Debug.Log("IdleRun");
                animator.SetBool("CarryScene", true);
            }
        }
    }


    private void FixedUpdate()
    {
        if (doJump)
        {
            _rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            doJump = false;
        }
    }
}
