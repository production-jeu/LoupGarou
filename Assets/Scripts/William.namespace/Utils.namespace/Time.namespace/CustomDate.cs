using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace William.Utils.Time
{
    public class CustomDate : MonoBehaviour
    {

        public DateTime dateTime;

        public CustomDate() { dateTime = DateTime.Now; }
        public CustomDate(DateTime dateTime_) { dateTime = dateTime_; }

        public static CustomDate FromStringToCustomDate()
        {
            return new CustomDate(DateTime.Parse("yyyyMMddHHmmss"));
        }

        public override string ToString()
        {
            return dateTime.ToString("yyyyMMddHHmmss");
        }

    }
}
