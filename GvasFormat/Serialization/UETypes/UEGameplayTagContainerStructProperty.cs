using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace GvasFormat.Serialization.UETypes
{
    [DebuggerDisplay("Count = {Properties.Count}", Name = "{Name}")]
    public sealed class UEGameplayTagContainerStructProperty : UEStructProperty
    { //TODO: populate this
        public List<UEProperty> Properties = new List<UEProperty>();

        public UEGameplayTagContainerStructProperty() { }

        public UEGameplayTagContainerStructProperty(BinaryReader reader)
        {
            // valueLength starts here
            Count = reader.ReadInt32();
            Items = new string[Count];
            for (int i = 0; i < Count; i++)
            {
                var name = reader.ReadUEString();
                Items[i] = name;
            }
        }

        public override void SerializeStructProp(BinaryWriter writer)
        {
            writer.WriteInt32(Count);

            for (int i = 0; i < Items.Length; i++)
            {
                writer.Write(false); //Terminator
                writer.WriteUEString(Items[i]);
                //writer.WriteUEString(Name);
                //writer.WriteInt64(ValueLength);
            }
        }

        public string[] Items;
        public int Count;
    }
}
