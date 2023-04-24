using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Course_Library.Script.NPC_Util
{

    public class NPCBussines
    {
        public NPCBussines(float speed)
        {
            this.speed = speed;
        }
        public float speed;

        public float offX;
        public float offY;
        public float offZ;
        private Vector3 offset;

        public Vector3 NPCMoviment()
        {
            offZ = Time.deltaTime * speed;

            offY = 0;
            offX = 0;
            return offset = new Vector3(offX, offY, offZ);
            // get the user's vertical input


            
        }
    }
}
