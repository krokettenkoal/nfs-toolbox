using NfsCore.Global;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.Underground2.Class
{
    public partial class CarTypeInfo
    {
        private string _defaultBasePaint = BaseArguments.UGPAINT;
        private string _defaultBasePaint2 = BaseArguments.UGPAINT;

        /// <summary>
        /// Represents first paint type of the cartypeinfo.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public override string DefaultBasePaint
        {
            get => _defaultBasePaint;
            set
            {
                if (Map.UG2PaintTypes.Contains(value))
                    _defaultBasePaint = value;
                else
                    throw new MappingFailException();
            }
        }

        /// <summary>
        /// Represents second paint type of the cartypeinfo.
        /// </summary>
        [AccessModifiable]
        [StaticModifiable]
        public string DefaultBasePaint2
        {
            get => _defaultBasePaint2;
            set
            {
                if (Map.UG2PaintTypes.Contains(value))
                    _defaultBasePaint2 = value;
                else
                    throw new MappingFailException();
            }
        }
    }
}