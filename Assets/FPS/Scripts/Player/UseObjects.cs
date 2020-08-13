/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

/// DarkTreeDevelopment (2019) DarkTree FPS v1.2
/// If you have any questions feel free to write me at email --- darktreedevelopment@gmail.com ---
/// Thanks for purchasing my asset!

using UnityEngine;
using UnityEngine.UI;

namespace DarkTreeFPS
{
    public class UseObjects : MonoBehaviour
    {
        [Tooltip("The distance within which you can pick up item")]
        public float distance = 1.5f;
        
        private GameObject use;
        private GameObject useCursor;
        private Text useText;

        private InputManager input;
        private Inventory inventory;

        private Button useButton;

        public GameObject GetObject;
        public Transform ObjectPosition;
        GameObject TempObject;

        public float Angle = 0;

        private void Start()
        {
            useCursor = GameObject.Find("UseCursor");
            useText = useCursor.GetComponentInChildren<Text>();
            useCursor.SetActive(false);

            inventory = FindObjectOfType<Inventory>();
            input = FindObjectOfType<InputManager>();

            if (InputManager.useMobileInput)
            {
                //useButton = GameObject.Find("UseButton").GetComponent<Button>();
                //useButton.gameObject.SetActive(false);
            }
        }

        void Update()
        {
            Pickup();
        }

        public void Pickup()
        {
            if (use != null)
            {
                use.transform.position = ObjectPosition.position;
                //use.transform.rotation = ObjectPosition.rotation; //new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.x, transform.rotation.z)
                use.transform.rotation = new Quaternion(ObjectPosition.transform.rotation.x, ObjectPosition.transform.rotation.y, ObjectPosition.transform.rotation.z, ObjectPosition.transform.rotation.w);
                if (Input.GetKeyDown(input.Fire))
                {
                    ObjectPosition.transform.Rotate(0, 90, 0);
                }
                else if (Input.GetKeyDown(input.Aim))
                {
                    ObjectPosition.transform.Rotate(0, -90, 0);
                }
            }

            RaycastHit hit;

            if (Input.GetKeyDown(input.Use) && use != null)
            {
                use.GetComponent<SphereCollider>().enabled = true;
                use.GetComponent<Rigidbody>().useGravity = true;
                use = null;
            }
            else if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
            {
                if (hit.collider.tag == "Item" && use == null && !hit.collider.GetComponent<Item>().IsSet)
                {
                    TempObject = hit.collider.gameObject;
                    //Get an item which we want to pickup
                    useCursor.SetActive(true);

                    if (hit.collider != null && hit.collider.GetComponent<Item>())
                    {
                        //if (hit.collider.transform.Find("Pipe1") != null) hit.collider.transform.Find("Pipe1").GetComponent<MeshRenderer>().material.color = new Color(255, 0, 0);
                        //if (hit.collider.transform.Find("Pipe2") != null) hit.collider.transform.Find("Pipe2").GetComponent<MeshRenderer>().material.color = new Color(255, 0, 0);
                        useText.text = hit.collider.GetComponent<Item>().title;
                        if (!InputManager.useMobileInput)
                        {
                            if (Input.GetKeyDown(input.Use))
                            {
                                use = hit.collider.gameObject;
                                use.GetComponent<Item>().IsSet = false;
                                //use = null;
                                use.GetComponent<SphereCollider>().enabled = false;
                                use.GetComponent<Rigidbody>().useGravity = false;
                                if (use.transform.Find("Counter") != null) use.transform.Find("Counter").gameObject.SetActive(true);
                            }
                        }
                    }
                }
                else
                {
                    useCursor.SetActive(false);

                    useText.text = "";
                }
            }
            else
            {
                if (TempObject != null)
                {
                    //if (TempObject.transform.Find("Pipe1") != null) TempObject.transform.Find("Pipe1").GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0);
                    //if (TempObject.transform.Find("Pipe2") != null) TempObject.transform.Find("Pipe2").GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0);
                    TempObject = null;
                }
                useCursor.SetActive(false);

                useText.text = "";
            }
        }
    }
}
