using System;

namespace StarCups.Shop.References
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