using OpenB.Core;
using System;
using System.Collections.Generic;
using System.Collections;

namespace OpenB.BPM.Core
{
    public class ProcessContext
    {
        public ModelCollection Models { get; private set; }

        public ProcessContext(ModelCollection models)
        {
            if (models == null)
                throw new ArgumentNullException(nameof(models));
        }
    }

    public class ModelCollection : IEnumerable<IModel>
    {
        private IDictionary<string, IModel> models;

        public ModelCollection()
        {
            models = new Dictionary<string, IModel>();
        }


        public IEnumerator<IModel> GetEnumerator()
        {
            return models.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IModel this[string key]
        {
            get
            {
                if (models.ContainsKey(key))
                {
                    return models[key];
                }
                throw new Exception($"Model with key {key} not found.");
            }
        }
    }
}