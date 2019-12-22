# IntelliEnum
Lyn.IntelliEnum is C# language useful enum helper method collection.

## Install via NuGet 
------------------
    Install-Package Lyn.IntelliEnum

## Changes
> ### v0.0.4 (12/23/2019)
> #### Enhancements
> - Run With Fastest Enum Library [Enums.NET](https://github.com/TylerBrinkley/Enums.NET)
> ### v0.0.1 ~ v0.0.3 (12/22/2019)
> #### Enhancements
> - Add GetDescriptionStrings Method
> - Add GetDescriptionStringMap Method
> - Add GetEnumValueFromDescription Method
> - Add GetDescription Method


## Lyn.IntelliEnum Demo
```C#
using Lyn.IntelliEnum;

using cm = System.ComponentModel;

namespace Lyn.IntelliEnum
{
    public enum TestEnum
    {
        [cm.Description("Value Test 01")]
        Value01 = 1,
        [cm.Description("Value Test 02")]
        Value02 = 2,
    }

 
    public class IntelliEnumTest
    {
        public void TestGetDescriptionStrings()
        {
            var testEnumStrings = IntelliEnum.IntelliEnum.GetDescriptionStrings<TestEnum>();
        }

        public void TestGetDescriptionStringMap()
        {
            var testEnumDict = IntelliEnum.IntelliEnum.GetDescriptionStringMap<TestEnum>();
        }
    }
}
```
