﻿namespace GlobalLib.Reflection.Abstract
{
	public abstract class BasicBase
	{
		public virtual byte[] _GlobalABUN { get; set; }
		public virtual byte[] _GlobalBLZC { get; set; }
		public virtual byte[] _LngGlobal { get; set; }
		public virtual byte[] _LngLabels { get; set; }

        /// <summary>
        /// Attempts to add class specfified to the database.
        /// </summary>
        /// <param name="CName">Collection Name of the new class.</param>
        /// <param name="root">Root of the new class. Range: Materials, CarTypeInfos, PresetRides.</param>
        /// <returns>True if class adding was successful, false otherwise.</returns>
        public bool TryAddClass(string CName, string root)
        {
            var node = this.GetType().GetProperty(root);
            if (root == null) return false;

            try
            {
                return (bool)node.PropertyType
                    .GetMethod("TryAddClass", new System.Type[] { typeof(string) })
                    .Invoke(node.GetValue(this), new object[] { CName });
            }
            catch (System.Exception) { return false; }
        }

        /// <summary>
        /// Attempts to add class specfified to the database.
        /// </summary>
        /// <param name="CName">Collection Name of the new class.</param>
        /// <param name="root">Root of the new class. Range: Materials, CarTypeInfos, PresetRides.</param>
        /// <param name="error">Error occured while trying to add class.</param>
        /// <returns>True if class adding was successful, false otherwise.</returns>
        public bool TryAddClass(string CName, string root, out string error)
        {
            error = null;
            var node = this.GetType().GetProperty(root);
            if (root == null) return false;

            try
            {
                var callargs = new object[] { CName, error };
                bool result = (bool)node.PropertyType
                    .GetMethod("TryAddClass", new System.Type[] { typeof(string), typeof(string).MakeByRefType() })
                    .Invoke(node.GetValue(this), callargs);
                error = callargs[1].ToString();
                return result;
            }
            catch (System.Exception)
            {
                if (error == null) error = $"Unable to add class to the root {root}.";
                return false;
            }
        }

        /// <summary>
        /// Attempts to remove class specfified in the database.
        /// </summary>
        /// <param name="CName">Collection Name of the class to be deleted.</param>
        /// <param name="root">Root of the class to delete. Range: Materials, CarTypeInfos, PresetRides.</param>
        /// <returns>True if class removing was successful, false otherwise.</returns>
        public bool TryRemoveClass(string CName, string root)
        {
            var node = this.GetType().GetProperty(root);
            if (root == null) return false;

            try
            {
                return (bool)node.PropertyType
                    .GetMethod("TryRemoveClass", new System.Type[] { typeof(string) })
                    .Invoke(node.GetValue(this), new object[] { CName });
            }
            catch (System.Exception) { return false; }
        }

        /// <summary>
        /// Attempts to remove class specfified in the database.
        /// </summary>
        /// <param name="CName">Collection Name of the class to be deleted.</param>
        /// <param name="root">Root of the class to delete. Range: Materials, CarTypeInfos, PresetRides.</param>
        /// <param name="error">Error occured while trying to remove class.</param>
        /// <returns>True if class removing was successful, false otherwise.</returns>
        public bool TryRemoveClass(string CName, string root, out string error)
        {
            error = null;
            var node = this.GetType().GetProperty(root);
            if (root == null) return false;

            try
            {
                var callargs = new object[] { CName, error };
                bool result = (bool)node.PropertyType
                    .GetMethod("TryRemoveClass", new System.Type[] { typeof(string), typeof(string).MakeByRefType() })
                    .Invoke(node.GetValue(this), callargs);
                error = callargs[1].ToString();
                return result;
            }
            catch (System.Exception)
            {
                error = $"Unable to remove class in root {root}.";
                return false;
            }
        }

        /// <summary>
        /// Attempts to clone class specfified in the database.
        /// </summary>
        /// <param name="newname">Collection Name of the new class.</param>
        /// <param name="copyfrom">Collection Name of the class to clone.</param>
        /// <param name="root">Root of the class to clone. Range: Materials, CarTypeInfos, PresetRides.</param>
        /// <returns>True if class cloning was successful, false otherwise.</returns>
        public bool TryCloneClass(string newname, string copyfrom, string root)
        {
            var node = this.GetType().GetProperty(root);
            if (root == null) return false;

            try
            {
                return (bool)node.PropertyType
                    .GetMethod("TryRemoveClass", new System.Type[] { typeof(string), typeof(string) })
                    .Invoke(node.GetValue(this), new object[] { newname, copyfrom });
            }
            catch (System.Exception) { return false; }
        }

        /// <summary>
        /// Attempts to clone class specfified in the database.
        /// </summary>
        /// <param name="newname">Collection Name of the new class.</param>
        /// <param name="copyfrom">Collection Name of the class to clone.</param>
        /// <param name="root">Root of the class to clone. Range: Materials, CarTypeInfos, PresetRides.</param>
        /// <param name="error">Error occured while trying to copy class.</param>
        /// <returns>True if class cloning was successful, false otherwise.</returns>
        public bool TryCloneClass(string newname, string copyfrom, string root, out string error)
        {
            error = null;
            var node = this.GetType().GetProperty(root);
            if (root == null) return false;

            try
            {
                var callargs = new object[] { newname, copyfrom, error };
                bool result = (bool)node.PropertyType
                    .GetMethod("TryRemoveClass", new System.Type[] { typeof(string), typeof(string), typeof(string).MakeByRefType() })
                    .Invoke(node.GetValue(this), callargs);
                error = callargs[2].ToString();
                return result;
            }
            catch (System.Exception)
            {
                error = $"Unable to copy class in root {root}.";
                return false;
            }
        }
    }
}