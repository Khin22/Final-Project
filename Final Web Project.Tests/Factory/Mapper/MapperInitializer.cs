using Final_Web_Project.Domain;
using Final_Web_Project.Services.Mapping;
using Final_Web_Project.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Final_Web_Project.Tests.Factory.Mapper
{
    public static class MapperInitializer
    {
        public static void InitializeMapper()
        {
            AutoMapperConfig.RegisterMappings(
                typeof(RecordServiceModel).GetTypeInfo().Assembly,
                typeof(Record).GetTypeInfo().Assembly);
        }
    }
}
