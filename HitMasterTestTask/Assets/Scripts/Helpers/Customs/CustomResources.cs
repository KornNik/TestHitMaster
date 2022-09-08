using UnityEngine;

namespace HitMaster.Helpers.Customs
{
    static class CustomResources
    {
        public static T Load<T>(string path) where T : Object
        {
            return (T)Resources.Load(path, typeof(T));
        }
    }
}
