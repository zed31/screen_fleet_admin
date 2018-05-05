using MongoDB.Bson;

namespace screen_fleet_admin.Models
{
    public class TreeResourceModel : ResourceModel
    {
        ResourceModel Leaf1 { get; set; }
        ResourceModel Leaf2 { get; set; }
    }
}
