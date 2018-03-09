using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//use script if damage from the bullet will be changed.  Power-ups?

public class BulletBehaviour : MonoBehaviour {
    //public int damage that bullet does; can change
    public int damage = 10;
 
	public int getdamageCount()
    {
        return damage;
    }
        
}
