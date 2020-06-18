using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApi
{
    //http://localhost:61781/api/people?Value=1|athar imam,2|Anjuman Shaheen
    public class EmployeeModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            var values = bindingContext.ValueProvider.GetValue("Value");
            //1|athar imam,2|Anjuman Shaheen
            if (values.Length == 0)
                return Task.CompletedTask;
            var splitObj = values.FirstValue.Split(',', StringSplitOptions.RemoveEmptyEntries);
            List<TestEmployee> empls = new List<TestEmployee>();
            foreach(string str in splitObj)
            {
                var splitData = str.Split(new char[] { '|' });
                if (splitData.Length >= 2)
                {
                    var result = new TestEmployee
                    {
                        Id = Convert.ToInt32(splitData[0]),
                        Name = splitData[1]
                    };
                    empls.Add(result);
                }
            }
            bindingContext.Result = ModelBindingResult.Success(empls);
            return Task.CompletedTask;
        }
    }

    //http://localhost:61781/api/people/address?v=bihar|patna,delhi|south delhi
    public class AddressModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            var values = bindingContext.ValueProvider.GetValue("v");
            //1|athar imam,2|Anjuman Shaheen
            if (values.Length == 0)
                return Task.CompletedTask;
            var splitObj = values.FirstValue.Split(',', StringSplitOptions.RemoveEmptyEntries);
            List<Address> empls = new List<Address>();
            foreach (string str in splitObj)
            {
                var splitData = str.Split(new char[] { '|' });
                if (splitData.Length >= 2)
                {
                    var result = new Address
                    {
                        State = splitData[0],
                        District = splitData[1]
                    };
                    empls.Add(result);
                }
            }
            bindingContext.Result = ModelBindingResult.Success(empls);
            return Task.CompletedTask;
        }
    }

    public class EmployeeModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(TestEmployee) || context.Metadata.ModelType == typeof(List<TestEmployee>))
            {
                return new EmployeeModelBinder();
            }
            else if (context.Metadata.ModelType == typeof(Address) || context.Metadata.ModelType == typeof(List<Address>))
            {
                return new AddressModelBinder();
            }

            return null;
        }
    }

    [ModelBinder(BinderType = typeof(EmployeeModelBinder))]
    public class TestEmployee
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    [ModelBinder(BinderType = typeof(AddressModelBinder))]
    public class Address
    {
        public string State { get; set; }

        public string District { get; set; }
    }
}
