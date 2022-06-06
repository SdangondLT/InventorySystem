using AutoMapper;
using InventorySystem.Entities.DTOs;
using InventorySystem.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Core.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ItemCreateDto, Item>();
            CreateMap<Item, ItemCreateDto>();

            CreateMap<MovementCreateDto, Movement>();
            CreateMap<Movement, MovementCreateDto>();
        }
    }
}
