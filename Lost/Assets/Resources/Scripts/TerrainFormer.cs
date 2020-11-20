using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectCode
{
    
    public class TerrainFormer : MonoBehaviour {

        private Terrain terr; // terrain to modify
        private int hmWidth; // heightmap width
        private int hmHeight; // heightmap height
        
        private int posXInTerrain; // position of the game object in terrain width (x axis)
        private int posYInTerrain; // position of the game object in terrain height (z axis)
        
        public int size = 5; // the diameter of terrain portion that will raise under the game object
        public float desiredHeight = 0f; // the height we want that portion of terrain to be
        private float actualHeight = 0f;
        private bool hChange = false;

        private float[,] originalHeights;

        private Vector3 coordsMine;
        
        private void Start () {

            terr = Terrain.activeTerrain;
            hmWidth = terr.terrainData.heightmapResolution;
            hmHeight = terr.terrainData.heightmapResolution;

            this.originalHeights = terr.terrainData.GetHeights(0, 0, hmWidth, hmHeight);

            Vector3 tempCoord = (transform.position - terr.gameObject.transform.position);
            coordsMine.x = tempCoord.x / terr.terrainData.size.x;
            coordsMine.y = tempCoord.y / terr.terrainData.size.y;
            coordsMine.z = tempCoord.z / terr.terrainData.size.z;

            actualHeight = coordsMine.y;

            SetDesiredHeight(5f); //Hack to make ground leveled from previous explosion, if there was one

        }

        public void SetDesiredHeight( float dh){
            desiredHeight = dh;
            hChange = true;
            MakeADent();
        }

        private void MakeADent() {

            float dHeight = desiredHeight / terr.terrainData.size.y;

            if(hChange) {
                // get the normalized position of this game object relative to the terrain
                Vector3 tempCoord = (transform.position - terr.gameObject.transform.position);
                Vector3 coord;
                coord.x = tempCoord.x / terr.terrainData.size.x;
                coord.y = tempCoord.y / terr.terrainData.size.y;
                coord.z = tempCoord.z / terr.terrainData.size.z;
            
                // get the position of the terrain heightmap where this game object is
                posXInTerrain = (int) (coord.x * hmWidth); 
                posYInTerrain = (int) (coord.z * hmHeight);
            
                // we set an offset so that all the raising terrain is under this game object
                int offset = size / 2;
            
                // get the heights of the terrain under this game object
                float[,] heights = terr.terrainData.GetHeights(posXInTerrain-offset,posYInTerrain-offset,size,size);
            
                // we set each sample of the terrain in the size to the desired height
                for (int i=0; i < size; i++)
                    for (int j=0; j < size; j++){
                        heights[i,j] = dHeight;
                        actualHeight = dHeight;
                    }

                // set the new height
                terr.terrainData.SetHeights(posXInTerrain-offset,posYInTerrain-offset,heights);

                hChange = false;
            }
        }
    }

}