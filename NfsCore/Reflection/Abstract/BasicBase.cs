﻿using System;
using System.IO;
using NfsCore.Database.Collection;
using NfsCore.Global;
using NfsCore.Reflection.Interface;
using NfsCore.Support.Shared.Class;

namespace NfsCore.Reflection.Abstract
{
	public abstract class BasicBase : IOperative
	{
		internal byte[] _GlobalABUN { get; set; }
		internal byte[] _GlobalBLZC { get; set; }
		internal byte[] _LngGlobal { get; set; }
		internal byte[] _LngLabels { get; set; }

        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public virtual GameINT GameINT => GameINT.None;

        /// <summary>
        /// Game string to which the class belongs to.
        /// </summary>
        public string GameSTR => GameINT.ToString();
        
        /// <summary>
        /// The database's FNGroups (frontend groups) collection.
        /// </summary>
        public Root<FNGroup> FNGroups { get; protected set; }
        /// <summary>
        /// The database's TPKBlocks (compressed textures) collection.
        /// </summary>
        public Root<TPKBlock> TPKBlocks { get; protected set; }
        /// <summary>
        /// The database's STRBlocks collection.
        /// </summary>
        public Root<STRBlock> STRBlocks { get; protected set; }

        protected BasicBase()
        {
            FNGroups = new Root<FNGroup>
            (
                "FNGroups",
                -1,
                -1,
                -1,
                false,
                false,
                this
            );

            TPKBlocks = new Root<TPKBlock>
            (
                "TPKBlocks",
                -1,
                -1,
                -1,
                false,
                false,
                this
            );

            STRBlocks = new Root<STRBlock>
            (
                "STRBlocks",
                -1,
                -1,
                -1,
                false,
                false,
                this
            );
        }

        /// <summary>
        /// Gets a <see cref="Collectable"/> class from CollectionName and root provided.
        /// </summary>
        /// <param name="CName">CollectionName of <see cref="Collectable"/> to find.</param>
        /// <param name="root">Root collection of the class.</param>
        /// <returns><see cref="Collectable"/> class.</returns>
        public virtual Collectable GetCollection(string CName, string root)
        {
            var property = GetType().GetProperty(root);
            if (property == null) return null;

            return (Collectable)property.PropertyType
                .GetMethod("FindCollection", new Type[] { typeof(string) })
                .Invoke(property.GetValue(this), new object[] { CName });
        }

