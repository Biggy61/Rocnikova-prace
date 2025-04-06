using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
 
 [SerializeField] private List<TKey> keys = new List<TKey>();
 [SerializeField] private List<TValue> values = new List<TValue>();
 
 //ulozit dictionary do listu
 public void OnBeforeSerialize()
 {
   //ujistime se ze tam nic neni, projdeme je a pridame je do listu
   keys.Clear();
   values.Clear();
   foreach (KeyValuePair<TKey, TValue> pair in this)
   {
       keys.Add(pair.Key);
       values.Add(pair.Value);
   }
 }
 //loadnout dictionary z listu
 public void OnAfterDeserialize()
 {
   keys.Clear();

   for (int i = 0; i < keys.Count; i++)
   {
       this.Add(keys[i], values[i]);
   }
 }
}
