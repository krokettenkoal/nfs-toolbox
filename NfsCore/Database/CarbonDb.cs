using System;
using System.IO;
using System.Linq;
using NfsCore.Database.Collection;
using NfsCore.Global;
using NfsCore.Reflection.Abstract;
using NfsCore.Reflection.ID;
using NfsCore.Support.Carbon.Class;
using NfsCore.Support.Carbon.Parts.CarParts;
using NfsCore.Utils;

namespace NfsCore.Database;

public class CarbonDb : BasicBase
{
    /// <summary>
    /// Game to which the class belongs to.
    /// </summary>
    public override GameINT GameINT => GameINT.Carbon;

    public Root<Material> Materials { get; set; }
    public Root<CarTypeInfo> CarTypeInfos { get; set; }
    public Root<PresetRide> PresetRides { get; set; }
    public Root<PresetSkin> PresetSkins { get; set; }
    public SlotType SlotTypes { get; set; }

    public CarbonDb()
    {
        Materials = new Root<Material>
        (
            "Materials",
            Material.MaxCNameLength,
            Material.CNameOffsetAt,
            Material.BaseClassSize,
            true,
            true,
            this
        );

        CarTypeInfos = new Root<CarTypeInfo>
        (
            "CarTypeInfos",
            CarTypeInfo.MaxCNameLength,
            CarTypeInfo.CNameOffsetAt,
            CarTypeInfo.BaseClassSize,
            true,
            true,
            this
        );

        PresetRides = new Root<PresetRide>
        (
            "PresetRides",
            PresetRide.MaxCNameLength,
            PresetRide.CNameOffsetAt,
            PresetRide.BaseClassSize,
            true,
            true,
            this
        );

        PresetSkins = new Root<PresetSkin>
        (
            "PresetSkins",
            PresetSkin.MaxCNameLength,
            PresetSkin.CNameOffsetAt,
            PresetSkin.BaseClassSize,
            true,
            true,
            this
        );

        SlotTypes = new SlotType();
    }

    ~CarbonDb()
    {
        _GlobalABUN = null;
        _GlobalBLZC = null;
        _LngGlobal = null;
        _LngLabels = null;
        CarTypeInfos = null;
        FNGroups = null;
        Materials = null;
        PresetRides = null;
        PresetSkins = null;
        TPKBlocks = null;
        SlotTypes = null;
        STRBlocks = null;
    }

    /// <summary>
    /// Adds <see cref="Collision"/> block to the database memory.
    /// </summary>
    /// <param name="CName">Collection Name of the <see cref="Collision"/> block.</param>
    /// <param name="filepath">Filepath of the <see cref="Collision"/> block to be imported.</param>
    /// <param name="error">Error occured when trying to add collision.</param>
    /// <returns>True if adding was successful; false otherwise.</returns>
    public override unsafe bool TryAddCollision(string CName, string filepath, out string error)
    {
        error = null;
        try
        {
            if (!File.Exists(filepath))
                throw new FileNotFoundException();

            if (Map.CollisionMap.Any(pair => CName == pair.Value))
            {
                throw new Exception("Collision with the same collection name already exists.");
            }

            var data = File.ReadAllBytes(filepath);
            fixed (byte* dataptr_t = &data[0])
            {
                if (*(uint*) dataptr_t != CarParts.Collision)
                    throw new Exception("File specified is not a collision file.");
                if (*(int*) (dataptr_t + 4) != data.Length - 8)
                    throw new Exception("File has incorrect length parameters.");
                var key = Vlt.Hash(CName);
                *(uint*) (dataptr_t + 8) = key;
                *(uint*) (dataptr_t + 16) = 0xFFFFFFFF;
                var collision = new Collision(data, CName);
                SlotTypes.Collisions[key] = collision;
                Map.CollisionMap[key] = CName;
            }

            return true;
        }
        catch (Exception e)
        {
            while (e.InnerException != null) e = e.InnerException;
            error = e.Message;
            return false;
        }
    }

    /// <summary>
    /// Gets information about <see cref="Carbon"/> database.
    /// </summary>
    /// <returns></returns>
    public override string GetDatabaseInfo()
    {
        var nl = Environment.NewLine;
        const string equals = " = ";
        const string collections = " collections.";
        var info = ToString() + nl;
        info += $"{CarTypeInfos.ThisName}{equals}{CarTypeInfos.Length}{collections}{nl}";
        info += $"{Materials.ThisName}{equals}{Materials.Length}{collections}{nl}";
        info += $"{PresetRides.ThisName}{equals}{PresetRides.Length}{collections}{nl}";
        info += $"{PresetSkins.ThisName}{equals}{PresetSkins.Length}{collections}{nl}";
        return info;
    }
}