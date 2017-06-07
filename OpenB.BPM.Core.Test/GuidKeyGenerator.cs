using System;

namespace OpenB.BPM.Core.Test
{
    internal class GuidKeyGenerator : IKeyGenerator
    {
        public string GenerateKey()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
