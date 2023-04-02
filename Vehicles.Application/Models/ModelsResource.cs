using System.Collections.ObjectModel;

namespace Vehicles.Application.Models;

public class ModelsResource : KeyValuePairResource
{
    public ICollection<KeyValuePairResource> Models { get; set; }

    public ModelsResource()
    {
        Models = new Collection<KeyValuePairResource>();
    }
}