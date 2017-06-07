using OpenB.Core;
using System;

namespace OpenB.BPM.Core.Test
{
    public class Person : IModel
    {
        public virtual string Name { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual Address Address { get; set; }

        public string Key { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }

}