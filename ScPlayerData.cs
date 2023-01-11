using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScPlayerData
{
    private float max_Health = 100f;
    private float min_Health = 0f;
    private float curr_Health = 80f;

    private float exp = 0.0f;
    private float max_exp = 20f;
    private int lwl = 1;
    private int pirate_coin = 0;
    private int soul_score = 0;

    private float playerPosX, playerPosY;
    
    public float getExp(){return this.exp;}
    public void increaseExp(){this.exp+=25;}
    public int getLwl(){return this.lwl;}
    public void increaseLwl(){this.lwl++;}
    public int getCoin(){return this.pirate_coin;}
    public void increaseCoin(){this.pirate_coin++;}
    public int getScore(){return this.soul_score;}
    public void increaseScore(){this.soul_score++;}

    public float getMinHealth(){ return this.min_Health; }
    public float getMaxHealth(){ return this.max_Health; }
    public float getCurrHealth(){ return this.curr_Health; }
    
    public void setHealth( float HealthAmount )
    {
        if(HealthAmount> this.max_Health)
            this.curr_Health=this.max_Health;
        else
            this.curr_Health = HealthAmount;
    }

    public void resetExp()
    {
        exp = 0;
    }
}
