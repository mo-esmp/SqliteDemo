using Newtonsoft.Json;
using Core.SeedWork;
using System.Collections.Generic;

namespace Core.Products
{
    public class ProductGroupTypeEntity : BaseEntity
    {
        [JsonIgnore]
        public string Title { get; set; }

        [JsonIgnore]
        public byte[] Icon { get; set; }

        [JsonIgnore]
        public bool IsActive { get; set; }

        [JsonIgnore]
        public string SettingDescription { get; set; }

        [JsonIgnore]
        public ICollection<ProductGroupEntity> ProductGroups { get; set; }
    }
}