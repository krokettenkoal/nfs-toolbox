using NfsCore.Global;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;
using NfsCore.Reflection.Exception;

namespace NfsCore.Support.Underground2.Class
{
    public partial class CarTypeInfo
    {
        private string _defaultbasepaint = BaseArguments.UGPAINT;
        private string _defaultbasepaint2 = BaseArguments.UGPAINT;

        /// <summary>
        /// Represents first paint type of the cartypeinfo.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public override string DefaultBasePaint
        {
            get => this._defaultbasepaint;
            set
            {
                if (Map.UG2PaintTypes.Contains(value))
                    this._defaultbasepaint = value;
                else
                    throw new MappingFailException();
            }
        }

        /// <summary>
        /// Represents second paint type of the cartypeinfo.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public string DefaultBasePaint2
        {
            get => this._defaultbasepaint2;
            set
            {
                if (Map.UG2PaintTypes.Contains(value))
                    this._defaultbasepaint2 = value;
                else
                    throw new MappingFailException();
            }
        }
    }
}