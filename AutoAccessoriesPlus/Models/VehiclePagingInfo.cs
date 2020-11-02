using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace AutoAccessoriesPlus.Models
{
    public class VehiclePagingInfo
    {
        public int? pageSize;
        public StaticPagedList<Vehicle> Vehicles { get; set; }

    }
}
