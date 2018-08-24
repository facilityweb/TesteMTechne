using System;

namespace MTechneTeste.Domain.Entities.Base
{
    public abstract class Entity : IEquatable<Entity>
    {
        public virtual bool Equals(Entity other)
        {
            if (ReferenceEquals(this, other))
                return true;

            if (ReferenceEquals(this, null) || ReferenceEquals(other, null))
                return false;

            if (other is IBaseId)
            {
                if (((IBaseId)other).Id == 0 && ((IBaseId)this).Id == 0)
                    return false;

                return ((IBaseId)other).Id == ((IBaseId)this).Id;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Entity);
        }

        public override int GetHashCode()
        {
            if (this is IBaseId)
                return ((IBaseId)this).Id;

            return 0;
        }
    }
}
