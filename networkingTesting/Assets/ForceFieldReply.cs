using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ForceFieldReply : NetworkBehaviour
{
    public bool QueryAuthority()
    {
        return hasAuthority;
    }
}