        /// <summary>
        /// Attempts to get <see cref="Collectable"/> class from CollectionName and root provided.
        /// </summary>
        /// <param name="CName">CollectionName of <see cref="Collectable"/> to find.</param>
        /// <param name="root">Root collection of the class.</param>
        /// <param name="collection"><see cref="Collectable"/> class that is to return.</param>
        /// <returns>True if collection exists and can be returned; false otherwise.</returns>
        public virtual bool TryGetCollection(string CName, string root, out Collectable collection)
        {
            collection = null;
            try
            {
                collection = GetCollection(CName, root);
                if (collection == null) return false;
                else return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a <see cref="Primitive"/> class from the path provided.
        /// </summary>
        /// <param name="path">Path of the <see cref="Primitive"/> class to find.</param>
        /// <returns><see cref="Primitive"/> class.</returns>
        public virtual Primitive GetPrimitive(params string[] path)
        {
            switch (path.Length)
            {
                case 2:
                    return GetCollection(path[1], path[0]);

                case 4:
                    var collection = GetCollection(path[1], path[0]);
                    return collection.GetSubPart(path[3], path[2]);

                default:
                    return null;
            }
        }

        public virtual bool TrySetStaticValue(string root, string field, string value)
        {
            var property = GetType().GetProperty(root ?? string.Empty);
            if (property == null) return false;
            try
            {
                return (bool)property.PropertyType
                    .GetMethod("TrySetStaticValue", new Type[] { typeof(string), typeof(string) })
                    .Invoke(property.GetValue(this), new object[] { field, value });
            }
            catch (System.Exception) { return false; }
        }

        public virtual bool TrySetStaticValue(string root, string field, string value, out string error)
        {
            error = null;
            var node = GetType().GetProperty(root ?? string.Empty);
            if (node == null)
            {
                error = $"Root named {root} does not exist in the database.";
                return false;
            }

            try
            {
                var callargs = new object[] { field, value, error };
                bool result = (bool)node.PropertyType
                    .GetMethod("TrySetStaticValue", new Type[] { typeof(string), typeof(string), typeof(string).MakeByRefType() })
                    .Invoke(node.GetValue(this), callargs);
                error = callargs[2]?.ToString();
                return result;
            }
            catch (System.Exception)
            {
                if (error == null) error = $"Unable to statically set value in the root {root}.";
                return false;
            }
        }

        /// <summary>
        /// Attempts to add class specfified to the database.
        /// </summary>
        /// <param name="collectionName">Collection Name of the new class.</param>
        /// <param name="root">Root of the new class. Range: Materials, CarTypeInfos, PresetRides.</param>
        /// <returns>True if class adding was successful, false otherwise.</returns>
        public virtual bool TryAddCollection(string collectionName, string root)
        {
            var node = GetType().GetProperty(root ?? string.Empty);
            if (node == null) return false;

            try
            {
                return (bool)node.PropertyType
                    .GetMethod("TryAddCollection", new Type[] { typeof(string) })
                    .Invoke(node.GetValue(this), new object[] { collectionName });
            }
            catch (System.Exception) { return false; }
        }

        /// <summary>
        /// Attempts to add class specfified to the database.
        /// </summary>
        /// <param name="collectionName">Collection Name of the new class.</param>
        /// <param name="root">Root of the new class. Range: Materials, CarTypeInfos, PresetRides.</param>
        /// <param name="error">Error occured while trying to add class.</param>
        /// <returns>True if class adding was successful, false otherwise.</returns>
        public virtual bool TryAddCollection(string collectionName, string root, out string error)
        {
            error = null;
            var node = GetType().GetProperty(root ?? string.Empty);
            if (node == null)
            {
                error = $"Root named {root} does not exist in the database.";
                return false;
            }

            try
            {
                var callargs = new object[] { collectionName, error };
                bool result = (bool)node.PropertyType
                    .GetMethod("TryAddCollection", new Type[] { typeof(string), typeof(string).MakeByRefType() })
                    .Invoke(node.GetValue(this), callargs);
                error = callargs[1]?.ToString();
                return result;
            }
            catch (System.Exception)
            {
                if (error == null) error = $"Unable to add collection to the root {root}.";
                return false;
            }
        }

        /// <summary>
        /// Attempts to remove class specfified in the database.
        /// </summary>
        /// <param name="collectionName">Collection Name of the class to be deleted.</param>
        /// <param name="root">Root of the class to delete. Range: Materials, CarTypeInfos, PresetRides.</param>
        /// <returns>True if class removing was successful, false otherwise.</returns>
        public virtual bool TryRemoveCollection(string collectionName, string root)
        {
            var node = GetType().GetProperty(root ?? string.Empty);
            if (node == null) return false;

            try
            {
                return (bool)node.PropertyType
                    .GetMethod("TryRemoveCollection", new Type[] { typeof(string) })
                    .Invoke(node.GetValue(this), new object[] { collectionName });
            }
            catch (System.Exception) { return false; }
        }

        /// <summary>
        /// Attempts to remove class specfified in the database.
        /// </summary>
        /// <param name="collectionName">Collection Name of the class to be deleted.</param>
        /// <param name="root">Root of the class to delete. Range: Materials, CarTypeInfos, PresetRides.</param>
        /// <param name="error">Error occured while trying to remove class.</param>
        /// <returns>True if class removing was successful, false otherwise.</returns>
        public virtual bool TryRemoveCollection(string collectionName, string root, out string error)
        {
            error = null;
            var node = GetType().GetProperty(root ?? string.Empty);
            if (node == null)
            {
                error = $"Root named {root} does not exist in the database.";
                return false;
            }

            try
            {
                var callargs = new object[] { collectionName, error };
                bool result = (bool)node.PropertyType
                    .GetMethod("TryRemoveCollection", new Type[] { typeof(string), typeof(string).MakeByRefType() })
                    .Invoke(node.GetValue(this), callargs);
                error = callargs[1]?.ToString();
                return result;
            }
            catch (System.Exception)
            {
                error = $"Unable to remove collection in root {root}.";
                return false;
            }
        }

        /// <summary>
        /// Attempts to clone class specfified in the database.
        /// </summary>
        /// <param name="newName">Collection Name of the new class.</param>
        /// <param name="copyFrom">Collection Name of the class to clone.</param>
        /// <param name="root">Root of the class to clone. Range: Materials, CarTypeInfos, PresetRides.</param>
        /// <returns>True if class cloning was successful, false otherwise.</returns>
        public virtual bool TryCloneCollection(string newName, string copyFrom, string root)
        {
            var node = GetType().GetProperty(root ?? string.Empty);
            if (node == null) return false;

            try
            {
                return (bool)node.PropertyType
                    .GetMethod("TryCloneCollection", new Type[] { typeof(string), typeof(string) })
                    .Invoke(node.GetValue(this), new object[] { newName, copyFrom });
            }
            catch (System.Exception) { return false; }
        }

        /// <summary>
        /// Attempts to clone class specfified in the database.
        /// </summary>
        /// <param name="newName">Collection Name of the new class.</param>
        /// <param name="copyFrom">Collection Name of the class to clone.</param>
        /// <param name="root">Root of the class to clone. Range: Materials, CarTypeInfos, PresetRides.</param>
        /// <param name="error">Error occured while trying to copy class.</param>
        /// <returns>True if class cloning was successful, false otherwise.</returns>
        public virtual bool TryCloneCollection(string newName, string copyFrom, string root, out string error)
        {
            error = null;
            var node = GetType().GetProperty(root ?? string.Empty);
            if (node == null)
            {
                error = $"Root named {root} does not exist in the database.";
                return false;
            }

            try
            {
                var callargs = new object[] { newName, copyFrom, error };
                bool result = (bool)node.PropertyType
                    .GetMethod("TryCloneCollection", new Type[] { typeof(string), typeof(string), typeof(string).MakeByRefType() })
                    .Invoke(node.GetValue(this), callargs);
                error = callargs[2]?.ToString();
                return result;
            }
            catch (System.Exception)
            {
                error = $"Unable to copy collection in root {root}.";
                return false;
            }
        }

        /// <summary>
        /// Imports class data from a file specified.
        /// </summary>
        /// <param name="root">Class type to be imported. Range: Material, CarTypeInfo, PresetRide, PresetSkin.</param>
        /// <param name="filepath">File with data to be imported.</param>
        /// <returns>True if class import was successful, false otherwise.</returns>
        public virtual bool TryImportCollection(string root, string filepath)
        {
            byte[] data;

            try
            {
                data = File.ReadAllBytes(filepath);
            }
            catch (System.Exception)
            {
                return false;
            }

            var node = GetType().GetProperty(root);
            if (root == null) return false;

            return (bool)node.PropertyType
                .GetMethod("TryImportCollection", new Type[] { typeof(byte).MakeArrayType() })
                .Invoke(node.GetValue(this), new object[] { data });
        }

        /// <summary>
        /// Imports class data from a file specified.
        /// </summary>
        /// <param name="root">Class type to be imported. Range: Material, CarTypeInfo, PresetRide, PresetSkin.</param>
        /// <param name="filepath">File with data to be imported.</param>
        /// <param name="error">Error occured while trying to import class.</param>
        /// <returns>True if class import was successful, false otherwise.</returns>
        public virtual bool TryImportCollection(string root, string filepath, out string error)
        {
            byte[] data;
            error = null;

            try
            {
                data = File.ReadAllBytes(filepath);
            }
            catch (System.Exception e)
            {
                while (e.InnerException != null) e = e.InnerException;
                error = e.Message;
                return false;
            }

            var node = GetType().GetProperty(root ?? string.Empty);
            if (node == null)
            {
                error = $"Root named {root} does not exist in the database.";
                return false;
            }

            try
            {
                var callargs = new object[] { data, error };
                bool result = (bool)node.PropertyType
                    .GetMethod("TryImportCollection", new Type[] { typeof(byte).MakeArrayType(), typeof(string).MakeByRefType() })
                    .Invoke(node.GetValue(this), callargs);
                error = callargs[1]?.ToString();
                return result;
            }
            catch (System.Exception)
            {
                if (error == null) error = $"Unable to import collection to the root {root}.";
                return false;
            }
        }

        /// <summary>
        /// Exports <see cref="Collectable"/> data from <see cref="Root{TypeID}"/> 
        /// root to a file path specified.
        /// </summary>
        /// <param name="collectionName">CollectionName of <see cref="Collectable"/> class.</param>
        /// <param name="root">Name of the <see cref="Root{TypeID}"/> collection.</param>
        /// <param name="filepath">Filepath where data should be exported.</param>
        /// <returns>True if class export was successful, false otherwise.</returns>
        public virtual bool TryExportCollection(string collectionName, string root, string filepath)
        {
            var node = GetType().GetProperty(root ?? string.Empty);
            if (node == null) return false;

            try
            {
                return (bool)node.PropertyType
                    .GetMethod("TryExportCollection", new Type[] { typeof(string), typeof(string) })
                    .Invoke(node.GetValue(this), new object[] { collectionName, filepath });
            }
            catch (System.Exception) { return false; }
        }

        /// <summary>
        /// Exports <see cref="Collectable"/> data from <see cref="Root{TypeID}"/> 
        /// root to a file path specified.
        /// </summary>
        /// <param name="collectionName">CollectionName of <see cref="Collectable"/> class.</param>
        /// <param name="root">Name of the <see cref="Root{TypeID}"/> collection.</param>
        /// <param name="filepath">Filepath where data should be exported.</param>
        /// <param name="error">Error occured while trying to export class.</param>
        /// <returns>True if class export was successful, false otherwise.</returns>
        public virtual bool TryExportCollection(string collectionName, string root, string filepath, out string error)
        {
            error = null;
            var node = GetType().GetProperty(root ?? string.Empty);
            if (node == null)
            {
                error = $"Root named {root} does not exist in the database.";
                return false;
            }

            try
            {
                var callargs = new object[] { collectionName, filepath, error };
                bool result = (bool)node.PropertyType
                    .GetMethod("TryExportCollection", new Type[] { typeof(string), typeof(string), typeof(string).MakeByRefType() })
                    .Invoke(node.GetValue(this), callargs);
                error = callargs[2]?.ToString();
                return result;
            }
            catch (System.Exception)
            {
                error = $"Unable to export collection in root {root}.";
                return false;
            }
        }

        /// <summary>
        /// Adds collision block to the database memory.
        /// </summary>
        /// <param name="collectionName">Collection Name of the collision block.</param>
        /// <param name="filename">Filepath of the collision block to be imported.</param>
        /// <param name="error">Error occured when trying to add collision.</param>
        /// <returns>True if adding was successful; false otherwise.</returns>
        public abstract unsafe bool TryAddCollision(string collectionName, string filename, out string error);

        /// <summary>
        /// Gets information about <see cref="BasicBase"/> database.
        /// </summary>
        /// <returns></returns>
        public abstract string GetDatabaseInfo();

        public override string ToString() => $"Database ({GameSTR})";
    }
}
