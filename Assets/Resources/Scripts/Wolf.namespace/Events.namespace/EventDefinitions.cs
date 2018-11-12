using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Wolf.Events
{
    public class IntEvent             :    UnityEvent<int>    { };
    public class StringEvent          :    UnityEvent<string> { };
    public class FloatEvent           :    UnityEvent<float>  { };
    public class BoolEvent            :    UnityEvent<bool>   { };
    public class GameObjectEvent      :    UnityEvent<GameObject> { };
    public class ZoneInteractionEvent :    UnityEvent<Interaction.ZoneInteraction> { };
}

