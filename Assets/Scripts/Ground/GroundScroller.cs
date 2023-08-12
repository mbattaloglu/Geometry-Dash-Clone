using System;
using UnityEngine;

namespace Game.Ground.Scroll
{
    public class GroundScroller : MonoBehaviour
    {
        public float scrollSpeed;
        private float playerDiff;
        private float xDiff;

        private Transform firstChild;
        private Transform lastChild;
        private Transform player;
        private Transform[] children;
        public Transform[] initial;

        private void Start()
        {
            children = new Transform[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                children[i] = transform.GetChild(i);
            }

            initial = new Transform[children.Length];
            Array.Copy(children, initial, children.Length);

            firstChild = children[0];
            lastChild = children[transform.childCount - 1];

            player = GameObject.FindGameObjectWithTag("Player").transform;

            playerDiff = lastChild.position.x - player.position.x;
            xDiff = children[1].position.x - children[0].position.x;
        }

        private void Update()
        {
            transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

            if (lastChild.position.x - player.position.x <= playerDiff)
            {
                firstChild.position = new Vector3(lastChild.position.x + xDiff, firstChild.position.y, firstChild.position.z);

                //shift array
                Transform temp = children[0];
                for (int i = 0; i < children.Length - 1; i++)
                {
                    children[i] = children[i + 1];
                }
                children[children.Length - 1] = temp;

                firstChild = children[0];
                lastChild = children[children.Length - 1];
            }
        }
    }
}