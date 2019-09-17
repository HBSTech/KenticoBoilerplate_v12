﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kentico.Caching.Example
{
    public class KenticoExampleModuleClassRepository : ExampleModuleClassRepository
    {
        [CacheDependency("example.examplemoduleclass|byid|{0}")]
        public ExampleModuleClassModel GetExampleModuleClass(int ID)
        {
            var ExampleModuleClass = ExampleModuleClassInfoProvider.GetExampleModuleClassInfo(ID);

            return new ExampleModuleClassModel()
            {
                Name = ExampleModuleClass?.ExampleModuleClassName
            };
        }

        public IEnumerable<ExampleModuleClassModel> GetExampleModuleClasses()
        {
            var ModelClasses = ExampleModuleClassInfoProvider.GetExampleModuleClasses()
                .ToList();

            return ModelClasses.Select(x =>
            {
                return new ExampleModuleClassModel()
                {
                    Name = x.ExampleModuleClassName
                };
            });
        }
    }
}
