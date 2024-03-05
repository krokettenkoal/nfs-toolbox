using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.MostWanted.Class
{
    public partial class CarTypeInfo
    {
        private string _collisionExternalName = BaseArguments.NULL;

        /// <summary>
        /// Represents external collision name of the cartypeinfo.
        /// </summary>
        [AccessModifiable]
        public string CollisionExternalName
        {
            get => _collisionExternalName;
            set
            {
                if (value != BaseArguments.NULL && value != CollName)
                    throw new MappingFailException(
                        "Value passed should be either equal to CollectionName, or be NULL.");
                _collisionExternalName = value;
            }
        }

        /// <summary>
        /// Represents internal collision name of the cartypeinfo.
        /// </summary>
        [AccessModifiable]
        public override string CollisionInternalName
        {
            get => base.CollisionInternalName;
            set => base.CollisionInternalName = value;
        }
    }
}