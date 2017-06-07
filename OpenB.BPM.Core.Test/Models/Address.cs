using System;
using OpenB.Core;

namespace OpenB.BPM.Core.Test
{
    public class Address : IModel
    {
        public virtual string City { get; set; }
        public virtual string Street { get; set; }
        public int HouseNumber { get; set; }
        public string HouseNumberExtension { get; set; }

        public string Key => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public bool IsActive { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

}