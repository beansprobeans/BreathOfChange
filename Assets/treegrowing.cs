using UnityEngine;

public class TreeGrowing : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] public Sprite bigtree;
    int loops = 0;
    bool treePlanted = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("down");
            if (CheckGrow())
            {
                //Debug.Log("checkgrow");
                spriteRenderer.enabled = true;

            }
        }

        if (treePlanted)
        {
            loops++;
            if (loops >= 1000)
            {

                spriteRenderer.sprite = bigtree;
            }
        }




    }



    private bool CheckGrow()
    {
        Debug.Log("Checkgrow");
        Collider2D[] collisions = Physics2D.OverlapCircleAll(gameObject.transform.position, 0.2f);
        Debug.Log(collisions.Length);
        foreach (Collider2D col in collisions)
        {
            Debug.Log(col.tag);
            if (col.CompareTag("Player"))
            {
                treePlanted = true;
                return true;
            }
        }
        return false;
    }

}
