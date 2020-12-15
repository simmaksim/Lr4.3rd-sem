using System.Collections.Generic;
namespace Lr4Win
{
    public interface IConfigurationParser
    {
        List<OptionsForDeserealizing> Parse();
    }
}
