// Type: System.Data.Objects.DataClasses.EntityReference`1
// Assembly: System.Data.Entity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\System.Data.Entity.dll

using System;
using System.ComponentModel;
using System.Data.Objects;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace System.Data.Objects.DataClasses
{
    [DataContract]
    [Serializable]
    public sealed class EntityReference<TEntity> : EntityReference where TEntity : class
    {
        public EntityReference();

        [XmlIgnore]
        [SoapIgnore]
        public TEntity Value { get; set; }

        public override void Load(MergeOption mergeOption);
        public void Attach(TEntity entity);
        public ObjectQuery<TEntity> CreateSourceQuery();

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [OnDeserialized]
        public void OnRefDeserialized(StreamingContext context);

        [OnSerializing]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnSerializing(StreamingContext context);
    }
}
