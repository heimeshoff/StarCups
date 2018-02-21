using System;

namespace StarCups.Shop
{
    public struct CustomerReference
    {
        public Guid Id { get; }

        public CustomerReference(Guid id)
        {
            Id = id;
        }
    }
}