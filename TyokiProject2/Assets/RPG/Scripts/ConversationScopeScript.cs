using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationScopeScript : MonoBehaviour
{
    void OnTriggerStay (Collider col)
    {
        if(col.tag=="Player"
            && col.GetComponent<Player>().GetState() != Player.State.Talk)
        {
            //ユニティちゃんが近づいたら会話相手として自分のゲームオブジェクトを渡す
            col.GetComponent<PlayerTalkScript>().
                SetConversationPartner(transform.parent.gameObject);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.tag=="Player"
            && col.GetComponent<Player>().GetState() != Player.State.Talk)
        {
            //ユニティちゃんが遠ざかったら会話相手から外す
            col.GetComponent<PlayerTalkScript>().
                ResetConversationPartner(transform.parent.gameObject);
        }
    }
}
